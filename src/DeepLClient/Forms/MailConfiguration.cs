using System.Text;
using DeepL;
using DeepLClient.Extensions;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace DeepLClient.Forms
{
    public partial class MailConfiguration : MetroForm
    {
        public MailConfiguration()
        {
            InitializeComponent();
        }

        private void MailConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                // set topmost
                TopMost = Variables.AppSettings.AlwaysOnTop;

                // catch all key presses
                KeyPreview = true;

                // set title
                Text = $"E-mail   |   {Variables.ApplicationName}";

                // load settings
                TbUser.Text = Variables.AppSettings.User;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CONFIGURATION-EMAIL] Error loading settings: {err}", ex.Message);
                MessageBoxAdv2.Show(this, "Something went wrong loading your settings.\r\n\r\nPlease manually review your config file and restart.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            try
            {
                // get config
                var user = TbUser.Text.Trim();
                var launchHidden = CbLaunchHidden.Checked;

                // check domain
                if (string.IsNullOrEmpty(user))
                {
                    MessageBoxAdv2.Show(this, "Please select the right domain.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActiveControl = TbUser;
                    return;
                }

                // set the new configuration
                Variables.AppSettings.User = user;
                Variables.AppSettings.LaunchHidden = launchHidden;

                // store config
                var success = SettingsManager.StoreAppSettings();
                if (!success) MessageBoxAdv2.Show(this, "Something went wrong saving your settings.\r\n\r\nPlease check the logs and retry.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // done
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CONFIGURATION-EMAIL] Error saving settings: {err}", ex.Message);
                MessageBoxAdv2.Show(this, "Something went wrong saving your settings.\r\n\r\nPlease check the logs and retry.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void MailConfiguration_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }
    }
}