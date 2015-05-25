using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Models.ViewModels;

namespace smolensk.ViewModels
{
    public class RestaurantsReserveListViewModel
    {
        public IEnumerable<RestaurantsReserveViewModel> Items { get; set; }
        public AccountViewModel User { get; set; }

        public string RouteName { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}