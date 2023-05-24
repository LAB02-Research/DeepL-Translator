using DeepLClient.Models;
using Serilog.Core;
using System.Reflection;
using DeepL;
using System.Globalization;
using WK.Libraries.HotkeyListenerNS;
using DeepLClient.Managers;
using Microsoft.Web.WebView2.Core;

namespace DeepLClient
{
    internal static class Variables
    {
        /// <summary>
        /// Application info
        /// </summary>
        public static string ApplicationName { get; } = "DeepL Translator";
        public static string MessageBoxTitle { get; } = $"{ApplicationName}  |  LAB02 Research";
        public static string ApplicationExecutable { get; } = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
        public static string Version { get; } = Application.ProductVersion;

        /// <summary>
        /// Constants
        /// </summary>
        internal const string SyncfusionLicense = "MjE3MTUwNkAzMjMxMmUzMjJlMzVjUGlGeU1CWllEcDBkVG55dWtnQnFhU0QrK25lY01QZGFPQU4wR2xyWWw4PQ==";
        internal static string RootRegKey { get; } = @$"HKEY_CURRENT_USER\SOFTWARE\LAB02Research\{ApplicationName}";
        internal static string CurrencySymbol { get; } = NumberFormatInfo.CurrentInfo.CurrencySymbol;

        /// <summary>
        /// Internal references
        /// </summary>
        internal static MainFormManager MainFormManager { get; set; }
        internal static HttpClient HttpClient { get; set; } = new();
        internal static Font DefaultFont { get; } = new("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        internal static CoreWebView2Environment WebViewEnvironment { get; set; } = null;
        
        /// <summary>
        /// HotKey
        /// </summary>
        internal static Hotkey GlobalHotkey { get; set; } = new(Keys.Control | Keys.Shift, Keys.T);
        internal static HotkeyListener HotkeyListener { get; set; }
        internal static HotkeyManager HotkeyManager { get; } = new();


        /// <summary>
        /// DeepL
        /// </summary>
        internal static Translator Translator { get; set; }
        internal static SortedDictionary<string, string> SourceLanguages { get; } = new();
        internal static SortedDictionary<string, string> TargetLanguages { get; } = new();
        internal static SortedDictionary<int, string> Formalities { get; } = new();
        internal static List<string> FormalitySupportedLanguages { get; } = new();

        /// <summary>
        /// Internal state
        /// </summary>
        internal static LoggingLevelSwitch LevelSwitch { get; } = new();
        internal static bool DebugMode { get; set; } = false;
        internal static bool ShuttingDown { get; set; }

        /// <summary>
        /// Local IO
        /// </summary>
        internal static string StartupPath { get; } = Path.GetDirectoryName(Application.ExecutablePath);
        internal static string LogPath { get; } = Path.Combine(StartupPath, "logs");
        internal static string ConfigPath { get; } = Path.Combine(StartupPath, "config");
        internal static string AppSettingsFile { get; } = Path.Combine(ConfigPath, "appsettings.json");
        internal static string EmailSettingsFile { get; } = Path.Combine(ConfigPath, "emailsettings.json");
        internal static string TranslationEventsLogFile { get; } = Path.Combine(ConfigPath, "translationeventslog.json");
        internal static string CachePath { get; } = Path.Combine(StartupPath, "cache");
        internal static string WebViewCachePath { get; } = Path.Combine(CachePath, "webview");
        internal static string WebPagesCachePath { get; } = Path.Combine(CachePath, "webpages");

        /// <summary>
        /// Config
        /// </summary>
        internal static AppSettings AppSettings { get; set; }
        internal static EmailSettings EmailSettings { get; set; }

        /// <summary>
        /// Usage Logging
        /// </summary>
        internal static List<TranslationEvent> TranslationEvents { get; set; } = new();

        /// <summary>
        /// Updater
        /// </summary>
        internal static string WyUpdateDownloadSource { get; } = "https://shares.lab02-research.org/deeplclient/";
        internal static string WyUpdateBinary { get; } = Path.Combine(StartupPath, "wyUpdate.exe");
        internal static string WyUpdateClientConfig { get; } = Path.Combine(StartupPath, "client.wyc");
    }
}
