using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class ad_categoriesStore
    {
        public IEnumerable<ad_categories> GetRootCategories()
        {
            return Meridian.Default.ad_categoriesStore.All().Where(item => item.parent_id == 0);
        }
    }
}
