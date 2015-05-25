using System.Collections.Generic;
using smolensk.Models.CodeModels;

namespace smolensk.Models.ViewModels
{
    public class FilterAdsViewModel
    {
        public List<AdType> Types { get; set; }
        public long CategoryId { get; set; }
        public long DescriptionId { get; set; }
        public long Type { get; set; }
        public string Sort { get; set; }
    }
}