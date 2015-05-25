using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class accounts_favoritesStore
    {
        public IEnumerable<sales> GetSales(long account_id)
        {
            var ss = Meridian.Default.salesStore;
            return All().Where(f => f.account_id == account_id && f.sale_id > 0 && ss.Exists(f.sale_id))
                .Select(f => ss.Get(f.sale_id));
        }
    }
}
