using System.ComponentModel.DataAnnotations;
using System;

namespace meridian.smolensk.proto
{
    internal sealed class accounts_meta
    {
        [Display(Name = "Пользователь")]
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Электропочта")]
        public string email { get; set; }

        [Display(Name = "Имя")]
        public string firstname { get; set; }

        [Display(Name = "Фамилия")]
        public string lastname { get; set; }

        [Display(Name = "Дата регистрации")]
        public DateTime created { get; set; }

        [Display(Name = "Роль")]
        [DataType("UserRole")]
        public long role_id { get; set; }

        [Display(Name = "Дата последнего входа")]
        public DateTime lastlogin { get; set; }

        [Display(Name = "Пароль")]
        [UIHint("Password")]
        public string password { get; set; }

        [Display(Name = "Соль")]
        public Guid salt { get; set; }

        [Display(Name = "Активационный ключ")]
        public Guid activation_guid { get; set; }

        [ScaffoldColumn(false)]
        public int lookup_value_level { get; set; }

        [ScaffoldColumn(false)]
        public bool lookup_value_disabled { get; set; }

        [ScaffoldColumn(false)]
        public string lookup_title { get; set; }
    }
}
