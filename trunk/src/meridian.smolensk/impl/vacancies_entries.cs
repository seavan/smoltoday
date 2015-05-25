using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class vacancies_entries : IDictionaryValue
	{
        public IDictionaryCategory Category
        {
            get
            {
                return this.GetVacanciesVacancy_entrie() != null
                           ? this.GetVacanciesVacancy_entrie().GetEntriesVacancy_entry_categorie()
                           : null;
            }
            set
            {
                //this.restaurant_entry_category_id = value.id;
            }
        }

        public string Value
        {
            get
            {
                return this.GetVacanciesVacancy_entrie() != null
                           ? this.GetVacanciesVacancy_entrie().title
                           : null;
            }
            set
            {
                //throw new NotImplementedException();
            }
        }


        public long ValueId
        {
            get { return vacancy_entry_id; }
            set
            {
                if (value != vacancy_entry_id)
                {
                    this.DeleteAggregations();
                    vacancy_entry_id = value;
                    this.LoadAggregations(Meridian.Default);
                    Meridian.Default.vacancies_entriesStore.Update(this);
                }
            }
        }

        public string FreeValue
        {
            get { return null; }
            set
            {
                //throw new NotImplementedException();
            }
        }
	}
}
