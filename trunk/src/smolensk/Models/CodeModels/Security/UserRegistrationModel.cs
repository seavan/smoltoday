using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.CodeModels.Security
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EMail(ErrorMessage = "Неправильный формат электронной почты")]
        [UniqueEMail(ErrorMessage = "Этот адрес электронной почты уже зарегистрирован")]
        [DisplayName("Ваш e-mail")]
        public string EMailReg { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DisplayName("Пароль ещё раз")]
        [UIHint("Password")]
        [Equality(ErrorMessage = "Пароли должны совпадать", FieldForComparison = "Password")]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Введите текст с картинки")]
        [DisplayName("Введите текст")]
        public string Captcha { get; set; }

        public bool Success { get; set; }
        public UserRegistrationModel()
        {
            Success = false;
        }
    }
}