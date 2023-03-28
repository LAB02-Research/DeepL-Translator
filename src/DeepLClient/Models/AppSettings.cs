using System.Diagnostics.CodeAnalysis;
using DeepL;

namespace DeepLClient.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AppSettings
    {
        public AppSettings()
        {
            //
        }

        public string User { get; set; } = string.Empty;
        public string DeepLDomain { get; set; } = string.Empty;
        public string DeepLAPIKey { get; set; } = string.Empty;
        public bool LaunchHidden { get; set; } = true;
        public bool StoreLastUsedSourceLanguage { get; set; } = true;
        public string LastSourceLanguage { get; set; } = string.Empty;
        public bool StoreLastUsedTargetLanguage { get; set; } = true;
        public string LastTargetLanguage { get; set;} = string.Empty;
        public Formality DefaultFormality { get; set; } = Formality.Default;
        public double PricePerCharacter { get; set; } = 0.00002;
        public double MinimumCharactersPerDocument { get; set; } = 50000;
        public int DocumentMaxSizeMB { get; set; } = 20;
        public bool CopyTranslationToClipboard { get; set; } = true;
        public bool LaunchOnWindowsLogin { get; set; } = true;
        public bool GlobalHotkeyEnabled { get; set; } = true;
        public string GlobalHotkey { get; set; } = "Shift, Control + T";
        public bool AlwaysOnTop { get; set; } = false;
        public bool EnableUsageLogging { get; set; } = true;
        public int RemoveUsageLogEntriesOlderThanDays { get; set; } = 31;
        public bool EnablePeriodicUsageMail { get; set; } = false;
        public int SendUsageLogMailEveryDays { get; set; } = 7;
        public string UsageLogMailReceiverAddress { get; set; } = string.Empty;
    }
}
