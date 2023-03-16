using DeepL;
using DeepL.Model;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using DeepLClient.Forms.Dialogs;

namespace DeepLClient.Controls
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    public partial class TextPage : UserControl
    {
        public TextPage()
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

        private async void TextPage_Load(object sender, EventArgs e)
        {
            // set cost info
            LblCost.Text = SubscriptionManager.BaseCostNotation();

            // activate source textbox
            ActiveControl = TbSource;

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

        private async void ExecuteTranslation()
        {
            try
            {
                // lock the interface
                LockInterface();

                // get the text
                var sourceText = TbSource.Text.Trim();

                // reset detection
                ResetDetectedSourceLanguage();

                // check it
                if (string.IsNullOrWhiteSpace(sourceText)) return;

                // do we have enough chars left?
                if (await SubscriptionManager.CharactersWillExceedLimitAsync(sourceText.Length))
                {
                    using var limit = new LimitExceeded(sourceText.Length);
                    var ignoreLimit = limit.ShowDialog();
                    if (ignoreLimit != DialogResult.OK) return;
                }

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
                    MessageBoxAdv2.Show("Please select a valid target language.", Variables.MessageBoxTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // prepare the translation
                TextResult translatedText;

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

                    // send the text to DeepL for translation
                    translatedText = await Variables.Translator.TranslateTextAsync(
                        sourceText,
                        sourceLanguage,
                        targetLanguage,
                        new TextTranslateOptions { Formality = formality });
                }
                else
                {
                    // nope, send the text as-is to DeepL for translation
                    translatedText = await Variables.Translator.TranslateTextAsync(
                        sourceText,
                        sourceLanguage,
                        targetLanguage);
                }

                // set the translated text
                TbTranslated.Text = translatedText.Text;

                // store the selected languages
                SettingsManager.StoreSelectedLanguages(CbSourceLanguage, CbTargetLanguage);

                // copy it to the clipbaord if configured
                CopyToClipboard();

                // is auto detect enabled?
                if (sourceLanguage != null) return;

                // yep, set the detected source language
                LblDetectedInfo.Visible = true;
                LblDetected.Visible = true;
                LblDetected.Text = DeepLManager.GetSourceLanguageByLanguageCode(translatedText.DetectedSourceLanguageCode);
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[TEXT] Connection error while translating the text: {err}", ex.Message);
                MessageBoxAdv2.Show("Unable to establish a connection to DeepL's servers.\r\n\r\nPlease try again later.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DocumentTranslationException ex)
            {
                Log.Fatal(ex, "[TEXT] Error while translating the text: {err}", ex.Message);
                MessageBoxAdv2.Show("Something went wrong on DeepL's end while translating the text.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEXT] Error while attempting to translate the text: {err}", ex.Message);
                MessageBoxAdv2.Show("Something went wrong on our end while translating the text.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LockInterface(false);

                // set focus to copy-clipbooard
                ActiveControl = BtnCopyClipboard;
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
        /// Show the amount of characters and their estimated cost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbSource_TextChanged(object sender, EventArgs e)
        {
            LblCharacters.Text = TbSource.Text.Length.ToString();
            LblCost.Text = SubscriptionManager.CalculateCost(TbSource.Text.Length, false);
        }

        /// <summary>
        /// Shows the dragdrop effect when hovering a file or text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextPage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;

            e.Effect = e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        /// <summary>
        /// Handles a dropped file or text, making sure it's supported and process it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextPage_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data == null) return;
                var text = string.Empty;

                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    // simple text, use as-is
                    text = (string)e.Data?.GetData(DataFormats.Text);
                }
                else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // file was dropped, fetch the relevant info
                    var files = (string[])e.Data?.GetData(DataFormats.FileDrop);
                    if (files == null) return;
                    if (!files.Any()) return;
                    var file = files.First();

                    // is it supported?
                    if (!DocumentManager.FileIsSupported(file, true))
                    {
                        MessageBoxAdv2.Show("Only .txt documents are supported here.\r\n\r\nFor other formats, use the 'documents' tab.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // and does it still exist?
                    if (!File.Exists(file))
                    {
                        MessageBoxAdv2.Show("The selected document doesn't exist (anymore).", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    // yep, use its content
                    text = File.ReadAllText(file);
                }

                // check for empty
                if (string.IsNullOrWhiteSpace(text)) return;

                // set the text
                TbSource.Text = text.Trim();

                // enable auto detect
                CbSourceLanguage.SelectedItem = Variables.SourceLanguages.GetEntry("AUTO DETECT");

                // select the translation button
                ActiveControl = BtnTranslate;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEXT] Error while processing dropped content: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Copies the translated text text to clipboard
        /// </summary>
        /// <param name="force"></param>
        private void CopyToClipboard(bool force = false)
        {
            try
            {
                // copy the text
                var cleanText = TbTranslated.Text.Trim();

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
                Log.Fatal(ex, "[TEXT] Error while copying to clipboard: {err}", ex.Message);
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
                TbSource.Enabled = !@lock;
                TbTranslated.Enabled = !@lock;
                CbSourceLanguage.Enabled = !@lock;
                CbTargetLanguage.Enabled = !@lock;
                CbTargetFormality.Enabled = !@lock;
                LblFormalityInfo.Enabled = !@lock;
                BtnTranslate.Enabled = !@lock;
                BtnCopyClipboard.Enabled = !@lock;
                BtnClean.Enabled = !@lock;
                BtnSave.Enabled = !@lock;
                BtnPrint.Enabled = !@lock;
            }));
        }

        private void LblFormalityInfo_Click(object sender, EventArgs e)
        {
            MessageBoxAdv2.Show(HelperFunctions.GetFormalityExplanation(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TbSource_KeyDown(object sender, KeyEventArgs e)
        {
            // execute translation on ctrl + enter
            if (!e.Control || e.KeyCode != Keys.Enter) return;

            // ignore the enter
            e.Handled = true;
            e.SuppressKeyPress = true;

            // start translating
            ExecuteTranslation();
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            // clear the text (will also clear costs)
            TbSource.Text = string.Empty;
            TbTranslated.Text = string.Empty;

            // reset detected source language
            ResetDetectedSourceLanguage();

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

            // focus source textbox
            ActiveControl = TbSource;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TbTranslated.Text)) return;

                LockInterface();

                using var dialog = new OpenFileDialog();
                dialog.CheckFileExists = false;
                dialog.Multiselect = false;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "Plain text (*.txt)|*.txt";

                var result = dialog.ShowDialog();
                if (result != DialogResult.OK) return;

                File.WriteAllText(dialog.FileName, TbTranslated.Text);

                var q = MessageBoxAdv2.Show("Page succesfully saved as a text file!\r\n\nClick 'ok' to open its folder.", Variables.MessageBoxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (q != DialogResult.OK) return;

                HelperFunctions.OpenFileInExplorer(dialog.FileName);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while saving to pdf: {err}", ex.Message);
                MessageBoxAdv2.Show("Something went wrong while saving the page to pdf.\r\n\r\nTry using the print method with Window's pdf printer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LockInterface(false);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TbTranslated.Text)) return;

                // lock the interface
                LockInterface();

                // get the printer settings
                using var printDialog = new PrintDialog();
                var dialogResult = printDialog.ShowDialog();
                if (dialogResult != DialogResult.OK) return;

                // print the doc
                var result = PrintFunctions.PrintText(TbTranslated.Text, printDialog.PrinterSettings);

                // done
                if (result) MessageBoxAdv2.Show("The translated text has been sent to your printer.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBoxAdv2.Show("Something went wrong when trying to print the translated text.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Error while trying to print: {err}", ex.Message);
                MessageBoxAdv2.Show("Something went wrong while trying to print.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LockInterface(false);
            }
        }

        private void BtnCopyClipboard_Click(object sender, EventArgs e) => CopyToClipboard(true);

        private void BtnTranslate_Click(object sender, EventArgs e) => ExecuteTranslation();

        private void CbSourceLanguage_SelectedValueChanged(object sender, EventArgs e) => ResetDetectedSourceLanguage();
    }
}
