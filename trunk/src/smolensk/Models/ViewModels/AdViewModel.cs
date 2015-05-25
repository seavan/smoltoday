using System.Collections.Generic;
using System.Web;
using meridian.smolensk.proto;
using smolensk.Models.CodeModels;

namespace smolensk.Models.ViewModels
{
    public class AdViewModel
    {
        public ad_advertisments Advertisment { get; set; }
        public List<ad_categories> Categories { get; set; }
        public PhotoScrollViewModel PhotosModel { get; set; }
        public List<AdvertProperty> Properties { get; set; }
        public bool InInterestingRequest { get; set; }
        public bool PinToListRequest { get; set; }
        public bool IsOwner { get; set; }
        public bool IsEdit { get; set; }
        public List<HttpPostedFileBase> Files { get; set; } 
    }
}