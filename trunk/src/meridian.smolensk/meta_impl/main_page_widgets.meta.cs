using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class main_page_widgets_meta
    {
        [ScaffoldColumn(false)]
        public long id { get; set; }

        [Editable(false)]
        [Display(Name = "Температура (сейчас)")]
        public string temperature { get; set; }
        
        [Editable(false)]
        [Display(Name = "Облачность (сейчас)")]
        public string sky { get; set; }

        [ScaffoldColumn(false)]
        public string sky_icon { get; set; }

        [Editable(false)]
        [Display(Name = "Курс евро (дельта)")]
        public System.Decimal eur_price { get; set; }

        [Editable(false)]
        [Display(Name = "Курс евро (дельта)")]
        public System.Decimal eur_change { get; set; }

        [Editable(false)]
        [Display(Name = "Курс доллара")]
        public System.Decimal usd_price { get; set; }

        [Editable(false)]
        [Display(Name = "Курс доллара (дельта)")]
        public System.Decimal usd_change { get; set; }

        [Display(Name = "Пробки (баллы)")]
        public int jams_degree { get; set; }

        [Display(Name = "Пробки (описание)")]
        public string jams_description { get; set; }

        [ScaffoldColumn(false)]
        public string sky_icon_morning { get; set; }

        [ScaffoldColumn(false)]
        public string sky_icon_afternoon { get; set; }

        [ScaffoldColumn(false)]
        public string sky_icon_evening { get; set; }

        [Editable(false)]
        [Display(Name = "Облачность (утро)")]
        public string sky_morning { get; set; }

        [Editable(false)]
        [Display(Name = "Облачность (обед)")]
        public string sky_afternoon { get; set; }
        
        [Editable(false)]
        [Display(Name = "Облачность (вечер)")]
        public string sky_evening { get; set; }

        [Editable(false)]
        [Display(Name = "Температура (утро)")]
        public string temperature_morning { get; set; }

        [Editable(false)]
        [Display(Name = "Температура (день)")]
        public string temperature_afternoon { get; set; }

        [Editable(false)]
        [Display(Name = "Температура (вечер)")]
        public string temperature_evening { get; set; }

    }
}