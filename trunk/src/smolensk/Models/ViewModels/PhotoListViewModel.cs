using System.Collections.Generic;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class PhotoListViewModel
    {
        public string Title { get; set; }
        public string NoPhotoTitle { get; set; }
        public IEnumerable<photobank_photos> Photos { get; set; } 
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public PhotoListViewModel()
        {
            NoPhotoTitle = "Нет фотографий";
        }
    }
}