using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using Serilog;
using Syncfusion.Windows.Forms;
using static DeepLClient.Functions.NativeFunctions;

namespace DeepLClient.Functions
{
    internal static class HelperFunctions
    {
        

        /// <summary>
        /// Initializes Syncfusion's messagebox style
        /// Todo: incomplete, button color etc need to be done
        /// </summary>
        internal static void SetMsgBoxStyle(Font font)
        {
            var style = new MetroStyleColorTable
            {
                BackColor = Color.FromArgb(45, 45, 48),
                BorderColor = Color.FromArgb(115, 115, 115),
                CaptionBarColor = Color.FromArgb(63, 63, 70),
                CaptionForeColor = Color.FromArgb(241, 241, 241),
                ForeColor = Color.FromArgb(241, 241, 241)
            };

            MessageBoxAdv.ApplyAeroTheme = false;
            MessageBoxAdv.MetroColorTable = style;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;

            MessageBoxAdv.CaptionFont = font;
            MessageBoxAdv.ButtonFont = font;
            MessageBoxAdv.DetailsFont = font;
            MessageBoxAdv.MessageFont = font;
        }

        /// <summary>
        /// Returns an info text explaining the use of formality.
        /// </summary>
        /// <returns></returns>
        internal static string GetFormalityExplanation()
        {
            var info = new StringBuilder();

            // set generic info
            info.AppendLine("By changing the formality, you can change the tone of the translation.");
            info.AppendLine("");
            info.AppendLine("For instance, for friends and family, you could use 'less'.");
            info.AppendLine("But for business translations, you can use 'more'");
            info.AppendLine("");
            info.AppendLine("This is only supported by these languages:");
            info.AppendLine("");

            // get the supported languages
            var languages = (from lang in Variables.TargetLanguages where Variables.FormalitySupportedLanguages.Contains(lang.Value) select lang.Key).ToList();

            // add them
            info.AppendLine($"{string.Join(", ", languages)}.");

            // done
            return info.ToString();
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
                    catch
                    {
                        // best effort
                    }
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
                OpenProcessToken(process.Handle, 8, out processHandle);
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
                if (processHandle != nint.Zero) CloseHandle(processHandle);
            }
        }

        /// <summary>
        /// Returns whether the user has been idle for the amount of minutes provided
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        internal static bool UserIdleForMinutes(int minutes)
        {
            return (DateTime.Now - GetLastInputTime()).TotalMilliseconds > minutes;
        }

        /// <summary>
        /// Returns the last moment the user executed any input
        /// </summary>
        /// <returns></returns>
        internal static DateTime GetLastInputTime()
        {
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            var envTicks = Environment.TickCount;

            if (!GetLastInputInfo(ref lastInputInfo)) return DateTime.Now;
            var lastInputTick = Convert.ToDouble(lastInputInfo.dwTime);

            var idleTime = envTicks - lastInputTick;
            return idleTime > 0 ? DateTime.Now - TimeSpan.FromMilliseconds(idleTime) : DateTime.Now;
        }
    }
}
