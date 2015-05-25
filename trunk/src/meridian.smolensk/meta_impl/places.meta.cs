using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class places_meta
    {
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Не указано название места проведения")]
        public string title { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string text { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Не указан адрес места проведения")]
        public string adress { get; set; }

        [Display(Name = "Стоимость")]
        public string price { get; set; }

        [Display(Name = "Часы работы")]
        [DataType(DataType.MultilineText)]
        public string work_time { get; set; }

        [Display(Name = "Как доехать")]
        public string location { get; set; }

        [Display(Name = "Телефон")]
        public string phone { get; set; }

        [Display(Name = "Сайт")]
        public string site { get; set; }

        [Display(Name = "Гугл+")]
        public string google_link { get; set; }

        [Display(Name = "Фейсбук")]
        public string facebook_link { get; set; }

        [Display(Name = "Твиттер")]
        public string twitter_link { get; set; }

        [Display(Name = "ВКонтакте")]
        public string vk_link { get; set; }

        [Display(Name = "Ссылка на Mой Мир мэйл ру")]
        public string mail_link { get; set; }

        [Display(Name = "Ссылка на одноклассники")]
        public string odnoklassniki_link { get; set; }

        [Display(Name = "Координаты (автоматически рассчитываются по адресу)")]
        [Editable(false)]
        public string coordinates { get; set; }

        [ScaffoldColumn(false)]
        public string ActionPlace { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationCoordinates { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationDescription { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationTitle { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
    }
}