using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
	public partial class photobank_licenses_meta
	{
        [Display(Name = "ИД")]
        [Editable(false)]
		public long id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Укажите название")]
		public string title { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<photobank_photo_prices> Licenses { get; set; }
	}
}
