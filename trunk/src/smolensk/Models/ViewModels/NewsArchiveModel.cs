using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.ViewModels
{
    public class NewsArchiveModel
    {
        public static int PerPages = 6;
        public DateTime Date { get; set; }
        public IEnumerable<news> Items { get; set; }
        public int PageNumber { get; set; }

        public int PagesTotalCount()
        {
            return (int)Math.Ceiling((double)Items.Count() / (double)PerPages);
        }

        public IEnumerable<news> PageItems()
        {
            return Items.Skip((PageNumber - 1) * PerPages).Take(PerPages);
        }

        public string GetFormattedDate()
        {
            return Date.ToString("dd MMMM yyyy");
        }
    }
}