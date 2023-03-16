using System.Diagnostics.CodeAnalysis;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class StorageManager
    {
        /// <summary>
        /// Downloads the provided uri into the provided local file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localFile"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        internal static async Task<bool> DownloadFileAsync(string uri, string localFile)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    Log.Error("[STORAGE] Unable to download file: got an empty uri");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(localFile))
                {
                    Log.Error("[STORAGE] Unable to download file: got an empty local file");
                    return false;
                }

                if (!uri.ToLower().StartsWith("http"))
                {
                    Log.Error("[STORAGE] Unable to download file: only HTTP uri's are allowed, got: {uri}", uri);
                    return false;
                }

                var localFilePath = Path.GetDirectoryName(localFile);
                if (!Directory.Exists(localFilePath)) Directory.CreateDirectory(localFilePath!);

                // parse the uri as a check
                var safeUri = new Uri(uri);

                // download the file
                await DownloadRemoteFileAsync(safeUri.AbsoluteUri, localFile);

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[STORAGE] Error downloading file: {uri}", uri);
                return false;
            }
        }

        /// <summary>
        /// Downloads the provided URI to a local file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localFile"></param>
        /// <returns></returns>
        private static async Task<bool> DownloadRemoteFileAsync(string uri, string localFile)
        {
            try
            {
                if (File.Exists(localFile))
                {
                    File.Delete(localFile);
                    await Task.Delay(50);
                }

                // get a stream from our http client
                await using var stream = await Variables.HttpClient.GetStreamAsync(uri);

                // get a local file stream
                await using var fileStream = new FileStream(localFile!, FileMode.CreateNew);

                // transfer the data
                await stream.CopyToAsync(fileStream);

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("[STORAGE] Error while downloading file!\r\nRemote URI: {uri}\r\nLocal file: {localFile}\r\nError: {err}", uri, localFile, ex.Message);
                return false;
            }
        }
    }
}
