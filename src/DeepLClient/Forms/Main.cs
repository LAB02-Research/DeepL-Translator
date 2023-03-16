using System.Diagnostics.CodeAnalysis;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace DeepLClient.Forms
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            try
            {
                // set title
                Text = $"{Variables.ApplicationName}   |   LAB02 Research   |   {Variables.Version}";

                // set systray icon text
                NotifyIcon.Text = $"{Variables.ApplicationName}   |   LAB02 Research";

                // catch all key presses
                KeyPreview = true;

                // check for updates
                _ = Task.Run(UpdateManager.Initialize);

                // initialize ourselves
                await Variables.MainFormManager.Initialize();

                // monitor subscription limits
                _ = Task.Run(SubscriptionManager.Initialize);

                // initialize the global hotkey
                InitializeHotkey();

#if DEBUG
                // always show when debugging
                await Task.Delay(250);
                Variables.MainFormManager.ShowMain(false);
#endif

                // set topmost
                TopMost = Variables.AppSettings.AlwaysOnTop;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error on Main_Load: {err}", ex.Message);
                MessageBoxAdv2.Show(this, "Something went wrong while launching the app." +
                                         "\r\n\r\nPlease make sure everything's configured correctly, and your internet connection is working." +
                                         "\r\n\r\nIf the problem persists, check your logs and contact the developer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);


                // we're done for
                ProcessManager.Shutdown();
            }
        }

        /// <summary>
        /// Initialises and binds the hotkey
        /// <para>Strange things happen when we put this in a seperate class ..</para>
        /// </summary>
        private void InitializeHotkey()
        {
            try
            {
                // create a hotkey listener
                Variables.HotkeyListener = new HotkeyListener();

                // prepare listener
                Variables.HotkeyListener.HotkeyPressed += HotkeyListener_HotkeyPressed;

                // initialise the manager
                Variables.HotkeyManager.Initialize();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error setting up the hotkey: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Fires when a registered hotkey is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotkeyListener_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            HotkeyManager.ProcessHotkey(e);
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            // show configuration dialog
            using var config = new Configuration();
            var result = config.ShowDialog();
            if (result != DialogResult.OK) return;

            // set topmost
            TopMost = Variables.AppSettings.AlwaysOnTop;

            // reset deepl?
            if (!config.ResetDeepL) return;

            // yep
            _ = Variables.MainFormManager.Initialize();
        }

        private void BtnSubscriptionInfo_Click(object sender, EventArgs e)
        {
            // show subscription info dialog
            using var subscriptionInfo = new SubscriptionInfo();
            subscriptionInfo.ShowDialog();
        }

        private void LblWarning_Click(object sender, EventArgs e)
        {
            // show subscription info dialog
            using var subscriptionInfo = new SubscriptionInfo();
            subscriptionInfo.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if we're already closing, nevermind
            if (Variables.ShuttingDown)
            {
                e.Cancel = true;
                return;
            }

            // how bad do they want it?
            if (e.CloseReason is CloseReason.TaskManagerClosing or CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                ProcessManager.Shutdown();
                return;
            }

            // just hide
            Invoke(new MethodInvoker(Hide));

            // cancel closing
            e.Cancel = true;

            // set to text (if possible)
            Variables.MainFormManager.ActivateText();
        }

        /// <summary>
        /// Shows the application by clicking the tray icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            Variables.MainFormManager.ShowMain(false);
        }

        /// <summary>
        /// Hides or closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHide_Click(object sender, EventArgs e)
        {
            // shutdown if ctrl is pressed
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                Variables.MainFormManager.Shutdown();
                return;
            }

            // hide
            Hide();

            // set to text (if possible)
            Variables.MainFormManager.ActivateText();
        }

        /// <summary>
        /// Hides and resets when esc is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            // hide on esc
            if (e.KeyCode != Keys.Escape) return;
            Hide();

            // set to text (if possible)
            Variables.MainFormManager.ActivateText();
        }

        /// <summary>
        /// Shows the 'about' form
        /// </summary>
        private static void ShowAbout()
        {
            using var about = new About();
            about.ShowDialog();
        }

        private void BtnAbout_Click(object sender, EventArgs e) => ShowAbout();

        private void TsAbout_Click(object sender, EventArgs e) => ShowAbout();

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) => Variables.MainFormManager.ShowMain(false);

        private void TsExit_Click(object sender, EventArgs e) => Variables.MainFormManager.Shutdown();

        private void TsShow_Click(object sender, EventArgs e) => Variables.MainFormManager.ShowMain(false);
    }
}