using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public partial class company_kind_activities : ILookupValue
    {
        public string lookup_title
        {
            get { return this.name; }
        }

        public int lookup_value_level
        {
            get { return 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }
    }
}
