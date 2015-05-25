using System.ComponentModel.DataAnnotations;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class SimpleMailModel
    {
        /// <summary> кому отправлять сообщение
        /// </summary>
        public accounts ToUser { get; set; }

        /// <summary> от кого сообщение
        /// </summary>
        public accounts FromUser { get; set; }

        /// <summary> заголовок сообщения
        /// </summary>
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Title { get; set; }
        /// <summary> текст сообщения
        /// </summary>
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Message { get; set; }

        /// <summary> тема письма 
        /// </summary>
        public string Subject { get; set; }
    }
}