using System.Collections.Generic;
using System.IO;
using System.Linq;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class ad_photos : IAttachedPhoto
    {
        //уменьшенное изображение 80x52px
        public string PreviewUrl
        {
            get { return Constants.AdvertsDataFolder + preview; }
        }

        //нормальное изображение 330x220px
        public string PhotoUrl
        {
            get { return Constants.AdvertsDataFolder + photo; }
        }

        public void Delete()
        {
            Meridian.Default.ad_photosStore.Delete(this);

            if (File.Exists(FileSystemFolders.AdvertPhotoFolder + preview))
            {
                File.Delete(FileSystemFolders.AdvertPhotoFolder + preview);
            }

            if (File.Exists(FileSystemFolders.AdvertPhotoFolder + photo))
            {
                File.Delete(FileSystemFolders.AdvertPhotoFolder + photo);
            }
        }

        public long Id
        {
            get { return id; }
        }

        public string ThumbUrl
        {
            get { return PreviewUrl; }
        }

        public string FullUrl
        {
            get { return PhotoUrl; }
        }


        public bool IsMain
        {
            get { return is_main; }
            set { is_main = value; }
        }


        public IEnumerable<IAttachedPhoto> SiblingsInclusive
        {
            get
            {
                return new IAttachedPhoto[] { this }.AsEnumerable();
            }
        }


        public admin.db.IDatabaseEntity AttachedPhotoContainer
        {
            get { return adverts_ad_photos_ad_advertisments; }
        }

        public bool ShowIsMain
        {
            get { return true; }
        }

        public string EditLink
        {
            get { return null; }
        }
    }
}
