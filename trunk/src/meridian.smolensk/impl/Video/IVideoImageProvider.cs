using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.impl.Video
{
    public interface IVideoImageProvider
    {
        string GetVideoImageExtension(Uri videoUri);
        void DownloadVideoImage(Uri videoUri, string imageFilePath);
    }
}
