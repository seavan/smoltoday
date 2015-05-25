using System.Collections.Generic;

namespace smolensk.Models.CodeModels
{
    public class AdvertProperty
    {
        public long DescriptionId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public long ValueId { get; set; }
        public Dictionary<long, string> Values { get; set; }

        public AdvertProperty()
        {
            Values = new Dictionary<long, string>();
        }
    }
}