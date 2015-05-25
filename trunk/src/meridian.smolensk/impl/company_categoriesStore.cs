using System.Linq;
using admin.db;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class company_categoriesStore 
    {
        public company_categories GetCategory(long categoryId)
        {
            if (Exists(categoryId))
            {
                return Get(categoryId);
            }

            return null;
        }
    }
}