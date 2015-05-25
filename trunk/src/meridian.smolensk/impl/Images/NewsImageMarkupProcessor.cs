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
    public class NewsImageMarkupProcessor : AbstractImageMarkupProcessor
    {
        private NewsImageHandler imageHandler;

        public NewsImageMarkupProcessor(NewsImageHandler imageHandler)
        {
            Condition.Requires(imageHandler, "imageHandler").IsNotNull();

            this.imageHandler = imageHandler;
        }

        public ThumbnailGenerator SmallThumbnailGenerator { get; set; }
        public ThumbnailGenerator MediumThumbnailGenerator { get; set; }
        public ThumbnailGenerator LargeThumbnailGenerator { get; set; }
        public ThumbnailGenerator NormalThumbnailGenerator { get; set; }

        public string ProcessedText { get; private set; }

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
                    bool inline = IsInline(node);

                    Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
                    HtmlImageInfo info = new HtmlImageInfo(node, guid, uri, alt, inline);
                    images.Add(info);
                }
            }

            MergeResult<IEntity<Guid>> mergeResult = imageHandler.MergeImages(images);
            foreach (var image in mergeResult.ItemsToRemove.ToList())
                imageHandler.DeleteImage(image.id);

            foreach (HtmlImageInfo image in mergeResult.ItemsToAdd.ToList())
                CreateThumbnailsAndSaveImage(image);

            PrepareProcessedText(document);
        }

        private void PrepareProcessedText(HtmlDocument document)
        {
            HtmlDocument copy = new HtmlDocument();
            copy.LoadHtml(document.DocumentNode.OuterHtml);
            //copy.DocumentNode.CopyFrom(document.DocumentNode, true);
            var imageNodes = SelectImageNodes(copy);
            foreach (var node in imageNodes)
            {
                if (!IsInline(node))
                    node.Remove();
            }
            this.ProcessedText = copy.DocumentNode.OuterHtml;
        }

        private static HtmlNodeCollection SelectImageNodes(HtmlDocument document)
        {
            return document.DocumentNode.SelectNodes("//img");
        }

        private bool IsInline(HtmlNode imageNode)
        {
            //TODO: сделать определение принадлежности картинки к галерее через спец. атрибут
            return false;
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

            news_images newsImage = new news_images();
            newsImage.guid = imageId;
            newsImage.original = originalFilename;
            newsImage.url = image.Uri.ToString();
            newsImage.alt = image.Alt;
            newsImage.inline = image.IsInline;

            ImageDownloader downloader = new ImageDownloader();
            downloader.DownloadImage(originalImageUri, originalFilePath);

            newsImage.small_thumbnail = GenerateThumbnail(SmallThumbnailGenerator, originalFilePath, 
                imagesBasePath, namingStrategy.GetSmallThumbnailName());
            newsImage.medium_thumbnail = GenerateThumbnail(MediumThumbnailGenerator, originalFilePath,
                imagesBasePath, namingStrategy.GetMediumThumbnailName());
            newsImage.large_thumbnail = GenerateThumbnail(LargeThumbnailGenerator, originalFilePath,
                imagesBasePath, namingStrategy.GetLargeThumbnailName());
            newsImage.normal_thumbnail = GenerateThumbnail(NormalThumbnailGenerator, originalFilePath,
                imagesBasePath, namingStrategy.GetNormalThumbnailName());

            imageHandler.InsertImage(newsImage);

            image.Node.SetAttributeValue("id", imageId.ToString());
            image.Node.SetAttributeValue("src", 
                imageHandler.GetUploadedImageUri(newsImage.normal_thumbnail).ToString());
        }
    }
}