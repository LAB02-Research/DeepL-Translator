using DeepL;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class DeepLManager
    {
        internal static bool IsInitialised { get; private set; }

        internal static async Task<(bool result, string error)> Initialise()
        {
            try
            {
                IsInitialised = false;

                // load translator
                if (Variables.Translator != null) Variables.Translator.Dispose();
                Variables.Translator = new Translator(Variables.AppSettings.DeepLAPIKey);

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
                return (true, string.Empty);
            }
            catch (ConnectionException ex)
            {
                Log.Fatal(ex, "[DEEPL] Error trying to contact the DeepL server: {err}", ex.Message);
                return (false, ex.Message);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DEEPL] Error initialising: {err}", ex.Message);
                return (false, ex.Message);
            }
        }
    }
}
