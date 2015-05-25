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
    public partial class companiesStore : Meridian.IEntityStore, IDataService<companies>, IGeolocationAware
	{
        public IEnumerable<IGeoLocation> GetEntityMap()
        {
            return All().Where(r => r.coordinates != null && r.coordinates != "");
        }

        public IEnumerable<IGeoLocation> GetFavoriteEntityMap(long accountId)
        {
            return All().Where(r => r.coordinates != null && r.coordinates != "" && r.IsFavorite(accountId));
        }

        companies IDataService<companies>.CreateItem()
        {
            return companies.Create();
        }
	}
}
