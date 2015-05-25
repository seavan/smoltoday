using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class restaurant_photosStore
    {
        public restaurant_photos GetMainPhoto(long restaurantId)
        {
            var restaurant = Meridian.Default.restaurantsStore.Get(restaurantId);

            return restaurant.Photos.OrderByDescending(rp => rp.is_main).FirstOrDefault();
        }
    }
}
