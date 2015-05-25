using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class city_prices_meta
    {
        [ScaffoldColumn(false)]
        public long id { get; set; }

        [Display(Name = "Заголовок")]
        public string title { get; set; }
        
        [Display(Name = "Иконка")]
        [DataType("Lookup")]
        public long icon_id { get; set; }

        [Display(Name = "Значение")]
        public string value { get; set; }

        [Display(Name = "Выпадающий HTML")]
        [DataType("TelerikHtml")]
        public string html { get; set; }

        [Display(Name = "Ссылка")]
        public string url_icon { get; set; }

        [Display(Name = "Ссылка показать все")]
        public string url_showall { get; set; }
    }
}