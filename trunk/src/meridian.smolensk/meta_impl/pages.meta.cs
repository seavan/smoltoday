using System;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class pages_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Заголовок страницы")]
        public string title { get; set; }

        [ScaffoldColumn(false)]
        public DateTime publish_date { get; set; }

        [ScaffoldColumn(false)]
        public long user_id { get; set; }
        
        [Display(Name = "Адрес/путь (без трейлинг слэша)")]
        public string alias { get; set; }

        [DataType("TelerikHtml")]
        public string html { get; set; }
    }
}