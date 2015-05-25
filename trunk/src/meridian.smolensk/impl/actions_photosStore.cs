using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.system;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class actions_photosStore
    {
        public IEnumerable<actions_photos> GetPhotos(long actionId)
        {
            return All().Where(ap => ap.action_id == actionId);
        }

        public actions_photos GetMainPhoto(long actionId)
        {
            return GetPhotos(actionId).FirstOrDefault(ap => ap.is_main);
        }
    }
}
