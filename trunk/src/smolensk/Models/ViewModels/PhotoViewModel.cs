using System.Collections.Generic;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class PhotoViewModel
    {
        public photobank_photos Photo { get; set; }
        public Dictionary<photobank_licenses, List<RelatedPhotoViewModel>> RelatedPhotos { get; set; }
        public photobank_related_photos OriginalPhoto { get; set; }
        public List<KeyValuePair<string, string>> Exif { get; set; }
        public PhotoScrollViewModel PhotoScrollModel { get; set; }
    }
}