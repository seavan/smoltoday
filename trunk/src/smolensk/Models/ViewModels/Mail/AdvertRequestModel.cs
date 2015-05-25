using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class AdvertRequestModel
    {
        public accounts Account { get; set; }
        public long  AdvertismentId { get; set; }
        public string Type { get; set; }
    }
}