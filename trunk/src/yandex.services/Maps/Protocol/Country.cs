namespace yandex.services.Maps.Protocol
{
    public class Country
    {
        public string AddressLine { get; set; }
        public string CountryNameCode { get; set; }
        public string CountryName { get; set; }
        public Locality Locality { get; set; }
    }
}