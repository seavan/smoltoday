using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.CodeModels.Security
{
    public class RegainModel
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EMail(ErrorMessage = "Неправильный формат электронной почты")]
        [DisplayName("Ваш e-mail")]
        public string EMailRem { get; set; }

        [Required(ErrorMessage = "Введите текст с картинки")]
        [DisplayName("Введите текст с картинки")]
        public string Captcha { get; set; }


        public bool Success { get; set; }
        public bool repeatActivation { get; set; }

        public RegainModel()
        {
            Success = false;
            repeatActivation = false;
        }
    }
}