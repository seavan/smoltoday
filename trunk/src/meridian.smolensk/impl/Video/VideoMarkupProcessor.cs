using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smolensk.common.Infrastructure;
using HtmlAgilityPack;
using meridian.smolensk.impl.Images;
using smolensk.common.Domain;
using System.IO;
using CuttingEdge.Conditions;
using meridian.smolensk.proto;

namespace meridian.smolensk.impl.Video
{
    public class VideoMarkupProcessor : AbstractImageMarkupProcessor
    {
        private NewsVideoHandler videoHandler;

        public VideoMarkupProcessor(NewsVideoHandler videoHandler)
        {
            Condition.Requires(videoHandler, "videoHandler").IsNotNull();

            this.videoHandler = videoHandler;
        }
        
        public ThumbnailGenerator ThumbnailGenerator { get; set; }

        public override void ProcessMarkup(HtmlDocument document)
        {
            HtmlNodeCollection embedNodes = SelectIframeNodes(document);

            IList<HtmlVideoInfo> videos = new List<HtmlVideoInfo>();
            if (embedNodes != null)
            {
                foreach (var node in embedNodes)
                {
                    var src = HtmlMarkupHelper.GetAttributeValue(node, "src");
                    Uri uri = HtmlMarkupHelper.CreateAbsoluteUri(src);

                    IVideoImageProvider imageProvider = null;
                    if (YoutubeImageProvider.CanHarvestUri(uri))
                        imageProvider = new YoutubeImageProvider();

                    if (imageProvider != null)
                    {
                        var id = HtmlMarkupHelper.GetAttributeValue(node, "id");
                        var guid = HtmlMarkupHelper.ParseGuid(id);

                        videos.Add(new HtmlVideoInfo(node, uri, guid, imageProvider));
                    }
                }
            }

            MergeResult<IEntity<Guid>> mergeResult = videoHandler.MergeVideos(videos);

            foreach (var video in mergeResult.ItemsToRemove.ToList())
                videoHandler.DeleteVideo(video.id);

            foreach (HtmlVideoInfo info in mergeResult.ItemsToAdd.ToList())
                CreateThumbnailsAndSaveVideo(info);
        }

        private void CreateThumbnailsAndSaveVideo(HtmlVideoInfo info)
        {
            Guid videoId = Guid.NewGuid();
            ImageNamingStrategy namingStrategy = new ImageNamingStrategy(videoId);

            string imagesBasePath = Path.Combine(ImagesPhysicalPath, videoHandler.EntityId.ToString());
            Directory.CreateDirectory(imagesBasePath);

            string originalExtension = info.ImageProvider.GetVideoImageExtension(info.Uri);
            string originalFilename = namingStrategy.GetOriginalImageFileName(originalExtension);
            string originalFilePath = Path.Combine(imagesBasePath, originalFilename);

            info.ImageProvider.DownloadVideoImage(info.Uri, originalFilePath);

            news_videos newsVideo = new news_videos();
            newsVideo.guid = videoId;
            newsVideo.original = originalFilename;
            newsVideo.url = info.Uri.ToString();

            newsVideo.small_thumbnail = GenerateThumbnail(ThumbnailGenerator, originalFilePath, 
                imagesBasePath, namingStrategy.GetSmallThumbnailName());

            info.Node.SetAttributeValue("id", videoId.ToString());

            videoHandler.InsertVideo(newsVideo);
        }

        private HtmlNodeCollection SelectIframeNodes(HtmlDocument document)
        {
            return document.DocumentNode.SelectNodes("//iframe");
        }
    }
}
