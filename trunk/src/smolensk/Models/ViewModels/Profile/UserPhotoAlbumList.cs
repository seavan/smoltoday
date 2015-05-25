using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Profile
{
    public class UserPhotoAlbumList
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<photobank_user_albums> Albums { get; set; }

        public UserPhotoAlbumList()
        {
            TotalPages = 1;
            CurrentPage = 1;
        }
    }
}