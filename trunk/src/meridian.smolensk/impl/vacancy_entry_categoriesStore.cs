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
	public partial class vacancy_entry_categoriesStore
	{
		public IEnumerable<vacancy_entry_categories> GetCategories()
		{
		    return Meridian.Default.vacancy_entry_categoriesStore.All().Where(c => c.id <= 5);
		}
	}
}
