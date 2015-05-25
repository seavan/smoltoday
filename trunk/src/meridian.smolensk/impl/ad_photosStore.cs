using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using admin.db;
using meridian.smolensk;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
	public partial class ad_photosStore
	{
        ad_photos IDataService<ad_photos>.CreateItem()
        {
            return new ad_photos()
            {
                create_date = DateTime.Now
            };
        }

        //void IDataService<ad_photos>.Delete(ad_photos ad_p)
        //{
        //    if(ad_p!=null)
        //    {
        //        ad_p.Delete();
        //    }
        //}

	}
}
