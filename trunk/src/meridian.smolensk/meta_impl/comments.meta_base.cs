using System;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class comments_meta_base
    {
        [Editable(false)]
        public long id { get; set; }

        [ScaffoldColumn(false)]
        public int left_key { get; set; }

        [ScaffoldColumn(false)]
        public int right_key { get; set; }
        
        [ScaffoldColumn(false)]
        public int level { get; set; }
        
        [ScaffoldColumn(false)]
        public int LeftKey { get; set; }
        
        [ScaffoldColumn(false)]
        public int RightKey { get; set; }

        [ScaffoldColumn(false)]
        public bool delete { get; set; }

        [Editable(false)]
        [Display(Name = "Дата публикации")]
        [ScaffoldColumn(false)]
        public DateTime create_date { get; set; }

        [ScaffoldColumn(false)]
        public long account_id { get; set; }

        [ScaffoldColumn(false)]
        public long AuthorId { get; set; }

        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [DataType("MultilineText")]
        [Display(Name = "Текст")]
        public string text { get; set; }

        [ScaffoldColumn(false)]
        public long CommentText { get; set; }

        [ScaffoldColumn(false)]
        public long parent_id { get; set; }

        [ScaffoldColumn(false)]
        public long ParentId { get; set; }

        [ScaffoldColumn(false)]
        public long MaterialId { get; set; }

        [ScaffoldColumn(false)]
        public string MaterialProtoName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public bool isReview { get; set; }

        [Display(Name = "Ссылка")]
        [Editable(false)]
        public Uri Link { get; set; }
    }
}