using System.Collections.Generic;

namespace yandex.services.Maps.Protocol
{
    public class GeoObjectCollection
    {
        public MetaDataProperty metaDataProperty { get; set; }
        public List<FeatureMember> featureMember { get; set; }
    }
}