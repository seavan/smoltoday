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
	public partial class news_videosStore : Meridian.IEntityStore, IDataService<news_videos>
	{
        public IEnumerable<IMainSlider> LoadMainVideoNews(int count = 3)
        {
            return All().Where(n => n.GetNewsVideoNew() != null)
                .Where(n => n.GetNewsVideoNew().is_main && n.GetImgItemMainUri() != null)
                .OrderByDescending(n => n.GetNewsVideoNew().publish_date)
                .Take(count);
        }

        public IEnumerable<IImageByTheme> LoadVideosByTheme(string theme)
        {
            return All().Where(i => i.GetNewsVideoNew() != null && i.GetNewsVideoNew().GetTagsArray() != null && i.GetNewsVideoNew().GetTagsArray().Contains(theme));
        }
	}
}
