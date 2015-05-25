using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class sale_categories : ILookupValue
    {
        public int lookup_value_level
        {
            get { return 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }

        public int GetSalesCount()
        {
            return Meridian.Default.salesStore.All().Count(s => s.category_id == this.id);
        }
        public string lookup_title
        {
            get { return title; }
        }
    }
}