﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
	public partial class cities_meta
	{

        [Editable(false)]
        [Display(Name = "ИД")]
        public long id { get; set; }
        
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название")]
        public string title { get; set; }

		public long region_id { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
	}
}
