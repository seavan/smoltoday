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
	public partial class photobank_photos_ratingStore : Meridian.IEntityStore, IDataService<photobank_photos_rating>
	{
        public IEnumerable<IMarkableMaterial> LoadUserMarks(long account_id)
        {
            return GetAll().Where(c => c.account_id == account_id);
        }
	}
}
