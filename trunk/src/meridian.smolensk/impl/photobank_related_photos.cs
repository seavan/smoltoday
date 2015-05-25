using System;
using System.IO;
using admin.db;
using meridian.smolensk.system;
using System.Linq;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class photobank_related_photos : IDatabaseEntity, IAttachedPhoto
    {
        public string PhotoUrl
        {
            get { return String.Format(Consts.PhotoUrlFormat, photo); }
        }

        public void Delete()
        {
            Meridian.Default.photobank_related_photosStore.Delete(this);

            if (File.Exists(FileSystemFolders.PhotoFolder + photo))
            {
                File.Delete(FileSystemFolders.PhotoFolder + photo);
            }
        }

        #region Implementation of IAttachedPhoto
        public long Id
        {
            get { return id; }
        }

        public string ThumbUrl
        {
            get { return String.Format(Consts.PhotoUrlFormat, GetPhotosPhotobank_photo().preview); }
        }

        public string FullUrl
        {
            get { return PhotoUrl; }
        }


        public bool IsMain
        {
            get { return original; }
            set { original = value; }
        }

        public IDatabaseEntity AttachedPhotoContainer
        {
            get { return pb_photos_photobank_photos; }
        }

        public bool ShowIsMain
        {
            get { return true; }
        }

        public string EditLink
        {
            get { return String.Format("/PhotoBankPhotosAdmin/Single/{0}", id); }
        }
        #endregion
    }
}
