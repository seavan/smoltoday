using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using meridian.smolensk.proto;
using admin.db;
using meridian.smolensk.system;
using meridian.smolensk.impl.Images;
using smolensk.common.Infrastructure;
using smolensk.common;
using meridian.smolensk.impl.Video;

namespace meridian.smolensk.protoStore
{
    public partial class newsStore : IDataService<news>
    {
        public IEnumerable<news> LoadNewsByPublishDate(DateTime date)
        {
            return GetAllVisible().Where(n => n.publish_date.Date == date).OrderByDescending(n => n.publish_date);
        }

        public IEnumerable<news> LoadNewsByPublishDate(DateRange date)
        {
            return GetAllVisible().Where(n => n.publish_date.Date >= date.fromDate && n.publish_date <= date.toDate).OrderByDescending(n => n.publish_date);
        }

        public IEnumerable<news> LoadNewsByCategory(long categoryId, DateTime? date = null)
        {
            if (date.HasValue)
            {
                return GetAllVisible().Where(n => n.category_id == categoryId && n.publish_date.Date == date).OrderByDescending(s => s.publish_date);
            }

            return GetAllVisible().Where(n => n.category_id == categoryId).OrderByDescending(s => s.publish_date);
        }

        public IEnumerable<news> LoadPopularNews(int count = 12, long categoryId = -1)
        {
            IEnumerable<news> all = GetAllVisible();
            if (categoryId > 0)
            {
                all = all.Where(n => n.category_id == categoryId);
            }

            return all.OrderByDescending(n => n.views).Take(count);
        }

        public IEnumerable<news> LoadBuzzedNews(int count = 6)
        {
            return GetAllVisible().OrderByDescending(n => n.comment_count).Take(count);
        }

        public IEnumerable<news> LoadMainNews(int count = 3)
        {
            return GetAllVisible().Where(n => n.is_main && n.GetNewsImages().Count() > 0).OrderByDescending(n => n.publish_date).Take(count);
        }

        public IEnumerable<IMainSlider> LoadSliderMainNews(int count = 3)
        {
            return GetAllVisible().Where(n => n.is_main/* && n.NewsVideo.Count() <= 0*/ && n.GetNewsImages().Count() > 0).OrderByDescending(n => n.publish_date).Take(count);
        }

        public IEnumerable<news> LoadLastNews(int count = 6, long categoryId = -1)
        {
            IEnumerable<news> all = GetAllVisible();
            if (categoryId > 0)
            {
                all = all.Where(n => n.category_id == categoryId);
            }
            return all.OrderByDescending(n => n.publish_date).Take(count);
        }

        public IEnumerable<news> LoadCityNews(int count = 6)
        {
            return GetAllVisible().Where(n => n.is_smolensk_news).OrderByDescending(i => i.publish_date).Take(count);
        }

        public IEnumerable<news> GetAllVisible()
        {
            var now = DateTime.Now.Date;
            return All().Where(n => n.publish_date.Date <= now);
        }

        void IDataService<news>.Insert(news item)
        {
            Insert(item);

            ProcessNewsTextImagesAndVideos(item);
        }

        void IDataService<news>.Delete(news item)
        {
            DeleteReferencedObjects(item);

            Delete(item);
        }

        private void DeleteReferencedObjects(news item)
        {
            var comments = item.NewsComments.ToList();
            foreach (var comment in comments)
                item.RemoveNewsComments(comment, true);

            var images = item.NewsImages.ToList();
            foreach (var image in images)
                item.RemoveNewsImages(image, true);

            var videos = item.NewsVideo.ToList();
            foreach (var video in videos)
                item.RemoveNewsVideo(video, true);
        }

        news IDataService<news>.CreateItem()
        {
            return new news()
                {
                    publish_date = DateTime.Now,
                    create_date = DateTime.Now
                };
        }


        void IDataService<news>.Update(news item)
        {
            Persist(item);

            ProcessNewsTextImagesAndVideos(item);
        }

        private void ProcessNewsTextImagesAndVideos(news item)
        {
            // создаем и настраиваем обработчик картинок
            NewsImageMarkupProcessorSettings imageProcessorSettings = ServiceLocator.Instance.Locate<NewsImageMarkupProcessorSettings>();
            UrlBuilder urlBuilder = ServiceLocator.Instance.Locate<UrlBuilder>();
            NewsImageHandler imageHandler = new NewsImageHandler(Meridian.Default, urlBuilder, item.id);
            NewsImageMarkupProcessor imageMarkupProcessor = new NewsImageMarkupProcessor(imageHandler);
            imageMarkupProcessor.SmallThumbnailGenerator = imageProcessorSettings.SmallThumbnailGenerator;
            imageMarkupProcessor.MediumThumbnailGenerator = imageProcessorSettings.MediumThumbnailGenerator;
            imageMarkupProcessor.LargeThumbnailGenerator = imageProcessorSettings.LargeThumbnailGenerator;
            imageMarkupProcessor.NormalThumbnailGenerator = imageProcessorSettings.NormalThumbnailGenerator;
            imageMarkupProcessor.ImagesPhysicalPath = HttpContext.Current.Server.MapPath(imageProcessorSettings.ImagesVirtualPath);

            // создаем и настраиваем обработчик видео
            VideoMarkupProcessorSettings videoProcessorSettings = ServiceLocator.Instance.Locate<VideoMarkupProcessorSettings>();
            NewsVideoHandler videoHandler = new NewsVideoHandler(Meridian.Default, urlBuilder, item.id);
            VideoMarkupProcessor videoMarkupProcessor = new VideoMarkupProcessor(videoHandler);
            videoMarkupProcessor.ThumbnailGenerator = videoProcessorSettings.ThumbnailGenerator;
            videoMarkupProcessor.ImagesPhysicalPath = HttpContext.Current.Server.MapPath(videoProcessorSettings.ImagesVirtualPath);

            // выстраиваем обработчики в chain of responsibility
            imageMarkupProcessor.Previous = videoMarkupProcessor;

            HtmlDomTransformer transformer = new HtmlDomTransformer();
            transformer.MarkupProcessorChain = imageMarkupProcessor;
            item.text = transformer.Transform(item.text);
            item.processed_text = imageMarkupProcessor.ProcessedText;

            Update(item);
        }
    }
}
