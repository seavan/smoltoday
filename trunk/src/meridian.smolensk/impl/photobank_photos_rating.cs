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
    public partial class photobank_photos_rating : IDatabaseEntity, IMarkableMaterial
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
                return Meridian.Default.photobank_photosStore.Exists(this.photo_id)
                           ? Meridian.Default.photobank_photosStore.Get(this.photo_id).ItemUri()
                           : null;
            }
        }
        public String MaterialTitle
        {
            get
            {
                return Meridian.Default.photobank_photosStore.Exists(this.photo_id)
                           ? Meridian.Default.photobank_photosStore.Get(this.photo_id).title
                           : null;
            }
        }
    }
}
