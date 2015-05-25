using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace meridian.smolensk.proto
{
    internal class restaurants_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string title { get; set; }

        [Display(Name = "Описание")]
        [DataType("TelerikHtml")]
        [Required]
        public string description { get; set; }

        [Display(Name = "Телефон")]
        public string phone { get; set; }

        [Display(Name = "Адрес")]
        [Required]
        public string address { get; set; }

        [Display(Name = "Количество мест")]
        public string holes_count { get; set; }

        [Display(Name = "Рабочее время")]
        public string work_time { get; set; }

        [Display(Name = "ВИП (выделен)")]
        public bool vip { get; set; }

        [Display(Name = "Можно бронировать столик")]
        public bool can_book_table { get; set; }

        [Display(Name = "E-mail для уведомлений")]
        public string feedback_email { get; set; }

        [Display(Name = "Галерея")]
        [ScriptIgnore]
        [DataType("GalleryEdit")]
        [Editable(true)]
        public IEnumerable<IAttachedPhoto> Photos { get; set; }

        [Display(Name = "Справочник")]
        [ScriptIgnore]
        [DataType("FixedDictionaryEdit")]
        [Editable(true)]
        public IEnumerable<IDictionaryValue> Entries { get; set; }

        [ScaffoldColumn(false)]
        public bool isReview { get; set; }

        [ScaffoldColumn(false)]
        public bool can_comment { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<restaurant_comments> RestaurantsComments { get; set; }

        [Display(Name = "Координаты")]
        [Editable(false)]
        public string coordinates { get; set; }

        [Display(Name = "Подпись на карте")]
        public string map_title { get; set; }

        [Display(Name = "Описание на карте")]
        public string map_description { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationCoordinates { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationTitle { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationDescription { get; set; }
    }
}