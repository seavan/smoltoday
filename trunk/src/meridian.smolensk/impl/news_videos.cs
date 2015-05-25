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
    public partial class news_videos : IDatabaseEntity, IMainSlider, IImageByTheme
    {
        #region IMainSlider Implementation
        public string title { get { return this.GetNewsVideoNew().title; } }
        public DateTime publish_date { get { return this.GetNewsVideoNew().publish_date; } }

        public Uri ItemMainUri
        {
            get { return new Uri(string.Format("/News/Single/{0}/{1}{2}", this.news_id, this.GetNewsVideoNew().title.TransliterateAndClear(), "#menuTop"), UriKind.Relative); }
        }
        public Uri GetImgItemMainUri()
        {
            if (string.IsNullOrEmpty(this.original))
                return null;

            UrlBuilder urlBuilder = new UrlBuilder();
            return urlBuilder.BuildNewsImageUri(this.news_id, this.original);
        }
        #endregion

        #region IImageByTheme Implementation
        public Uri GetItemThemeUri()
        {
            return this.GetNewsVideoNew().ItemUri();
        }

        public Uri GetImgItemThemeUri()
        {
            return new Uri(this.url, UriKind.Absolute);
        }
        public Uri GetImgThumbnailItemThemeUri()
        {
            if (string.IsNullOrEmpty(this.original))
                return null;

            UrlBuilder urlBuilder = new UrlBuilder();
            return urlBuilder.BuildNewsImageUri(this.news_id, this.original);
        }
        #endregion
	}
}
