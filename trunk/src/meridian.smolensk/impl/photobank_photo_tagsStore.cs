using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using meridian.smolensk.proto;
using admin.db;

namespace meridian.smolensk.protoStore
{
	public partial class photobank_photo_tagsStore : Meridian.IEntityStore, IDataService<photobank_photo_tags>
	{
        public IEnumerable<IImageByTheme> LoadPhotosByTheme(string theme)
        {
            return
                All().Where(
                    p =>
                    p.GetTagsPhotoTagsPhotobank_tag() != null &&
                    p.GetTagsPhotoTagsPhotobank_tag().title.ToLower() == theme).Select(
                        p => p.GetPhotoTagsPhotobank_photo());
        }
	}
}
