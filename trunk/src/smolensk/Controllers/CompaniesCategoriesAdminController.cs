using System.Collections.Generic;
using System.Linq;
using meridian.smolensk.controller;
using meridian.smolensk.proto;

namespace smolensk.Controllers
{
    public class CompaniesCategoriesAdminController : meridian_company_categories
    {
        protected override System.Linq.IQueryable<meridian.smolensk.proto.company_categories> Filter(System.Linq.IQueryable<meridian.smolensk.proto.company_categories> _src)
        {
            var result = new List<company_categories>();
            
            var parentCats = _src.Where(s => s.GetChildrenCompany_categorie() == null).OrderBy(s => s.title);

            foreach (var c in parentCats)
            {
                result.Add(c);
                result.AddRange(c.Children);
            }

            return result.AsQueryable();
        }
    }
}