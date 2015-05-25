using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Domain;

namespace smolensk.Models.CodeModels
{
    public class DateRange
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public DateRange() { }

        public DateRange(DateTime date) : this(date, 1) { }

        public DateRange(DateTime date, int dayCount) : this(date, date.AddDays(dayCount).Date.Subtract(new TimeSpan(1))) { }

        public DateRange(DateTime? from, DateTime? to)
        {
            this.From = from;
            this.To = to;
        }

        public bool HasValue
        {
            get
            {
                return From.HasValue || To.HasValue;
            }
        }

        public bool IsInterval
        {
            get
            {
                return From.HasValue && To.HasValue;
            }
        }

        

        public int DayCount
        {
            get 
            {
                return IsInterval ? (int)Math.Truncate(To.Value.Subtract(From.Value).TotalDays) : -1;
            }
        }

        public override bool Equals(object obj)
        {
            var range = obj as DateRange;
            if (range == null)
                return false;

            return range.From.Equals(this.From) && range.To.Equals(this.To);
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode();
        }

        public override string ToString()
        {
            return ToStringFormat(Formatter.FormatLongDate);
        }

        public string ToStringFormat(Func<DateTime, string> format, bool asInterval = false)
        {
            var result = string.Empty;

            var from = From.HasValue ? format(From.Value) : string.Empty;
            var to = To.HasValue ? format(To.Value) : string.Empty;

            if (DayCount == 0)
                return from;
            if (asInterval && IsInterval)
                return string.Format("{0} - {1} ", from, to);

            if (!string.IsNullOrEmpty(from))
                result += string.Format("c {0} ", from);

            if (!string.IsNullOrEmpty(to))
                result += string.Format("по {0} ", to);

            return result;
        }
    }
}