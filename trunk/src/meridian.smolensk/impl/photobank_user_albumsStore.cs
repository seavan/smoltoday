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
	public partial class photobank_user_albumsStore : Meridian.IEntityStore, IDataService<photobank_user_albums>
	{
		public IEnumerable<photobank_user_albums> LoadUserAlbums(long accountId)
		{
		    return GetAll().Where(a => a.account_id == accountId).OrderByDescending(a=>a.shoot_date);
		}

        photobank_user_albums IDataService<photobank_user_albums>.CreateItem()
        {
            return new photobank_user_albums()
            {
                shoot_date = DateTime.Now
            };
        }
	}
}
