using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.system;
using CuttingEdge.Conditions;
using meridian.smolensk.proto;
using smolensk.common;
using smolensk.common.Domain;
using smolensk.common.Infrastructure;

namespace meridian.smolensk.impl.Images
{
    public class NewsImageHandler : EntityContentHandler
    {
        public NewsImageHandler(Meridian meridian, UrlBuilder urlBuilder, long newsId) : base(meridian, urlBuilder, newsId)
        {
        }

        public Uri GetUploadedImageUri(string imageFilename)
        {
            return urlBuilder.BuildNewsImageUri(EntityId, imageFilename);
        }

        public MergeResult<IEntity<Guid>> MergeImages(IEnumerable<IEntity<Guid>> newImages)
        {
            IEnumerable<IEntity<Guid>> currentImages = null;

            if (!meridian.newsStore.Exists(EntityId))
                currentImages = new List<IEntity<Guid>>(0);
            else
                currentImages = meridian.newsStore.Get(EntityId)
                    .GetNewsImages()
                    .Select(ni => new NewsImagesToEntityAdapter(ni));

            return MergeUtils.Merge(currentImages, newImages);
        }

        public void InsertImage(news_images image)
        {
            image.news_id = EntityId;
            meridian.news_imagesStore.Insert(image);
        }

        public void DeleteImage(Guid id)
        {
            var image = meridian.news_imagesStore.All().FirstOrDefault(ni => ni.news_id == EntityId && ni.guid.Equals(id));

            if (image != null)
                meridian.news_imagesStore.Delete(image);
        }

        private class NewsImagesToEntityAdapter : IEntity<Guid>
        {
            private news_images image;

            public NewsImagesToEntityAdapter(news_images image)
            {
                this.image = image;
            }

            public Guid id
            {
                get { return image.guid; }
            }
        }
    }
}