using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
	public partial class photobank_obtainedStore : Meridian.IEntityStore, IDataService<photobank_obtained>
	{
		public IEnumerable<photobank_obtained> LoadUserObtainedPhotos(long accountId)
		{
		    return GetAll().Where(p => p.account_id == accountId);
		}
	}
}
