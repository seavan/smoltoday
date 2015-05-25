using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace meridian.smolensk.proto
{
    internal class companies_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название компании")]
        public string title { get; set; }

        [Display(Name = "Рабочее время")]
        public string work_time { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес компании")]
        public string address { get; set; }

        [Display(Name = "Веб-сайт")]
        public string www { get; set; }

        [Display(Name = "Адрес почты (в т.ч. для уведомлений)")]
        public string email { get; set; }

        [Display(Name = "Телефоны")]
        public string phones { get; set; }

        [Display(Name = "Руководитель")]
        public string leader { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime publish_date { get; set; }

        [Display(Name = "Категории")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Укажите категорию")]
        [DataType("Lookup")]
        public long category_id { get; set; }

        [Display(Name = "Сортировка в платных")]
        public long paid_order { get; set; }

        [Display(Name = "Сортировка в надежных")]
        public long stable_order { get; set; }

        [Display(Name = "Количество просмотров")]
        [Editable(false)]
        public long views_count { get; set; }

        [Display(Name = "Координаты")]
        [Editable(false)]
        public string coordinates { get; set; }

        [Display(Name = "Подпись на карте")]
        public string map_title { get; set; }

        [Display(Name = "Описание на карте")]
        public string map_description { get; set; }

        [Display(Name = "Галерея")]
        [ScriptIgnore]
        [DataType("GalleryEdit")]
        [Editable(true)]
        public IEnumerable<IAttachedPhoto> Photos { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationCoordinates { get; set; }

        [Display(Name = "Форма собственности")]
        [DataType("Lookup")]
        public long ownership_id { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationTitle { get; set; }

        [ScaffoldColumn(false)]
        public string GeoLocationDescription { get; set; }

        [ScaffoldColumn(false)]
        public int ViewsCount { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<company_comments> RootComments { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<company_rating> Ratings { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<vacancies> Vacancies { get; set; }

        [Display(Name = "Разрешить комментарии")]
        [ScaffoldColumn(false)]
        public bool can_comment { get; set; }

        [ScaffoldColumn(false)]
        public bool isReview { get; set; }

        [Display(Name = "Области деятельности")]
        [DataType("OneToManyEdit")]
        [Editable(true)]
        public IEnumerable<companies_kind_activities> Kinds { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<company_files> Files { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
    }
}