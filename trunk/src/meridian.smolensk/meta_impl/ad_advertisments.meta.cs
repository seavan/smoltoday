using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace meridian.smolensk.proto
{
    internal class ad_advertisments_meta
    {
        private const string CategoryErrorMessage = "Укажите категорию";
        private const string AccountErrorMessage = "Укажите аккаунт";

        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Аккаунт")]
        [Required(ErrorMessage = AccountErrorMessage)]
        [Range(1, int.MaxValue, ErrorMessage = AccountErrorMessage)]
        [DataType("Lookup")]
        public long account_id { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = CategoryErrorMessage)]
        [Range(1, int.MaxValue, ErrorMessage = CategoryErrorMessage)]
        [DataType("Lookup")]
        public long category_id { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime created_date { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Display(Name = "Имя")]
        public string name { get; set; }

        [Display(Name = "Телефон")]
        public string phone { get; set; }

        [Display(Name = "Почта")]
        public string email { get; set; }

        [Editable(false)]
        [Display(Name = "Количество просмотров")]
        public int view_count { get; set; }

        [Display(Name = "Выводить на главную")]
        public bool on_main { get; set; }

        [Display(Name = "Выводить в интересных")]
        public bool in_interesting { get; set; }

        [Display(Name = "Поднять в списках")]
        public bool pin_to_list { get; set; }

        [Required(ErrorMessage = "Название не может быть пустым")]
        [Display(Name = "Заголовок")]
        public string title { get; set; }

        [Display(Name = "Цена")]
        [Range(0d, 1e12, ErrorMessage = "Цена должна быть числом от нуля до квадриллиона")]
        public double price { get; set; }

        [Editable(false)]
        [Display(Name = "Источник объявления")]
        public string url { get; set; }

        [ScaffoldColumn(false)]
        public int ViewsCount { get; set; }

        [Display(Name = "Галерея")]
        [ScriptIgnore]
        [DataType("GalleryEdit")]
        [Editable(true)]
        public IEnumerable<IAttachedPhoto> Photos { get; set; }

        [Display(Name = "Справочник")]
        [ScriptIgnore]
        [DataType("FixedDictionaryEdit")]
        [Editable(true)]
        public IEnumerable<IDictionaryValue> AdFields { get; set; }

        [ScaffoldColumn(false)]
        public string PhotoUrl { get; set; }

        [ScaffoldColumn(false)]
        public string PreviewPhotoUrl { get; set; }

        [ScaffoldColumn(false)]
        public long ParentCategoryId { get; set; }
    }
}