using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.common.Infrastructure;
using smolensk.common;

namespace meridian.smolensk.impl.Images
{
    public class BlogsImageMarkupProcessorSettings
    {
        public BlogsImageMarkupProcessorSettings()
        {
            ImagesVirtualPath = "~" + Constants.BlogsDataFolder;
        }

        public ThumbnailGenerator ListThumbnailGenerator { get; set; }
        public ThumbnailGenerator NormalThumbnailGenerator { get; set; }
        
        public string ImagesVirtualPath { get; set; }
    }
}