using DeepLClient.Managers;
using Syncfusion.Windows.Forms;

namespace DeepLClient.Forms.Dialogs
{
    public partial class ConfirmDocument : MetroForm
    {
        private readonly long _charCount;
        private readonly string _chars;
        private readonly string _file;
        private readonly bool _isTxt;

        public ConfirmDocument(long chars, string file, bool isTxt = false)
        {
            _charCount = chars;
            _chars = $"{chars:N0}";
            _file = file;
            _isTxt = isTxt;

            InitializeComponent();
        }

        private void ConfirmDocument_Load(object sender, EventArgs e)
        {
            // set topmost
            TopMost = Variables.AppSettings.AlwaysOnTop;

            // catch all key presses
            KeyPreview = true;

            // set title
            Text = $"Cost Confirmation   |   {Variables.ApplicationName}";

            // set content
            LblDocument.Text = _file;

            // inform the user of possible minimum cost
            var charInfo = _charCount > Variables.AppSettings.MinimumCharactersPerDocument
                ? $"It contains {_chars} characters."
                : $"It contains {_chars} characters. However, since it's a document, it'll cost the minimum of {Variables.AppSettings.MinimumCharactersPerDocument:N0} characters.";

            // show relevant variant
            LblCostInfo.Text = SubscriptionManager.UsingFreeSubscription()
                ? $"{charInfo}\r\n\r\nYou're on a free subscription, so no costs."
                : $"{charInfo}\r\n\r\nIt will probably cost around {SubscriptionManager.CalculateCost(_charCount)}.";

            // optionally tip about small text files
            if (_isTxt && _charCount < Variables.AppSettings.MinimumCharactersPerDocument) LblTxt.Visible = true;

            // done
            ActiveControl = BtnYes;
        }

        private void BtnNo_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void BtnYes_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void ConfirmDocument_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            DialogResult = DialogResult.Cancel;
        }
    }
}