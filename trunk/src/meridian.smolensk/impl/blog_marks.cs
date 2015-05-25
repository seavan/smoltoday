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
    public partial class blog_marks : IDatabaseEntity, IMarkableMaterial
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
                return mark;
            }

        }

        public Uri MaterialLink
        {
            get
            {
                return Meridian.Default.blogsStore.Exists(this.blog_id)
                           ? Meridian.Default.blogsStore.Get(this.blog_id).ItemUri()
                           : null;
            }
        }
        public String MaterialTitle
        {
            get
            {
                return Meridian.Default.blogsStore.Exists(this.blog_id)
                           ? Meridian.Default.blogsStore.Get(this.blog_id).title
                           : null;
            }
        }
	}
}
