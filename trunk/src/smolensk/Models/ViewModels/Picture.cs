using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuttingEdge.Conditions;

namespace smolensk.ViewModels
{
    public class Picture
    {
        private Uri uri;

        private Picture(Uri uri)
        {
            Condition.Requires(uri, "uri").IsNotNull();

            this.uri = uri;
        }

        public static Picture Create(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return null;

            return new Picture(new Uri(uri, UriKind.RelativeOrAbsolute));
        }

        public static Picture Create(Uri uri)
        {
            return new Picture(uri);
        }

        public Uri GetImageUri()
        {
            return uri;
        }
    }
}