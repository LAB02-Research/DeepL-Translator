﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using DeepL;
using DeepL.Model;
using DeepLClient.Enums;
using DeepLClient.Forms;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools.Win32API;

namespace DeepLClient.Controls
{
    public partial class DocumentsPage : UserControl
    {
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

        private async void DocumentsPage_Load(object sender, EventArgs e)
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
            var processed = await ProcessSelectedDocument(dialog.FileName);
            if (!processed) return;

            TbSourceDocument.Text = dialog.FileName;
            TbSourceDocument.SelectionStart = TbSourceDocument.Text.Length;
        }

        /// <summary>
        /// Processes the selected file, making sure it's supported, counting the content and asking the user whether they're sure.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private async Task<bool> ProcessSelectedDocument(string file)
        {
            try
            {
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
                var characterCount = 0L;
                switch (docType)
                {
                    case DocumentType.Word:
                        characterCount = await Task.Run(() => DocumentManager.GetDocCharacterCount(file));
                        break;
                    case DocumentType.PowerPoint:
                        characterCount = await Task.Run(() => DocumentManager.GetPowerPointCharacterCount(file));
                        break;
                    case DocumentType.PDF:
                        characterCount = await Task.Run(() => DocumentManager.GetPdfCharacterCount(file));
                        break;
                    case DocumentType.Text:
                        characterCount = await Task.Run(() => DocumentManager.GetTxtCharacterCount(file));
                        break;
                    case DocumentType.HTML:
                        characterCount = await Task.Run(() => DocumentManager.GetHtmlCharacterCount(file));
                        break;
                }

                // ask the user if they're sure
                using var confirmDoc = new ConfirmDocument(characterCount, AccountManager.CalculateCost(characterCount), Path.GetFileName(file), docType == DocumentType.Text);
                var res = confirmDoc.ShowDialog();

                if (res != DialogResult.OK)
                {
                    LblState.Text = string.Empty;
                    return false;
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
        }

        /// <summary>
        /// Executes the translation of the document.
        /// </summary>
        private async void ExecuteTranslation()
        {
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
                DocumentStatus state;

                // wait for DeepL to finish translating
                var dotCount = 2;
                while (true)
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
                            LblState.Text = "translation failed.";
                            break;
                    }

                    // wait a bit
                    await Task.Delay(500);
                }

                // did we succeed?
                if (!state.Ok)
                {
                    // nope
                    LblState.Text = $"translation failed: {state.ErrorMessage}";
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
                    LblState.Text = "something went wrong: file not found after download.";
                    return;
                }

                // set some info
                if (state.BilledCharacters != null)
                {
                    var billedCharacters = Convert.ToDouble(state.BilledCharacters);
                    LblState.Text = $"translation complete!\r\n\r\nthe document has been billed for {billedCharacters} characters, costing {AccountManager.CalculateCost(billedCharacters)}.";
                }
                else LblState.Text = "translation complete!";

                // store the selected languages
                StoreSelectedLanguages();

                // set the translated doc
                TbTranslatedDocument.Text = targetFile;
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Connection error while translating the document: {err}", ex.Message);
                LblState.Text = "unable to establish a connection to DeepL's servers.\r\n\r\nplease try again later.";
            }
            catch (DocumentTranslationException ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Error while translating the document: {err}", ex.Message);
                LblState.Text = "something went wrong on DeepL's end while translating the document.";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DOCUMENT] Error while attempting to translate the document: {err}", ex.Message);
                LblState.Text = "something went wrong on our end while translating the document.";
            }
            finally
            {
                LockInterface(false);
            }
        }

        /// <summary>
        /// Gets and stores the selected languages for both source and target.
        /// </summary>
        private void StoreSelectedLanguages()
        {
            // get source language
            string sourceLanguage = null;
            if (CbSourceLanguage.SelectedItem != null)
            {
                var item = (KeyValuePair<string, string>)CbSourceLanguage.SelectedItem;
                sourceLanguage = item.Value;
            }

            if (sourceLanguage != null)
            {
                // store last used
                Variables.AppSettings.LastSourceLanguage = sourceLanguage;
            }

            // get target language
            string targetLanguage = null;
            if (CbTargetLanguage.SelectedItem != null)
            {
                var item = (KeyValuePair<string, string>)CbTargetLanguage.SelectedItem;
                targetLanguage = item.Value;
            }

            if (targetLanguage != null)
            {
                // store last used
                Variables.AppSettings.LastTargetLanguage = targetLanguage;
            }

            // store them
            SettingsManager.Store();

            // done
        }

        /// <summary>
        /// Shows or hides the formality dropbox, depending on whether the selected language supports it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTargetLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            string targetLanguage = null;
            if (CbTargetLanguage.SelectedItem != null)
            {
                var item = (KeyValuePair<string, string>)CbTargetLanguage.SelectedItem;
                targetLanguage = item.Value;
            }

            if (targetLanguage == null)
            {
                // notify
                return;
            }
            
            // check formality supported
            var supported = Variables.FormalitySupportedLanguages.Contains(targetLanguage);
            CbTargetFormality.Visible = supported;
            LblTargetFormality.Visible = supported;
            LblFormalityInfo.Visible = supported;
        }

        /// <summary>
        /// Opens the translated document's folder in Explorer, selecting the document.
        /// </summary>
        private void OpenTranslatedDocumentFolder()
        {
            if (string.IsNullOrEmpty(TbTranslatedDocument.Text)) return;

            var argument = "/select, \"" + TbTranslatedDocument.Text + "\"";
            Process.Start("explorer.exe", argument);
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
            var files = (string[])e.Data?.GetData(DataFormats.FileDrop);
            if (files == null) return;
            if (!files.Any()) return;

            var file = files.First();
            if (!DocumentManager.FileIsSupported(file))
            {
                MessageBoxAdv.Show(this, "The selected filetype is unsupported.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // process selected file
            var processed = await ProcessSelectedDocument(file);
            if (!processed) return;

            TbSourceDocument.Text = file;
            TbSourceDocument.SelectionStart = TbSourceDocument.Text.Length;
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
                TbOpenTranslatedFolder.Enabled = !@lock;
                TbTranslatedDocument.Enabled = !@lock;
            }));
        }

        private void LblFormalityInfo_Click(object sender, EventArgs e)
        {
            MessageBoxAdv.Show(this, HelperFunctions.GetFormalityExplanation(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTranslate_Click(object sender, EventArgs e) => ExecuteTranslation();

        private void TbSourceDocument_DoubleClick(object sender, EventArgs e) => SelectSourceFile();

        private void TbTranslatedDocument_DoubleClick(object sender, EventArgs e) => OpenTranslatedDocumentFolder();

        private void BtnBrowse_Click(object sender, EventArgs e) => SelectSourceFile();

        private void TbOpenTranslatedFolder_Click(object sender, EventArgs e) => OpenTranslatedDocumentFolder();
    }
}
