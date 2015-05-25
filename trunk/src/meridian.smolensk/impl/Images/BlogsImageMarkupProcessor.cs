using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CuttingEdge.Conditions;
using HtmlAgilityPack;
using meridian.smolensk.proto;
using smolensk.common.Domain;
using smolensk.common.Infrastructure;

namespace meridian.smolensk.impl.Images
{
    public class BlogsImageMarkupProcessor : AbstractImageMarkupProcessor
    {
        private BlogsImageHandler imageHandler;

        public BlogsImageMarkupProcessor(BlogsImageHandler imageHandler)
        {
            Condition.Requires(imageHandler, "imageHandler").IsNotNull();

            this.imageHandler = imageHandler;
        }

        public ThumbnailGenerator ListThumbnailGenerator { get; set; }
        public ThumbnailGenerator NormalThumbnailGenerator { get; set; }

        public override void ProcessMarkup(HtmlDocument document)
        {
            IList<HtmlImageInfo> images = new List<HtmlImageInfo>();
            HtmlNodeCollection imageNodes = SelectImageNodes(document);
            if (imageNodes != null)
            {
                foreach (var node in imageNodes)
                {
                    string id = HtmlMarkupHelper.GetAttributeValue(node, "id");
                    string alt = HtmlMarkupHelper.GetAttributeValue(node, "alt");
                    string url = HtmlMarkupHelper.GetAttributeValue(node, "src");

                    if (string.IsNullOrEmpty(url))
                        continue;

                    Guid guid = HtmlMarkupHelper.ParseGuid(id);

                    Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
                    HtmlImageInfo info = new HtmlImageInfo(node, guid, uri, alt, false);
                    images.Add(info);
                }
            }

            MergeResult<IEntity<Guid>> mergeResult = imageHandler.MergeImages(images);
            foreach (var image in mergeResult.ItemsToRemove.ToList())
                imageHandler.DeleteImage(image.id);

            foreach (HtmlImageInfo image in mergeResult.ItemsToAdd.ToList())
                CreateThumbnailsAndSaveImage(image);
        }

        private static HtmlNodeCollection SelectImageNodes(HtmlDocument document)
        {
            return document.DocumentNode.SelectNodes("//img");
        }

        private void CreateThumbnailsAndSaveImage(HtmlImageInfo image)
        {
            Uri originalImageUri = imageHandler.GetAbsoluteImageUri(image.Uri.ToString());
            Guid imageId = Guid.NewGuid();
            ImageNamingStrategy namingStrategy = new ImageNamingStrategy(imageId);

            string imagesBasePath = Path.Combine(ImagesPhysicalPath, imageHandler.EntityId.ToString());
            Directory.CreateDirectory(imagesBasePath);

            string originalExtension = Path.GetExtension(originalImageUri.AbsolutePath.ToString());
            string originalFilename = namingStrategy.GetOriginalImageFileName(originalExtension);
            string originalFilePath = Path.Combine(imagesBasePath, originalFilename);

            blog_photos newsImage = new blog_photos();
            newsImage.guid = imageId;
            newsImage.original = originalFilename;
            newsImage.url = image.Uri.ToString();
            newsImage.alt = image.Alt;
            
            ImageDownloader downloader = new ImageDownloader();
            downloader.DownloadImage(originalImageUri, originalFilePath);

            newsImage.list_thumbnail = GenerateThumbnail(ListThumbnailGenerator, originalFilePath, 
                imagesBasePath, namingStrategy.GetSmallThumbnailName());
            newsImage.normal_thumbnail = GenerateThumbnail(NormalThumbnailGenerator, originalFilePath,
                imagesBasePath, namingStrategy.GetNormalThumbnailName());

            imageHandler.InsertImage(newsImage);

            image.Node.SetAttributeValue("id", imageId.ToString());
            image.Node.SetAttributeValue("src", 
                imageHandler.GetUploadedImageUri(newsImage.normal_thumbnail).ToString());
        }
    }
}