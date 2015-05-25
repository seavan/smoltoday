using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{


    public partial class sale_types : ILookupValue
    {
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