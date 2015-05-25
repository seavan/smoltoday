using System.Collections.Generic;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class InterestingAdsViewModel
    {
        public List<ad_advertisments> Advertismentses { get; set; }
        public string Category { get; set; }
    }
}