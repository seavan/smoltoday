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
	public partial class meridian_companies_kind_activities : BaseUniversalController<companies_kind_activities>
	{
		public meridian_companies_kind_activities()
		{
		}
		protected override admin.db.IDataService<companies_kind_activities> GetService()
		{
			return Meridian.Default.companies_kind_activitiesStore;
		}
	}
}
