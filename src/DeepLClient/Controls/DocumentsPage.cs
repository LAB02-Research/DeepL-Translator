using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DeepL;
using DeepL.Model;
using DeepLClient.Enums;
using DeepLClient.Forms;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;

namespace DeepLClient.Controls
{
    public partial class DocumentsPage : UserControl
    {
        private bool _isInitialised;

        public DocumentsPage()
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

            CbTargetFormality.DrawItem += ComboBoxTheme.DrawDictionaryIntStringItem;
        }

        private void DocumentsPage_Load(object sender, EventArgs e)
        {
            if (!_isInitialised) _ = InitializeAsync();
        }

        /// <summary>
        /// Initialises the interface
        /// </summary>
        /// <returns></returns>
        private async Task<bool> InitializeAsync()
        {
            try
            {
                // wait for DeepL to load
                while (!DeepLManager.IsInitialised) await Task.Delay(50);

                // set formalities
                CbTargetFormality.DataSource = new BindingSource(Variables.Formalities, null);

                // set source languages
                CbSourceLanguage.DataSource = new BindingSource(Variables.SourceLanguages, null);

                // set target languages
                CbTargetLanguage.DataSource = new BindingSource(Variables.TargetLanguages, null);

                // load default formality
                CbTargetFormality.SelectedItem = Variables.Formalities.GetEntry((int)Variables.AppSettings.DefaultFormality);

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

                // done
                return true;
            }
            catch (Exception ex)
            {
                LockInterface();
                LblState.Text = "something went wrong trying to initialise the document translator\r\n\r\ncheck the logs and contact the developer for help";
                Log.Fatal(ex, "[DOCUMENT] Unable to initialize: {err}", ex.Message);
                return false;
            }
            finally
            {
                _isInitialised = true;
            }
        }

        /// <summary>
        /// Shows a OpenFileDialog and allows the user to select a document, filtering only allowed filetypes and processes the selected file.
        /// </summary>
        private async void SelectSourceFile()
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = DocumentManager.GetFileTypeFilters();

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            // process selected file
            var processed = await ProcessSelectedDocumentAsync(dialog.FileName);
            if (!processed) return;

            TbSourceDocument.Text = dialog.FileName;
            TbSourceDocument.SelectionStart = TbSourceDocument.Text.Length;

            ActiveControl = BtnTranslate;
        }

        /// <summary>
        /// Processes the selected file, making sure it's supported, counting the content and asking the user whether they're sure.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal async Task<bool> ProcessSelectedDocumentAsync(string file)
        {
            if (!_isInitialised)
            {
                var initialised = await InitializeAsync();
                if (!initialised) return false;
            }

            try
            {
                // lock the interface
                LockInterface();

                // notify the user
                LblState.Text = "checking the selected document ..";

                // does it exist?
                if (!File.Exists(file))
                {
                    MessageBoxAdv.Show(this, "The selected document doesn't exist (anymore).\r\n\r\nPlease select a new one.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LblState.Text = string.Empty;
                    return false;
                }

                // check the filetype
                var docType = await Task.Run(() => DocumentManager.GetFileDocumentType(file));
                if (docType == DocumentType.Unsupported)
                {
                    MessageBoxAdv.Show(this, "The selected filetype is unsupported.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LblState.Text = string.Empty;
                    return false;
                }

                // check its size
                var (tooLarge, sizeMB) = await Task.Run(() => DocumentManager.CheckDocumentSize(file));
                if (tooLarge)
                {
                    MessageBoxAdv.Show(this, $"The selected document is too large.\r\n\r\nIt's {sizeMB:N2} MB, while the max is {Variables.AppSettings.DocumentMaxSizeMB} MB.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LblState.Text = string.Empty;
                    return false;
                }

                // get the character count
                var characterCount = await DocumentManager.GetDocumentCharacterCountAsync(docType, file);

                // do we have enough chars left?
                if (await SubscriptionManager.CharactersWillExceedLimitAsync(characterCount, true))
                {
                    using var limit = new LimitExceeded(characterCount, true);
                    var ignoreLimit = limit.ShowDialog();
                    if (ignoreLimit != DialogResult.OK)
                    {
                        LblState.Text = string.Empty;
                        return false;
                    }
                }
                else
                {
                    // yep, ask the user if they're sure
                    using var confirmDoc = new ConfirmDocument(characterCount, Path.GetFileName(file), docType == DocumentType.Text);
                    var confirmed = confirmDoc.ShowDialog();
                    if (confirmed != DialogResult.OK)
                    {
                        LblState.Text = string.Empty;
                        return false;
                    }
                }

                // done
                LblState.Text = "document ready, press the translate button to begin";
                if (sizeMB > 5) LblState.Text = $"{LblState.Text}\r\n\r\nnote: the document is quite large ({sizeMB:N0} MB), it might take a while to process";
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Error while checking document '{doc}': {err}", file, ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong while checking the document.\r\n\r\nPlease check the logs and try again.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblState.Text = string.Empty;
                return false;
            }
            finally
            {
                LockInterface(false);

                // set focus to translate button
                ActiveControl = BtnTranslate;
            }
        }

        /// <summary>
        /// Executes the translation of the document.
        /// </summary>
        internal async void ExecuteTranslation()
        {
            if (!_isInitialised)
            {
                var initialised = await InitializeAsync();
                if (!initialised) return;
            }

            try
            {
                // lock the interface
                LockInterface();

                // check the source file
                var file = TbSourceDocument.Text;
                if (string.IsNullOrEmpty(file))
                {
                    LblState.Text = string.Empty;
                    return;
                }

                if (!File.Exists(file))
                {
                    MessageBoxAdv.Show(this, "The selected document doesn't exist (anymore).\r\n\r\nPlease select a new one.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LblState.Text = string.Empty;
                    return;
                }

                // set the stage
                TbTranslatedDocument.Text = string.Empty;
                LblState.Text = "preparing the document for translation ..";

                // check the size
                var docSize = DocumentManager.GetDocumentSizeMB(file);
                if (docSize > 5) LblState.Text = $"{LblState.Text}\r\n\r\nnote: the document is quite large ({docSize:N0} MB), it might take a while to process";

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
                    MessageBoxAdv.Show(this, "Please select a valid target language.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LblState.Text = string.Empty;
                    return;
                }

                // prepare the translated file
                var path = Path.GetDirectoryName(file);
                var filename = Path.GetFileNameWithoutExtension(file);
                var ext = Path.GetExtension(file);
                var targetFile = Path.Combine(path!, $"{filename}_{targetLanguage}{ext}");

                // check if it's already there
                if (File.Exists(targetFile))
                {
                    var confirm = MessageBoxAdv.Show(this, $"The proposed target file already exists:\r\n\r\n{targetFile}\r\n\r\nDo you want to overwrite it?", Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (confirm != DialogResult.Yes)
                    {
                        LblState.Text = string.Empty;
                        return;
                    }
                }

                // prepare the document handle
                DocumentHandle documentHandle;

                // is formality enabled?
                var enableFormality = Variables.FormalitySupportedLanguages.Contains(targetLanguage);
                if (enableFormality)
                {
                    // yep, fetch the selected formality
                    var formality = Formality.Default;
                    if (CbTargetFormality.SelectedItem != null)
                    {
                        var selectedFormality = (KeyValuePair<int, string>)CbTargetFormality.SelectedItem;
                        formality = (Formality)selectedFormality.Key;
                    }

                    // upload the document to DeepL for translation
                    documentHandle = await Variables.Translator.TranslateDocumentUploadAsync(
                        new FileInfo(file),
                        sourceLanguage,
                        targetLanguage,
                        new DocumentTranslateOptions { Formality = formality });
                }
                else
                {
                    // nope, upload the document as-is to DeepL for translation
                    documentHandle = await Variables.Translator.TranslateDocumentUploadAsync(
                        new FileInfo(file),
                        sourceLanguage,
                        targetLanguage);
                }

                // prepare the translation state
                DocumentStatus state = null;

                // wait for DeepL to finish translating
                var dotCount = 2;
                var awaitUpload = true;
                while (awaitUpload)
                {
                    // get the current state
                    state = await Variables.Translator.TranslateDocumentStatusAsync(documentHandle);

                    // done?
                    if (state.Done) break;

                    // prepare our dots
                    var dotStr = string.Empty;
                    switch (dotCount)
                    {
                        case 1:
                            dotStr = ".";
                            dotCount++;
                            break;

                        case 2:
                            dotStr = "..";
                            dotCount++;
                            break;

                        case 3:
                            dotStr = "...";
                            dotCount = 1;
                            break;
                    }

                    // show the relevant state
                    switch (state.Status)
                    {
                        case DocumentStatus.StatusCode.Queued:
                            LblState.Text = $"document queued for translation {dotStr}";
                            break;

                        case DocumentStatus.StatusCode.Translating:
                            if (state.SecondsRemaining == null) LblState.Text = $"translating {dotStr}";
                            else
                            {
                                var seconds = state.SecondsRemaining;
                                if (seconds > 2100000000) LblState.Text = $"translating {dotStr}"; // weird count that's sometimes returned ..
                                else
                                {
                                    if (seconds < 0) seconds = 0;
                                    var secondStr = seconds == 1 ? "second" : "seconds";
                                    LblState.Text = $"translating ({seconds} {secondStr} remaining) {dotStr}";
                                }
                            }
                            break;

                        case DocumentStatus.StatusCode.Done:
                            LblState.Text = "document translated!";
                            break;

                        case DocumentStatus.StatusCode.Error:
                            LblState.Text = "translation failed";
                            awaitUpload = false;
                            break;
                    }

                    // wait a bit
                    await Task.Delay(500);
                }

                // did we succeed?
                if (!state.Ok || state.Status == DocumentStatus.StatusCode.Error)
                {
                    // nope
                    // error message?
                    if (string.IsNullOrWhiteSpace(state.ErrorMessage))
                    {
                        LblState.Text = "translation failed:\r\n\r\nDeepL provided no reason :(";
                        return;
                    }

                    // yep, first check for 'equal language'
                    if (state.ErrorMessage.Contains("are equal"))
                    {
                        LblState.Text = "translation failed:\r\n\r\nsource and target language are equal";
                        return;
                    }

                    // unknown
                    LblState.Text = $"translation failed:\r\n\r\n{state.ErrorMessage}";
                    return;
                }

                // wait a bit
                await Task.Delay(250);

                // yep, download the translated document
                LblState.Text = "downloading the translated document ..";
                await Variables.Translator.TranslateDocumentDownloadAsync(documentHandle, new FileInfo(targetFile));

                // check if it's there
                if (!File.Exists(targetFile))
                {
                    LblState.Text = "something went wrong:\r\n\r\nfile not found after download";
                    return;
                }

                // set some info
                if (state.BilledCharacters != null)
                {
                    var billedCharacters = Convert.ToDouble(state.BilledCharacters);
                    LblState.Text = SubscriptionManager.UsingFreeSubscription()
                    ? $"translation complete!\r\n\r\nthe document has been billed for {billedCharacters} characters\r\nyou're on a free subscription, so no costs"
                    : $"translation complete!\r\n\r\nthe document has been billed for {billedCharacters} characters, costing {SubscriptionManager.CalculateCost(billedCharacters)}.";
                }
                else LblState.Text = "translation complete!";

                // store the selected languages
                SettingsManager.StoreSelectedLanguages(CbSourceLanguage, CbTargetLanguage);

                // set the translated doc
                TbTranslatedDocument.Text = targetFile;

                // note: doesn't look like DeepL provides the detected source language value?
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Connection error while translating the document: {err}", ex.Message);
                LblState.Text = "unable to establish a connection to DeepL's servers\r\n\r\nplease try again later";
            }
            catch (DocumentTranslationException ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Error while translating the document: {err}", ex.Message);
                LblState.Text = "something went wrong on DeepL's end while translating the document";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Error while attempting to translate the document: {err}", ex.Message);
                LblState.Text = "something went wrong on our end while translating the document";
            }
            finally
            {
                LockInterface(false);

                // set focus to open-translated-folder button
                ActiveControl = BtnOpenTranslatedFolder;
            }
        }

        /// <summary>
        /// Shows or hides the formality dropbox, depending on whether the selected language supports it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTargetLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            // check formality supported
            var supported = DeepLManager.TargetLanguageSupportsFormality(CbTargetLanguage);
            CbTargetFormality.Visible = supported;
            LblTargetFormality.Visible = supported;
            LblFormalityInfo.Visible = supported;
        }

        /// <summary>
        /// Shows the dragdrop effect when hovering a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentsPage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        /// <summary>
        /// Handles a dropped file, making sure it's supported and process it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DocumentsPage_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // get filelist
                var files = (string[])e.Data?.GetData(DataFormats.FileDrop);
                if (files == null) return;
                if (!files.Any()) return;

                // we can only handle one
                var file = files.First();

                // do we support it?
                if (!DocumentManager.FileIsSupported(file))
                {
                    MessageBoxAdv.Show(this, "The selected filetype is unsupported.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // yep, process it
                var processed = await ProcessSelectedDocumentAsync(file);
                if (!processed) return;

                // all good
                TbSourceDocument.Text = file;
                TbSourceDocument.SelectionStart = TbSourceDocument.Text.Length;

                // enable auto detect
                CbSourceLanguage.SelectedItem = Variables.SourceLanguages.GetEntry("AUTO DETECT");

                // select the translation button
                ActiveControl = BtnTranslate;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Error while processing dropped document: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Locks or unlocks the interface.
        /// </summary>
        /// <param name="lock"></param>
        private void LockInterface(bool @lock = true)
        {
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                TbSourceDocument.Enabled = !@lock;
                BtnBrowse.Enabled = !@lock;
                CbSourceLanguage.Enabled = !@lock;
                CbTargetLanguage.Enabled = !@lock;
                CbTargetFormality.Enabled = !@lock;
                LblFormalityInfo.Enabled = !@lock;
                BtnTranslate.Enabled = !@lock;
                BtnOpenTranslatedFolder.Enabled = !@lock;
                TbTranslatedDocument.Enabled = !@lock;
                BtnClean.Enabled = !@lock;
            }));
        }

        private void LblFormalityInfo_Click(object sender, EventArgs e)
        {
            MessageBoxAdv.Show(this, HelperFunctions.GetFormalityExplanation(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            // clear docs
            TbSourceDocument.Text = string.Empty;
            TbTranslatedDocument.Text = string.Empty;

            // clear state info
            LblState.Text = string.Empty;

            // load default formality
            CbTargetFormality.SelectedItem = Variables.Formalities.GetEntry((int)Variables.AppSettings.DefaultFormality);

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
        }

        private void BtnTranslate_Click(object sender, EventArgs e) => ExecuteTranslation();

        private void TbSourceDocument_DoubleClick(object sender, EventArgs e) => SelectSourceFile();

        private void TbTranslatedDocument_DoubleClick(object sender, EventArgs e) => HelperFunctions.OpenFileInExplorer(TbTranslatedDocument.Text);

        private void BtnBrowse_Click(object sender, EventArgs e) => SelectSourceFile();

        private void BtnOpenTranslatedFolder_Click(object sender, EventArgs e) => HelperFunctions.OpenFileInExplorer(TbTranslatedDocument.Text);
    }
}
