using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class news_imagesStore
    {
        public IEnumerable<news_images> LoadImages(long newsId)
        {
            return All().Where(ni => ni.news_id == newsId);
        }

        public IEnumerable<IImageByTheme> LoadImagesByTheme(string theme)
        {
            return All().Where(i => i.GetNewsImagesNew() != null && i.GetNewsImagesNew().GetTagsArray() != null && i.GetNewsImagesNew().GetTagsArray().Contains(theme));
        }
    }
}
