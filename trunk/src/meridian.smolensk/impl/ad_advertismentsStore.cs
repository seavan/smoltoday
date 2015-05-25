using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using admin.db;

namespace meridian.smolensk.protoStore
{
    public partial class ad_advertismentsStore
    {
        void IDataService<ad_advertisments>.Delete(ad_advertisments advert)
        {
            if (advert != null)
                advert.Delete();
        }

        ad_advertisments IDataService<ad_advertisments>.CreateItem()
        {
            return new ad_advertisments()
            {
                created_date = DateTime.Now
            };
        }
    }
}
