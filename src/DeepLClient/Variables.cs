using DeepLClient.Models;
using Serilog.Core;
using System.Reflection;
using DeepL;
using DeepLClient.Forms;

namespace DeepLClient
{
    internal static class Variables
    {
        /// <summary>
        /// Application info
        /// </summary>
        public static string ApplicationName { get; } = Assembly.GetExecutingAssembly().GetName().Name ?? "DeepL Translator";
        public static string MessageBoxTitle { get; } = "DeepL Translator  |  LAB02 Research";
        public static string ApplicationExecutable { get; } = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
        public static string Version { get; } = Application.ProductVersion;

        /// <summary>
        /// Constants
        /// </summary>
        internal const string SyncfusionLicense = "MTI0OTg2NUAzMjMwMmUzNDJlMzBSblBWOVBUdEZITG5WZVkyZWUvV0xPWjMyTWJ5S0Yvb3JzbUExTVdDWVdVPQ==";

        /// <summary>
        /// Internal references
        /// </summary>
        internal static Main MainForm { get; set; }
        internal static HttpClient HttpClient { get; set; } = new();
        internal static Font DefaultFont { get; } = new("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        internal static bool ShuttingDown { get; set; }

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

        /// <summary>
        /// Local IO
        /// </summary>
        internal static string StartupPath { get; } = Path.GetDirectoryName(Application.ExecutablePath);
        internal static string LogPath { get; } = Path.Combine(StartupPath, "logs");
        internal static string ConfigPath { get; } = Path.Combine(StartupPath, "config");
        internal static string AppSettingsFile { get; } = Path.Combine(ConfigPath, "appsettings.json");
        internal static string UsageFile { get; } = Path.Combine(ConfigPath, "usage.json");

        /// <summary>
        /// Config
        /// </summary>
        internal static AppSettings AppSettings { get; set; }
        
        /// <summary>
        /// Updater
        /// </summary>
        internal static string WyUpdateDownloadSource { get; } = "https://shares.lab02-research.org/deeplclient/";
        internal static string WyUpdateBinary { get; } = Path.Combine(StartupPath, "wyUpdate.exe");
        internal static string WyUpdateClientConfig { get; } = Path.Combine(StartupPath, "client.wyc");
    }
}
