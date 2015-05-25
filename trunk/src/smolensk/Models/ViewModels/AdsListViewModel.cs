using System.Collections.Generic;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class AdsListViewModel
    {
        public string Title { get; set; }
        public string NoAdsTitle { get; set; }
        public IEnumerable<ad_advertisments> Advertisments { get; set; } 
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public bool IsFavorite { get; set; }
        public string RouteName { get; set; }

        public AdsListViewModel()
        {
            NoAdsTitle = "Нет объявлений";
        }
    }
}