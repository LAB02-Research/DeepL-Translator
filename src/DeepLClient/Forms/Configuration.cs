using System.Text;
using DeepL;
using DeepL.Model;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace DeepLClient.Forms
{
    public partial class Configuration : MetroForm
    {
        private readonly HotkeySelector _hotkeySelector = new();
        private readonly Hotkey _previousHotkey = Variables.GlobalHotkey;

        private readonly Dictionary<string, string> _deepLDomains = new();

        public Configuration()
        {
            InitializeComponent();

            // make sure our comboboxes look good
            BindComboBoxTheme();
        }

        /// <summary>
        /// Sets the ComboBox themes
        /// </summary>
        private void BindComboBoxTheme()
        {
            CbDefaultFormality.DrawItem += ComboBoxTheme.DrawDictionaryIntStringItem;
            CbDomain.DrawItem += ComboBoxTheme.DrawDictionaryStringStringItem;
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            try
            {
                // suspend global hotkeys
                Variables.HotkeyListener.Suspend();

                // load domains
                LoadDomains();

                // load formalities
                if (!Variables.Formalities.Any())
                {
                    var formalities = Enum.GetValuesAsUnderlyingType<Formality>();
                    foreach (var formalityObj in formalities)
                    {
                        var formality = (Formality)formalityObj;
                        Variables.Formalities.Add((int)formality, formality.ToString());
                    }
                }

                // set formalities
                CbDefaultFormality.DataSource = new BindingSource(Variables.Formalities, null);

                // set domains
                CbDomain.DataSource = new BindingSource(_deepLDomains, null);

                // load settings
                TbUser.Text = Variables.AppSettings.User;
                TbAPIKey.Text = Variables.AppSettings.DeepLAPIKey;
                CbLaunchHidden.Checked = Variables.AppSettings.LaunchHidden;
                CbCopyTranslationToClipboard.Checked = Variables.AppSettings.CopyTranslationToClipboard;
                CbStoreLastUsedSourceLanguage.Checked = Variables.AppSettings.StoreLastUsedSourceLanguage;
                CbStoreLastUsedTargetLanguage.Checked = Variables.AppSettings.StoreLastUsedTargetLanguage;
                CbLaunchHidden.Checked = Variables.AppSettings.LaunchOnWindowsLogin;
                CbEnableGlobalHotkey.Checked = Variables.AppSettings.GlobalHotkeyEnabled;

                // set hotkey
                if (Variables.GlobalHotkey != null) _hotkeySelector.Enable(TbHotkey, Variables.GlobalHotkey);
                else _hotkeySelector.Enable(TbHotkey);

                // load default formality
                CbDefaultFormality.SelectedItem = Variables.Formalities.GetEntry((int)Variables.AppSettings.DefaultFormality);

                // load domain
                if (!string.IsNullOrEmpty(Variables.AppSettings.DeepLDomain)) CbDomain.SelectedItem = _deepLDomains.GetEntry(Variables.AppSettings.DeepLDomain);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CONFIGURATION] Error loading settings: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong loading your settings.\r\n\r\nPlease manually review your config file and restart.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LoadDomains()
        {
            _deepLDomains.Add("api-free.deepl.com", "Free (api-free.deepl.com)");
            _deepLDomains.Add("api.deepl.com", "Pro (api.deepl.com)");
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            try
            {
                // get config
                var user = TbUser.Text.Trim();
                var api = TbAPIKey.Text.Trim();
                var launchHidden = CbLaunchHidden.Checked;
                var copyClipboard = CbCopyTranslationToClipboard.Checked;
                var storeSource = CbStoreLastUsedSourceLanguage.Checked;
                var storeTarget = CbStoreLastUsedTargetLanguage.Checked;
                var launchWindows = CbLaunchOnWindows.Checked;
                var hotkeyEnabled = CbEnableGlobalHotkey.Checked;

                // get formality
                var formality = Formality.Default;
                if (CbDefaultFormality.SelectedItem != null)
                {
                    var selectedFormality = (KeyValuePair<int, string>)CbDefaultFormality.SelectedItem;
                    formality = (Formality)selectedFormality.Key;
                }

                // get domain
                var domain = string.Empty;
                if (CbDomain.SelectedItem != null)
                {
                    var selectedDomain = (KeyValuePair<string, string>)CbDomain.SelectedItem;
                    domain = selectedDomain.Key;
                }

                // check the values
                if (string.IsNullOrEmpty(user))
                {
                    MessageBoxAdv.Show(this, "Please enter your name.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActiveControl = TbUser;
                    return;
                }

                if (string.IsNullOrEmpty(domain))
                {
                    MessageBoxAdv.Show(this, "Please select the right domain.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActiveControl = CbDomain;
                    return;
                }

                // set them
                Variables.AppSettings.User = user;
                Variables.AppSettings.DeepLAPIKey = api;
                Variables.AppSettings.LaunchHidden = launchHidden;
                Variables.AppSettings.CopyTranslationToClipboard = copyClipboard;
                Variables.AppSettings.StoreLastUsedSourceLanguage = storeSource;
                Variables.AppSettings.StoreLastUsedTargetLanguage = storeTarget;
                Variables.AppSettings.DefaultFormality = formality;
                Variables.AppSettings.DeepLDomain = domain;
                Variables.AppSettings.LaunchOnWindowsLogin = launchWindows;

                // hotkey config
                Variables.AppSettings.GlobalHotkeyEnabled = hotkeyEnabled;
                if (hotkeyEnabled)
                {
                    // hotkey enabled, store and activate
                    Variables.GlobalHotkey = new Hotkey(TbHotkey.Text);
                    Variables.AppSettings.GlobalHotkey = Variables.GlobalHotkey.ToString();
                    Variables.HotkeyManager.HotkeyChanged(_previousHotkey);
                }
                else
                {
                    // hotkey disabled, remove and deactivate
                    Variables.GlobalHotkey = null;
                    Variables.AppSettings.GlobalHotkey = string.Empty;
                    Variables.HotkeyManager.HotkeyChanged(_previousHotkey, false);
                }

                // store config
                var success = SettingsManager.Store();
                if (!success) MessageBoxAdv.Show(this, "Something went wrong saving your settings.\r\n\r\nPlease check the logs and retry.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // process launch-on-login
                if (launchWindows) LaunchManager.EnableLaunchOnUserLogin();
                else LaunchManager.DisableLaunchOnUserLogin();

                // done
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CONFIGURATION] Error saving settings: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong saving your settings.\r\n\r\nPlease check the logs and retry.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblFormalityInfo_Click(object sender, EventArgs e)
        {
            MessageBoxAdv.Show(this, HelperFunctions.GetFormalityExplanation(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblDomainInfo_Click(object sender, EventArgs e)
        {
            var info = new StringBuilder();
            info.AppendLine("Your API key only works with its corresponding domain.");
            info.AppendLine("");
            info.AppendLine("If you have a free subscription, select the free domain.");
            info.AppendLine("If you have a pro subscription, you guessed it, select the pro domain.");

            MessageBoxAdv.Show(this, info.ToString(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            // resume global hotkeys
            Variables.HotkeyListener.Resume();

            // remove hotkey selector
            _hotkeySelector?.Disable(TbHotkey);
            _hotkeySelector?.Dispose();
        }

        private void BtnCleanHotkey_Click(object sender, EventArgs e)
        {
            TbHotkey.Text = _hotkeySelector.EmptyHotkeyText;
        }

        private void LblHotkeyInfo_Click(object sender, EventArgs e)
        {
            var info = new StringBuilder();
            info.AppendLine("You can use the global hotkey to easily open DeepL Translator.");
            info.AppendLine("");
            info.AppendLine("Simply press the hotkey anytime, and the text translation page will pop up.");
            info.AppendLine("");
            info.AppendLine("Tip: if you press the hotkey after selecting text, it'll be conveniently pasted into the source textbox!");

            MessageBoxAdv.Show(this, info.ToString(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}