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
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class photobank_user_albums : IDatabaseEntity, ILookupValue, ILookupValueAspectProvider
	{
		public string PreviewUrl {
            get
            {
                var photo = Meridian.Default.photobank_photosStore.GetAll().FirstOrDefault(p => p.album_id == this.id);
                if (photo != null && !string.IsNullOrEmpty(photo.PreviewUrl))
                    return photo.PreviewUrl;
                return String.Format("{0}{1}", Constants.UserDataFolder, "noImg138_138.gif");
            }
        }

        public int CountPhotos
        {
            get
            {
                return Meridian.Default.photobank_photosStore.GetAll().Where(p => p.album_id == this.id && p.album_id > 0).Count();
            }
        }

        public int lookup_value_level
        {
            get { return 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }
        public string lookup_title
        {
            get
            {
                if (account_id > 0)
                    return String.Format("{0}, {1}, {2}, {3}", title, pb_user_albums_accounts.ShortName, pb_user_albums_accounts.email, account_id);

                return title;
            }
        }

        public ILookupValueAspect Getaccount_idLookupValueAspect()
        {
            return new LookupAspect("account_id", this, () => { return Meridian.Default.accountsStore.All(); });
        }

        public string PhotosLink
        {
            get { return String.Format("/PhotoBankAdmin/Index?album={0}", id); }
        }

	}
}
