using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace meridian.smolensk.impl.Images
{
    public static class HtmlMarkupHelper
    {
        public static Guid ParseGuid(string value)
        {
            Guid result = Guid.Empty;
            try
            {
                result = Guid.Parse(value);
            }
            catch (ArgumentException)
            {
            }
            catch (FormatException)
            {
            }

            return result;
        }

        public static bool ParseBool(string value)
        {
            bool result = false;
            try
            {
                result = bool.Parse(value);
            }
            catch (ArgumentException)
            {
            }
            catch (FormatException)
            {
            }

            return result;
        }

        public static Uri CreateAbsoluteUri(string uri)
        {
            if (uri.StartsWith("//"))
                uri = uri.Remove(0, 2);

            if (!uri.StartsWith(Uri.UriSchemeHttp))
                uri = Uri.UriSchemeHttp + Uri.SchemeDelimiter + uri;

            return new Uri(uri, UriKind.Absolute);
        }

        public static string GetAttributeValue(HtmlNode node, string attributeName)
        {
            return GetAttributeValue(node, attributeName, string.Empty);
        }

        public static string GetAttributeValue(HtmlNode node, string attributeName, string defaultValue)
        {
            var attribute = node.Attributes[attributeName];
            if (attribute == null)
                return defaultValue;

            return attribute.Value;
        }
    }
}
