using System;
using System.Linq;
using System.Text;

namespace yandex.services.Maps.Protocol
{
    public class GeocoderResponseMetaData
    {
        public string request { get; set; }
        public string found { get; set; }
        public string results { get; set; }
    }
}
