using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using admin.db;
using meridian.smolensk;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class news_marks : IDatabaseEntity, IMarkableMaterial
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
                return Meridian.Default.newsStore.Exists(this.news_id)
                           ? Meridian.Default.newsStore.Get(this.news_id).ItemMainUri
                           : null;
            }
        }
        public string MaterialTitle
        {
            get
            {
                return Meridian.Default.newsStore.Exists(this.news_id)
                           ? Meridian.Default.newsStore.Get(this.news_id).title
                           : null;
            }
        }
	}
}
