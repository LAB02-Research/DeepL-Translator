using DeepLClient.Models;
using Newtonsoft.Json;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class SettingsManager
    {
        /// <summary>
        /// Load the stored config, or save a default one
        /// </summary>
        /// <returns></returns>
        internal static bool Load()
        {
            try
            {
                // check if there's config found
                if (!Directory.Exists(Variables.ConfigPath) || !File.Exists(Variables.AppSettingsFile))
                {
                    return StoreDefault();
                }

                // yep, load it
                var settingsStr = File.ReadAllText(Variables.AppSettingsFile);

                // content?
                if (string.IsNullOrWhiteSpace(settingsStr))
                {
                    Log.Warning("[SETTINGS] Config file empty");
                    return StoreDefault();
                }

                // try to parse
                Variables.AppSettings = JsonConvert.DeserializeObject<AppSettings>(settingsStr);
                if (Variables.AppSettings == null)
                {
                    Log.Error("[SETTINGS] Parsing config returned a null object");
                    return false;
                }

                // done
                Log.Information("[SETTINGS] Config loaded");
                return true;
            }
            catch (JsonException ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error parsing the config: {err}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error loading: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Store the current config
        /// </summary>
        /// <returns></returns>
        internal static bool Store()
        {
            try
            {
                // check the path
                if (!Directory.Exists(Variables.ConfigPath)) Directory.CreateDirectory(Variables.ConfigPath);

                // store values
                var settings = JsonConvert.SerializeObject(Variables.AppSettings, Formatting.Indented);
                File.WriteAllText(Variables.AppSettingsFile, settings);

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing config: {err}", ex.Message);
                return false;
            }
        }

        private static bool StoreDefault()
        {
            try
            {
                // check the path
                if (!Directory.Exists(Variables.ConfigPath)) Directory.CreateDirectory(Variables.ConfigPath);

                // set default
                Variables.AppSettings = new AppSettings();

                // store values
                var settings = JsonConvert.SerializeObject(Variables.AppSettings, Formatting.Indented);
                File.WriteAllText(Variables.AppSettingsFile, settings);

                // done
                Log.Information("[SETTINGS] Default settings stored");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing default: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stores the selected languages
        /// </summary>
        /// <param name="selectedSourceLanguage"></param>
        /// <param name="selectedTargetLanguage"></param>
        internal static void StoreSelectedLanguages(ComboBox selectedSourceLanguage, ComboBox selectedTargetLanguage)
        {
            try
            {
                // get source language
                string sourceLanguage = null;
                if (selectedSourceLanguage.SelectedItem != null)
                {
                    var item = (KeyValuePair<string, string>)selectedSourceLanguage.SelectedItem;
                    sourceLanguage = item.Value;
                }

                if (sourceLanguage != null)
                {
                    // store last used
                    Variables.AppSettings.LastSourceLanguage = sourceLanguage;
                }

                // get target language
                string targetLanguage = null;
                if (selectedTargetLanguage.SelectedItem != null)
                {
                    var item = (KeyValuePair<string, string>)selectedTargetLanguage.SelectedItem;
                    targetLanguage = item.Value;
                }

                if (targetLanguage != null)
                {
                    // store last used
                    Variables.AppSettings.LastTargetLanguage = targetLanguage;
                }

                // store them
                Store();

                // done
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing selected languages: {err}", ex.Message);
            }
        }
    }
}
