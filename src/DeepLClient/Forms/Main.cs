using System.Diagnostics.CodeAnalysis;
using DeepLClient.Controls;
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
        private TextPage _text;
        private DocumentsPage _documents;
        private UrlPage _url;

        private bool _isClosing = false;

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

                // catch all key presses
                KeyPreview = true;

                // check for updates
                _ = Task.Run(UpdateManager.Initialize);

                // monitor subscription limits
                _ = Task.Run(SubscriptionManager.Initialize);

                // initialize ourselves
                Initialize();

                // initialize the global hotkey
                InitializeHotkey();

#if DEBUG
                // always show when debugging
                await Task.Delay(250);
                ShowMain(false);
#endif
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error on Main_Load: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong while launching the app.\r\n\r\nPlease make sure everything's configured correctly, and your internet connection is working.\r\n\r\nIf the problem persists, check your logs and contact the developer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // we're done for
                ProcessManager.Shutdown();
            }
        }

        /// <summary>
        /// Initialises the application and interface
        /// </summary>
        private async void Initialize()
        {
            // check autolaunch state
            if (Variables.AppSettings.LaunchOnWindowsLogin) LaunchManager.EnableLaunchOnUserLogin();

            // check if we have an API key
            if (string.IsNullOrEmpty(Variables.AppSettings.DeepLAPIKey))
            {
                // show api notification, and provide some extra info for non-euro users
                MessageBoxAdv.Show(this,
                    Variables.CurrencySymbol == "€"
                        ? "No API key has been set.\r\n\r\nIn the main window, click the configuration button at the bottom left to set your personal key.\r\n\r\nTip: if you're on a pro subscription, remember to set the right domain."
                        : "No API key has been set.\r\n\r\nIn the main window, click the configuration button at the bottom left to set your personal key.\r\n\r\nTip: if you're on a pro subscription, remember to set the right domain.\r\n\r\nAlso check the price-per-character, as the default value is only valid for euros.",
                    Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // no subscription yet
                BtnSubscription.Enabled = false;

                // don't continue
                return;
            }

            // initialise DeepL
            var deepLisInitialised = await DeepLManager.InitializeAsync();
            if (!deepLisInitialised)
            {
                // failed
                MessageBoxAdv.Show(this, $"Something went wrong when initialising DeepL.\r\n\r\nPlease make sure everything's configured correctly, and your internet connection is working.\r\n\r\nYou can try again later, but if the problem persists, check your logs and contact the developer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnSubscription.Enabled = false;

                // no point going on
                return;
            }

            // optionally remove current pages
            ClearTabPages();

            // load fresh ones
            LoadTabPages();
        }

        /// <summary>
        /// Disposes and removes all initialised tab pages
        /// </summary>
        private void ClearTabPages()
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            if (_text != null)
            {
                TabText.Controls.Remove(_text);
                _text.Dispose();
            }
            
            if (_documents != null)
            {
                TabDocuments.Controls.Remove(_documents);
                _documents.Dispose();
            }
            
            if (_url != null)
            {
                TabDocuments.Controls.Remove(_url);
                _url.Dispose();
            }
        }

        /// <summary>
        /// Creates and sets new tab pages
        /// </summary>
        private void LoadTabPages()
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            // load pages
            _text = new TextPage();
            _documents = new DocumentsPage();
            _url = new UrlPage();

            // set controls
            TabText.Controls.Add(_text);
            TabDocuments.Controls.Add(_documents);
            TabUrl.Controls.Add(_url);
        }

        /// <summary>
        /// Initialises and bindes the hotkey
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

        /// <summary>
        /// Show/hide ourself
        /// </summary>
        internal async void ShowMain(bool hideIfVisible = true)
        {
            try
            {
                if (!IsHandleCreated) return;
                if (IsDisposed) return;

                if (Visible && hideIfVisible)
                {
                    // hide us
                    Hide();

                    // set to text so it'll laod faster on return
                    ActivateText();
                    return;
                }

                // show interface
                Show();

                // wait a bit
                // todo: ugly
                await Task.Delay(250);

                // make sure we get the attention we deserve
                BringToFront();
                Activate();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error showing UI: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Closes the application after the user agrees
        /// </summary>
        private void Shutdown()
        {
            var confirm = MessageBoxAdv.Show(this, "Are you sure you want to completely exit?", Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            ProcessManager.Shutdown();
        }

        /// <summary>
        /// Attempts to revert back to the default text tab
        /// </summary>
        private void ActivateText()
        {
            try
            {
                if (!IsHandleCreated) return;
                if (IsDisposed) return;

                // set to text (if possible)
                if (_text == null) return;
                if (TranslationTabs.SelectedTab != TabText) TranslationTabs.SelectedTab = TabText;
                ActiveControl = _text.TbSource;
            }
            catch { }
        }

        /// <summary>
        /// Hides the tray icon
        /// </summary>
        internal void HideTrayIcon()
        {
            try
            {
                if (!IsHandleCreated) return;
                if (IsDisposed) return;

                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        NotifyIcon.Visible = false;
                    }
                    catch { }
                }));
            }
            catch { }
        }

        /// <summary>
        /// Shows (or optionally hides) the 'limit reached' warning
        /// </summary>
        /// <param name="show"></param>
        internal void ShowLimitWarning(bool show = true)
        {
            try
            {
                if (!IsHandleCreated) return;
                if (IsDisposed) return;

                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        LblCharLimitReached.Visible = show;
                    }
                    catch { }
                }));
            }
            catch { }
        }

        /// <summary>
        /// Sets the provided text in the source field, and optionally shows the form
        /// </summary>
        /// <param name="text"></param>
        /// <param name="showForm"></param>
        internal void SetSourceText(string text, bool showForm)
        {
            try
            {
                if (!IsHandleCreated) return;
                if (IsDisposed) return;

                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        // is the ui ready?
                        if (_text == null) return;
                        if (TranslationTabs.SelectedTab != TabText) TranslationTabs.SelectedTab = TabText;

                        // set the selected text
                        _text.TbSource.Text = text;
                        _text.TbSource.SelectionStart = _text.TbSource.Text.Length;

                        // focus the textbox
                        ActiveControl = _text.BtnTranslate;

                        // show our ui
                        if (showForm) ShowMain(false);
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "[MAIN] Error while setting source text: {err}", ex.Message);
                    }
                }));
            }
            catch { }
        }

        /// <summary>
        /// Sets the provided url, shows the form and starts translation
        /// </summary>
        /// <param name="url"></param>
        internal void SetSourceUrl(string url)
        {
            try
            {
                if (!IsHandleCreated) return;
                if (IsDisposed) return;

                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        // is the ui ready?
                        if (_text == null) return;
                        if (TranslationTabs.SelectedTab != TabUrl) TranslationTabs.SelectedTab = TabUrl;

                        // set the selected text
                        _url.TbUrl.Text = url;
                        _url.TbUrl.SelectionStart = _url.TbUrl.Text.Length;

                        // focus the textbox
                        ActiveControl = _text.BtnTranslate;

                        // show our ui
                        ShowMain(false);

                        // start translation
                        _url.ExecuteTranslation();
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "[MAIN] Error while setting source url: {err}", ex.Message);
                    }
                }));
            }
            catch { }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            // show configuration dialog
            using var config = new Configuration();
            var result = config.ShowDialog();
            if (result != DialogResult.OK) return;

            // reload
            Initialize();
        }

        private void BtnSubscriptionInfo_Click(object sender, EventArgs e)
        {
            // show subscription info dialog
            using var subscriptionInfo = new SubscriptionInfo();
            subscriptionInfo.ShowDialog();
        }

        private void LblCharLimitReached_Click(object sender, EventArgs e)
        {
            // show subscription info dialog
            using var subscriptionInfo = new SubscriptionInfo();
            subscriptionInfo.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isClosing) return;

            Invoke(new MethodInvoker(Hide));

            if (!Variables.ShuttingDown)
            {
                // cancel closing
                e.Cancel = true;

                // set to text (if possible)
                ActivateText();
                return;
            }

            // we're calling the shutdown function, but async won't hold so ignore that
            Task.Run(ProcessManager.Shutdown);

            // cancel and let the shutdown function handle it
            _isClosing = true;
            e.Cancel = true;
        }

        /// <summary>
        /// Shows the application by clicking the tray icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            ShowMain(false);
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
                Shutdown();
                return;
            }

            // hide
            Hide();

            // set to text (if possible)
            ActivateText();
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
            ActivateText();
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

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) => ShowMain(false);

        private void TsExit_Click(object sender, EventArgs e) => Shutdown();

        private void TsShow_Click(object sender, EventArgs e) => ShowMain(false);
    }
}