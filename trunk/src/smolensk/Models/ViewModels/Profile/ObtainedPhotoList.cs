using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Profile
{
    public class ObtainedPhotoList
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<photobank_obtained> ObtainedPhotos { get; set; }
        public bool HasProfile { get; set; }

        public ObtainedPhotoList()
        {
            TotalPages = 1;
            CurrentPage = 1;
            HasProfile = false;
        }
    }
}