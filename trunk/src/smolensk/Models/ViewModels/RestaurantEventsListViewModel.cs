using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    using DayOfWeek = Models.DayOfWeek;

    public class RestaurantEventsListViewModel
    {
        public DayOfWeek Day { get; set; }
        public IList<RestaurantEventViewModel> Events { get; set; }
    }
}