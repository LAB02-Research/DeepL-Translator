namespace DeepLClient.Models
{
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
