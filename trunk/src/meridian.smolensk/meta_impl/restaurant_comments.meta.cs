using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace meridian.smolensk.proto
{
    internal class restaurant_comments_meta : comments_meta_base
    {
        [Display(Name = "Ресторан")]
        public string RestaurantTitle { get; set; }

        [ScaffoldColumn(false)]
        public long restaurant_id { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<restaurant_comments> RestaurantChildComments { get; set; }
    }
}