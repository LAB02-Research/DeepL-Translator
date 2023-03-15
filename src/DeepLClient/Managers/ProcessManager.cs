using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DeepLClient.Functions;
using Serilog;

namespace DeepLClient.Managers
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    internal static class ProcessManager
    {
        private static bool _shutdownCalled = false;
        private static Mutex _mutex = null;

        /// <summary>
        /// Checks whether we're the first instance
        /// </summary>
        /// <returns></returns>
        internal static bool IsFirstInstance()
        {
            try
            {
                // check if we can claim the mutex
                _mutex = new Mutex(true, Variables.ApplicationName, out var isFirstInstance);
                return isFirstInstance;
            }
            catch (Exception ex)
            {
                Log.Fatal("[PROCESS] Error processing mutex: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Releases our mutex lock, allowing another instance to load
        /// </summary>
        internal static void ReleaseMutex()
        {
            try
            {
                _mutex?.ReleaseMutex();
            }
            catch { }
        }

        /// <summary>
        /// Closes all instances of the provided process name (do not include the extension)
        /// </summary>
        /// <param name="processName"></param>
        internal static void CloseAllInstancesForCurrentUser(string processName)
        {
            try
            {
                var procList = Process.GetProcesses().Where(proc => proc.ProcessName == processName);
                var procListEnumerable = procList as Process[] ?? procList.ToArray();

                if (!procListEnumerable.Any()) return;

                foreach (var proc in procListEnumerable)
                {
                    try
                    {
                        if (Environment.UserName != GetProcessOwner(proc)) continue;
                        proc.Kill();
                        Thread.Sleep(1500);
                    }
                    catch { }
                    finally
                    {
                        proc?.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PROCESS] Something went wrong when killing {proc}: {err}", processName, ex.Message);
            }
        }

        /// <summary>
        /// Gets the owner of the provided process
        /// </summary>
        /// <param name="process"></param>
        /// <param name="includeDomain"></param>
        /// <returns></returns>
        private static string GetProcessOwner(Process process, bool includeDomain = false)
        {
            var processHandle = nint.Zero;
            try
            {
                NativeFunctions.OpenProcessToken(process.Handle, 8, out processHandle);
                using var wi = new WindowsIdentity(processHandle);
                var user = wi.Name;
                // ReSharper disable once StringIndexOfIsCultureSpecific.1
                if (!includeDomain) return user.Contains(@"\") ? user[(user.IndexOf(@"\") + 1)..] : user;
                else return user;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (processHandle != nint.Zero) NativeFunctions.CloseHandle(processHandle);
            }
        }

        /// <summary>
        /// Shutsdown all relevant aspects and closes us down (somewhat) nicely
        /// </summary>
        internal static void Shutdown()
        {
            var logClosed = false;
            var exitCode = 0;

            try
            {
                // process only once
                if (_shutdownCalled) return;
                _shutdownCalled = true;

                // announce we're stopping
                Variables.ShuttingDown = true;

                // log our demise
                Log.Information("[SYSTEM] Application shutting down");

                // remove tray icon
                Variables.MainForm?.HideTrayIcon();

                // unbind all hotkeys
                Variables.HotkeyListener?.RemoveAll();

                // dispose global hotkey
                Variables.HotkeyListener?.Dispose();

                // dispose our translator
                Variables.Translator?.Dispose();

                // release our lock
                ReleaseMutex();

                // flush the log
                Log.Information("[SYSTEM] Application shutdown complete");
                Log.CloseAndFlush();
                logClosed = true;
            }
            catch (Exception ex)
            {
                exitCode = 1;

                if (!logClosed)
                {
                    Log.Error("[SYSTEM] Error shutting down nicely: {msg}", ex.Message);
                    Log.CloseAndFlush();
                }
            }
            finally
            {
                // shutdown
                Environment.Exit(exitCode);
            }

        }
    }
}
