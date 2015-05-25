using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class GetSessionModel
    {
        public accounts Photographer { get; set; }
        public accounts User { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
    }
}