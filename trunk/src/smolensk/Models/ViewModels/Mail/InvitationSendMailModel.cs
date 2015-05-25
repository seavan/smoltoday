using System.ComponentModel.DataAnnotations;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class InvitationSendMailModel
    {
        public accounts Sender { get; set; }

        public resumes Resume { get; set; }
        public long ResumeId { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Message { get; set; }        
    }
}