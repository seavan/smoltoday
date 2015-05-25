using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace smolensk.Domain
{
    public static class TextHelper
    {
        private static readonly Regex ImageSourceRegex = new Regex("<img.*?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);
        private static readonly Regex AltRegex = new Regex("alt=[\"'](.*?)[\"']", RegexOptions.IgnoreCase);

        public static string CreateAnnounce(string materialText, int maxlength = 200)
        {
            MarkupParser parser = new MarkupParser();

            return parser.SubstringPost(materialText, maxlength);
        }

        public static string TrimAnnounce(string title, string announce, 
            int rowMaxNumber = 5, int rowMaxLength = 34, int titleRowMaxLength = 22)
        {
            string[] titleWords = title.Split(' ');
            int titleRowNumbers = 1;
            int wordNumber = 0;
            foreach (string word in titleWords)
            {
                wordNumber += word.Length + 1;
                if (wordNumber > titleRowMaxLength)
                {
                    wordNumber = word.Length;
                    titleRowNumbers++;
                }
            }

            string announceText = Regex.Replace(announce, "<[^>]+>", "");
            announceText = Regex.Replace(announceText, "[\r\n\t]", "");
            string anonceTextToCount = Regex.Replace(announceText, "&[^;]+;", "_");

            string[] wordsToCount = anonceTextToCount.Split(' ');
            string[] words = announceText.Split(' ');
            int letterNumber = 0;
            wordNumber = 0;
            int rowNumber = 1;
            foreach (string word in wordsToCount)
            {
                wordNumber++;
                letterNumber += word.Length + 1;
                if (letterNumber > rowMaxLength)
                {
                    rowNumber++;
                    letterNumber = word.Length + 1;
                    if (rowNumber > rowMaxNumber - titleRowNumbers)
                    {
                        wordNumber--;
                        words[wordNumber - 1] += "...";
                        break;
                    }
                }
            }
            return string.Join(" ", words.Take(wordNumber));
        }
    }
}