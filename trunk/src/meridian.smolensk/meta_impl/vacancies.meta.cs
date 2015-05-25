using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace meridian.smolensk.proto
{
	public partial class vacancies_meta
	{
        [Display(Name = "ИД")]
        [Editable(false)]
		public long id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Название не может быть пустым")]
		public string title { get; set; }

        [Display(Name = "Компания")]
        [Required(ErrorMessage = "Укажите компанию")]
        [Range(1, Int32.MaxValue)]
        [DataType("Lookup")]
		public long company_id { get; set; }

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город")]
        [Range(1, Int32.MaxValue)]
        [DataType("Lookup")]
		public long city_id { get; set; }

        [Display(Name = "Представитель")]
        [Required(ErrorMessage = "Укажите контактное лицо")]
		public string contact_person { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Телефон для связи не может быть пустым")]
		public string contact_phone { get; set; }
        [Display(Name = "Добавочный телефон")]
		public string contact_phone2 { get; set; }


        [Display(Name = "Оплата труда ОТ")]
		public int compensation1 { get; set; }
        [Display(Name = "Оплата труда ДО")]
		public int compensation2 { get; set; }
        [Display(Name = "Возраст ОТ")]
		public int age1 { get; set; }
        [Display(Name = "Возраст ДО")]
		public int age2 { get; set; }
        [Display(Name = "Пол")]
		public int sex { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
		public string description { get; set; }

        [Display(Name = "Обязанности")]
        [DataType(DataType.MultilineText)]
		public string responsibility { get; set; }

        [Display(Name = "Требования")]
        [DataType(DataType.MultilineText)]
		public string requirements { get; set; }

        [Display(Name = "Условия")]
        [DataType(DataType.MultilineText)]
		public string terms { get; set; }

        [ScaffoldColumn(false)]
		public long work_region_id { get; set; }
        [ScaffoldColumn(false)]
		public long work_city_id { get; set; }
        [ScaffoldColumn(false)]
		public string work_phone { get; set; }
        [ScaffoldColumn(false)]
		public string work_phone2 { get; set; }
        [ScaffoldColumn(false)]
		public string work_address { get; set; }

        [Display(Name = "Дата создания")]
		public DateTime created { get; set; }

        [Display(Name = "Дата редактирования")]
		public DateTime edited { get; set; }

        [ScaffoldColumn(false)]
		public long views_count { get; set; }

        [Display(Name = "Закрыта")]
		public bool closed { get; set; }

        [Display(Name = "Показывать в баннерах")]
		public bool show_in_banner { get; set; }

        [Display(Name = "Создатель вакансии")]
        [DataType("Lookup")]
		public long account_id { get; set; }

        [Display(Name = "Опубликовано")]
		public bool is_publish { get; set; }

        [Editable(false)]
        [Display(Name = "Ссылка")]
		public string url { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActual { get; set; }

        [Display(Name = "Вес")]
        public int Weight { get; set; }

        [Editable(false)]
        [Display(Name = "Количество просмотров")]
        public int ViewsCount { get; set; }

        [Display(Name = "Профессиональная область")]
        [ScriptIgnore]
        [DataType("OneToManyEdit")]
        [Editable(true)]
        public IEnumerable<ILookupValue> Profressionals { get; set; }

        [Display(Name = "Справочник")]
        [ScriptIgnore]
        [DataType("FixedDictionaryEdit")]
        [Editable(true)]
        public IEnumerable<IDictionaryValue> Entries { get; set; }

        [Display(Name = "Льготы")]
        [ScriptIgnore]
        [DataType("FixedDictionaryEdit")]
        [Editable(true)]
        public IEnumerable<IDictionaryValue> Facilities { get; set; }
		
	}
}
