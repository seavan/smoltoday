using System;
using admin.db;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class photobank_categories : IDatabaseEntity, ILookupValue
    {

        public string PhotoUrl
        {
            get { return String.Format(Consts.PhotoUrlFormat, photo); }
        }

        public int lookup_value_level
        {
            get { return 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }
        public string lookup_title
        {
            get { return title; }
        }
    }
}
