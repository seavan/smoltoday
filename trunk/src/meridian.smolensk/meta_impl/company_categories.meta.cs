using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class company_categories_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название категории")]
        public string name { get; set; }

        [Display(Name = "Путь к иконке")]
        public string icon { get; set; }

        [Display(Name = "Родительская категория")]
        [DataType("Lookup")]
        public long parent { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }

        [ScaffoldColumn(false)]
        public int ProtoName { get; set; }

        [ScaffoldColumn(false)]
        public int title { get; set; }

        [ScaffoldColumn(false)]
        public int Children { get; set; }

        [ScaffoldColumn(false)]
        public int Companies { get; set; }


    }
}