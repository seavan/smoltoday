using System;
using System.IO;
using System.Net;

namespace smolensk.common.Infrastructure
{
    public class ImageDownloader
    {
        private const int RequestTimeout = 5 * 60 * 1000;

        public void DownloadImage(Uri imageUri, string filePath)
        {
            byte[] imageBytes = GetImage(imageUri);
            WriteDownImageFile(imageBytes, filePath);
        }

        private void WriteDownImageFile(byte[] imageBytes, string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                writer.Write(imageBytes);
        }

        private byte[] GetImage(Uri imageUri)
        {
            WebResponse response = MakeRequest(imageUri);

            byte[] imageBytes = new byte[response.ContentLength];

            using (Stream stream = response.GetResponseStream())
            {
                int currentOffset = 0;
                int bytesRead = int.MaxValue;

                for (bytesRead = int.MaxValue; bytesRead > 0; currentOffset += bytesRead)
                    bytesRead = stream.Read(imageBytes, currentOffset, (int)response.ContentLength - currentOffset);
            }

            return imageBytes;
        }

        private WebResponse MakeRequest(Uri pageUri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUri);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; WOW64; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; InfoPath.2; .NET CLR 3.5.21022)";
            request.Accept = "Accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/msword, application/xaml+xml, application/vnd.ms-xpsdocument, application/x-ms-xbap, application/x-ms-application, */*";
            request.Timeout = RequestTimeout;

            return request.GetResponse();
        }
    }
}