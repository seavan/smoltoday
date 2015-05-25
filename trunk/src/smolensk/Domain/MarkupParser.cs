using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using HtmlAgilityPack;
using System.Collections.Generic;

namespace smolensk.Domain
{
    public class MarkupParser
    {
        private const string HOST_PATTERN = @"(?:http\:\/\/|~/|/)?((?:[-\w]+\.)+(?:com|ru))";
        private const string YOUTUBE_PATTERN = @"v=([\w-]+)[&]?";
        private const string RUTUBE_PATTERN = YOUTUBE_PATTERN;
        private const string VIMEO_PATTERN = @"/([\d]+)";
        private const string TAGS_PATTERN = @"\<.*?\>";

        public string SubstringPost(string text, int maxlength = 0)
        {
            if (text == null) return null;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(text);
            doc.OptionAutoCloseOnEnd = true;

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//span[@name=\"cutpoint\"]");
            if (nodes != null)
            {
                HtmlNode attention = nodes.First();
                text = attention.ToString();
            }

            string tmpStr = text;
            while (tmpStr.Contains("<table"))
            {
                var si = tmpStr.IndexOf("<table");
                var li = tmpStr.IndexOf("</table>");
                var cnt = li - si + 8;
                if(cnt < 0) cnt = tmpStr.Length - si;
                tmpStr = tmpStr.Remove(si,  cnt );
            }
            text = tmpStr;
            Regex rgx = new Regex(TAGS_PATTERN);
            text = rgx.Replace(text, "");
            
            ///!!!!!!!!!!!!!!!!!!!!!!
            text = text.Replace("&nbsp;", " ");
            text = text.Replace("<", "&lt;");
            text = text.Replace(">", "&gt;"); 
            
            text = text.Trim();
            if (maxlength <= 0 || maxlength > 2000) maxlength = 2000;
            if(text.Length > maxlength)
            {
                if (text.Substring(0, maxlength).LastIndexOf(" ") > 0)
                {
                    text = text.Substring(0, text.Substring(0, maxlength).LastIndexOf(" ")) + "...";
                }
                else
                {
                    text = text.Substring(0, maxlength) + "...";
                }
            }
            text = text.Replace("\r\n", "<br/>");

            return text;
        }

        public string StripImageTags(string text)
        { 
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(text);

            try
            {
                var nodes = doc.DocumentNode.SelectNodes(@"//img[@src]").ToList();
                foreach (var node in nodes)
                    node.Remove();

                return doc.DocumentNode.OuterHtml;
            }
            catch(System.Exception)
            {
                return text;
            }
        }
    }
}