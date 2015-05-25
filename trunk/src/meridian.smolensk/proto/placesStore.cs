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
    public partial class placesStore : Meridian.IEntityStore, IDataService<places>, IGeolocationAware
	{
        public IEnumerable<IGeoLocation> GetEntityMap()
        {
            return All().Where(r 
                => r.coordinates != null 
                && r.coordinates != "" 
                && r.ActionPlace.Any(a => a.Schedule.Any(s => s.datetime > DateTime.Now)));
        }
	}
}
