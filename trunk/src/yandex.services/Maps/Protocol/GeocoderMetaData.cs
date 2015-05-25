namespace yandex.services.Maps.Protocol
{
    public class GeocoderMetaData
    {
        public string kind { get; set; }
        public string text { get; set; }
        public string precision { get; set; }
        public AddressDetails AddressDetails { get; set; }
    }
}