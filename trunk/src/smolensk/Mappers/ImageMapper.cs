using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using meridian.smolensk.proto;
using smolensk.Domain;
using meridian.smolensk.system;
using smolensk.common;

namespace smolensk.Mappers
{
    public static class ImageMapper
    {
        private const string EmptyImageName = "emptyImage.gif";

        private static readonly ImageViewModel EmptyImage = new ImageViewModel(0)
        {
            SmallThumbnail = CreateEmptyPicture(),
            MediumThumbnail = CreateEmptyPicture(),
            LargeThumbnail = CreateEmptyPicture(),
            NormalThumbnail = CreateEmptyPicture(),
            OriginalImage = CreateEmptyPicture()
        };

        public static ICollection<ImageViewModel> ToImages(long newsId)
        {
            var images = Meridian.Default.news_imagesStore.LoadImages(newsId);

            return ToImages(images);
        }

        public static ICollection<ImageViewModel> ToImages(IEnumerable<news_images> images)
        {
            List<ImageViewModel> result = new List<ImageViewModel>();
            bool emptyImagesCollection = true;
            foreach (var image in images)
            {
                ImageViewModel model = ToSingleImage(image);
                result.Add(model);
                emptyImagesCollection = false;
            }

            if (emptyImagesCollection)
                result.Add(EmptyImage);
            
            return result;
        }

        public static ImageViewModel ToSingleImage(news_images image)
        {
            ImageViewModel result = new ImageViewModel(image.id);
            
            result.OriginalImage = CreateNewsPicture(image.news_id, image.original);
            result.LargeThumbnail = CreateNewsPicture(image.news_id, image.large_thumbnail);
            result.MediumThumbnail = CreateNewsPicture(image.news_id, image.medium_thumbnail);
            result.SmallThumbnail = CreateNewsPicture(image.news_id, image.small_thumbnail);
            result.NormalThumbnail = CreateNewsPicture(image.news_id, image.normal_thumbnail);
            result.Description = image.description;
            result.Alt = image.alt;

            return result;
        }

        private static Picture CreateNewsPicture(long newsId, string imageFilename)
        {
            if (string.IsNullOrEmpty(imageFilename))
                return CreateEmptyPicture();

            UrlBuilder urlBuilder = new UrlBuilder();
            
            return Picture.Create(urlBuilder.BuildNewsImageUri(newsId, imageFilename));
        }

        private static Picture CreateEmptyPicture()
        {
            return Picture.Create(VirtualPathUtility.Combine(Constants.NewsDataFolder, EmptyImageName));
        }
    }
}