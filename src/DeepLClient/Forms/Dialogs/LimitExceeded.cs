using System.Text;
using DeepL.Model;
using Syncfusion.Windows.Forms;

namespace DeepLClient.Forms.Dialogs
{
    public partial class LimitExceeded : MetroForm
    {
        private Usage _usage;
        private readonly long _charCount;
        private readonly string _chars;
        private readonly bool _isDocument;

        public LimitExceeded(long chars, bool isDocument = false)
        {
            _charCount = chars;
            _chars = $"{chars:N0}";
            _isDocument = isDocument;

            InitializeComponent();
        }

        private async void LimitExceeded_Load(object sender, EventArgs e)
        {
            // set topmost
            TopMost = Variables.AppSettings.AlwaysOnTop;

            // catch all key presses
            KeyPreview = true;

            // set title
            Text = $"Limit Warning   |   {Variables.ApplicationName}";

            // get the current state
            _usage = await Variables.Translator.GetUsageAsync();

            // set focus to yes
            ActiveControl = BtnYes;

            // check for limit
            if (_usage.AnyLimitReached)
            {
                SetLimitReached();
                return;
            }

            // set limit info
            var charsLeft = _usage.Character!.Limit - _usage.Character!.Count;

            LblIntro.Text = "You'll probably reach your limit with this translation!";

            var inf = new StringBuilder();
            inf.AppendLine($"Your limit is set to {_usage.Character!.Limit:N0}. You've used {_usage.Character!.Count:N0}, so you have {charsLeft:N0} left.");
            inf.AppendLine("");

            // inform the user of possible minimum cost
            if (_isDocument && _charCount < Variables.AppSettings.MinimumCharactersPerDocument) inf.AppendLine($"This translation contains {_chars} characters. However, since it's a document, it'll cost the minimum of {Variables.AppSettings.MinimumCharactersPerDocument:N0} characters.");
            else inf.AppendLine($"This translation will use {_chars} characters.");

            inf.AppendLine("");
            inf.AppendLine("Do you still want to try to translate?");

            LblInfo.Text = inf.ToString();

            // show info
            LblLoading.Visible = false;
            LblIntro.Visible = true;
            LblInfo.Visible = true;
        }

        private void SetLimitReached()
        {
            LblIntro.Text = "DeepL has flagged your subscription's limit as reached!";

            var inf = new StringBuilder();
            inf.AppendLine($"Your limit is set to {_usage.Character!.Limit:N0}.");
            inf.AppendLine("");
            inf.AppendLine("");
            inf.AppendLine("Do you still want to try to translate?");

            LblInfo.Text = inf.ToString();

            // show info
            LblLoading.Visible = false;
            LblIntro.Visible = true;
            LblInfo.Visible = true;
        }

        private void BtnNo_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void BtnYes_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void LimitExceeded_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            DialogResult = DialogResult.Cancel;
        }
    }
}