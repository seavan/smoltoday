using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.common.Infrastructure;
using smolensk.common;

namespace meridian.smolensk.impl.Images
{
    public class NewsImageMarkupProcessorSettings
    {
        public NewsImageMarkupProcessorSettings()
        {
            ImagesVirtualPath = "~" + Constants.NewsDataFolder;
        }

        public ThumbnailGenerator SmallThumbnailGenerator { get; set; }
        public ThumbnailGenerator MediumThumbnailGenerator { get; set; }
        public ThumbnailGenerator LargeThumbnailGenerator { get; set; }
        public ThumbnailGenerator NormalThumbnailGenerator { get; set; }
        
        public string ImagesVirtualPath { get; set; }
    }
}