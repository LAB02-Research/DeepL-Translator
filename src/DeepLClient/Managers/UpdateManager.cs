using DeepLClient.Functions;
using Microsoft.Win32;
using System.Diagnostics;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class UpdateManager
    {
        private static bool _updateActive;

        /// <summary>
        /// Executes an initial update check, with periodic checks afterwards
        /// </summary>
        internal static async void Initialize()
        {
            try
            {
                // check for updates
                AreWeUpdated();

                // initial update check, regardless of idle
                await CheckForUpdateAsync(false);

                // commence periodic check
                _ = Task.Run(PeriodicUpdateCheck);

                // done
                Log.Information("[UPDATER] Initialised");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
            }
        }

        /// <summary>
        /// Periodically checks for new updates
        /// </summary>
        private static async void PeriodicUpdateCheck()
        {
            while (!Variables.ShuttingDown)
            {
                // wait a bit
                await Task.Delay(TimeSpan.FromMinutes(30));

                // check updates
                await CheckForUpdateAsync();
            }
        }

        /// <summary>
        /// Checks for new updates. Will install and close the client when found.
        /// <para>Only if the user is idle long enough, when checkForIdle is TRUE</para>
        /// </summary>
        /// <param name="checkForIdle"></param>
        internal static async Task CheckForUpdateAsync(bool checkForIdle = true)
        {
            try
            {
                // don't update in debug mode
                if (Variables.DebugMode) return;
                
                // are we already updating?
                if (_updateActive) return;

                // is the pc idle long enough?
                if (checkForIdle && !HelperFunctions.UserIdleForMinutes(15)) return;

                // let's start
                _updateActive = true;
                
                // check whether wyupdate.exe and client.wyc are available
                if (!File.Exists(Variables.WyUpdateBinary))
                {
                    Log.Warning("[UPDATER] Component wyUpdate.exe not found, downloading ..");
                    var wyUpdateOk = await StorageManager.DownloadFileAsync( $"{Variables.WyUpdateDownloadSource}wyUpdate.exe", Variables.WyUpdateBinary);
                    if (!wyUpdateOk)
                    {
                        Log.Error("[UPDATER] Downloading wyUpdate.exe failed");
                        _updateActive = false;
                        return;
                    }
                    Log.Information("[UPDATER] Component wyUpdate.exe restored");
                }

                if (!File.Exists(Variables.WyUpdateClientConfig))
                {
                    Log.Warning("[UPDATER] Component client.wyc not found, downloading ..");
                    var clientOk = await StorageManager.DownloadFileAsync($"{Variables.WyUpdateDownloadSource}client.wyc", Variables.WyUpdateClientConfig);
                    if (!clientOk)
                    {
                        Log.Error("[UPDATER] Downloading client.wyc failed");
                        _updateActive = false;
                        return;
                    }
                    Log.Information("[UPDATER] Component client.wyc restored");
                }

                // updater is available, let's check for an update
                var isUpdateReady = await IsUpdateReadyAsync();
                if (!isUpdateReady)
                {
                    // nothing to do
                    _updateActive = false;
                    return;
                }

                // new update available
                Log.Information("[UPDATER] New update available!");

                // is the pc still idle?
                if (checkForIdle && !HelperFunctions.UserIdleForMinutes(15))
                {
                    Log.Information("[UPDATER] Cancelling update, user became active");
                    return;
                }

                // looks good, install
                Log.Information("[UPDATER] System ready, commencing update ..");
                StartUpdate();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error checking for update: {err}", ex.Message);
                _updateActive = false;
            }
        }

        /// <summary>
        /// Asks wyUpdate whether there's a new update pending
        /// <para>Using wyUpdate.exe instead of the library, as recommended by wyDay</para>
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> IsUpdateReadyAsync()
        {
            try
            {
                // updater found?
                if (!File.Exists(Variables.WyUpdateBinary))
                {
                    Log.Error("[UPDATER] WyUpdate.exe not found, unable to check for updates");
                    return false;
                }

                // prepare wyUpdate in check-only mode
                var startInfo = new ProcessStartInfo
                {
                    FileName = Variables.WyUpdateBinary,
                    Arguments = "/quickcheck /justcheck /noerr",
                    WorkingDirectory = Variables.StartupPath
                };

                // prepare our process
                using var process = new Process();
                process.StartInfo = startInfo;

                // try to start it
                var started = process.Start();

                // did we start?
                if (!started)
                {
                    Log.Error("[UPDATER] Unable to start wyUpdate, unable to check for updates");
                    return false;
                }

                // give it 15 min
                process.WaitForInputIdle();
                process.WaitForExit(Convert.ToInt32(TimeSpan.FromMinutes(15).TotalMilliseconds));

                // did wyUpdate neatly close?
                if (!process.HasExited)
                {
                    if (process.Responding)
                    {
                        Log.Error("[UPDATER] wyUpdate still busy after 15 minutes, closed responsively");

                        // ask it to close
                        process.CloseMainWindow();

                        // give it time to close
                        await Task.Delay(TimeSpan.FromSeconds(1));

                        // kill it
                        CloseWyUpdateInstances();
                    }
                    else
                    {
                        Log.Error("[UPDATER] wyUpdate still busy after 15 minutes, forcibly closed");

                        // kill it
                        process.Kill();

                        // give it time to close
                        await Task.Delay(TimeSpan.FromSeconds(1));

                        // multikill it
                        CloseWyUpdateInstances();
                    }
                }

                // check the result
                var procExitCode = process.ExitCode;
                switch (procExitCode)
                {
                    case 0:
                        // nothing to do
                        return false;
                    case 1:
                        // error
                        Log.Error("[UPDATER] wyUpdate returned exitcode 1 when checking for updates");
                        return false;
                    case 2:
                        // update available
                        return true;
                    default:
                        // shouldn't happen
                        Log.Error("[UPDATER] wyUpdate returned an unknown exitcode: {procExitCode}", procExitCode);
                        return false;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error querying wyUpdate for updates: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gives wyUpdate the command to start updating, and closes the client
        /// <para>Using wyUpdate.exe instead of the library, as recommended by wyDay</para>
        /// </summary>
        private static void StartUpdate()
        {
            try
            {
                // updater found?
                if (!File.Exists(Variables.WyUpdateBinary))
                {
                    Log.Error("[UPDATER] WyUpdate.exe not found, unable to check for updates");
                    return;
                }

                // hide our tray icon
                Variables.MainFormManager?.HideTrayIcon();

                // dispose the translator
                Variables.Translator?.Dispose();

                // release our lock
                ProcessManager.ReleaseMutex();

                // prepare wyUpdate in silent-update mode
                var startInfo = new ProcessStartInfo
                {
                    FileName = Variables.WyUpdateBinary,
                    Arguments = "/skipinfo",
                    WorkingDirectory = Variables.StartupPath
                };

                // start it
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error executing update install: {err}", ex.Message);
            }
            finally
            {
                // note: this is a risk, in case the updater doesn't properly launch
                // but if we're not closed when it has launched, it'll get stuck waiting for us until the end of times
                
                // bye bye
                ProcessManager.Shutdown();
            }
        }

        /// <summary>
        /// Active instances of wyUpdate can prevent us from updating
        /// </summary>
        private static void CloseWyUpdateInstances() => ProcessManager.CloseAllInstancesForCurrentUser("wyUpdate");

        /// <summary>
        /// Checks whether we're updated
        /// </summary>
        private static void AreWeUpdated()
        {
            try
            {
                var lastVersion = (string)Registry.GetValue(Variables.RootRegKey, "LastVersion", string.Empty);
                if (string.IsNullOrEmpty(lastVersion)) return;
                if (lastVersion == Variables.Version) return;

                Log.Information("[UPDATER] Succesfully updated from {old} to {new}", lastVersion, Variables.Version);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error checking whether we're updated: {err}", ex.Message);
            }
            finally
            {
                StoreVersionNumber();
            }
        }

        /// <summary>
        /// Stores our current version number
        /// </summary>
        private static void StoreVersionNumber()
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "LastVersion", Variables.Version, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error storing our version: {err}", ex.Message);
            }
        }
    }
}
