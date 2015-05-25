using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Profile
{
    public class AddNewPhotoModel
    {
        public long AlbumId { get; set; }
        public string Title { get; set; }
        public int LicenseId { get; set; }
        public long CategoryId { get; set; }
        public int Price { get; set; }
        public HttpPostedFileBase FileImg { get; set; }
        public List<string> Tags { get; set; }
        public IEnumerable<photobank_licenses> Licenseses { get; set; }
        public IEnumerable<photobank_categories> Categories { get; set; }
        /*for rel*/
        public long ParentId { get; set; }
        public string CategoryTitle { get; set; }
    }
}