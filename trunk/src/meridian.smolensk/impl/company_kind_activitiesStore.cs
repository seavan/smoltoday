using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using admin.db;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class company_kind_activitiesStore
    {
        void IDataService<company_kind_activities>.Delete(company_kind_activities item)
        {
            var meridian = Meridian.Default;
            var links = item.Companies.ToList();

            foreach (var link in links)
            {
                if (meridian.companiesStore.Exists(link.company_id))
                {
                    var company = meridian.companiesStore.Get(link.company_id);
                    company.RemoveKinds(link, true);
                }
            }

            meridian.company_kind_activitiesStore.Delete(item);
        }
    }
}
