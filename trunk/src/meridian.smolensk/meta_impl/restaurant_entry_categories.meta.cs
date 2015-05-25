using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class restaurant_entry_categories_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        public string title { get; set; }

        [Display(Name = "Множественный выбор")]
        public bool is_multiple { get; set; }

        [Display(Name = "Произвольное значение")]
        [ScaffoldColumn(false)]
        public bool is_anyvalue { get; set; }

        [Display(Name = "Список допустимых значений")]
        [DataType("ValueListEdit")]
        [Editable(true)]
        public IEnumerable<IValueListItem> EntriesValues { get; set; }

        [ScaffoldColumn(false)]
        public bool is_visible { get; set; }

        [ScaffoldColumn(false)]
        public bool MultiValue { get; set; }

        [ScaffoldColumn(false)]
        public bool FreeValue { get; set; }

        [ScaffoldColumn(false)]
        public bool Selectable { get; set; }
    }
}