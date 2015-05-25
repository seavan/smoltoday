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
    public class BlogsImageHandler : EntityContentHandler
    {
        public BlogsImageHandler(Meridian meridian, UrlBuilder urlBuilder, long blogId) : base(meridian, urlBuilder, blogId)
        {
        }

        public Uri GetUploadedImageUri(string imageFilename)
        {
            return urlBuilder.BuildBlogsImageUri(EntityId, imageFilename);
        }

        public MergeResult<IEntity<Guid>> MergeImages(IEnumerable<IEntity<Guid>> newImages)
        {
            IEnumerable<IEntity<Guid>> currentImages = null;

            if (!meridian.blogsStore.Exists(EntityId))
                currentImages = new List<IEntity<Guid>>(0);
            else
                currentImages = meridian.blog_photosStore.All()
                    .Where(ni => ni.blog_id == EntityId)
                    .Select(ni => new BlogsImagesToEntityAdapter(ni));

            return MergeUtils.Merge(currentImages, newImages);
        }

        public void InsertImage(blog_photos image)
        {
            image.blog_id = EntityId;
            meridian.blog_photosStore.Insert(image);
        }

        public void DeleteImage(Guid id)
        {
            var image = meridian.blog_photosStore.All()
                .Where(ni => ni.blog_id == EntityId && ni.guid.Equals(id)).FirstOrDefault();

            if (image != null)
                meridian.blog_photosStore.Delete(image);
        }

        private class BlogsImagesToEntityAdapter : IEntity<Guid>
        {
            private blog_photos image;

            public BlogsImagesToEntityAdapter(blog_photos image)
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