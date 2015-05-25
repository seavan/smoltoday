using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smolensk.common.Infrastructure;
using smolensk.common;

namespace meridian.smolensk.impl.Video
{
    public class VideoMarkupProcessorSettings
    {
        public VideoMarkupProcessorSettings()
        {
            ImagesVirtualPath = "~" + Constants.NewsDataFolder;
        }

        public ThumbnailGenerator ThumbnailGenerator { get; set; }

        public string ImagesVirtualPath { get; set; }
    }
}
