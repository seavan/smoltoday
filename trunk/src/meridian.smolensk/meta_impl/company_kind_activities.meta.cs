using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
	public partial class company_kind_activities_meta
	{
        [Display(Name = "ИД")]
        [Editable(false)]
		public long id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Укажите наименование сферы деятельности")]
		public string name { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<companies_kind_activities> Companies { get; set; }
	}
}
