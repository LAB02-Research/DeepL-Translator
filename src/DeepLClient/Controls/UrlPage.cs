using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using DeepL;
using DeepL.Model;
using DeepLClient.Forms;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Serilog;
using SmartReader;
using Syncfusion.Windows.Forms;
using Windows.Globalization;
using Newtonsoft.Json;

namespace DeepLClient.Controls
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    public partial class UrlPage : UserControl
    {
        private bool _isInitialised;
        private bool _webviewEnabled = true;

        public UrlPage()
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
            CbSourceLanguage.DrawItem += ComboBoxTheme.DrawDictionaryStringStringItemUsingKey;
            CbTargetLanguage.DrawItem += ComboBoxTheme.DrawDictionaryStringStringItemUsingKey;
        }

        private void UrlPage_Load(object sender, EventArgs e)
        {
            if (!_isInitialised) _ = InitializeAsync();
        }

        /// <summary>
        /// Initialises the WebView control and the rest of the interface
        /// </summary>
        /// <returns></returns>
        private async Task<bool> InitializeAsync()
        {
            try
            {
                // set cost info
                LblCost.Text = SubscriptionManager.BaseCostNotation();

                // prepare a webview environment
                Variables.WebViewEnvironment ??= await CoreWebView2Environment.CreateAsync(null, Variables.WebViewCachePath);

                // make sure our webview is loaded
                await WebView.EnsureCoreWebView2Async(Variables.WebViewEnvironment);

                // disable parts we're not using
                WebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                WebView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
                WebView.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
                WebView.CoreWebView2.Settings.AreDevToolsEnabled = false;
                WebView.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
                WebView.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
                WebView.CoreWebView2.Settings.IsPinchZoomEnabled = false;
                WebView.CoreWebView2.Settings.IsStatusBarEnabled = false;
                WebView.CoreWebView2.Settings.IsSwipeNavigationEnabled = false;

                // bind to navigation completed
                WebView.CoreWebView2.NavigationCompleted += CoreWebView2OnNavigationCompleted;

                // allow drag 'n drop
                // todo: doesn't work, override
                WebView.AllowExternalDrop = true;
                WebView.DragDrop += WebViewOnDragDrop;

                // wait for DeepL to load
                while (!DeepLManager.IsInitialised) await Task.Delay(50);

                // set source languages
                CbSourceLanguage.DataSource = new BindingSource(Variables.SourceLanguages, null);

                // set target languages
                CbTargetLanguage.DataSource = new BindingSource(Variables.TargetLanguages, null);

                // optionally set last source language
                if (Variables.AppSettings.StoreLastUsedSourceLanguage && !string.IsNullOrEmpty(Variables.AppSettings.LastSourceLanguage))
                {
                    CbSourceLanguage.SelectedItem = Variables.SourceLanguages.GetKeyByEntry(Variables.AppSettings.LastSourceLanguage);
                }

                // optionally set last target language
                if (Variables.AppSettings.StoreLastUsedTargetLanguage &&
                    !string.IsNullOrEmpty(Variables.AppSettings.LastTargetLanguage))
                {
                    CbTargetLanguage.SelectedItem = Variables.TargetLanguages.GetKeyByEntry(Variables.AppSettings.LastTargetLanguage);
                }

                // done
                return true;
            }
            catch (WebView2RuntimeNotFoundException ex)
            {
                LockInterface();

                _webviewEnabled = false;

                LblState.Text = "you don't have the required component installed on your pc";
                LblState.Visible = true;

                Log.Fatal(ex, "[URL] WebView2 runtime not found, unable to initialize: {err}", ex.Message);

                var q = MessageBoxAdv.Show(this, "Microsoft's WebView2 runtime isn't found on your machine. This is a required component for showing your webpages.\r\n\r\n" +
                                                 "Usually this is handled by the installer, but you can still install it manually.\r\n\r\n" +
                                                 "Do you want to download the runtime installer?", Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (q != DialogResult.Yes) return false;

                HelperFunctions.LaunchUrl("https://go.microsoft.com/fwlink/p/?LinkId=2124703");
                return false;
            }
            catch (Exception ex)
            {
                LockInterface();

                _webviewEnabled = false;

                LblState.Text = "something went wrong trying to initialise the webpage translator\r\n\r\ncheck the logs and contact the developer for help";
                LblState.Visible = true;

                Log.Fatal(ex, "[URL] Unable to initialize: {err}", ex.Message);
                return false;
            }
            finally
            {
                _isInitialised = true;
            }
        }

        internal async void ExecuteTranslation()
        {
            if (!_webviewEnabled) return;

            if (!_isInitialised)
            {
                var initialised = await InitializeAsync();
                if (!initialised) return;
            }

            try
            {
                // lock the interface
                LockInterface();

                // clear content
                ClearWebpageInterface();

                // remove warning
                PbWarning.Visible = false;

                // get the url
                var url = TbUrl.Text.Trim();
                if (string.IsNullOrEmpty(url)) return;

                // check and prepare the url
                var isLocal = UrlManager.IsLocalOrNetworkFile(url);
                if (!UrlManager.IsUrl(url) && !isLocal)
                {
                    // assuming remote, but without http, add it (defaulting to https)
                    url = $"https://{url}";
                    TbUrl.Text = url;
                }

                // reset detection
                ResetDetectedSourceLanguage();

                // set the stage
                LblState.Text = "hold on while your webpage is being translated ..";
                LblState.Visible = true;

                // get the content
                var webpageResult = await UrlManager.GetReadableContentAsync(url, isLocal);
                if (!webpageResult.Success)
                {
                    LblState.Text = !string.IsNullOrEmpty(webpageResult.Error)
                        ? $"something went wrong while trying to fetch your webpage:\r\n\r\n{webpageResult.Error}"
                        : "something went wrong while trying to fetch your webpage";
                    return;
                }

                // check it
                if (string.IsNullOrWhiteSpace(webpageResult.Content))
                {
                    LblState.Text = "your webpage doesn't seem to contain any text";
                    return;
                }

                // do we have enough chars left?
                if (await SubscriptionManager.CharactersWillExceedLimitAsync(webpageResult.Content.Length))
                {
                    using var limit = new LimitExceeded(webpageResult.Content.Length);
                    var ignoreLimit = limit.ShowDialog();
                    if (ignoreLimit != DialogResult.OK)
                    {
                        ClearWebpageInterface();
                        return;
                    }
                }

                // readable?
                if (!webpageResult.IsReadable) PbWarning.Visible = true;

                // fetch the source language
                string sourceLanguage = null;
                if (CbSourceLanguage.SelectedItem != null)
                {
                    var item = (KeyValuePair<string, string>)CbSourceLanguage.SelectedItem;
                    sourceLanguage = item.Value;
                }

                // auto detect?
                if (sourceLanguage == "AUTO DETECT") sourceLanguage = null;

                // fetch the target language
                string targetLanguage = null;
                if (CbTargetLanguage.SelectedItem != null)
                {
                    var item = (KeyValuePair<string, string>)CbTargetLanguage.SelectedItem;
                    targetLanguage = item.Value;
                }

                if (targetLanguage == null)
                {
                    LblState.Text = "unable to translate:\r\n\r\nplease select a valid target language";
                    ClearWebpageInterface(false);
                    return;
                }

                // make sure html tags don't get translated, and preserve the formatting
                var options = new TextTranslateOptions
                {
                    TagHandling = "html",
                    PreserveFormatting = true
                };

                // don't use formality, send the text as-is to DeepL for translation
                var translatedText = await Variables.Translator.TranslateTextAsync(
                    webpageResult.Content,
                    sourceLanguage,
                    targetLanguage,
                    options);
                
                // set the cost
                LblCharacters.Text = translatedText.Text.Length.ToString();
                LblCost.Text = SubscriptionManager.CalculateCost(translatedText.Text.Length, false);

                // wrap it in html for styling
                var source = UrlManager.WrapContentInHtml(translatedText.Text, webpageResult.Title);

                // set the translated text
                WebView.NavigateToString(source);

                // hide info
                LblState.Text = string.Empty;
                LblState.Visible = false;

                // store the selected languages
                SettingsManager.StoreSelectedLanguages(CbSourceLanguage, CbTargetLanguage);

                // is auto detect enabled?
                if (sourceLanguage != null) return;

                // yep, set the detected source language
                LblDetectedInfo.Visible = true;
                LblDetected.Visible = true;
                LblDetected.Text = DeepLManager.GetSourceLanguageByLanguageCode(translatedText.DetectedSourceLanguageCode);
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[URL] Connection error while translating the webpage: {err}", ex.Message);
                LblState.Text = "unable to establish a connection to DeepL's servers\r\n\r\nplease try again later";
                ClearWebpageInterface(false);
            }
            catch (DocumentTranslationException ex)
            {
                Log.Fatal(ex, "[URL] Error while translating the webpage: {err}", ex.Message);
                LblState.Text = "something went wrong on DeepL's end while translating the text\r\n\r\nplease try again later";
                ClearWebpageInterface(false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while attempting to translate the webpage: {err}", ex.Message);
                LblState.Text = "something went wrong on our end while translating the webpage\r\n\r\nplease try again later";
                ClearWebpageInterface(false);
            }
            finally
            {
                LockInterface(false);

                // set focus to copy-clipbooard
                ActiveControl = BtnCopyClipboard;
            }
        }

        /// <summary>
        /// Clears notifications and the webpage's content
        /// </summary>
        /// <param name="clearStateLabel"></param>
        private void ClearWebpageInterface(bool clearStateLabel = true)
        {
            if (clearStateLabel)
            {
                LblState.Text = string.Empty;
                LblState.Visible = true;
            }

            WebView.NavigateToString(string.Empty);
        }

        /// <summary>
        /// Shows the dragdrop effect when hovering a file or text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UrlPage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;

            e.Effect = e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        /// <summary>
        /// Handles a dropped file or text, making sure it's supported and process it.
        /// </summary>
        /// <param name="e"></param>
        private void ProcessDrop(DragEventArgs e)
        {
            try
            {
                if (e.Data == null) return;

                // clear content
                ClearWebpageInterface();

                // reset detection
                ResetDetectedSourceLanguage();

                // clear url
                TbUrl.Text = string.Empty;

                // remove warning
                PbWarning.Visible = false;

                var value = string.Empty;
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    // simple text
                    value = (string)e.Data?.GetData(DataFormats.Text);

                    // check for empty
                    if (string.IsNullOrWhiteSpace(value)) return;

                    // is it an url?
                    if (!UrlManager.IsUrl(value) && !UrlManager.IsLocalOrNetworkFile(value))
                    {
                        LblState.Text = "you can only drop links to webpages here\r\n\r\nuse the text tab to translate text";
                        LblState.Visible = true;
                        return;
                    }

                    // enable auto detect
                    CbSourceLanguage.SelectedItem = Variables.SourceLanguages.GetEntry("AUTO DETECT");
                }
                else if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // file was dropped, fetch the relevant info
                    var files = (string[])e.Data?.GetData(DataFormats.FileDrop);
                    if (files == null) return;
                    if (!files.Any()) return;
                    var file = files.First();

                    // is it supported?
                    if (!DocumentManager.FileIsSupported(file, false, true))
                    {
                        LblState.Text = "only .html files are supported here\r\n\r\nfor other formats, use the 'documents' tab";
                        LblState.Visible = true;
                        return;
                    }

                    // and does it still exist?
                    if (!File.Exists(file))
                    {
                        LblState.Text = "sorry, the selected document doesn't exist (anymore)";
                        LblState.Visible = true;
                        return;
                    }

                    // yep, use it
                    value = file;
                }

                // set the value
                TbUrl.Text = value;

                // enable auto detect
                CbSourceLanguage.SelectedItem = Variables.SourceLanguages.GetEntry("AUTO DETECT");

                // select the translation button
                ActiveControl = BtnTranslate;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while processing dropped content: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Copies the current webview text to clipboard
        /// </summary>
        /// <param name="force"></param>
        private async void CopySourceToClipboard(bool force = false)
        {
            try
            {
                // copy the text
                var cleanText = await WebView.ExecuteScriptAsync("document.body.innerText");
                if (string.IsNullOrWhiteSpace(cleanText)) return;

                // clean it up
                cleanText = UrlManager.CleanText(cleanText.Trim());

                // copy it to the clipboard if not empty and configured as such
                if (string.IsNullOrWhiteSpace(cleanText) || (!force && !Variables.AppSettings.CopyTranslationToClipboard)) return;

                // prepare sta thread
                var clipboardThread = new Thread(new ThreadStart(delegate
                {
                    Clipboard.SetDataObject(cleanText, true, 10, 100);
                }));

                // set it
                clipboardThread.SetApartmentState(ApartmentState.STA);

                // go
                clipboardThread.Start();

                // notify the user
                LblClipboardCopied.Visible = true;

                // hide the notification after a bit
                _ = Task.Run(HideClipboardCopied);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while copying to clipboard: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Resets and hides the detected source language info
        /// </summary>
        private void ResetDetectedSourceLanguage()
        {
            if (IsDisposed) return;
            if (!IsHandleCreated) return;

            Invoke(new MethodInvoker(delegate
            {
                // reset detected
                LblDetectedInfo.Visible = false;
                LblDetected.Visible = false;
                LblDetected.Text = string.Empty;
            }));
        }

        /// <summary>
        /// Hides the 'copied to clipboard' text after three seconds.
        /// </summary>
        private async void HideClipboardCopied()
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                if (IsDisposed) return;
                if (!IsHandleCreated) return;

                LblClipboardCopied.Invoke(delegate { LblClipboardCopied.Visible = false; });
            }
            catch { }
        }

        /// <summary>
        /// Locks or unlocks the interface.
        /// </summary>
        /// <param name="lock"></param>
        private void LockInterface(bool @lock = true)
        {
            if (IsDisposed) return;
            if (!IsHandleCreated) return;

            Invoke(new MethodInvoker(delegate
            {
                TbUrl.Enabled = !@lock;
                CbSourceLanguage.Enabled = !@lock;
                CbTargetLanguage.Enabled = !@lock;
                BtnTranslate.Enabled = !@lock;
                BtnCopyClipboard.Enabled = !@lock;
                BtnClean.Enabled = !@lock;
                BtnPrint.Enabled = !@lock;
                BtnSave.Enabled = !@lock;
                BtnOpenInBrowser.Enabled = !@lock;
            }));
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            // clear url
            TbUrl.Text = string.Empty;

            // clear cost
            LblCost.Text = SubscriptionManager.BaseCostNotation();
            LblCharacters.Text = "0";

            // clear webpage
            ClearWebpageInterface();

            // remove warning
            PbWarning.Visible = false;

            // reset detected source language
            ResetDetectedSourceLanguage();

            // optionally set last source language
            if (Variables.AppSettings.StoreLastUsedSourceLanguage && !string.IsNullOrEmpty(Variables.AppSettings.LastSourceLanguage))
            {
                CbSourceLanguage.SelectedItem = Variables.SourceLanguages.GetKeyByEntry(Variables.AppSettings.LastSourceLanguage);
            }

            // optionally set last target language
            if (Variables.AppSettings.StoreLastUsedTargetLanguage && !string.IsNullOrEmpty(Variables.AppSettings.LastTargetLanguage))
            {
                CbTargetLanguage.SelectedItem = Variables.TargetLanguages.GetKeyByEntry(Variables.AppSettings.LastTargetLanguage);
            }

            // focus source textbox
            ActiveControl = TbUrl;
        }

        private void PbWarning_Click(object sender, EventArgs e)
        {
            var warning = new StringBuilder();
            warning.AppendLine("Unfortunately, it's not clear what part of your website contains the relevant text.");
            warning.AppendLine("");
            warning.AppendLine("This can happen on pages with lots of links but no actual articles,");
            warning.AppendLine("on image-only pages, or just because the page uses non-standard code.");
            warning.AppendLine("");
            warning.AppendLine("Your website is therefore shown as-is.");

            MessageBoxAdv.Show(this, warning.ToString(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TbUrl_KeyUp(object sender, KeyEventArgs e)
        {
            // start translating on enter
            if (e.KeyCode == Keys.Enter) ExecuteTranslation();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LockInterface();

                using var dialog = new OpenFileDialog();
                dialog.CheckFileExists = false;
                dialog.Multiselect = false;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "PDF (*.pdf)|*.pdf";

                var result = dialog.ShowDialog();
                if (result != DialogResult.OK) return;

                var printed = await WebView.CoreWebView2.PrintToPdfAsync(dialog.FileName);
                if (!printed)
                {
                    MessageBoxAdv.Show(this, "Something went wrong while saving the page to pdf.\r\n\r\nTry using the print method with Window's pdf printer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var q = MessageBoxAdv.Show(this, "Page succesfully saved to pdf!\r\n\nClick 'ok' to open its folder.", Variables.MessageBoxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (q != DialogResult.OK) return;

                var argument = "/select, \"" + dialog.FileName + "\"";
                Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while saving to pdf: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong while saving the page to pdf.\r\n\r\nTry using the print method with Window's pdf printer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LockInterface(false);
            }
        }

        private async void BtnOpenInBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                LockInterface();

                var source = await WebView.ExecuteScriptAsync("document.documentElement.outerHTML;");
                source = JsonConvert.DeserializeObject<string>(source);

                if (string.IsNullOrEmpty(source)) return;

                // make sure the cache folder exists
                if (!Directory.Exists(Variables.WebPagesCachePath)) Directory.CreateDirectory(Variables.WebPagesCachePath);

                // prepare a temp file
                var tempFile = Path.Combine(Variables.WebPagesCachePath, $"{Guid.NewGuid().ToString().Replace("-", "")}.html");

                // write the source to it
                await File.WriteAllTextAsync(tempFile, source);

                // open in user's default browser
                HelperFunctions.LaunchUrl(tempFile);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while opening in browser: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong while opening the page in your browser.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LockInterface(false);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e) => WebView.CoreWebView2.ShowPrintUI(CoreWebView2PrintDialogKind.Browser);

        private void CoreWebView2OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) => CopySourceToClipboard();

        private void BtnTranslate_Click(object sender, EventArgs e) => ExecuteTranslation();

        private void UrlPage_DragDrop(object sender, DragEventArgs e) => ProcessDrop(e);

        private void WebViewOnDragDrop(object sender, DragEventArgs e) => ProcessDrop(e);

        private void CbSourceLanguage_SelectedValueChanged(object sender, EventArgs e) => ResetDetectedSourceLanguage();

        private void BtnCopyClipboard_Click(object sender, EventArgs e) => CopySourceToClipboard(true);
    }
}
