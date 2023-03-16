using Syncfusion.Windows.Forms;

namespace DeepLClient.Functions
{
    internal static class MessageBoxAdv2
    {
        /// <summary>
        /// Shows a MessageBoxAdv through the main form's handle, while suspending and resuming topmost
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        internal static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return !Variables.MainFormManager.MainFormReady() 
                ? DialogResult.Cancel 
                : Show(Variables.MainFormManager.MainForm, text, caption, buttons, icon);
        }

        /// <summary>
        /// Shows a MessageBoxAdv, while suspending and resuming topmost
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        internal static DialogResult Show(Form owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // suspend topmost
            if (owner.TopMost) owner.TopMost = false;
            
            // show our dialog
            var dialogResult = MessageBoxAdv.Show(owner, text, caption, buttons, icon);

            // resume topmost
            if (Variables.AppSettings.AlwaysOnTop) owner.TopMost = true;

            // done
            return dialogResult;
        }
    }
}
