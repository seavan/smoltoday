using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.XPath;
using HtmlAgilityPack;

namespace smolensk.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetDateOfLastDayInMonth(this DateTime date)
        {
            date = date.Date;
            var d = new DateTime(date.Year, date.Month, 1);
            d = d.AddMonths(1);
            var d2 = new DateTime(date.Year, date.Month, 1);
            int days = (int)d.Subtract(d2).TotalDays;

            return new DateTime(date.Year, date.Month, days);
        }
    }

    public static class WeatherHelper
    {
        public class WeatherInfo
        {
            public string Temperature;
            public string Sky;
            public string SkyIcon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hour">Час, от которого рассчитывать (утро, день, вечер). От 0 до 23.</param>
        /// <returns>список из четырех значений. первое - текущая. потом утро, день, вечер</returns>
        public static WeatherInfo[] GetCurrentWeatherInfo()
        {
            var result = new WeatherInfo[4];

            string url = "http://www.gismeteo.ru/city/daily/4239/";

            string iconXpath = "td[@class='clicon']/img";
            string tempXpath = "td[@class='temp']/span[@class='value m_temp c']";
            var date = DateTime.Now;

            var hours = new int[] {date.Hour, 7, 16, 20};



            var request = HttpWebRequest.Create(url);
            using (var res = request.GetResponse())
            {

                var page = new HtmlDocument();
                page.Load(res.GetResponseStream(), Encoding.UTF8);
                for (var i = 0; i < hours.Length; ++i)
                {
                    string selector = String.Format("wrow-{0}-{1:D2}-{2:D2}-{3:D2}", date.Year, date.Month, date.Day,
                        4 + (hours[i] / 6) * 6);

                    var element = page.GetElementbyId(selector);

                    if (element != null)
                    {
                        var icon = element.SelectSingleNode(iconXpath).GetAttributeValue("src", "");
                        var weather = element.SelectSingleNode(iconXpath).GetAttributeValue("alt", "");
                        var temp = element.SelectSingleNode(tempXpath).InnerText;

                        result[i] = new WeatherInfo()
                            {
                                SkyIcon = icon,
                                Sky = weather,
                                Temperature = temp
                            };
                    }
                }

            }

            return result;
        }
    }
}