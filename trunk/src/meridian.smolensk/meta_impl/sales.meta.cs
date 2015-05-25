using System;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class sales_meta
    {
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Заголовок")]
        [Required]
        public string title { get; set; }

        [Display(Name = "Условия акции")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string text { get; set; }

        [Display(Name = "Дата создания")]
        [Editable(false)]
        public DateTime publish_date { get; set; }

        [Display(Name = "Выводить на главную")]
        [ScaffoldColumn(false)]
        public bool is_main { get; set; }

        [Display(Name = "Категория")]
        [DataType("Lookup")]
        [Required]
        public long category_id { get; set; }

        [Display(Name = "Компания")]
        [DataType("Lookup")]
        public long company_id { get; set; }

        [Display(Name = "Тип скидки")]
        [DataType("Lookup")]
        [Required]
        public long sale_type_id { get; set; }

        [ScaffoldColumn(false)]
        public int comment_count { get; set; }

        [Display(Name = "Дата начала")]
        public DateTime start_date { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTime end_date { get; set; }

        [Display(Name = "Минимальный процент")]
        public int percent { get; set; }

        [Display(Name = "Максимальный процент")]
        public int percent_max { get; set; }

        [Display(Name = "Сайт")]
        public string site { get; set; }

        [Display(Name = "Телефон")]
        public string phone { get; set; }

        [Display(Name = "Товары/услуги")]
        public string products { get; set; }

        [Display(Name = "Рабочее время")]
        public string work_time { get; set; }

        [Display(Name = "Офисы")]
        public string sales_offices { get; set; }

        [Display(Name = "Изображение")]
        [DataType("GalleryEdit")]
        public string image { get; set; }

        [Display(Name = "Изображение на главной странице портала")]
        [DataType("GalleryEdit")]
        [ScaffoldColumn(false)]
        public string image_for_main { get; set; }

        [ScaffoldColumn(false)]
        public string can_comment { get; set; }

        [ScaffoldColumn(false)]
        public string isReview { get; set; }

    }
}