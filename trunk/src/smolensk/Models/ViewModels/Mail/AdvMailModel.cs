using System.ComponentModel.DataAnnotations;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class AdvMailModel
    {
        public accounts User { get; set; }
        public ad_advertisments Adv { get; set; }

        public long AdvId { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Theme { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Message { get; set; }
    }
}