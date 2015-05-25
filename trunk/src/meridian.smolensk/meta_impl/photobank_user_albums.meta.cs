using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
	public partial class photobank_user_albums_meta
	{
        [Editable(false)]
        [Display(Name = "ИД")]
		public long id { get; set; }

        [Display(Name = "Аккаунт")]
        [Required(ErrorMessage = "Укажите аккаунт")]
        [Range(1, double.MaxValue)]
        [DataType("Lookup")]
		public long account_id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название")]
		public string title { get; set; }

        [Display(Name = "Дата съёмки")]
		public DateTime shoot_date { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }

        [ScaffoldColumn(false)]
        public string PreviewUrl { get; set; }

        [Editable(false)]
        [Display(Name = "Фотографий в альбоме")]
        public int CountPhotos { get; set; }

        [Display(Name = " ")]
        [DataType("PhotosLink")]
        public string PhotosLink { get; set; }

	}
}
