using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Script.Serialization;
using admin.db;
using meridian.smolensk.impl.Aspects;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class photobank_photos : IDatabaseEntity, IMarkable, IImageByTheme, IAttachedPhotoAspectProvider, ILookupValueAspectProvider
    {
        public string PreviewMainUrl
        {
            get { return !string.IsNullOrEmpty(preview_main) ? String.Format(Consts.PhotoUrlFormat, preview_main) : preview_main; }
        }
        public string PreviewUrl
        {
            get { return !string.IsNullOrEmpty(preview) ? String.Format(Consts.PhotoUrlFormat, preview) : preview; }
        }

        public string PreviewSquareUrl
        {
            get { return !string.IsNullOrEmpty(preview_square) ? String.Format(Consts.PhotoUrlFormat, preview_square) : preview_square; }
        }

        public accounts Account
        {
            get { return Meridian.Default.accountsStore.Exists(account_id) ?
                Meridian.Default.accountsStore.Get(account_id) : Meridian.Default.accountsStore.All().First();
            }
        }

        public photobank_categories Category
        {
            get { return Meridian.Default.photobank_categoriesStore.Exists(category_id) ?
                Meridian.Default.photobank_categoriesStore.Get(category_id) :
                Meridian.Default.photobank_categoriesStore.All().First();
            }
        }

        public List<photobank_tags> Tags
        {
            get
            {
                return PhotoTags.Select(t => t.GetTagsPhotoTagsPhotobank_tag()).ToList();
            }
        }

        [ScriptIgnore]
        public photobank_related_photos MainPhoto
        {
            get
            {
                return Photos.FirstOrDefault(i => i.original);
            }
        } 

        public void SetMark(IMark mark)
        {
            photobank_photos_rating photoRating = Meridian.Default.photobank_photos_ratingStore.All().FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.photo_id == mark.MaterialId);

            if (photoRating == null)
            {
                photoRating = new photobank_photos_rating
                {
                    account_id = mark.AuthorId,
                    create_date = mark.CreateDate,
                    rating = mark.CMark,
                    photo_id = id
                };

                Meridian.Default.photobank_photos_ratingStore.Insert(photoRating);
            }
            else
            {
                photoRating.rating = mark.CMark;
                photoRating.create_date = mark.CreateDate;
                Meridian.Default.photobank_photos_ratingStore.Update(photoRating);
            }

            rating = GetRating();
            Meridian.Default.photobank_photosStore.Update(this);
        }

        public int GetRating()
        {
            var photoRatings = Meridian.Default.photobank_photos_ratingStore.All().Where(item => item.photo_id == id).ToList();

            return photoRatings.Any()
                ? (int)Math.Floor((double)(photoRatings.Sum(m => m.rating) / photoRatings.Count))
                : 0;
        }
        public int GetCountMarks()
        {
            var marks = Meridian.Default.photobank_photos_ratingStore.All().Where(m => m.photo_id.Equals(this.id));
            int count = marks.Count();
            return count <= 0 ? 0 : count;
        }

        public Uri ItemUri()
        {
            string uri = string.Format("/PhotoBank/Image/{0}/{1}", this.id, this.title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
        

        #region IImageByTheme Implementation
        public Uri GetItemThemeUri()
        {
            return ItemUri();
        }

        public Uri GetImgItemThemeUri()
        {
            return new Uri(this.PreviewUrl, UriKind.Relative);
        }
        public Uri GetImgThumbnailItemThemeUri()
        {
            return new Uri(this.PreviewSquareUrl, UriKind.Relative);
        }
        #endregion

        #region Implementation of IAttachedPhotoAspectProvider
        public IAttachedPhotoAspect GetAttachedPhotoAspect(string _fieldName)
        {
            return new PhotoBanksPhotosAspect(this);
        }
        #endregion

        #region Implementation of ILookupValueAspectProvider
        public ILookupValueAspect Getalbum_idLookupValueAspect()
        {
            return new LookupAspect("album_id", this, () => { return Meridian.Default.photobank_user_albumsStore.All(); });
        }

        public ILookupValueAspect Getcategory_idLookupValueAspect()
        {
            return new LookupAspect("category_id", this, () => { return Meridian.Default.photobank_categoriesStore.All(); }, false);
        }
        #endregion
    }
}
