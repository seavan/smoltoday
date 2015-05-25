using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
	public partial class regions_meta
	{
        [Display(Name = "ИД")]
        [Editable(false)]
		public long id { get; set; }

        [Display(Name = "Наименование региона")]
		public string title { get; set; }

        [Display(Name = "Города")]
        [DataType("ValueListEdit")]
        [Editable(true)]
        public IEnumerable<IValueListItem> Cities { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<resumes> Resumes { get; set; }
		
	}
}
