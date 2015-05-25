using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class vacancy_entriesStore
    {
        public vacancy_entries GetEntryГражданинРФ()
        {
            return GetEntry("Гражданин РФ");
        }

        private vacancy_entries GetEntry(string name)
        {
            return All().FirstOrDefault(e => e.title == name);
        }
    }
}
