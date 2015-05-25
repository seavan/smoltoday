using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class sale_categories_meta
    {
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Заголовок")]
        public string title { get; set; }

        [Display(Name = "Порядок")]
        public int order_id { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
    }
}