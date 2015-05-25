using System.ComponentModel.DataAnnotations;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class MaterialComplaintMailModel
    {
        public accounts User { get; set; }
        public string MaterialLink { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Message { get; set; }
    }
}