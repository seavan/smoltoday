using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    internal class company_comments_meta : comments_meta_base
    {
        [Display(Name = "Компания")]
        public string CompanyTitle { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<company_comments> Children { get; set; }

        [ScaffoldColumn(false)]
        public long company_id { get; set; }
    }
}