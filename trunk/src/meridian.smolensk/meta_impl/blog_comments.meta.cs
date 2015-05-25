using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class blog_comments_meta : comments_meta_base
    {
        [Display(Name = "Блог")]
        public string BlogTitle { get; set; }

        [ScaffoldColumn(false)]
        public long blog_id { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<blog_comments> BlogChildComments { get; set; }
    }
}