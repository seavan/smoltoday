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
    public partial class news_images : IDatabaseEntity, IImageByTheme
    {
        #region IImageByTheme Implementation
        public string title { get { return this.GetNewsImagesNew().title; } }
        public Uri GetItemThemeUri()
        {
            return this.GetNewsImagesNew().ItemUri();
        }

        public Uri GetImgItemThemeUri()
        {

            if (string.IsNullOrEmpty(this.normal_thumbnail))
                return null;

            UrlBuilder urlBuilder = new UrlBuilder();
            return urlBuilder.BuildNewsImageUri(this.news_id, this.normal_thumbnail);
        }
        public Uri GetImgThumbnailItemThemeUri()
        {
            if (string.IsNullOrEmpty(this.medium_thumbnail))
                return null;

            UrlBuilder urlBuilder = new UrlBuilder();
            return urlBuilder.BuildNewsImageUri(this.news_id, this.medium_thumbnail);
        }
        #endregion
    }
}
