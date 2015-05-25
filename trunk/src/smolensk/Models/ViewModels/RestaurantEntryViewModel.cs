using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.common;

namespace smolensk.ViewModels
{
    public class RestaurantEntryViewModel : EntityBaseViewModel
    {
        public RestaurantEntryViewModel(long id) 
            : base(id)
        {
        }

        public string Title { get; set; }
        public RestaurantEntryCategory Category { get; set; }
        public bool Selected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((RestaurantEntryViewModel) obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}