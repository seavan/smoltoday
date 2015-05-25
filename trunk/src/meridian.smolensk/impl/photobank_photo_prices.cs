using admin.db;
using meridian.smolensk.system;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    public partial class photobank_photo_prices : IDatabaseEntity
    {
        public photobank_photos Photo
        {
            get
            {
                return pb_prices_photos_photobank_related_photos != null ? pb_prices_photos_photobank_related_photos.GetPhotosPhotobank_photo() : null;
            }
        }

        public IEnumerable<photobank_licenses> AllLicenses()
        {
            return Meridian.Default.photobank_licensesStore.All();
        }
    }
}
