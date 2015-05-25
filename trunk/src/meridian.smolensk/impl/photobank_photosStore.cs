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
	public partial class photobank_photosStore : Meridian.IEntityStore, IDataService<photobank_photos>
	{
		public IEnumerable<photobank_photos> LoadAlbumPhotos(long albumId)
		{
            return GetAll().Where(a => a.album_id == albumId && a.Photos != null && a.Photos.Count() > 0);
		}

        public IEnumerable<photobank_photos> LoadForMain(int count = 10)
        {
            var preList = GetAll().Where(p => p.is_main && !p.day_photo).OrderByDescending(p => p.view_count).Take(50).ToList();
            var postList = preList.OrderBy(p => Guid.NewGuid());
            return postList.Take(count);
        }

        public photobank_photos GetPhotoDay()
        {
            return GetAll().Where(p => p.is_main && p.day_photo).OrderByDescending(p => p.publish_date).FirstOrDefault();
        }

        photobank_photos IDataService<photobank_photos>.CreateItem()
        {
            return new photobank_photos()
            {
                publish_date = DateTime.Now
            };
        }
	}
}
