using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    internal class photobank_photos_meta
    {
        [Editable(false)]
        [Display(Name = "ИД")]
        public long id { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Укажите аккаунт")]
        [Range(1, double.MaxValue)]
        [DataType("Lookup")]
        public long category_id { get; set; }

        [ScaffoldColumn(false)]
        public long account_id { get; set; }

        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Укажите название")]
        public string title { get; set; }

        [Display(Name = "Описание")]
        public string description { get; set; }

        [Display(Name = "Адрес предпросмотра")]
        [Editable(false)]
        public string preview { get; set; }

        [Display(Name = "Адрес квадратного предпросмотра ")]
        [Editable(false)]
        public string preview_square { get; set; }

        [Display(Name = "Адрес основного предпросмотра")]
        [Editable(false)]
        public string preview_main { get; set; }

        [Display(Name = "Количество просмотров")]
        [Editable(false)]
        public int view_count { get; set; }

        [Display(Name = "Количество скачиваний")]
        [Editable(false)]
        public int download_count { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime publish_date { get; set; }

        [Display(Name = "Рейтинг")]
        [Editable(false)]
        public int rating { get; set; }

        [Display(Name = "Альбом")]
        [NeedSelectEntity(ErrorMessage = "Укажите альбом")]
        [DataType("Lookup")]
        public long album_id { get; set; }

        [Display(Name = "Выводить на главной")]
        public bool is_main { get; set; }

        [Display(Name = "Фото дня")]
        public bool day_photo { get; set; }

        [Display(Name = "Фотографии")]
        [ScriptIgnore]
        [DataType("GalleryEdit")]
        [Editable(true)]
        public IEnumerable<IAttachedPhoto> Photos { get; set; }


        [ScaffoldColumn(false)]
        public string MainPhoto { get; set; }

        [ScaffoldColumn(false)]
        public string Account { get; set; }

        [ScaffoldColumn(false)]
        public string Category { get; set; }

        [ScaffoldColumn(false)]
        public string Tags { get; set; }

        [ScaffoldColumn(false)]
        public string PreviewMainUrl { get; set; }

        [ScaffoldColumn(false)]
        public string PreviewUrl { get; set; }

        [ScaffoldColumn(false)]
        public string PreviewSquareUrl { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<photobank_photo_tags> PhotoTags { get; set; }
    }
}