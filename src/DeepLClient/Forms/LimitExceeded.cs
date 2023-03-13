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

            LblIntro.Text = "You'll probably reach your limit with this translation!";

            var inf = new StringBuilder();
            inf.AppendLine($"Your limit is set to {_usage.Character!.Limit:N0}. You've used {_usage.Character!.Count:N0}, so you have {charsLeft:N0} left.");
            inf.AppendLine("");
            inf.AppendLine($"This translation will use {_chars} characters.");
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
    }
}