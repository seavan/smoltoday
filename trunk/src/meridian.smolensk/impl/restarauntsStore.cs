using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using admin.db;
using meridian.smolensk.impl.Images;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.common.Infrastructure;

namespace meridian.smolensk.protoStore
{
    public partial class restaurantsStore : IDataService<restaurants>, IGeolocationAware
    {
        public IEnumerable<IGeoLocation> GetEntityMap()
        {
            return All().Where(r => r.coordinates != null && r.coordinates != "");
        }

        void IDataService<restaurants>.Delete(restaurants item)
        {
            DeleteReferencedObjects(item);

            Delete(item);
        }

        private void DeleteReferencedObjects(restaurants item)
        {
            var comments = item.RestaurantsComments.ToList();
            foreach (var comment in comments)
                item.RemoveRestaurantsComments(comment, true);
        }
    }
}