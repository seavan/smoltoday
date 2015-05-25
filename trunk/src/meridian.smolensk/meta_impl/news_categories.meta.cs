using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class news_categories_meta
    {
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Класс в разметке")]
        public string css_class { get; set; }

        [Display(Name = "Заголовок")]
        public string title { get; set; }

        [Display(Name = "Сортировка")]
        public int order_id { get; set; }
    }
}