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
    public partial class actionsStore : Meridian.IEntityStore, IDataService<actions>, IGeolocationAware
	{
        public IEnumerable<IGeoLocation> GetEntityMap()
        {
            return All().Where(a=>a.published && a.approve).SelectMany(a => a.GetGeoLocations());
        }
        public IEnumerable<IMainSlider> LoadMainActions(int count = 3)
        {
            return All().OrderByDescending(n => n.publish_date).Where(n => n.is_main && n.GetImgItemMainUri() != null).Take(count);
        }

        actions IDataService<actions>.CreateItem()
        {
            return actions.Create();
        }
	}
}
