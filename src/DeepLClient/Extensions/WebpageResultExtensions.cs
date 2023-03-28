using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLClient.Models;

namespace DeepLClient.Extensions
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
}
