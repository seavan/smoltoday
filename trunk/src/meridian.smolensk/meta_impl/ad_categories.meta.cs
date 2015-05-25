using System;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal sealed class ad_categories_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }

        [ScaffoldColumn(false)]
        public string AdsCount { get; set; }

        [ScaffoldColumn(false)]
        public string ParentCategoryId { get; set; }

        [ScaffoldColumn(false)]
        public string IsRootCategory { get; set; }
 
        [ScaffoldColumn(false)]
        public string CategoryIds { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название категории")]
        public string title { get; set; }

        [Display(Name = "Категория")]
        [DataType("Lookup")]
        public string parent_id { get; set; }
        
        [ScaffoldColumn(false)]
        public string Descriptions { get; set; }
        
        [ScaffoldColumn(false)]
        public string Subcategories { get; set; }
        
        [ScaffoldColumn(false)]
        public string Advertisments { get; set; }
    }
}