﻿using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using meridian.smolensk.proto;
using admin.db;

namespace meridian.smolensk.protoStore
{
	public partial class restaurant_ratingStore : Meridian.IEntityStore, IDataService<restaurant_rating>
	{
        public IEnumerable<IMarkableMaterial> LoadUserMarks(long account_id)
        {
            return GetAll().Where(c => c.account_id == account_id);
        }
	}
}