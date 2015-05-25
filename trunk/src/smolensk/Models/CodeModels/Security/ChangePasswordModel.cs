using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.CodeModels.Security
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DisplayName("Пароль ещё раз")]
        [UIHint("Password")]
        [Equality(ErrorMessage = "Пароли должны совпадать", FieldForComparison = "Password")]
        public string PasswordConfirmation { get; set; }
    }
}