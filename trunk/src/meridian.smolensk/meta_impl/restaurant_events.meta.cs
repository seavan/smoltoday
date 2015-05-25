using System;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class restaurant_events_meta
    {
        [Display(Name = "ИД")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Обязательное поле \"Название\" не заполнено")]
        public string title { get; set; }

        [Display(Name = "Краткое описание")]
        [DataType("TelerikHtml")]
        public string short_desc { get; set; }

        [Display(Name = "Ресторан")]
        [DataType("Lookup")]
        [Required(ErrorMessage = "Не выбран ресторан")]
        public string restaurant_id { get; set; }

        [Display(Name = "Дата и время")]
        [Required(ErrorMessage = "Не указано время проведения мероприятия")]
        public DateTime date { get; set; }

        [ScaffoldColumn(false)]
        public string ProtoName { get; set; }
    }
}