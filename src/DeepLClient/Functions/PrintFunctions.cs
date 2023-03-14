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

                // prepare our document with the provided settings
                using var pd = new PrintDocument();
                pd.PrinterSettings = printerSettings;
                
                // bind to the print handler
                pd.PrintPage += PrintTextFileHandler;

                // print
                pd.Print();

                // close the stringreader
                _stringReader?.Close();

                // unbind
                pd.PrintPage -= PrintTextFileHandler; 

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PRINT] Error trying to print text: {err}", ex.Message);
                return false;
            }
        }

        private static void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            try
            {
                if (_stringReader == null) return;
            
                // get the graphics handler
                using var graphics = ppeArgs.Graphics;
                if (graphics == null) return;
                
                // prepare some vars
                float leftMargin = ppeArgs.MarginBounds.Left;
                float topMargin = ppeArgs.MarginBounds.Top;
                var linesPerPage = ppeArgs.MarginBounds.Height/Font.GetHeight(graphics);
                
                // print
                var count = 0;
                string line = null;
                while (count < linesPerPage && ( line = _stringReader.ReadLine ()) != null)
                {
                    var yPos = topMargin + count * Font.GetHeight(graphics);
                    graphics.DrawString (line, Font, Brushes.Black,leftMargin, yPos, new StringFormat());
                    count++;
                }  

                // todo: check multiple pages
                ppeArgs.HasMorePages = line != null;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PRINT] Error printing text: {err}", ex.Message);
            }
        }
    }
}
