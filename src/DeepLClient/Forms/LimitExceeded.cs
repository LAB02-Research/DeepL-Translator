using System.Text;
using DeepL.Model;
using DeepLClient.Managers;
using Syncfusion.Windows.Forms;

namespace DeepLClient.Forms
{
    public partial class LimitExceeded : MetroForm
    {
        private Usage _usage;
        private readonly string _chars;

        public LimitExceeded(long chars)
        {
            _chars = $"{chars:N0}";
            InitializeComponent();
        }

        private async void LimitExceeded_Load(object sender, EventArgs e)
        {
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

            var inf = new StringBuilder();
            inf.AppendLine("You'll probably reach your limit with this translation.");
            inf.AppendLine("");
            inf.AppendLine($"Your limit is set to {_usage.Character!.Limit:N0}. You've used {_usage.Character!.Count:N0}, so you have {charsLeft:N0} left.");
            inf.AppendLine("");
            inf.AppendLine($"This translation will use {_chars} characters.");
            inf.AppendLine("");
            inf.AppendLine("Do you still want to try to translate?");

            LblInfo.Text = inf.ToString();
        }

        private void SetLimitReached()
        {
            var inf = new StringBuilder();
            inf.AppendLine("DeepL has flagged your subscription's limit as reached.");
            inf.AppendLine("");
            inf.AppendLine($"Your limit is set to {_usage.Character!.Limit:N0}.");
            inf.AppendLine("");
            inf.AppendLine("");
            inf.AppendLine("Do you still want to try to translate?");

            LblInfo.Text = inf.ToString();
        }

        private void BtnNo_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void BtnYes_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;
    }
}