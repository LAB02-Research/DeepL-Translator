using System.Globalization;
using DeepLClient.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class SettingsManager
    {
        /// <summary>
        /// Load the stored app settings, or save a default one
        /// </summary>
        /// <returns></returns>
        internal static bool LoadAppSettings()
        {
            try
            {
                // check if there's config found
                if (!Directory.Exists(Variables.ConfigPath) || !File.Exists(Variables.AppSettingsFile))
                {
                    return StoreDefaultAppSettings();
                }

                // yep, load it
                var settingsStr = File.ReadAllText(Variables.AppSettingsFile);

                // content?
                if (string.IsNullOrWhiteSpace(settingsStr))
                {
                    Log.Warning("[SETTINGS] App settings file empty");
                    return StoreDefaultAppSettings();
                }

                // try to parse
                Variables.AppSettings = JsonConvert.DeserializeObject<AppSettings>(settingsStr);
                if (Variables.AppSettings == null)
                {
                    Log.Error("[SETTINGS] Parsing app settings returned a null object");
                    return false;
                }

                // done
                Log.Information("[SETTINGS] App settings loaded");
                return true;
            }
            catch (JsonException ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error parsing app settings: {err}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error loading app settings: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Load the stored e-mail settings, or save a default one
        /// </summary>
        /// <returns></returns>
        internal static bool LoadEmailSettings()
        {
            //not implemented yet
            return true;

            try
            {
                // check if there's config found
                if (!Directory.Exists(Variables.ConfigPath) || !File.Exists(Variables.EmailSettingsFile))
                {
                    return StoreDefaultEmailSettings();
                }

                // yep, load it
                var settingsStr = File.ReadAllText(Variables.EmailSettingsFile);

                // content?
                if (string.IsNullOrWhiteSpace(settingsStr))
                {
                    Log.Warning("[SETTINGS] E-mail settings file empty");
                    return StoreDefaultEmailSettings();
                }

                // try to parse
                Variables.EmailSettings = JsonConvert.DeserializeObject<EmailSettings>(settingsStr);
                if (Variables.EmailSettings == null)
                {
                    Log.Error("[SETTINGS] Parsing e-mail settings returned a null object");
                    return false;
                }

                // done
                Log.Information("[SETTINGS] E-mail settings loaded");
                return true;
            }
            catch (JsonException ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error parsing e-mail settings: {err}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error loading e-mail settings: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Store the current app settings
        /// </summary>
        /// <returns></returns>
        internal static bool StoreAppSettings()
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
                Log.Fatal(ex, "[SETTINGS] Error storing app settings: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Store the current e-mail settings
        /// </summary>
        /// <returns></returns>
        internal static bool StoreEmailSettings()
        {
            //not implemented yet
            return true;

            try
            {
                // check the path
                if (!Directory.Exists(Variables.ConfigPath)) Directory.CreateDirectory(Variables.ConfigPath);

                // store values
                var settings = JsonConvert.SerializeObject(Variables.EmailSettings, Formatting.Indented);
                File.WriteAllText(Variables.EmailSettingsFile, settings);

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing e-mail settings: {err}", ex.Message);
                return false;
            }
        }

        private static bool StoreDefaultAppSettings()
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
                Log.Information("[SETTINGS] Default app settings stored");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing default app settings: {err}", ex.Message);
                return false;
            }
        }

        private static bool StoreDefaultEmailSettings()
        {
            //not implemented yet
            return true;

            try
            {
                // check the path
                if (!Directory.Exists(Variables.ConfigPath)) Directory.CreateDirectory(Variables.ConfigPath);

                // set default
                Variables.EmailSettings = new EmailSettings();

                // store values
                var settings = JsonConvert.SerializeObject(Variables.EmailSettings, Formatting.Indented);
                File.WriteAllText(Variables.EmailSettingsFile, settings);

                // done
                Log.Information("[SETTINGS] Default e-mail settings stored");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing default e-mail settings: {err}", ex.Message);
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
                StoreAppSettings();

                // done
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing selected languages: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Gets the 'ApiKeyMissingShown' setting from registry
        /// </summary>
        /// <returns></returns>
        internal static bool GetApiKeyMissingShown()
        {
            try
            {
                var setting = (string)Registry.GetValue(Variables.RootRegKey, "ApiKeyMissingShown", "0");
                if (string.IsNullOrEmpty(setting)) return false;

                return setting == "1";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error retrieving 'ApiKeyMissingShown' setting: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stores the 'ApiKeyMissingShown' setting in registry
        /// </summary>
        /// <param name="shown"></param>
        internal static void SetApiKeyMissingShown(bool shown)
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "ApiKeyMissingShown", shown ? "1" : "0", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing 'ApiKeyMissingShown' setting: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Gets the 'DomainConfirmationShown' setting from registry
        /// </summary>
        /// <returns></returns>
        internal static bool GetDomainConfirmationShown()
        {
            try
            {
                var setting = (string)Registry.GetValue(Variables.RootRegKey, "DomainConfirmationShown", "0");
                if (string.IsNullOrEmpty(setting)) return false;

                return setting == "1";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error retrieving 'DomainConfirmationShown' setting: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stores the 'DomainConfirmationShown' setting in registry
        /// </summary>
        /// <param name="shown"></param>
        internal static void SetDomainConfirmationShown(bool shown)
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "DomainConfirmationShown", shown ? "1" : "0", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing 'DomainConfirmationShown' setting: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Gets the 'TranslationEventsLastMailed' setting from registry
        /// </summary>
        /// <returns></returns>
        internal static DateTime GetTranslationEventsLastMailed()
        {
            try
            {
                var momentStr = (string)Registry.GetValue(Variables.RootRegKey, "TranslationEventsLastMailed", string.Empty);
                if (string.IsNullOrEmpty(momentStr)) return DateTime.MinValue;

                // try to parse
                var parsed = DateTime.TryParseExact(momentStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out var moment);
                if (!parsed) return DateTime.MinValue;

                // looks good
                return moment;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error retrieving 'TranslationEventsLastMailed' setting: {err}", ex.Message);
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Stores the 'TranslationEventsLastMailed' setting in registry
        /// </summary>
        /// <param name="moment"></param>
        internal static void SetTranslationEventsLastMailed(DateTime moment)
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "TranslationEventsLastMailed", $"{moment:yyyy-MM-dd HH:mm:ss}", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing 'TranslationEventsLastMailed' setting: {err}", ex.Message);
            }
        }
    }
}
