using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Profile
{
    public class PhotosList
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<photobank_photos> Photos { get; set; }
        public long albumId { get; set; }

        public PhotosList()
        {
            TotalPages = 1;
            CurrentPage = 1;
            albumId = 0;
        }
    }
}