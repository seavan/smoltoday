using System.ComponentModel.DataAnnotations;
namespace meridian.smolensk.proto
{
    internal class city_prices_icons_meta
    {
        [ScaffoldColumn(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        public string title { get; set; }

        [Display(Name = "Класс")]
        public string css_class { get; set; }

        [ScaffoldColumn(false)]
        public string Prices { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_value_disabled  { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
    }
}