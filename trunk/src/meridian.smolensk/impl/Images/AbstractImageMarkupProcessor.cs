using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smolensk.common.Infrastructure;
using HtmlAgilityPack;
using System.IO;

namespace meridian.smolensk.impl.Images
{
    public abstract class AbstractImageMarkupProcessor : IMarkupProcessor
    {
        public IMarkupProcessor Previous { get; set; }

        public string ImagesPhysicalPath { get; set; }

        public abstract void ProcessMarkup(HtmlDocument document);

        protected string GenerateThumbnail(ThumbnailGenerator generator, string originalFilePath,
            string imagesBasePath, string thumbnailName)
        {
            string thumbnailPathNoExtension = Path.Combine(imagesBasePath, thumbnailName);

            string fullThumbnailPath = generator.GenerateThumbnail(originalFilePath, thumbnailPathNoExtension);

            return Path.GetFileName(fullThumbnailPath);
        }
    }
}
