using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class ad_fieldsStore
    {
        public IEnumerable<ad_fields> GetExisting()
        {
            return All().Where(af => af.GetAdFieldsAd_advertisment() != null);
        }
    }
}
