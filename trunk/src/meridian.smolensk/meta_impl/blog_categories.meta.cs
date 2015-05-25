using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    internal class blog_categories_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [ScaffoldColumn(false)]
        public string key { get; set; }

        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Укажите заголовок категории")]
        public string title { get; set; }

        [Display(Name = "Сортировка (от меньшего к большему)")]
        public int order_id { get; set; }

        [ScaffoldColumn(false)]
        public bool is_sub { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }

        [ScaffoldColumn(false)]
        public bool IsCur { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<blogs> CategoryBlog { get; set; }
    }
}