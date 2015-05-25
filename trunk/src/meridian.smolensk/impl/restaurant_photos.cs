using System.Collections.Generic;
using System.Linq;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class restaurant_photos : IAttachedPhoto
    {
        public long Id
        {
            get { return id; }
        }

        public string ThumbUrl
        {
            get { return Constants.RestaurantsDataFolder + this.normal; }
        }

        public string FullUrl
        {
            get { return Constants.RestaurantsDataFolder + this.normal; }
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
                return pr_photos_restaurants != null
                           ? pr_photos_restaurants.GetPhotos()
                           : new IAttachedPhoto[] {this}.AsEnumerable();
            }
        }


        public admin.db.IDatabaseEntity AttachedPhotoContainer
        {
            get { return pr_photos_restaurants;  }
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