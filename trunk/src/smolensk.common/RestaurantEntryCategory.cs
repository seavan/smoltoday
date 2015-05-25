using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.common
{
    public enum RestaurantEntryCategory : long
    {
        Nothing = 0,

        Type = 1,
        AverageCost = 2,
        Kitchen = 3,
        ForKids = 4,
        Offers = 5,
        Specials = 6,
        Entertainment = 7,
        Ideal = 8,
        Other = 9,
        Discounts = 10,
    }
}