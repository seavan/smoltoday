using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models
{
    public class DayOfWeek
    {
        public string Title { get; set; }
        public string DayOfMonth { get; set; }
        public DateTime Date { get; set; }
        public bool IsHoliday { get; set; }
    }
}