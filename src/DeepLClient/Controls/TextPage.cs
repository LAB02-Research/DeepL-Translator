using DeepL;
using DeepL.Model;
using DeepLClient.Functions;
using DeepLClient.Managers;
using Serilog;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools.Win32API;

namespace DeepLClient.Controls
{
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

                // check it
                if (string.IsNullOrWhiteSpace(sourceText)) return;

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
                    MessageBoxAdv.Show(this, "Please select a valid target language.", Variables.MessageBoxTitle,
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
                StoreSelectedLanguages();

                // copy it to the clipbaord if configured
                if (Variables.AppSettings.CopyTranslationToClipboard && !string.IsNullOrWhiteSpace(translatedText.Text))
                {
                    Clipboard.SetText(translatedText.Text);
                    LblClipboardCopied.Visible = true;
                    _ = Task.Run(HideClipboardCopied);
                }

                // is auto detect enabled?
                if (sourceLanguage != null) return;

                // yep, set the detected source language
                LblDetectedInfo.Visible = true;
                LblDetected.Visible = true;
                LblDetected.Text = Variables.SourceLanguages.First(x => x.Value == translatedText.DetectedSourceLanguageCode).Key;
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[TEXT] Connection error while translating the document: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Unable to establish a connection to DeepL's servers.\r\n\r\nPlease try again later.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DocumentTranslationException ex)
            {
                Log.Fatal(ex, "[TEXT] Error while translating the document: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong on DeepL's end while translating the text.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEXT] Error while attempting to translate the document: {err}", ex.Message);
                MessageBoxAdv.Show(this, "Something went wrong on our end while translating the text.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Show the amount of characters and their estimated cost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbSource_TextChanged(object sender, EventArgs e)
        {
            LblCharacters.Text = TbSource.Text.Length.ToString();
            LblCost.Text = AccountManager.CalculateCost(TbSource.Text.Length, false);
        }

        /// <summary>
        /// Hide the auto detected language info when a new source language is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbSourceLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            // reset detected
            LblDetectedInfo.Visible = false;
            LblDetected.Visible = false;
            LblDetected.Text = string.Empty;
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
            if (e.Data == null) return;
            var text = string.Empty;

            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                // simple text
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
                    MessageBoxAdv.Show(this, "Only .txt documents are supported here.\r\n\r\nFor other formats, use the 'documents' tab.", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // and does it still exist?
                if (!File.Exists(file))
                {
                    MessageBoxAdv.Show(this, "The selected document doesn't exist (anymore).", Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        /// <summary>
        /// Copy the translated text (if any) to the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCopyClipboard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbTranslated.Text)) return;

            Clipboard.SetText(TbTranslated.Text);
            LblClipboardCopied.Visible = true;
            _ = Task.Run(HideClipboardCopied);
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
                LblClipboardCopied.Invoke(delegate { LblClipboardCopied.Visible = false; });
            }
            catch
            {
                // best effort
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
                TbSource.Enabled = !@lock;
                TbTranslated.Enabled = !@lock;
                CbSourceLanguage.Enabled = !@lock;
                CbTargetLanguage.Enabled = !@lock;
                CbTargetFormality.Enabled = !@lock;
                LblFormalityInfo.Enabled = !@lock;
                BtnTranslate.Enabled = !@lock;
                BtnCopyClipboard.Enabled = !@lock;
            }));
        }

        private void LblFormalityInfo_Click(object sender, EventArgs e)
        {
            MessageBoxAdv.Show(this, HelperFunctions.GetFormalityExplanation(), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnTranslate_Click(object sender, EventArgs e) => ExecuteTranslation();
    }
}
