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
	public partial class meridian_ad_field_descriptions : BaseUniversalController<ad_field_descriptions>
	{
		public meridian_ad_field_descriptions()
		{
		}
		protected override admin.db.IDataService<ad_field_descriptions> GetService()
		{
			return Meridian.Default.ad_field_descriptionsStore;
		}
	}
}
