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
                // set cost info
                LblCost.Text = SubscriptionManager.UsingFreeSubscription() ? "FREE" : "€ 0,00";

                // get the current state
                var state = await Variables.Translator.GetUsageAsync();

                if (state.Character != null)
                {
                    // set character info
                    LblCharacterLimit.Text = $"{state.Character.Limit:N0}";
                    LblCharactersUsed.Text = $"{state.Character.Count:N0}";

                    // determine how many chars are left
                    var charsLeft = state.Character.Limit - state.Character.Count;
                    if (charsLeft < 0) charsLeft = 0;
                    LblCharactersLeft.Text = $"{charsLeft:N0}";

                    // check for reached limit
                    if (state.Character.LimitReached || charsLeft == 0)
                        LblLimitReached.Text = "you've reached the monthly limit, and are unable to translate until next month!";

                    // determine cost
                    LblCost.Text = SubscriptionManager.UsingFreeSubscription() ? "FREE" : SubscriptionManager.CalculateCost(state.Character.Count, false);
                }
                else
                {
                    // unknown, weird
                    LblCharacterLimit.Text = "?";
                    LblCharactersUsed.Text = "?";
                    LblCharactersLeft.Text = "?";
                    LblCost.Text = "?";
                }

                // done
                ActiveControl = BtnYes;
            }
            catch (ConnectionException ex)
            {
                if (IsDisposed) return;
                Log.Fatal(ex, "[SUBSCRIPTION] Unable to establish a connection to DeepL's servers: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Unable to establish a connection to DeepL's servers.\r\n\r\nPlease try again later.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                Log.Fatal(ex, "[SUBSCRIPTION] Something went wrong: {err}", ex.Message);
                MessageBoxAdv.Show(this, $"Something went wrong:\r\n\r\n{ex.Message}", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void BtnYes_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void LblSubscriptionPage_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.deepl.com/account/plan");
    }
}