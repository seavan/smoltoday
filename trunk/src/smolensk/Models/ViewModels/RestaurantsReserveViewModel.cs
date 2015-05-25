using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    public class RestaurantsReserveViewModel : EntityBaseViewModel
    {
        public RestaurantsReserveViewModel(long id) : base(id) { }
        
        public RestaurantViewModel Restaurant { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int PersonCount { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
    }
}