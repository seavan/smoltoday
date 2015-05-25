using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class CategoryAdsViewModel
    {
        public ad_categories Category { get; set; }
        public AdsListViewModel Advertisments { get; set; }
        public long Type { get; set; }
        public string Sort { get; set; }
        public FilterAdsViewModel Filter { get; set; }
    }
}