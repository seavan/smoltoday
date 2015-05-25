using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class sales_comments_meta : comments_meta_base
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [ScaffoldColumn(false)]
        public int Level { get; set; }

        [ScaffoldColumn(false)]
        public long sale_id { get; set; }

        [ScaffoldColumn(false)]
        public bool Delete { get; set; }
    }
}
