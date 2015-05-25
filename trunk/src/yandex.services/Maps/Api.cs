using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using yandex.services.Maps.Protocol;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace yandex.services.Maps
{
    public class Api
    {
        private string key;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Api(string key = "")
        {
        }

        public string MakeJsonRequestString(IEnumerable<KeyValuePair<string, string>> pars)
        {
            var sortedPars = new SortedList<string, string>();
            foreach (var i in pars)
            {
                sortedPars[i.Key] = i.Value;
            }

            sortedPars["key"] = key;
            sortedPars["format"] = "json";

            var url = "http://geocode-maps.yandex.ru/1.x/?{0}";
            var actualUrl = string.Format(url, string.Join("&", sortedPars.Select(s => string.Join("=", s.Key, s.Value))), key);

            var request = (HttpWebRequest)WebRequest.Create(actualUrl);

            request.ContentType = "application/json; charset=utf-8";
            string text;

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                log.Debug("Exception on Yandex.Maps webrequest", e);
                return null;
            }

            return text;
        }

        public Response MakeJsonRequest(IEnumerable<KeyValuePair<string, string>> pars)
        {
            var text = MakeJsonRequestString(pars);
            if (!String.IsNullOrEmpty(text))
            {
                try
                {
                    var result =
                        new JavaScriptSerializer().Deserialize<RootObject>(text);
                    return result.response;
                }
                catch (Exception e)
                {
                    log.Debug("Exception on Yandex.Maps webrequest JSON deserialization", e);
                    return null;
                }
            }

            return null;
        }

        public Response GetGeocode(string address)
        {
            var pars = new SortedList<string, string>();
            pars["geocode"] = address;
            pars["results"] = "1";
            return MakeJsonRequest(pars);
        }

        public Point GetCoordinates(string address)
        {
            var response = GetGeocode(address);
            if (response != null)
            {
                if (response.GeoObjectCollection != null && response.GeoObjectCollection.featureMember != null)
                {
                    var respMetaData = response.GeoObjectCollection.featureMember;
                    if (respMetaData.Count > 0)
                    {
                        var obj = respMetaData.First();
                        if (obj.GeoObject != null)
                        {
                            return obj.GeoObject.Point;
                        }
                    }
                }
            }

            return null;
        }

        public string NormalizeAddress(string address, string baseCity)
        {
            if (!address.ToLower().Contains(baseCity.ToLower()))
            {
                address = baseCity + ", " + address;
            }

            return address;
        }

        public string GetCoordinatesString(string address)
        {
            var point = GetCoordinates(address);

            if (point != null)
            {
                return point.pos.Replace(" ", ",");
            }

            return null;
        }
    }
}
