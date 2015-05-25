using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.CodeModels.Security
{
    public class OAuthModel
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EMail(ErrorMessage = "Неправильный формат электронной почты")]
        [DisplayName("Ваш e-mail")]
        public string UserEmail { get; set; }

        public Guid ServerAccessToken { get; set; }
        public string UserFirstName { get; set; }
    }
}