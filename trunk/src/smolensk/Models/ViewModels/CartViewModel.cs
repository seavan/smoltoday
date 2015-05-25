using System.Collections.Generic;
using System.Linq;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class CartViewModel
    {
        public List<photobank_licenses> Licenses { get; set; }
        public List<photobank_photo_prices> Items { get; set; }

        public double Total
        {
            get
            {
                return Items.Sum(item => item.price);
            }
        }

        public CartViewModel()
        {
            Items = new List<photobank_photo_prices>();
        }
    }
}