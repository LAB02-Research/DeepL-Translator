using System.Diagnostics.CodeAnalysis;
using ByteSizeLib;
using DeepLClient.Enums;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Presentation;

namespace DeepLClient.Managers
{
    internal static class DocumentManager
    {
        /// <summary>
        /// Try to determine the character count of the PDF file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static long GetPdfCharacterCount(string file)
        {
            using var inputStream = new FileStream(file, FileMode.Open);
            using var loadedDocument = new PdfLoadedDocument(inputStream);

            var characterCount = 0L;
            foreach (PdfLoadedPage page in loadedDocument.Pages)
            {
                var pageText = page.ExtractText();
                if (string.IsNullOrEmpty(pageText)) continue;

                characterCount += pageText.Length;
            }
            
            loadedDocument.Close(true);
            return characterCount;
        }

        /// <summary>
        /// Try to determine the character count of the DOCX file
        /// <para>Source: https://www.syncfusion.com/document-processing/word-framework/net</para>
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static long GetDocCharacterCount(string file)
        {
            using var document = new WordDocument(file, Syncfusion.DocIO.FormatType.Automatic);
            return document.BuiltinDocumentProperties.CharCount;
        }

        /// <summary>
        /// Try to determine the character count of the TXT file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static long GetTxtCharacterCount(string file)
        {
            var content = File.ReadAllText(file);
            return content.Length;
        }

        /// <summary>
        /// Try to determine the character count of the HTML file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static long GetHtmlCharacterCount(string file)
        {
            var content = File.ReadAllText(file);
            return content.Length;
        }

        /// <summary>
        /// Try to determine the character count of the PPTX file
        /// <para>Source: https://github.com/syncfusion/file-formats-windows-forms-demos/blob/master/Presentation/Getting%20Started/HelloWorld/CS/Form1.cs</para> 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static long GetPowerPointCharacterCount(string file)
        {
            using var presentation = Presentation.Open(file);
            return (from slide in presentation.Slides 
                from slideItem in slide.Shapes 
                select (IShape)slideItem
                into shape 
                select shape.TextBody.Text.Length).Sum();
        }

        /// <summary>
        /// Returns a filter list of supported document types, used by OpenFileDialogs
        /// </summary>
        /// <returns></returns>
        internal static string GetFileTypeFilters()
        {
            return "Supported (*.docx;*.pptx;*.pdf;*.txt;*.html)|*.docx;*.pptx;*.pdf;*.txt;*.html" +
                   "|Word (*.docx)|*.docx" +
                   "|PowerPoint (*.pptx)|*.pptx" +
                   "|PDF (*.pdf)|*.pdf" +
                   "|Text (*.txt)|*.txt" +
                   "|HTML (*.html)|*.html";
        }

        /// <summary>
        /// Determines whether the provided file is supported
        /// </summary>
        /// <param name="file"></param>
        /// <param name="onlyText"></param>
        /// <returns></returns>
        internal static bool FileIsSupported(string file, bool onlyText = false)
        {
            var supportedExts = onlyText 
                ? new List<string> { ".txt" } 
                : new List<string> { ".docx", ".pptx", ".pdf", ".txt", ".html" };

            var ext = Path.GetExtension(file).ToLower();
            return supportedExts.Contains(ext);
        }

        /// <summary>
        /// Converts the file's type to a DocumentType
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static DocumentType GetFileDocumentType(string file)
        {
            var ext = Path.GetExtension(file).ToLower();
            switch (ext)
            {
                case ".docx":
                    return DocumentType.Word;
                case ".pptx":
                    return DocumentType.PowerPoint;
                case ".pdf":
                    return DocumentType.PDF;
                case ".txt":
                    return DocumentType.Text;
                case ".html":
                    return DocumentType.HTML;
                default:
                    return DocumentType.Unsupported;
            }
        }

        /// <summary>
        /// Checks whether the document's size exceeds the max allowed size
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static (bool tooLarge, double sizeMB) CheckDocumentSize(string file)
        {
            var sizeBytes = Convert.ToDouble(new FileInfo(file).Length);
            var sizeMB = new ByteSize(sizeBytes).MegaBytes;

            return sizeMB > Variables.AppSettings.DocumentMaxSizeMB ? (true, sizeMB) : (false, sizeMB);
        }

        /// <summary>
        /// Gets the document's size in MB
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static double GetDocumentSizeMB(string file)
        {
            var sizeBytes = Convert.ToDouble(new FileInfo(file).Length);
            return new ByteSize(sizeBytes).MegaBytes;
        }
    }
}
