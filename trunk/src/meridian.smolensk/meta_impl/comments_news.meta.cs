using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class comments_news_meta : comments_meta_base
    {
        [Display(Name = "Новость")]
        public string NewsTitle { get; set; }


        [ScaffoldColumn(false)]
        public bool ChildComments { get; set; }

        [ScaffoldColumn(false)]
        public long news_id { get; set; }

    }
}