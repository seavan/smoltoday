using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    internal class blogs_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Укажите заголовок блога")]
        public string title { get; set; }

        [Display(Name = "Анонс")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Введите анонс")]
        [StringLength(170, ErrorMessage = "Максимальная длина анонса 170 символов")]
        public string announce { get; set; }

        [Display(Name = "Текст")]
        [DataType("TelerikHtml")]
        [Required(ErrorMessage = "Введите текст записи блога")]
        public string text { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime create_date { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime publish_date { get; set; }

        [Display(Name = "Показывать на главной")]
        public bool is_main { get; set; }

        [Display(Name = "Показывать в интересных")]
        public bool is_interesting { get; set; }

        [Display(Name = "Блог месяца")]
        public bool is_thebest { get; set; }

        [Display(Name = "Рейтинг")]
        [Editable(false)]
        public int rating { get; set; }

        [Display(Name = "Количество просмотров")]
        [Editable(false)]
        public int views { get; set; }

        [ScaffoldColumn(false)]
        public int comment_count { get; set; }

        [Display(Name = "Категория")]
        [DataType("Lookup")]
        public long category_id { get; set; }

        [Display(Name = "Автор")]
        [DataType("Lookup")]
        [Required(ErrorMessage = "Укажите автора")]
        [NeedSelectEntity(ErrorMessage = "Укажите автора")]
        public long account_id { get; set; }

        [Display(Name = "Разрешить комментарии")]
        public bool can_comment { get; set; }

        [Display(Name = "Опубликовать")]
        public bool is_publish { get; set; }

        [Display(Name = "Удалить")]
        public bool is_delete { get; set; }

        [ScaffoldColumn(false)]
        public string ProtoName { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<blog_comments> BlogComments { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<blog_marks> BlogMarks { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<blog_lastviews> LastViews { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<blog_photos> ImagesBlog { get; set; }
    }
}