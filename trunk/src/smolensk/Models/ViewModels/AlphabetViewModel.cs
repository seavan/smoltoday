using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using smolensk.common;

namespace smolensk.Models.ViewModels
{
    public class AlphabetViewModel
    {
        private readonly string _letterKey;
        private readonly string _alphabetKey;
        private readonly RouteValueDictionary _routeData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routeName">Имя маршрута</param>
        /// <param name="routeData">данные маршрута</param>
        /// <param name="letterKey">параметр маршрута ответственный за символ</param>
        /// <param name="alphabetKey">параметр маршрута ответственный за язык</param>
        public AlphabetViewModel(string routeName, RouteValueDictionary routeData, string letterKey, string alphabetKey)
        {
            _letterKey = letterKey;
            _alphabetKey = alphabetKey;
            RouteName = routeName;
            _routeData = new RouteValueDictionary(routeData);

            if (!_routeData.ContainsKey(letterKey))
            {
                _routeData.Add(letterKey, Constants.AnyLetter);
            }
            if (alphabetKey != null && !_routeData.ContainsKey(alphabetKey))
            {
                _routeData.Add(alphabetKey, Alphabet.Rus);
            }
        }

        public AlphabetViewModel(string routeName, RouteValueDictionary routeData, string letterKey)
            : this(routeName, routeData, letterKey, null)
        {
        }

        public string Letter { get; set; }
        public Alphabet Alphabet { get; set; }
        public string RouteName { get; private set; }
        
        public string RouteUrl(UrlHelper url, string letter, Alphabet alphabet)
        {
            var data = new RouteValueDictionary(_routeData);
            data[_letterKey] = letter;
            data[_alphabetKey] = alphabet;
            return url.RouteUrl(RouteName, data);
        }

        public string RouteUrl(UrlHelper url, string letter)
        {
            var data = new RouteValueDictionary(_routeData);
            data[_letterKey] = letter;
            return url.RouteUrl(RouteName, data);
        }

        public static string[] RusAlphabet = new[]
                                          {
                                              "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К", 
                                              "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", 
                                              "Х", "Ц", "Ч", "Ш", "Щ", "Э", "Ю", "Я"
                                          };

        public static string[] EngAlphabet = new[]
                                          {
                                              "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", 
                                              "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", 
                                              "U", "V", "W", "X", "Y", "Z"
                                          };
    }
}