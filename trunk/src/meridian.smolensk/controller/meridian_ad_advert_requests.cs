﻿/* Automatically generated codefile, Meridian
 * Generated by magic, please do not interfere
 * Please sleep well and do not smoke. Love, Sam */

using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using meridian.smolensk.proto;
using admin.web.common;

namespace meridian.smolensk.controller
{
	public partial class meridian_ad_advert_requests : BaseUniversalController<ad_advert_requests>
	{
		public meridian_ad_advert_requests()
		{
		}
		protected override admin.db.IDataService<ad_advert_requests> GetService()
		{
			return Meridian.Default.ad_advert_requestsStore;
		}
	}
}
