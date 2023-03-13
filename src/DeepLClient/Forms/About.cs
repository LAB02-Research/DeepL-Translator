using DeepLClient.Functions;
using DeepLClient.Managers;
using Syncfusion.Windows.Forms;

namespace DeepLClient.Forms
{
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // set version
            LblVersion.Text = Variables.Version;
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblLab02Research_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://lab02-research.org");

        private void LblByteSize_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/omar/ByteSize");

        private void LblDeepLnet_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/DeepLcom/deepl-dotnet");

        private void LblWebView2_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://learn.microsoft.com/en-us/microsoft-edge/webview2/");

        private void LblNewtonsoftJson_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.newtonsoft.com/json");

        private void LblHotkeyListener_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/ruffk/HotkeyListener");

        private void LblSerilog_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/serilog/serilog");

        private void LblSmartReader_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/strumenta/SmartReader");

        private void LblSyncfusion_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.syncfusion.com/");

        private void PbBMAC_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.buymeacoffee.com/lab02research");

        private void PbPayPal_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.paypal.com/donate/?hosted_button_id=5YL6UP94AQSPC");

        private void PbKoFi_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://ko-fi.com/lab02research");

        private void PbGithubSponsor_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/sponsors/LAB02-Admin");

        private void LblDeepLProject_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/DeepL-Translator");

        private void About_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }
    }
}