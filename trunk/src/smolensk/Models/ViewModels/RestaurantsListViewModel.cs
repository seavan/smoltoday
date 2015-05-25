using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Models.ViewModels;

namespace smolensk.ViewModels
{
    public class RestaurantsListViewModel
    {
        public IList<RestaurantEntryViewModel> Kitchens { get; set; }
        public IList<RestaurantEntryViewModel> AverageCosts { get; set; }
        public IList<RestaurantEntryViewModel> Discounts { get; set; }
        public IList<RestaurantEntryViewModel> Specials { get; set; }
        public AlphabetViewModel Alphabet { get; set; }

        public IList<RestaurantViewModel> Restaurants { get; set; }
        public int TotalRestaurants { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public IList<RestaurantEventsListViewModel> EventsListsCollection { get; set; }

        public string ToEntriesString()
        {
            var list = new List<long>();
            list.AddRange(Kitchens.Where(k=>k.Selected).Select(k => k.Id));
            list.AddRange(AverageCosts.Where(k => k.Selected).Select(a => a.Id));
            list.AddRange(Discounts.Where(k => k.Selected).Select(d => d.Id));
            list.AddRange(Specials.Where(k => k.Selected).Select(s => s.Id));
            return string.Join(",", list);
        } 
    }
}