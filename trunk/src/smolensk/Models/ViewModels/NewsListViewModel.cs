using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    public class NewsListViewModel
    {
        public bool mainNews { get; set; }
        public CategoryViewModel Category { get; set; }
        public IEnumerable<SingleNewsViewModel> Items { get; set; }
        public DateTime Date { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public string GetFormattedDate()
        {
            return Date.ToString("dd MMMM yyyy");
        }

        public NewsListViewModel()
        {
            this.mainNews = false;
        }
    }
}