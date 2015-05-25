using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
	public partial class genres_meta
	{
        [Display(Name = "ИД")]
        [Editable(false)]
		public long id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Укажите наименование жанра")]
		public string title { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<actions_genres> Genre { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level{ get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled{ get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
	}
}
