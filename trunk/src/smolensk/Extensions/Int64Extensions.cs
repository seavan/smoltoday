using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Extensions
{
    public static class Int64Extensions
    {
        public static string ToFileSize(this long size)
        {
            if (size < 1024)
            {
                //return (size).ToString("F0") + " bytes";
                return "1 кб";
            }

            if (size < Math.Pow(1024, 2))
            {
                return (size/1024).ToString("F0") + " кб";
            }

            if (size < Math.Pow(1024, 3))
            {
                return (size/Math.Pow(1024, 2)).ToString("F0") + " мб";
            }

            return (size/Math.Pow(1024, 3)).ToString("F0") + " гб";
        }


        #region Окончания числительных
        public static string ToCounterWordForm(this long counter, string form1, string form2, string form5, bool onlyText = true)
        {
            var n = Math.Abs(counter) % 100;
            var n1 = n % 10;

            if (n > 10 && n < 20) return onlyText ? form5 : counter.ToString() + " " + form5;
            if (n1 > 1 && n1 < 5) return onlyText ? form2 : counter.ToString() + " " + form2;
            if (n1 == 1) return onlyText ? form1 : counter.ToString() + " " + form1;

            return onlyText ? form5 : counter.ToString() + " " + form5;
        }
        public static string ToCounterWordForm(this int counter, string form1, string form2, string form5, bool onlyText = true)
        {
            return ToCounterWordForm((long)counter, form1, form2, form5, onlyText);
        }
        public static string ToCounterWordForm(this long counter, string[] forms, bool onlyText = true)
        {
            if(forms.Count() >=3)
                return ToCounterWordForm(counter, forms[0], forms[1], forms[2], onlyText);
            return string.Empty;
        }
        public static string ToCounterWordForm(this int counter, string[] forms, bool onlyText = true)
        {
            if (forms.Count() >= 3)
                return ToCounterWordForm((long)counter, forms[0], forms[1], forms[2], onlyText);
            return string.Empty;
        }

        private static string[] _commentsForm = new string[] { "комментарий", "комментария", "комментариев" };
        public static string[] CommentsForm { get { return _commentsForm; } }

        private static string[] _vacancyForm = new string[] { "вакансия", "вакансии", "вакансий" };
        public static string[] VacancyForm { get { return _vacancyForm; } }

        private static string[] _recordForm = new string[] { "запись", "записи", "записей" };
        public static string[] RecordForm { get { return _recordForm; } }

        private static string[] _reviewForm = new string[] { "отзыв", "отзыва", "отзывов" };
        public static string[] ReviewForm { get { return _reviewForm; } }

        private static string[] _companyForm = new string[] { "компания", "компании", "компаний" };
        public static string[] CompanyForm { get { return _companyForm; } }

        private static string[] _advertForm = new string[] { "объявление", "объявления", "объявлений" };
        public static string[] AdvertForm { get { return _advertForm; } }

        private static string[] _photoForm = new string[] { "фотография", "фотографии", "фотографий" };
        public static string[] PhotoForm { get { return _photoForm; } }

        #endregion
    }
}