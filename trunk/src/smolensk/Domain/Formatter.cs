using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;

namespace smolensk.Domain
{
    public static class Formatter
    {
        public const string RussianCultureName = "ru-RU";

        public static CultureInfo GetRussianCulture()
        {
            return CultureInfo.GetCultureInfo("ru-RU");
        }

        /// <summary>
        /// Mask "dd MMMM yyyy, HH:mm"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatLongDateTime(DateTime dateTime)
        {
            IFormatProvider formatProvider = GetRussianCulture();
            return dateTime.ToString("dd MMMM yyyy, HH:mm", formatProvider);
        }
        /// <summary>
        /// Mask "dd MMMM yyyy - HH:mm"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatLongDateTimeWithHyphen(DateTime dateTime)
        {
            IFormatProvider formatProvider = GetRussianCulture();
            return dateTime.ToString("dd MMMM yyyy - HH:mm", formatProvider);
        }
        /// <summary>
        /// Mask "dd MMMM yyyy \n HH:mm"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static MvcHtmlString FormatLongDateTimeDifline(DateTime dateTime)
        {
            return MvcHtmlString.Create(FormatLongDateTime(dateTime).Replace(", ", "<br/>"));
        }

        public static string FormatLongDateTimeNoComma(DateTime dateTime)
        {
            IFormatProvider formatProvider = GetRussianCulture();
            if(dateTime.Year.Equals(DateTime.Now.Year))
            {
                return dateTime.ToString("dd MMMM HH:mm", formatProvider);
            }
            else
            {
                return dateTime.ToString("dd MMMM yyyy HH:mm", formatProvider);
            }
        }

        public static string FormatRecentDate(DateTime dateToFormat, DateTime now)
        {
            int daysDelta = (now.Date - dateToFormat.Date).Days;

            if (daysDelta == 0)
                return FormatTime(dateToFormat);

            if (daysDelta == 1)
                return string.Format("Вчера в {0:HH:mm}", dateToFormat);

            return dateToFormat.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// format dddd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetNameOfDayOfWeek(DateTime dt)
        {
            return dt.ToString("dddd", GetRussianCulture());
        }

        /// <summary>
        /// format dd MMMM
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetNameOfDayOfMonth(DateTime dt)
        {
            return dt.ToString("dd MMMM", GetRussianCulture());
        }

        /// <summary>
        /// format dd MMMM yyyy
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string FormatLongDate(DateTime dt)
        {
            return dt.ToString("dd MMMM yyyy", GetRussianCulture());
        }

        /// <summary>
        /// Форматный вывод только времени (HH:mm)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatTime(DateTime dateTime)
        {
            return dateTime.ToString("HH:mm", GetRussianCulture());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetWeekDayAndNameOfDayOfMonth(DateTime dt)
        {
            return dt.ToString("ddd, dd MMMM", GetRussianCulture());
        }

        public static string FormatCompanyPublishDate(DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy", GetRussianCulture());
        }

        public static string FormatVacancyPublishDate(DateTime dt)
        {
            return dt.ToString("dd MMMM yyyy", GetRussianCulture());
        }

        public static string FormatRestaurantReservesPublishDate(DateTime dt)
        {
            return FormatLongDateTimeWithHyphen(dt);
        }

        public static string FormatPrice(decimal value, int decimalPlaces = 2)
        { 
            string formatSpecifier = string.Format("F{0}", decimalPlaces);

            return value.ToString(formatSpecifier, GetRussianCulture());
        }

        public static string FormatPrice(double value, int decimalPlaces = 2)
        {
            string formatSpecifier = string.Format("N{0}", decimalPlaces);

            return value.ToString(formatSpecifier, GetRussianCulture());
        }

        public static string FormatChange(decimal value)
        { 
            string sign = string.Empty;
            if (value > 0)
                sign = "+";
            else if (value < 0)
                sign = "-";

            return string.Format("{0} {1}%", sign, FormatPrice(Math.Abs(value)));
        }

        /// <summary>
        /// Формат даты для вакансии
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string FormatVacancyDate(DateTime dt)
        {
            if (DateTime.Now.Year != dt.Year)
                return dt.ToString("dd MMMM yyyy");

            return dt.ToString("dd MMMM");
        }

        public static MvcHtmlString FormatResumeDate(DateTime date)
        {
            return FormatLongDateTimeDifline(date);
        }

        /// <summary>
        /// dd.MMMM
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string FormatMonthAndYear(DateTime dt)
        {
            return dt.ToString("dd.MMMM");
        }
    }
}