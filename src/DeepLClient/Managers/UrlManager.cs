using SmartReader;
using System.Net.Sockets;
using System.Text;
using Serilog;
using DeepLClient.Models;

namespace DeepLClient.Managers
{
    internal static class UrlManager
    {
        /// <summary>
        /// Attempts to load the url, and extract the relevant readable text
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isLocaLFile"></param>
        /// <returns></returns>
        internal static async Task<WebpageResult> GetReadableContentAsync(string url, bool isLocaLFile = false)
        {
            var webpageResult = new WebpageResult();

            try
            {
                // fetch the content if it's a local file, otherwise download it
                var reader = isLocaLFile 
                    ? new Reader(url, await File.ReadAllTextAsync(url)) 
                    : new Reader(url);
                
                // get the article
                var article = await reader.GetArticleAsync();
                
                // readable?
                if (!article.IsReadable)
                {
                    // nope
                    Log.Warning("[URL] Fetching readable text failed: {url}", url);
                    return webpageResult.SetReadableFailed(article.Content, article.Title);
                }
                
                // done
                return webpageResult.SetSuccess(article.Content, article.Title);
            }
            catch (UriFormatException ex)
            {
                Log.Fatal(ex, "[URL] Unable to parse host '{url}': {err}", url, ex.Message);
                return webpageResult.SetFailed("provided url is in the wrong format");
            }
            catch (HttpRequestException ex)
            {
                Log.Fatal(ex, "[URL] Unable to contact host '{url}': {err}", url, ex.Message);

                if (ex.InnerException?.GetType() == typeof(SocketException))
                {
                    var exc = (SocketException)ex.InnerException;

                    return exc.SocketErrorCode switch
                    {
                        SocketError.HostNotFound => webpageResult.SetFailed("the remote host address wasn't found"),
                        SocketError.AccessDenied => webpageResult.SetFailed("access denied by the remote host"),
                        SocketError.TimedOut => webpageResult.SetFailed("the host didn't respond"),
                        SocketError.HostDown => webpageResult.SetFailed("the remote host is offline"),
                        SocketError.HostUnreachable or SocketError.NetworkUnreachable => webpageResult.SetFailed("the remote host couldn't be reached"),
                        SocketError.NotConnected => webpageResult.SetFailed("no internet connection"), 
                        _ => webpageResult.SetFailed($"error trying to contact the host: {exc.SocketErrorCode.ToString().ToLower()}")
                    };
                }

                var statusCode = ex.StatusCode.ToString();
                return !string.IsNullOrWhiteSpace(statusCode)
                    ? webpageResult.SetFailed($"error trying to contact the host: {statusCode}")
                    : webpageResult.SetFailed("unknown error trying to contact the host");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Unable to process host '{url}': {err}", url, ex.Message);
                return webpageResult.SetFailed("unknown error trying to contact the host");
            }
        }

        /// <summary>
        /// Strips tags etc from the text.
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        internal static string CleanText(string rawText)
        {
            if (string.IsNullOrEmpty(rawText)) return string.Empty;

            if (rawText.StartsWith("\"")) rawText = rawText.Remove(0, 1);
            if (rawText.EndsWith("\"")) rawText = rawText.Remove(rawText.Length - 1, 1);

            rawText = rawText.Replace("\\n\\n", Environment.NewLine);
            rawText = rawText.Replace("\\n", Environment.NewLine);
            rawText = rawText.Replace("\\\"", "\"");

            return rawText;
        }

        /// <summary>
        /// Checks if the value contains an url
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static bool IsUrl(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.ToLower().StartsWith("http");
        }

        /// <summary>
        /// Checks if the value contains an uri to a local or network file
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static bool IsLocalOrNetworkFile(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return value.Substring(1, 2) == ":\\" || value[..2] == "\\\\";
        }

        /// <summary>
        /// Wraps the provided content into a reading mode html page, and adds the title
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        internal static string WrapContentInHtml(string content, string title)
        {
            var htmlContent = new StringBuilder();
            htmlContent.AppendLine("<html>");
            htmlContent.AppendLine("<head>");
            htmlContent.AppendLine($"<title>{title}</title>");
            htmlContent.AppendLine("<style>");
            htmlContent.AppendLine("a:active, a:hover, a:link, a:visited { color: #6590fd }");
            htmlContent.AppendLine("body::-webkit-scrollbar { width: 12px }");
            htmlContent.AppendLine("body::-webkit-scrollbar-corner { background: #3f3f46 }");
            htmlContent.AppendLine("body::-webkit-scrollbar-track { background: #3f3f46 }");
            htmlContent.AppendLine("body::-webkit-scrollbar-thumb { background-color: #3f3f46; border-radius: 2px; border: 1px solid #646464 }");
            htmlContent.AppendLine("</style>");
            htmlContent.AppendLine("</head>");
            htmlContent.AppendLine("<body style=\"background-color: #3f3f46; color: #f1f1f1;\">");
            htmlContent.AppendLine(content);
            htmlContent.AppendLine("</body>");
            htmlContent.AppendLine("</html>");

            return htmlContent.ToString();
        }
    }
}
