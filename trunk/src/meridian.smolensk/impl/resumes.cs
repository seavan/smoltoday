using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.impl.Interfaces;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
	public partial class resumes :IVacancyOrResume, IFavorite
	{
        public int GetAge()
        {
            return (int)(DateTime.Now.Subtract(birth_date).TotalDays / 365);
        }

        #region Implementation of IVacancyOrResume

        public int Weight { get; set; }

        public IEnumerable<vacancy_professionals> GetRootProfessionals()
        {
            var m = Meridian.Default;
            return GetProfressionals()
                .Select(p => m.vacancy_professionalsStore.Get(p.professional_id))
                .Where(p => !p.parent_id.HasValue());
        }

        public List<vacancy_facilities> GetFacilityList()
        {
            return GetFacilities()
                .Select(f => Meridian.Default.vacancy_facilitiesStore.Get(f.facility_id))
                .ToList();
        }

        public vacancy_facility_variants GetVariant(long facilityId)
        {
            long vId = GetFacilities().Single(f => f.facility_id == facilityId).variant_id;
            return Meridian.Default.vacancy_facility_variantsStore.Get(vId);
        }

        #endregion

	    public void AddToFavorite(long account_id)
	    {
            Meridian.Default.accounts_favoritesStore.Insert(
                new accounts_favorites() { account_id = account_id, resume_id = this.id });
	    }

	    public void DeleteFromFavorite(long account_id)
	    {
            var fs = Meridian.Default.accounts_favoritesStore.All().FirstOrDefault(f => f.account_id == account_id && f.resume_id == this.id);
            if (fs == null) return;
	        Meridian.Default.accounts_favoritesStore.Delete(fs);
	    }

	    public bool IsFavorite(long account_id)
	    {
            return Meridian.Default.accounts_favoritesStore.All()
                .Any(f => f.account_id == account_id && f.resume_id == id);
	    }
	}
}
