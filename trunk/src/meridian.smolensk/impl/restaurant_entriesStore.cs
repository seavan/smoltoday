using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class restaurant_entriesStore
    {
        public IEnumerable<restaurant_entries> GetBy(long categoryId)
        {
            return All().Where(e => e.restaurant_entry_category_id == categoryId);
        }
    }
}
