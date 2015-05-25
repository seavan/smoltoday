using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    internal sealed class news_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Заголовок")]
        [Required]
        public string title { get; set; }

        [Display(Name = "Лид")]
        public string lead_title { get; set; }

        [DataType("TelerikHtml")]
        [Display(Name = "Анонс")]
        [Required]
        public string announce { get; set; }

        [Display(Name = "Материал подготовлен (в творительном падеже)")]
        public string author_as_text { get; set; }

        [DataType("TelerikHtml")]
        [Display(Name = "Текст")]
        [Required]
        public string text { get; set; }

        [ScaffoldColumn(false)]
        public string processed_text { get; set; }

        [Editable(false)]
        [Display(Name = "Дата создания")]
        public DateTime create_date { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime publish_date { get; set; }

        [Display(Name = "Главная новость")]
        public bool is_main { get; set; }

        [Display(Name = "Новость Смоленска")]
        public bool is_smolensk_news { get; set; }

        [Display(Name = "Рейтинг")]
        [Editable(false)]
        public int rating { get; set; }

        [Display(Name = "Количество просмотров")]
        [Editable(false)]
        public int views { get; set; }

        [Display(Name = "Количество комментариев")]
        [Editable(false)]
        public int comment_count { get; set; }

        [Display(Name = "Категория")]
        [DataType("NewsCategory")]
        public long category_id { get; set; }

        [ScaffoldColumn(false)]
        public bool can_comment { get; set; }

        [ScaffoldColumn(false)]
        public bool isReview { get; set; }

        [ScaffoldColumn(false)]
        public string ItemMainUri { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<comments_news> NewsComments { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<news_images> NewsImages { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<news_videos> NewsVideo { get; set; }

        [Display(Name = "Теги (через запятую)")]
        public string tags { get; set; }
    }
}