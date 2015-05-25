using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.CodeModels.Security
{
    public class UserAuthenticationModel
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EMail(ErrorMessage = "Неправильный формат электронной почты")]
        [DisplayName("Ваш e-mail")]
        public string EMailAuth { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [DisplayName("Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [DisplayName("Запомнить меня")]
        public bool Remember { get; set; }
        
        public bool isActivate { get; set; }

        public UserAuthenticationModel()
        {
            isActivate = true;
        }

        public string currentUrlToReturn { get; set; }
    }
}