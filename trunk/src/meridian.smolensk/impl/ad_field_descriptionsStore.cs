using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
	public partial class ad_field_descriptionsStore
    {
        public ad_field_descriptions GetDescription(long id)
        {
            return Exists(id) ? Get(id) : null;
        }

        public IEnumerable<ad_field_descriptions> GetDescriptionsByCategory(long? categoryId)
        {
            if (categoryId.HasValue && Meridian.Default.ad_categoriesStore.Exists(categoryId.Value))
            {
                var category = Meridian.Default.ad_categoriesStore.Get(categoryId.Value);
                if(category.parent_id > 0)
                {
                    return All().Where(d => d.ad_category_id == category.id || d.ad_category_id == category.parent_id).OrderBy(d => d.ad_category_id);
                }
                else
                {
                    return All().Where(d => d.ad_category_id == category.id);
                }
            }
            else
            {
                return new List<ad_field_descriptions>();
            }
            
        }
    }
}
