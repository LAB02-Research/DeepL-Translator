using DeepL;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;

namespace DeepLClient.Forms
{
    public partial class SubscriptionInfo : MetroForm
    {
        public SubscriptionInfo()
        {
            InitializeComponent();
        }

        private async void SubscriptionInfo_Load(object sender, EventArgs e)
        {
            try
            {
                // set topmost
                TopMost = Variables.AppSettings.AlwaysOnTop;

                // catch all key presses
                KeyPreview = true;

                // set title
                Text = $"Subscription Information   |   {Variables.ApplicationName}";

                // set cost info
                LblCost.Text = SubscriptionManager.BaseCostNotation();

                // get the current state
                var state = await Variables.Translator.GetUsageAsync();

                if (state.Character == null)
                {
                    // unknown, weird
                    LblCharacterLimit.Text = "?";
                    LblCharactersUsed.Text = "?";
                    LblCharactersLeft.Text = "?";
                    LblCost.Text = "?";

                    // we're done
                    return;
                }

                // set characters used
                LblCharactersUsed.Text = $"{state.Character.Count:N0}";

                // determine limit and how many chars are left, only on free
                if (SubscriptionManager.UsingFreeSubscription())
                {
                    // get our limit
                    LblCharacterLimit.Text = $"{state.Character.Limit:N0}";

                    // get our remaining chars
                    var charactersLeft = state.Character.Limit - state.Character.Count;
                    if (charactersLeft < 0) charactersLeft = 0;
                    LblCharactersLeft.Text = $"{charactersLeft:N0}";

                    // warn the user if we're getting close to the limit
                    if (charactersLeft < 10000) LblCharactersLeft.ForeColor = Color.FromArgb(255, 128, 128);

                    // no cost :D
                    LblCost.Text = "FREE";

                    // check for reached limit
                    if (state.Character.LimitReached || charactersLeft == 0) LblLimitReached.Text = "you've reached the monthly limit, and are unable to translate until next month!";
                }
                else
                {
                    // infinity
                    LblCharacterLimit.Text = "∞";
                    LblCharactersLeft.Text = "∞";

                    // not for free though
                    LblCost.Text = SubscriptionManager.CalculateCostString(state.Character.Count, false);
                }

                // done
                ActiveControl = BtnYes;
            }
            catch (ConnectionException ex)
            {
                if (IsDisposed) return;
                Log.Fatal(ex, "[SUBSCRIPTION] Unable to establish a connection to DeepL's servers: {err}", ex.Message);
                MessageBoxAdv2.Show(this, "Unable to establish a connection to DeepL's servers.\r\n\r\nPlease try again later.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                Log.Fatal(ex, "[SUBSCRIPTION] Something went wrong: {err}", ex.Message);
                MessageBoxAdv2.Show(this, $"Something went wrong:\r\n\r\n{ex.Message}", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void SubscriptionInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            DialogResult = DialogResult.Cancel;
        }

        private void BtnYes_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void LblSubscriptionPage_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.deepl.com/account/plan");
    }
}