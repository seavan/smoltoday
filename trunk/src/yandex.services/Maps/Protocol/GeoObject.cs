namespace yandex.services.Maps.Protocol
{
    public class GeoObject
    {
        public MetaDataProperty2 metaDataProperty { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public BoundedBy boundedBy { get; set; }
        public Point Point { get; set; }
    }
}