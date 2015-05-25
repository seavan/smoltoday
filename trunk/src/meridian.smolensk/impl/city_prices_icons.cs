using System.ComponentModel.DataAnnotations;
using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class city_prices_icons : ILookupValue
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