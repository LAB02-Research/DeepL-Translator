using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DeepLClient.Controls;
using DeepLClient.Functions;
using Serilog;
using DeepLClient.Forms;
using Exception = System.Exception;
using Action = System.Action;

namespace DeepLClient.Managers
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    internal class MainFormManager : IDisposable
    {
        internal readonly Main MainForm;
        private bool _isDosposing;

        private TextPage _text;
        private DocumentsPage _documents;
        private UrlPage _url;

        internal MainFormManager(Main mainForm)
        {
            MainForm = mainForm;
        }

        /// <summary>
        /// Initialises the application and interface
        /// </summary>
        internal async Task Initialize()
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(delegate { _ = Initialize(); }));
                    return;
                }

                // check autolaunch state
                if (Variables.AppSettings.LaunchOnWindowsLogin) LaunchManager.EnableLaunchOnUserLogin();

                // check if we have an API key
                if (string.IsNullOrEmpty(Variables.AppSettings.DeepLAPIKey))
                {
                    // set guidance message
                    ShowWarningMessage("← PLEASE SET YOUR API KEY HERE", ContentAlignment.TopLeft);

                    // api notification already shown?
                    if (!SettingsManager.GetApiKeyMissingShown())
                    {
                        // nope, show api notification, and provide some extra info for non-euro users
                        const string baseMessage = "No API key has been set.\r\n\r\n" +
                                                   "In the main window, click the configuration button at the bottom left to set your personal key.\r\n\r\n" +
                                                   "Tip: if you're on a pro subscription, remember to set the right domain.";
                    
                        MessageBoxAdv2.Show(MainForm,
                            Variables.CurrencySymbol == "€"
                                ? baseMessage
                                : $"{baseMessage}\r\n\r\n" +
                                  "Make sure to check the price-per-character, as the default value is only valid for euros.",
                            Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // only once
                        SettingsManager.SetApiKeyMissingShown(true);
                    }

                    // no subscription yet
                    MainForm.BtnSubscription.Enabled = false;

                    // don't continue
                    return;
                }

                // initialise DeepL
                var deepLisInitialised = await DeepLManager.InitializeAsync();
                if (!deepLisInitialised)
                {
                    // failed
                    MessageBoxAdv2.Show(MainForm, "Something went wrong when initialising DeepL.\r\n\r\n" +
                                              "Please make sure everything's configured correctly, and your internet connection is working.\r\n\r\n" +
                                              "You can try again later, but if the problem persists, check your logs and contact the developer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MainForm.BtnSubscription.Enabled = false;

                    // no point going on
                    return;
                }

                // optionally re-enable subscription button
                if (!MainForm.BtnSubscription.Enabled) MainForm.BtnSubscription.Enabled = true;

                // optionally hide guidance message
                HideWarningMessage();

                // optionally remove current pages
                ClearTabPages();

                // load fresh ones
                LoadTabPages();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error on initialising: {err}", ex.Message);
                
                MessageBoxAdv2.Show(MainForm, "Something went wrong while initialising the app.\r\n\r\n" +
                                          "Please make sure everything's configured correctly, and your internet connection is working.\r\n\r\n" +
                                          "If the problem persists, check your logs and contact the developer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // we're done for
                ProcessManager.Shutdown();
            }
        }

        /// <summary>
        /// Disposes and removes all initialised tab pages
        /// </summary>
        private void ClearTabPages()
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(ClearTabPages));
                    return;
                }

                if (_text != null)
                {
                    MainForm.TabText.Controls.Remove(_text);
                    _text.Dispose();
                }

                if (_documents != null)
                {
                    MainForm.TabDocuments.Controls.Remove(_documents);
                    _documents.Dispose();
                }

                if (_url != null)
                {
                    MainForm.TabDocuments.Controls.Remove(_url);
                    _url.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error clearing tab pages: {ex}", ex.Message);
            }
        }

        /// <summary>
        /// Creates and sets new tab pages
        /// </summary>
        private void LoadTabPages()
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(LoadTabPages));
                    return;
                }

                // load pages
                _text = new TextPage();
                _documents = new DocumentsPage();
                _url = new UrlPage();

                // set controls
                MainForm.TabText.Controls.Add(_text);
                MainForm.TabDocuments.Controls.Add(_documents);
                MainForm.TabUrl.Controls.Add(_url);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error showing tab pages: {ex}", ex.Message);
            }
        }

        /// <summary>
        /// Show/hide the main form
        /// </summary>
        internal async void ShowMain(bool hideIfVisible = true)
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(delegate { ShowMain(hideIfVisible); }));
                    return;
                }

                if (MainForm.Visible && hideIfVisible)
                {
                    // hide us
                    MainForm.Hide();

                    // set to text so it'll laod faster on return
                    ActivateText();
                    return;
                }

                // show interface
                MainForm.Show();

                // wait a bit
                // todo: ugly
                await Task.Delay(250);

                // make sure we get the attention we deserve
                MainForm.BringToFront();
                MainForm.Activate();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error showing UI: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Hides the main form
        /// </summary>
        internal void HideMain()
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(HideMain));
                    return;
                }

                MainForm.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Closes the application after the user agrees
        /// </summary>
        internal void Shutdown()
        {
            if (!MainFormReady()) return;
            if (InvokeRequired())
            {
                MainForm.Invoke(new MethodInvoker(Shutdown));
                return;
            }
            
            var confirm = MessageBoxAdv2.Show(MainForm, "Are you sure you want to completely exit?", Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            ProcessManager.Shutdown();
        }

        /// <summary>
        /// Suspends the mainform's topmost status
        /// </summary>
        internal void SuspendTopMost()
        {
            if (!MainFormReady()) return;
            if (InvokeRequired())
            {
                MainForm.Invoke(new MethodInvoker(Shutdown));
                return;
            }

            if (MainForm.TopMost) MainForm.TopMost = false;
        }

        /// <summary>
        /// Resumes the mainform's topmost status, by default only if set by the user
        /// </summary>
        /// <param name="onlyIfSetting"></param>
        internal void ResumeTopMost(bool onlyIfSetting = true)
        {
            if (onlyIfSetting && !Variables.AppSettings.AlwaysOnTop) return;

            if (!MainFormReady()) return;
            if (InvokeRequired())
            {
                MainForm.Invoke(new MethodInvoker(Shutdown));
                return;
            }
            MainForm.TopMost = true;
        }

        /// <summary>
        /// Attempts to revert back to the default text tab
        /// </summary>
        internal void ActivateText()
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(ActivateText));
                    return;
                }

                // set to text (if possible)
                if (_text == null) return;
                if (MainForm.TranslationTabs.SelectedTab != MainForm.TabText) MainForm.TranslationTabs.SelectedTab = MainForm.TabText;
                MainForm.ActiveControl = _text.TbSource;
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
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(HideTrayIcon));
                    return;
                }

                MainForm.NotifyIcon.Visible = false;
            }
            catch { }
        }

        /// <summary>
        /// Hides and resets the warning message
        /// </summary>
        internal void HideWarningMessage()
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(HideWarningMessage));
                    return;
                }

                MainForm.LblWarning.TextAlign = ContentAlignment.TopCenter;
                MainForm.LblWarning.Text = string.Empty;
                MainForm.LblWarning.Visible = false;
            }
            catch { }
        }

        /// <summary>
        /// Shows the specified warning
        /// </summary>
        /// <param name="message"></param>
        /// <param name="alignment"></param>
        internal void ShowWarningMessage(string message, ContentAlignment alignment = ContentAlignment.TopCenter)
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(delegate { ShowWarningMessage(message, alignment); }));
                    return;
                }

                MainForm.LblWarning.TextAlign = alignment;
                MainForm.LblWarning.Text = message;
                MainForm.LblWarning.Visible = true;
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
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(delegate { SetSourceText(text, showForm); }));
                    return;
                }

                // is the ui ready?
                if (_text == null) return;
                if (MainForm.TranslationTabs.SelectedTab != MainForm.TabText) MainForm.TranslationTabs.SelectedTab = MainForm.TabText;

                // set the selected text
                _text.TbSource.Text = text;
                _text.TbSource.SelectionStart = _text.TbSource.Text.Length;

                // focus the textbox
                MainForm.ActiveControl = _text.BtnTranslate;

                // show our ui
                if (showForm) ShowMain(false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error while setting source text: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Sets the provided url, shows the form and starts translation
        /// </summary>
        /// <param name="url"></param>
        internal void SetSourceUrl(string url)
        {
            try
            {
                if (!MainFormReady()) return;
                if (InvokeRequired())
                {
                    MainForm.Invoke(new MethodInvoker(delegate { SetSourceUrl(url); }));
                    return;
                }

                // is the ui ready?
                if (_text == null) return;
                if (MainForm.TranslationTabs.SelectedTab != MainForm.TabUrl) MainForm.TranslationTabs.SelectedTab = MainForm.TabUrl;

                // set the selected text
                _url.TbUrl.Text = url;
                _url.TbUrl.SelectionStart = _url.TbUrl.Text.Length;

                // focus the textbox
                MainForm.ActiveControl = _text.BtnTranslate;

                // show our ui
                ShowMain(false);

                // start translation
                _url.ExecuteTranslation();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error while setting source url: {err}", ex.Message);
            }
        }
        
        /// <summary>
        /// Returns whether the main form is (still) created and available
        /// </summary>
        /// <returns></returns>
        internal bool MainFormReady() => !Variables.ShuttingDown && MainForm.IsHandleCreated && !MainForm.IsDisposed;

        /// <summary>
        /// Returns whether an invoke is required for the main form
        /// </summary>
        /// <returns></returns>
        internal bool InvokeRequired() => MainForm.InvokeRequired;

        /// <summary>
        /// Runs the provided action on the main UI thread
        /// </summary>
        /// <param name="action"></param>
        internal void RunOnUiThread(Action action)
        {
            if (!MainFormReady()) return;
            MainForm.Invoke(action);
        }

        /// <summary>
        /// Dispose the mainform and other dispoable controls
        /// <para>This will end the application.</para>
        /// </summary>
        public void Dispose()
        {
            if (_isDosposing) return;
            _isDosposing = true;

            try
            {
                if (_text != null)
                {
                    MainForm.TabText.Controls.Remove(_text);
                    _text.Dispose();
                }

                if (_documents != null)
                {
                    MainForm.TabDocuments.Controls.Remove(_documents);
                    _documents.Dispose();
                }

                if (_url != null)
                {
                    MainForm.TabDocuments.Controls.Remove(_url);
                    _url.Dispose();
                }

                MainForm?.Close();
                MainForm?.Dispose();
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"[MAIN] Error while disposing: {ex.Message}");
                throw;
#endif

                // use the axe
                Environment.Exit(1);
            }
        }
    }
}
