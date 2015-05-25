using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExifLib;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;

namespace smolensk.Mappers
{
    public static class PhotosMapper
    {
        public static PhotoListViewModel ToPhotoListViewModel(List<photobank_photos> entries, int page, int pageSize = Constants.PhotosPageSize)
        {
            int count = entries.Count;
            int size = count / pageSize + Convert.ToInt32(count % pageSize != 0);

            return new PhotoListViewModel
            {
                Photos = MappingUtils.TakePage(entries, page, pageSize),
                TotalPages = size,
                CurrentPage = page
            };
        }

        public static ProfileViewModel ToProfileViewModel(long accountId, int page, int pageSize = Constants.PhotosPageSize)
        {
            var result = new ProfileViewModel();
            var profile = Meridian.Default.accountsStore.Get(accountId);
            result.Profile = profile;
            var photos =
                Meridian.Default.photobank_photosStore.All().Where(item => item.account_id == accountId).ToList();
            result.PhotosList = ToPhotoListViewModel(photos, page, pageSize);
            result.PhotosList.Title = "Портфолио";

            return result;
        }

        public static PhotoViewModel ToPhotoViewModel(long photoId)
        {
            var result = new PhotoViewModel();
            var photo = Meridian.Default.photobank_photosStore.Get(photoId);
            var originalPhoto = Meridian.Default.photobank_related_photosStore.All()
                .First(item => item.photo_id == photoId && item.original);
            var relatedPhotosInfo = new Dictionary<photobank_licenses, List<RelatedPhotoViewModel>>();

            foreach (var license in Meridian.Default.photobank_licensesStore.All())
            {
                var photos = new List<RelatedPhotoViewModel>();

                foreach (var relPhoto in photo.GetPhotos())
                {
                    var price = Meridian.Default.photobank_photo_pricesStore.All().FirstOrDefault(item => item.rel_photo_id == relPhoto.id && item.license_id == license.id);

                    if (price != null)
                    {
                        photos.Add(new RelatedPhotoViewModel
                        {
                            PhotoId = relPhoto.id,
                            Height = relPhoto.height,
                            Width = relPhoto.width,
                            Price = price.price,
                            PriceId = price.id
                        });

                    }
                }

                relatedPhotosInfo.Add(license, photos.OrderByDescending(item => item.Width).ToList());
            }

            result.Photo = photo;
            result.OriginalPhoto = originalPhoto;
            result.RelatedPhotos = relatedPhotosInfo;
            result.Exif = GetExif(originalPhoto.photo);

            var relPhotos = Meridian.Default.photobank_photosStore.All()
                    .Where(item => item.title.Contains(photo.title) && item.title != photo.title);

            var tagsPhoto = new List<photobank_photos>();
            foreach (var tag in photo.Tags)
            {
                var photoIds = Meridian.Default.photobank_photo_tagsStore.All().Where(item =>
                    item.photo_id != photo.id && item.tag_id == tag.id).Select(item=>item.photo_id).ToList();
                photoIds.ForEach(item => tagsPhoto.Add(Meridian.Default.photobank_photosStore.Get(item)));
            }

            relPhotos = relPhotos.Union(tagsPhoto.Distinct()).Distinct().ToList();

            var relPhotosModel = new PhotoScrollViewModel
            {
                PhotoWidth = 56, 
                PhotoHeight = 40,
                PhotosCount = 4
            };

            UrlHelper helper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            foreach (var p in relPhotos)
            {
                relPhotosModel.Photos.Add(new RelatedPhoto
                {
                    Link = helper.Action("Image", "PhotoBank", new { p.id }),
                    PhotoUrl = p.PreviewUrl,
                    Title = p.title
                });
            }

            result.PhotoScrollModel = relPhotosModel;
            return result;
        }

        public static List<KeyValuePair<string, string>> GetExif(string filename)
        {
            var result = new List<KeyValuePair<string, string>>();
            var extension = Path.GetExtension(filename);

            if (extension != null && (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg"))
            {
                try
                {
                    var reader =
                    new ExifReader(HttpContext.Current.Server.MapPath(string.Format(Consts.PhotoUrlFormat, filename)));
                    var tags = new List<KeyValuePair<string, ExifTags>>
                {
                    new KeyValuePair<string, ExifTags>("Make", ExifTags.Make),
                    new KeyValuePair<string, ExifTags>("Model", ExifTags.Model),
                    new KeyValuePair<string, ExifTags>("XResolution", ExifTags.XResolution),
                    new KeyValuePair<string, ExifTags>("YResolution", ExifTags.YResolution),
                    new KeyValuePair<string, ExifTags>("DateTime", ExifTags.DateTime),
                    new KeyValuePair<string, ExifTags>("Artist", ExifTags.Artist),
                    new KeyValuePair<string, ExifTags>("Copyright", ExifTags.Copyright),
                    new KeyValuePair<string, ExifTags>("ExposureTime", ExifTags.ExposureTime),
                    new KeyValuePair<string, ExifTags>("FNumber", ExifTags.FNumber),
                    new KeyValuePair<string, ExifTags>("ISOSpeedRatings", ExifTags.ISOSpeedRatings),
                    new KeyValuePair<string, ExifTags>("ExposureBiasValue", ExifTags.ExposureBiasValue),
                    new KeyValuePair<string, ExifTags>("MeteringMode", ExifTags.MeteringMode),
                    new KeyValuePair<string, ExifTags>("Flash", ExifTags.Flash),
                    new KeyValuePair<string, ExifTags>("FocalLength", ExifTags.FocalLength)
                };

                    dynamic value;
                    foreach (var tag in tags)
                    {
                        reader.GetTagValue(tag.Value, out value);

                        if (value != null)
                            if (value != null)
                            {
                                result.Add(new KeyValuePair<string, string>(tag.Key, value.ToString()));
                            }
                    }
                }
                catch (Exception)
                {

                    return null;
                }
                
            }

            return result;
        }
    }
}