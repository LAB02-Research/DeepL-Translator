namespace DeepLClient.Models
{
    public static class WebpageResultExtensions
    {
        public static WebpageResult SetReadableFailed(this WebpageResult webpageResult, string content, string title)
        {
            webpageResult.Success = true;
            webpageResult.IsReadable = false;
            webpageResult.Content = content;
            webpageResult.Title = title;
            webpageResult.Error = "unable to determine what part of the site is relevant text";

            return webpageResult;
        }

        public static WebpageResult SetSuccess(this WebpageResult webpageResult, string content, string title)
        {
            webpageResult.Success = true;
            webpageResult.IsReadable = true;
            webpageResult.Content = content;
            webpageResult.Title = title;

            return webpageResult;
        }

        public static WebpageResult SetFailed(this WebpageResult webpageResult, string error)
        {
            webpageResult.Success = false;
            webpageResult.IsReadable = false;
            webpageResult.Error = error;

            return webpageResult;
        }
    }

    public class WebpageResult
    {
        public WebpageResult()
        {
            //
        }

        public bool Success { get; set; }
        public bool IsReadable { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }
}
