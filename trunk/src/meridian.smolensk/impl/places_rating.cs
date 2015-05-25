using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;

namespace meridian.smolensk.proto
{
    public partial class places_rating : IDatabaseEntity, IMarkableMaterial
    {
        public DateTime CreateDate
        {
            get
            {
                return create_date;
            }
        }

        public int CMark
        {
            get
            {
                return rating;
            }

        }

        public Uri MaterialLink
        {
            get
            {
                return Meridian.Default.placesStore.Exists(this.place_id)
                           ? Meridian.Default.placesStore.Get(this.place_id).ItemUri()
                           : null;
            }
        }
        public String MaterialTitle
        {
            get
            {
                return Meridian.Default.placesStore.Exists(this.place_id)
                           ? Meridian.Default.placesStore.Get(this.place_id).title
                           : null;
            }
        }
    }
}
