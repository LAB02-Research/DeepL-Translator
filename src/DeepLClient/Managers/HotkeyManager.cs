using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using WK.Libraries.HotkeyListenerNS;

namespace DeepLClient.Managers
{
    internal class HotkeyManager
    {
        /// <summary>
        /// Initialises the global hotkey
        /// </summary>
        internal void Initialize()
        {
            Variables.MainForm?.BeginInvoke(new MethodInvoker(delegate
            {
                // check if the global hotkey's active
                if (!Variables.AppSettings.GlobalHotkeyEnabled) return;

                // anything stored?
                if (!string.IsNullOrEmpty(Variables.AppSettings.GlobalHotkey))
                {
                    Variables.GlobalHotkey = new Hotkey(Variables.AppSettings.GlobalHotkey);
                }

                // check if it's configured
                if (Variables.GlobalHotkey == null || Variables.GlobalHotkey.ToString() == "None") return;

                // all good, bind
                Variables.HotkeyListener?.Add(Variables.GlobalHotkey);

                Log.Information("[HOTKEY] Completed bind for global hotkey: {key}", Variables.GlobalHotkey.ToString());
            }));
        }

        /// <summary>
        /// Processes the hotkey
        /// </summary>
        /// <param name="e"></param>
        internal static void ProcessHotkey(HotkeyEventArgs e)
        {
            try
            {
                // get the string value
                var hotkey = e.Hotkey.ToString();
                Log.Debug("[HOTKEY] Detected: {key}", hotkey);

                // relevant?
                if (string.IsNullOrEmpty(hotkey)) return;
                if (e.Hotkey != Variables.GlobalHotkey) return;

                // yep, any selected text?
                var selection = e.SourceApplication.Selection;
                if (!string.IsNullOrWhiteSpace(selection))
                {
                    // set url or text
                    if (selection.ToLower().StartsWith("http")) Variables.MainForm?.SetSourceUrl(selection.Trim());
                    else Variables.MainForm?.SetSourceText(selection.Trim(), true);
                    return;
                }

                // nope, just show
                Variables.MainForm?.ShowMain(false);
            }
            catch (Exception ex)
            {
                Log.Fatal("[HOTKEY] Error handling hotkey: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Process a changed quickactions hotkey
        /// </summary>
        /// <param name="previousKey"></param>
        /// <param name="register"></param>
        internal void HotkeyChanged(Hotkey previousKey, bool register = true)
        {
            Variables.MainForm?.BeginInvoke(new MethodInvoker(delegate
            {
                Variables.HotkeyListener?.Remove(previousKey);
                if (register && Variables.GlobalHotkey != null && Variables.GlobalHotkey.KeyCode != Keys.None) Variables.HotkeyListener?.Add(Variables.GlobalHotkey);
            }));
        }
    }
}
