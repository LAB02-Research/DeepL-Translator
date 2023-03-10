using SmartReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

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
        internal static async Task<(bool success, bool isReadable, string content, string error)> GetReadableContentAsync(string url, bool isLocaLFile = false)
        {
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
                    return (true, false, article.Content, "unable to determine what part of the site is relevant text");
                }

                // yep
                return (true, true, article.Content, string.Empty);
            }
            catch (UriFormatException ex)
            {
                Log.Fatal(ex, "[URL] Unable to parse host '{url}': {err}", url, ex.Message);
                return (false, false, string.Empty, "provided url is in the wrong format");
            }
            catch (HttpRequestException ex)
            {
                Log.Fatal(ex, "[URL] Unable to contact host '{url}': {err}", url, ex.Message);

                if (ex.InnerException?.GetType() == typeof(SocketException))
                {
                    var exc = (SocketException)ex.InnerException;

                    return exc.SocketErrorCode switch
                    {
                        SocketError.HostNotFound => (false, false, string.Empty, "the remote host address wasn't found"),
                        SocketError.AccessDenied => (false, false, string.Empty, "access denied by the remote host"),
                        SocketError.TimedOut => (false, false, string.Empty, "the host didn't respond"),
                        SocketError.HostDown => (false, false, string.Empty, "the remote host is offline"),
                        SocketError.HostUnreachable or SocketError.NetworkUnreachable => (false, false, string.Empty, "the remote host couldn't be reached"),
                        SocketError.NotConnected => (false, false, string.Empty, "no internet connection"), 
                        _ => (false, false, string.Empty, $"error trying to contact the host: {exc.SocketErrorCode.ToString().ToLower()}")
                    };
                }

                var statusCode = ex.StatusCode.ToString();
                return !string.IsNullOrWhiteSpace(statusCode) 
                    ? (false, false, string.Empty, $"error trying to contact the host: {statusCode}") 
                    : (false, false, string.Empty, "unknown error trying to contact the host");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[URL] Unable to process host '{url}': {err}", url, ex.Message);
                return (false, false, string.Empty, "unknown error trying to contact the host");
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
    }
}
