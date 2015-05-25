using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuttingEdge.Conditions;

namespace smolensk.common
{
    public class UrlBuilder
    {
        private const string UserDataPath = "/content/userdata/";

        private Uri host;

        public UrlBuilder()
        {
            Uri requestUri = HttpContext.Current.Request.Url;
            UriBuilder builder = new UriBuilder(Uri.UriSchemeHttp, requestUri.Host);
            if (!requestUri.IsDefaultPort)
                builder.Port = requestUri.Port;

            SetHost(builder.Uri);
        }

        public UrlBuilder(Uri host)
        {
            SetHost(host);
        }

        public Uri Host
        {
            get { return host; }
        }

        public Uri BuildAbsoluteUri(string relativeOrAbsoluteUrl)
        {
            Uri uri = new Uri(relativeOrAbsoluteUrl, UriKind.RelativeOrAbsolute);
            if (uri.IsAbsoluteUri)
                return uri;

            return new Uri(Host, uri);
        }

        public Uri BuildNewsImageUri(long newsId, string imageFilename)
        {
            string url = string.Format(UserDataPath + "news/{0}/{1}", newsId, imageFilename);

            return new Uri(url, UriKind.Relative);
        }

        public Uri BuildActionImageUri(long actionId, string imageFilename)
        {
            string url = string.Format(UserDataPath + "actions/{0}", imageFilename); //надо "actions/{0}/{1}" но пока всё в одной папке лежит

            return new Uri(url, UriKind.Relative);
        }

        private void SetHost(Uri uri)
        {
            Condition.Requires(uri, "uri").IsNotNull();

            this.host = uri;
        }

        public Uri BuildBlogsImageUri(long blogId, string imageFilename)
        {
            string url = string.Format(UserDataPath + "blogs/{0}/{1}", blogId, imageFilename);

            return new Uri(url, UriKind.Relative);
        }
    }
}