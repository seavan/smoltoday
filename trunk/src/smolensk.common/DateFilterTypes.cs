using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace smolensk.common
{
    public enum DateFilterTypes
    {
        /// <summary>
        /// за неделю
        /// </summary>
        [Description("за неделю")]
        InWeek = 1,
        /// <summary>
        /// за месяц
        /// </summary>
        [Description("за месяц")]
        InMonth = 2,
        /// <summary>
        /// за всё время
        /// </summary>
        [Description("за всё время")]
        InAllTime = 3,
        /// <summary>
        /// за год
        /// </summary>
        [Description("за год")]
        InYear = 4,
        /// <summary>
        /// сегодня
        /// </summary>
        [Description("сегодня")]
        ToDay = 5,
        /// <summary>
        /// вчера
        /// </summary>
        [Description("вчера")]
        Yesterday = 6
    }

    public class DateRange
    {
        public DateRange()
        {
            fromDate = DateTime.MinValue;
            toDate = DateTime.MaxValue;
        }

        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }

    public static class DateFilterTypesExtension
    {
        public static DateTime ToDate(this DateFilterTypes dateType)
        {
            DateTime baseDate = DateTime.MinValue;

            switch (dateType)
            {
                case DateFilterTypes.InWeek:
                    baseDate = DateTime.Now.AddDays(-7);break;
                case DateFilterTypes.InMonth:
                    baseDate = DateTime.Now.AddMonths(-1);break;
                case DateFilterTypes.InYear:
                    baseDate = DateTime.Now.AddYears(-1);break;
                case DateFilterTypes.Yesterday:
                    baseDate = DateTime.Now.AddDays(-1);break;
                case DateFilterTypes.ToDay:
                    baseDate = DateTime.Now;break;
            }

            return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day);
        }
        public static DateRange ToDateRange(this DateFilterTypes dateType)
        {
            DateRange range = new DateRange();

            range.fromDate = dateType.ToDate();

            if(dateType == DateFilterTypes.Yesterday)
            {
                DateTime nowDate = DateTime.Now;
                range.toDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day);
            }

            return range;
        }
        
    }
}
