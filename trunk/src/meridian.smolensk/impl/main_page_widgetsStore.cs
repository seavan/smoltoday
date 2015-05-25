using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class main_page_widgetsStore
    {
        public main_page_widgets GetRecord()
        {
            return All().First();
        }
    }
}
