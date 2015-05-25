using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using smolensk.common.Infrastructure;

namespace meridian.smolensk.impl.Video
{
    public class YoutubeImageProvider : IVideoImageProvider
    {
        private const string YotubeHostName = "youtube.com";

        public static bool CanHarvestUri(Uri uri)
        {
            return IsYoutubeHost(uri);
        }

        public string GetVideoImageExtension(Uri videoUri)
        {
            return ".jpg";
        }

        public void DownloadVideoImage(Uri videoUri, string imageFilePath)
        {
            string videoId = null;
            if (IsYoutubeHost(videoUri))
                videoId = ExtractVideoId(videoUri);

            if (string.IsNullOrEmpty(videoId))
                throw new ArgumentException(
                    string.Format("Failed to extract video id from uri '{0}'", videoUri),
                        "videoUri");

            Uri imageUri = new Uri(string.Format("http://img.youtube.com/vi/{0}/0.jpg", videoId));

            var downloader = new ImageDownloader();
            downloader.DownloadImage(imageUri, imageFilePath);
        }

        private static bool IsYoutubeHost(Uri uri)
        {
            return uri.Host.Contains(YotubeHostName);
        }

        private static string ExtractVideoId(Uri videoUri)
        {
            string[] pathItems = videoUri.AbsolutePath.Split('/');

            return pathItems[2];
        }
    }
}
