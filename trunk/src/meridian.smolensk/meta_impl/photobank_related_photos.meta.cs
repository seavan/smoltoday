using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using admin.db;

namespace meridian.smolensk.proto
{
	public partial class photobank_related_photos_meta
	{
        [Editable(false)]
        [Display(Name = "ИД")]
		public long id { get; set; }

        [Display(Name = " ")]
        [DataType("ParentLink")]
		public long photo_id { get; set; }

        [ScaffoldColumn(false)]
		public bool original { get; set; }

        [Display(Name = "Ширина")]
        [Editable(false)]
		public int width { get; set; }

        [Display(Name = "Высота")]
        [Editable(false)]
		public int height { get; set; }

        [Display(Name = "Лицензия / Цена")]
        [ScriptIgnore]
        [DataType("Licenses")]
        [Editable(true)]
        public IEnumerable<photobank_photo_prices> Prices{ get; set; }

        [Display(Name = "Системное имя")]
        [Editable(false)]
		public string photo { get; set; }

        [Display(Name = "Имя оригинального файла")]
        [Editable(false)]
		public string filename { get; set; }

        [ScaffoldColumn(false)]
        public bool IsMain { get; set; }

        [ScaffoldColumn(false)]
        public bool ShowIsMain { get; set; }

        [ScaffoldColumn(false)]
        public string EditLink { get; set; }

        [ScaffoldColumn(false)]
        public string ThumbUrl { get; set; }

        [ScaffoldColumn(false)]
        public string FullUrl { get; set; }

        [ScaffoldColumn(false)]
        public string PhotoUrl { get; set; }

        [ScaffoldColumn(false)]
        public IDatabaseEntity AttachedPhotoContainer { get; set; }

        [ScaffoldColumn(false)]
        public long Id { get; set; }

	}
}
