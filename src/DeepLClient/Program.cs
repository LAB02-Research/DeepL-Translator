using Serilog.Events;
using Serilog;
using System.Text;
using DeepLClient.Forms;
using DeepLClient.Functions;
using DeepLClient.Managers;

namespace DeepLClient
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                // singleton app
                if (!ProcessManager.IsFirstInstance()) return;

                // syncfusion license
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Variables.SyncfusionLicense);

                // prepare logger
                Variables.LevelSwitch.MinimumLevel = LogEventLevel.Information;

#if DEBUG
                Variables.LevelSwitch.MinimumLevel = LogEventLevel.Debug;
                Variables.DebugMode = true;
#endif

                // prepare a serilog logger
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(Variables.LevelSwitch)
                    .WriteTo.File(Path.Combine(Variables.LogPath, $"[{DateTime.Now:yyyy-MM-dd}] {Variables.ApplicationName}_.log"),
                            rollingInterval: RollingInterval.Day,
                            fileSizeLimitBytes: 10000000,
                            retainedFileCountLimit: 10,
                            rollOnFileSizeLimit: true,
                            buffered: true,
                            flushToDiskInterval: TimeSpan.FromMilliseconds(150))
                    .CreateLogger();

                // log our launch
                Log.Information("[MAIN] {name} version: {version}", Variables.ApplicationName, Variables.Version);

                // prepare application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // set scaling
                Application.SetHighDpiMode(HighDpiMode.DpiUnaware);

                // register the encoding provider for non-default encodings
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // prepare default application
                Variables.MainForm = new Main();

                // prepare msgbox
                HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                // load settings
                var settingsLoaded = SettingsManager.Load();
                if (!settingsLoaded) return;

                // store user
                if (!string.IsNullOrEmpty(Variables.AppSettings.User)) Log.Information("[MAIN] Registered user: {version}", Variables.AppSettings.User);
                else Log.Information("[MAIN] No registered user.");
                
                // run hidden?
                if (!string.IsNullOrEmpty(Variables.AppSettings.DeepLAPIKey) && Variables.AppSettings.LaunchHidden) Application.Run(new CustomApplicationContext(Variables.MainForm));
                else Application.Run(Variables.MainForm);
            }
            catch (AccessViolationException ex)
            {
                Log.Fatal(ex, "[PROGRAM] AccessViolationException: {err}", ex.Message);
                Log.CloseAndFlush();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PROGRAM] {err}", ex.Message);
                Log.CloseAndFlush();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}