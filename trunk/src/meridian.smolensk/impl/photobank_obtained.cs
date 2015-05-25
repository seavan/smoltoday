using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;

namespace meridian.smolensk.proto
{
	public partial class photobank_obtained : IDatabaseEntity
	{
        public photobank_photo_prices GetPhotoPrices()
        {
            return Meridian.Default.photobank_photo_pricesStore.GetAll().FirstOrDefault(p => p.id == this.price_id);
        }
	}
}
