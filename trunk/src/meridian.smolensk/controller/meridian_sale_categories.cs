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
	public partial class meridian_sale_categories : BaseUniversalController<sale_categories>
	{
		public meridian_sale_categories()
		{
		}
		protected override admin.db.IDataService<sale_categories> GetService()
		{
			return Meridian.Default.sale_categoriesStore;
		}
	}
}
