using System;
using System.Collections.Generic;
using System.Linq;
using admin.db;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class company_photos : IAttachedPhoto
    {
        public long Id
        {
            get { return id; }
        }
        public string ThumbUrl
        {
            get { return Constants.CompaniesDataFolder + this.normal; }
        }

        public string FullUrl
        {
            get { return Constants.CompaniesDataFolder + this.normal; }
        }


        public bool IsMain
        {
            get { return is_main; }
            set { is_main = value; }
        }



        public admin.db.IDatabaseEntity AttachedPhotoContainer
        {
            get { return GetPhotosCompanie(); }
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