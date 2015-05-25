using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace meridian.smolensk.proto
{
    internal sealed class actions_meta
    {
        [Display(Name = "Мероприятие")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Название не может быть пустым")]
        public string title { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string text { get; set; }

        [Display(Name = "Дата создания")]
        [Editable(false)]
        public DateTime publish_date { get; set; }

        [Display(Name = "Показывать на главной странице портала")]
        public bool is_main { get; set; }

        [Display(Name = "Показать в разделе Кино и Театр на главной странице")]
        public bool is_main_category { get; set; }

        [Display(Name = "Поднимать в списках")]
        [ScaffoldColumn(false)]
        public bool is_top { get; set; }

        [Display(Name = "Рейтинг")]
        [Editable(false)]
        public int rating { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public int age_limit { get; set; }

        [ScaffoldColumn(false)]
        public int comment_count { get; set; }

        [Display(Name = "Число участников")]
        [Editable(false)]
        public int participiants_count { get; set; }

        [Display(Name = "Категория")]
        [DataType("Lookup")]
        [Required]
        public long category_id { get; set; }

        [Display(Name = "Мероприятия создано")]
        [DataType("Lookup")]
        public long account_id { get; set; }

        [Display(Name = "Опубликовано")]
        public bool published { get; set; }

        [Display(Name = "Подтверждено")]
        public bool approve { get; set; }

        [Display(Name = "Удалено")]
        public bool delete { get; set; }

        [Display(Name = "Автор")]
        public string author { get; set; }

        [Display(Name = "Режиссер")]
        public string producer { get; set; }

        [Display(Name = "Постановка")]
        public string statement { get; set; }

        [Display(Name = "Лектор")]
        public string lecturer { get; set; }

        [Display(Name = "Исполнители")]
        public string performers { get; set; }

        [Display(Name = "Страна")]
        public string country { get; set; }

        [Display(Name = "Продолжительность, мин")]
        public int duration { get; set; }

        [Display(Name = "Премьера")]
        public DateTime start_date { get; set; }

        [Display(Name = "Цена от")]
        public int price_min { get; set; }

        [Display(Name = "Цена до")]
        public int price_max { get; set; }

        [Display(Name = "Сайт")]
        public string site { get; set; }

        [Display(Name = "Ссылка в Google+")]
        public string google_link { get; set; }

        [Display(Name = "Ссылка в Facebook")]
        public string facebook_link { get; set; }

        [Display(Name = "Ссылка в Twitter")]
        public string twitter_link { get; set; }

        [Display(Name = "Ссылка во ВКонтакте")]
        public string vk_link { get; set; }

        [Display(Name = "Ссылка в mail")]
        public string mail_link { get; set; }

        [Display(Name = "Ссылка в Одноклассниках")]
        public string odnoklassniki_link { get; set; }

        [Display(Name = "Координаты")]
        [ScaffoldColumn(false)]
        public string coordinates { get; set; }

        [Display(Name = "Заголовок на карте")]
        [ScaffoldColumn(false)]
        public string map_title { get; set; }

        [Display(Name = "Описание на карте")]
        [ScaffoldColumn(false)]
        public string map_description { get; set; }

        [Display(Name = "Изображение на главной странице портала")]
        [DataType("GalleryEdit")]
        public string image_for_main { get; set; }

        [ScaffoldColumn(false)]
        public bool can_comment { get; set; }

        [ScaffoldColumn(false)]
        public bool isReview { get; set; }

        [Editable(false)]
        [Display(Name = "Основная ссылка")]
        public bool ItemMainUri { get; set; }

        [Display(Name = "Галерея")]
        [ScriptIgnore]
        [DataType("GalleryEdit")]
        [Editable(true)]
        public IEnumerable<IAttachedPhoto> Photos { get; set; }

        [Display(Name = "Жанры")]
        [ScriptIgnore]
        [DataType("OneToManyEdit")]
        [Editable(true)]
        public IEnumerable<ILookupValue> ActionGenre { get; set; }

        [Display(Name = "Места проведения события")]
        [ScriptIgnore]
        [DataType("OneToManyEdit")]
        [Editable(true)]
        public IEnumerable<ILookupValue> ActionPlace { get; set; }

        [Display(Name = "Расписание")]
        [ScriptIgnore]
        [DataType("ScheduleEdit")]
        [Editable(true)]
        public string ActionSchedule { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<actions_comments> ActionComment { get; set; }
    }
}
