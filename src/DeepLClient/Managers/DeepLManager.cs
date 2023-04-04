using DeepL;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class DeepLManager
    {
        internal static bool IsInitialised { get; private set; }

        /// <summary>
        /// Establishes contact with DeepL's API and fetches all entities
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> InitializeAsync()
        {
            try
            {
                IsInitialised = false;
                
                // optionally dispose an old translator
                Variables.Translator?.Dispose();

                // prepare options
                var options = new TranslatorOptions {
                    appInfo =  new AppInfo { AppName = "DeepL Translator by LAB02 Research", AppVersion = Variables.Version }
                };

                // create translator
                Variables.Translator = new Translator(Variables.AppSettings.DeepLAPIKey, options);

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

                // load source languages
                Variables.SourceLanguages.Clear();
                var sourceLanguages = await Variables.Translator.GetSourceLanguagesAsync();
                foreach (var language in sourceLanguages) Variables.SourceLanguages.Add(language.Name, language.Code);

                // add auto detect option
                Variables.SourceLanguages.Add("AUTO DETECT", "AUTO DETECT");

                // load target languages
                Variables.TargetLanguages.Clear();
                var targetLanguages = await Variables.Translator.GetTargetLanguagesAsync();
                foreach (var language in targetLanguages)
                {
                    Variables.TargetLanguages.Add(language.Name, language.Code);
                    if (language.SupportsFormality) Variables.FormalitySupportedLanguages.Add(language.Code);
                }

                // done
                IsInitialised = true;
                return true;
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[DEEPL] Error trying to contact the DeepL server: {err}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DEEPL] Error initialising: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Returns whether the selected target language supports formality
        /// </summary>
        /// <param name="selectedTargetLanguage"></param>
        /// <returns></returns>
        internal static bool TargetLanguageSupportsFormality(ComboBox selectedTargetLanguage)
        {
            try
            {
                string targetLanguage = null;
                if (selectedTargetLanguage.SelectedItem != null)
                {
                    var item = (KeyValuePair<string, string>)selectedTargetLanguage.SelectedItem;
                    targetLanguage = item.Value;
                }

                if (targetLanguage == null) return false;

                // check formality supported
                return Variables.FormalitySupportedLanguages.Contains(targetLanguage);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DEEPL] Error determining whether target language supports formality: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Looks up the human readable language value for the provided language code
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        internal static string GetSourceLanguageByLanguageCode(string languageCode)
        {
            return Variables.SourceLanguages.FirstOrDefault(x => x.Value == languageCode, new KeyValuePair<string, string>(string.Empty, string.Empty)).Key;
        }
    }
}
