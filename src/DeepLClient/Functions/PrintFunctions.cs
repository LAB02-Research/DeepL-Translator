using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace DeepLClient.Functions
{
    internal static class PrintFunctions
    {
        private static StringReader _stringReader;
        private static readonly Font Font = new("Verdana", 10);

        /// <summary>
        /// Attempts to print the provided text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="printerSettings"></param>
        /// <returns></returns>
        internal static bool PrintText(string text, PrinterSettings printerSettings)
        {
            try
            {
                _stringReader = new StringReader (text);
                using var pd = new PrintDocument();
                pd.PrinterSettings = printerSettings;
                
                pd.PrintPage += PrintTextFileHandler;
                pd.Print();
                _stringReader?.Close();
                pd.PrintPage -= PrintTextFileHandler; 

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PRINT] Error trying to print text: {err}", ex.Message);
                return false;
            }
        }

        private static void PrintTextFileHandler (object sender, PrintPageEventArgs ppeArgs)
        {
            try
            {
                if (_stringReader == null) return;
            
                using var g = ppeArgs.Graphics;
                float leftMargin = ppeArgs.MarginBounds.Left;
                float topMargin = ppeArgs.MarginBounds.Top;
                string line = null;
                var linesPerPage = ppeArgs.MarginBounds.Height/Font.GetHeight (g);
                var count = 0;
                while (count<linesPerPage && ( line = _stringReader.ReadLine ()) != null)
                {
                    var yPos = topMargin + count * Font.GetHeight (g);
                    g.DrawString (line, Font, Brushes.Black,leftMargin, yPos, new StringFormat());
                    count++;
                }  

                ppeArgs.HasMorePages = line != null;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PRINT] Error printing text: {err}", ex.Message);
            }
        }
    }
}
