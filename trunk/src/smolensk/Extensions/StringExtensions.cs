using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace smolensk.Extensions
{
    public static class StringExtensions
    {
        private const string NAME_STRING_PATTERN = @"[<>/\\'=\$`\*\^%\?\+\!@#;:\.,&«»-]+";
        private const string TAGS_PATTERN = @"\<.*?\>";

        public static bool CheckEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            string _temp = str;

            _temp = _temp.Replace("\r", "");
            _temp = _temp.Replace("\n", "");
            _temp = _temp.Replace("&nbsp;", "");

            Regex rgx = new Regex(TAGS_PATTERN);
            _temp = rgx.Replace(_temp, "");

            rgx = new Regex(NAME_STRING_PATTERN);
            _temp = rgx.Replace(_temp, "").Trim();

            return string.IsNullOrEmpty(_temp);
        }
        
        /// <summary>
        /// Очищает имя компании от апострофов, кавычек, лишних пробелов и аббревиатур. Переводит его в нижний регистр
        /// </summary>
        public static string ClearCompanyName(this String str)
        {
            str = str
                //.Replace("'","")
                .Replace("|", "")
                .Replace("\"", "")
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("“", "")
                .Replace("”", "")
                //.Replace("«", "")
                //.Replace("»", "")
                .Replace("‘", "")
                .Replace("’", "")
                .Replace("ОАО ", "")
                .Replace("ЗАО ", "")
                .Replace("ООО ", "")
                .Replace("НО ", "")
                .Replace("ИП ", "")
                .Replace(" ", "")
                //.Replace(":", "")
                //.Replace(",", "")
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("&quot", "")
                .Replace("&amp", "")
                .Replace("&lt", "")
                .Replace("&gt", "")
                .Replace("&laquo", "")
                .Replace("&raquo", "")
                .Replace("&copy", "")
                .Replace("&reg", "")
                .Trim()
                .ToLower()
                ;

            Regex rgx = new Regex(NAME_STRING_PATTERN);
            str = rgx.Replace(str, "").Trim();

            return str;
        }

        public static string[] SplitWords(this string newTag)
        {
            string[] words = newTag.Split(' ');
            string[] sWords;
            if (words.Count() == 1)
            {
                sWords = new string[] { words[0].ClearCompanyName(), "", "" };
            }
            else if (words.Count() == 2)
            {
                sWords = new string[] { words[0].ClearCompanyName(), words[1].ClearCompanyName(), "" };
            }
            else if (words.Count() >= 3)
            {
                sWords = new string[] { words[0].ClearCompanyName(), words[1].ClearCompanyName(), words[2].ClearCompanyName() };
            }
            else
            {
                sWords = new string[] { "", "", "" };
            }
            return sWords;
        }

        public static string LinkToUrlFormat(this string url)
        {
            if (!url.StartsWith("www.") && !url.StartsWith("http://"))
            {
                url = "http://" + url;
            }
            if (!url.StartsWith("http://") && url.StartsWith("www."))
            {
                url = "http://" + url;
            }
            if (url.StartsWith("http://") && !url.Contains("www."))
            {
                url = "http://" + url.Remove(0, 7);
            }
            if (url.EndsWith("/"))
            {
                url = url.Remove(url.LastIndexOf("/"), 1);
            }
            return url;
        }
    }
}