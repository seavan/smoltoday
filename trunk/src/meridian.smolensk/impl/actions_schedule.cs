using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class actions_schedule
    {
        public places GetPlace()
        { 
            var store = Meridian.Default.actions_placesStore;
            var ap = store.Exists(action_place_id) ? store.Get(action_place_id) : null;
            return ap != null ? ap.GetActionPlacePlace() : null;
        }
    }
}
