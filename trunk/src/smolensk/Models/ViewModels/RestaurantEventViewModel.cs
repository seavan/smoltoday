using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    public class RestaurantEventViewModel : EntityBaseViewModel
    {
        public RestaurantEventViewModel(long id) : base(id)
        {
        }

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public RestaurantViewModel Restaurant { get; set; }
    }
}