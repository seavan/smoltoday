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
	public partial class company_rating : IDatabaseEntity, IMarkableMaterial
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
                return Meridian.Default.companiesStore.Exists(this.company_id)
                           ? Meridian.Default.companiesStore.Get(this.company_id).ItemUri()
                           : null;
            }
        }
        public String MaterialTitle
        {
            get
            {
                return Meridian.Default.companiesStore.Exists(this.company_id)
                           ? Meridian.Default.companiesStore.Get(this.company_id).title
                           : null;
            }
        }
	}
}
