using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Models.ViewModels;

namespace smolensk.ViewModels
{
    public class RestaurantViewModel : EntityBaseViewModel
    {
        public RestaurantViewModel(long id) : base(id)
        {
            Dictionary = new SortedList<string, string>();
        }

        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string HolesCount { get; set; }
        public string WorkTime { get; set; }
        public string NormalPhotoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsVip { get; set; }
        public string FeedbackEmail { get; set; }
        public bool CanBookTable { get; set; }

        public IEnumerable<RestaurantEntryViewModel> Types { get; set; }
        public IEnumerable<RestaurantEntryViewModel> Kitchen { get; set; }
        public RestaurantEntryViewModel AverageCost { get; set; }

        public IList<RestaurantEventsListViewModel> Events { get; set; }
        public IList<RestaurantViewModel> Similar { get; set; }
        
        public PhotoScrollViewModel PhotoScroller { get; set; }

        public string Description { get; set; }

        public SortedList<string, string> Dictionary { get; set; }

        public ICommentable Comments { get; set; }
        public IMarkable Marks { get; set; }
        public IGeoLocation GeoLocation { get; set; }
        public IFavorite Favorite { get; set; }

        public int Rating { get; set; }

        public Uri GetItemUri()
        {
            //string uri = GetItemUriBase("#menuTop");
            string uri = string.Format("/Restaurants/One/{0}/{1}", Id, Title.TransliterateAndClear());
            return new Uri(uri, UriKind.Relative);
        }
    }
}