using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ByteSizeLib;
using DeepLClient.Enums;
using DeepLClient.Functions;
using Serilog;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Presentation;
using FormatType = Syncfusion.DocIO.FormatType;

namespace DeepLClient.Managers
{
    internal static class DocumentManager
    {
        /// <summary>
        /// Try to determine the character count of the PDF file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static (long charCount, bool success) GetPdfCharacterCount(string file)
        {
            try
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
                return (characterCount, true);
            }
            catch (IOException ex)
            {
                Log.Fatal(ex, "[DM] IO error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
        }

        /// <summary>
        /// Try to determine the character count of the DOCX file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static (long charCount, bool success) GetDocCharacterCount(string file)
        {
            try
            {
                using var document = new WordDocument(file, FormatType.Automatic);

                // update wordcount
                document.UpdateWordCount(false);

                return (document.BuiltinDocumentProperties.CharCount, true);
            }
            catch (IOException ex)
            {
                Log.Fatal(ex, "[DM] IO error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
        }

        /// <summary>
        /// Try to determine the character count of the TXT file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static (long charCount, bool success) GetTxtCharacterCount(string file)
        {
            try
            {
                var content = File.ReadAllText(file);
                return (content.Length, true);
            }
            catch (IOException ex)
            {
                Log.Fatal(ex, "[DM] IO error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
        }

        /// <summary>
        /// Try to determine the character count of the HTML file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static (long charCount, bool success) GetHtmlCharacterCount(string file)
        {
            try
            {
                var content = File.ReadAllText(file);
                return (content.Length, true);
            }
            catch (IOException ex)
            {
                Log.Fatal(ex, "[DM] IO error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
        }

        /// <summary>
        /// Try to determine the character count of the PPTX file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static (long charCount, bool success) GetPowerPointCharacterCount(string file)
        {
            try
            {
                using var presentation = Presentation.Open(file);
                var count = (from slide in presentation.Slides 
                    from slideItem in slide.Shapes 
                    select (IShape)slideItem
                    into shape 
                    select shape.TextBody.Text.Length).Sum();

                return (count, true);
            }
            catch (IOException ex)
            {
                Log.Fatal(ex, "[DM] IO error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error getting wordcount for {file}: {err}", file, ex.Message);
                return (-1, false);
            }
        }

        /// <summary>
        /// Tries to determine the character count of the file, based on its document type
        /// </summary>
        /// <param name="docType"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static async Task<(long charCount, bool success)> GetDocumentCharacterCountAsync(DocumentType docType, string file)
        {
            try
            {
                switch (docType)
                {
                    case DocumentType.Word:
                        return await Task.Run(() => GetDocCharacterCount(file));
                    case DocumentType.PowerPoint:
                        return await Task.Run(() => GetPowerPointCharacterCount(file));
                    case DocumentType.PDF:
                        return await Task.Run(() => GetPdfCharacterCount(file));
                    case DocumentType.Text:
                        return await Task.Run(() => GetTxtCharacterCount(file));
                    case DocumentType.HTML:
                        return await Task.Run(() => GetHtmlCharacterCount(file));
                }

                Log.Error("[DM] Error determining character count for {file}: unknown filetype", file);
                return (0L, false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error determining character count for {file}: {err}", file, ex.Message);
                return (0L, false);
            }
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
        /// <param name="onlyHtml"></param>
        /// <returns></returns>
        internal static bool FileIsSupported(string file, bool onlyText = false, bool onlyHtml = false)
        {
            List<string> supportedExts;

            if (onlyHtml) supportedExts = new List<string> { ".html" };
            else if (onlyText) supportedExts = new List<string> { ".txt" };
            else supportedExts = new List<string> { ".docx", ".pptx", ".pdf", ".txt", ".html" };

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
            try
            {
                var sizeMB = GetDocumentSizeMB(file);
                return sizeMB > Variables.AppSettings.DocumentMaxSizeMB ? (true, sizeMB) : (false, sizeMB);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error checking file size for {file}: {err}", file, ex.Message);
                return (false, 0d);
            }
        }

        /// <summary>
        /// Gets the document's size in MB
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static double GetDocumentSizeMB(string file)
        {
            try
            {
                var sizeBytes = Convert.ToDouble(new FileInfo(file).Length);
                return new ByteSize(sizeBytes).MegaBytes;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DM] Error getting file size for {file}: {err}", file, ex.Message);
                return 0d;
            }
        }
    }
}
