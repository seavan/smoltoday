using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.impl.Interfaces;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class vacancies : IViewableMaterial, IVacancyOrResume, IFavorite, ILookupValueAspectProvider, IOneToManyAspectProvider, IDictionaryValuesAspectProvider
    {
        public bool IsActual
        {
            get { return !closed && is_publish; }
        }

        #region Implementation of IViewableMaterial

        public int ViewsCount
        {
            get { return (int)views_count; }
            set { views_count = value; }
        }

        public void IncrementViewsCount()
        {
            ViewsCount++;
            Meridian.Default.vacanciesStore.Update(this);
        }

        #endregion

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

        #region Implementation of IFavorite
        public bool IsFavorite(long account_id)
        {
            return Meridian.Default.accounts_favoritesStore.All().Any(f => f.account_id == account_id && f.vacancy_id == this.id);
        }

        public void AddToFavorite(long account_id)
        {
            Meridian.Default.accounts_favoritesStore.Insert(
                new accounts_favorites() { account_id = account_id, vacancy_id = this.id });
        }

        public void DeleteFromFavorite(long account_id)
        {
            var fs = Meridian.Default.accounts_favoritesStore.All().FirstOrDefault(f => f.account_id == account_id && f.vacancy_id == this.id);
            if (fs == null) return;
            Meridian.Default.accounts_favoritesStore.Delete(fs);
        }
        #endregion
        
        #region Implementation of ILookupValueAspectProvider
        public ILookupValueAspect Getcompany_idLookupValueAspect()
        {
            return new LookupAspect("company_id", this, () => { return Meridian.Default.companiesStore.All(); });
        }

        public ILookupValueAspect Getcity_idLookupValueAspect()
        {
            return new LookupAspect("city_id", this, () => { return Meridian.Default.citiesStore.All(); });
        }
        public ILookupValueAspect Getaccount_idLookupValueAspect()
        {
            return new LookupAspect("account_id", this, () => { return Meridian.Default.accountsStore.All(); });
        }
        #endregion

        #region Implemetnation of IOneToManyAspectProvider
        public IEnumerable<vacancy_professionals> GetRealProfressionals()
        {
            return this.GetProfressionals().Where(s => s.GetVacanciesVacancy_professional() != null).Select(s => s.GetVacanciesVacancy_professional());
        }
        public IOneToManyAspect GetOneToManyAspect(string _fieldName)
        {
            switch (_fieldName)
            {
                case "Profressionals":
                    return new OneToManyAspect<vacancy_professionals>(this, "Profressionals",
                                                               Meridian.Default.vacancy_professionalsStore.All,
                                                               this.GetRealProfressionals,
                                                               (prof) =>
                                                               {
                                                                   if (!this.GetRealProfressionals().Any(s => s.id.Equals(prof)))
                                                                   {
                                                                       this.AddProfressionals(new vacancies_professionals()
                                                                           {
                                                                               vacancy_id = this.id,
                                                                               professional_id = prof
                                                                           }, true);
                                                                   }

                                                               }
                                                               ,
                                                               (prof)
                                                               =>
                                                               {
                                                                   var professionals =
                                                                       GetProfressionals()
                                                                           .Where(s => s.professional_id.Equals(prof)).ToArray();
                                                                   foreach (var g in professionals)
                                                                   {
                                                                       this.RemoveProfressionals(g, true);
                                                                   }

                                                               });
                


            }

            return null;
        }
        #endregion

        #region Implemetnation of IDictionaryValuesAspectProvider
        public IDictionaryValuesAspect GetDictionaryValuesAspect(string _fieldName)
        {
            switch (_fieldName)
            {
                case "Entries":
                    {
                        return new DictionaryAspect<vacancy_entry_categories, vacancies_entries>(
                            this,
                            "Entries",
                            () => Meridian.Default.vacancy_entry_categoriesStore.GetCategories(),
                            () => this.Entries,
                            (a, b) =>
                            {
                                var entries = Entries.Where(s => b != 0 ? s.ValueId.Equals(b) : s.Category != null && s.Category.id.Equals(a)).ToArray();
                                foreach (var e in entries) this.RemoveEntries(e, true);
                            },
                            (a, b, c) =>
                            {
                                var existing = Entries.Where(s => s.Category != null && s.Category.id == a).ToArray();

                                if (existing.Count() >= 1)
                                {
                                    var category = existing.First().Category;

                                    if (category.MultiValue)
                                    {
                                        if (existing.Any(s => s.ValueId.Equals(b)))
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 1; i < existing.Length; ++i)
                                        {
                                            RemoveEntries(existing[i], true);
                                        }
                                        existing[0].ValueId = b;

                                        return;
                                    }


                                }

                                this.AddEntries(new vacancies_entries()
                                {
                                    vacancy_id = id,
                                    vacancy_entry_id = b
                                }, true);
                            }
                            );
                    }
                case "Facilities":
                    {
                        return new DictionaryAspect<vacancy_facilities, vacancies_facilities>(
                            this,
                            "Facilities",
                            () => Meridian.Default.vacancy_facilitiesStore.All(),
                            () => this.Facilities,
                            (a, b) =>
                            {
                                var entries = Facilities.Where(s => b != 0 ? s.ValueId.Equals(b) : s.Category != null && s.Category.id.Equals(a)).ToArray();
                                foreach (var e in entries) this.RemoveFacilities(e, true);
                            },
                            (a, b, c) =>
                            {
                                var existing = Facilities.Where(s => s.Category != null && s.Category.id == a).ToArray();

                                if (existing.Count() >= 1)
                                {
                                    var category = existing.First().Category;

                                    if (category.MultiValue)
                                    {
                                        if (existing.Any(s => s.ValueId.Equals(b)))
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 1; i < existing.Length; ++i)
                                        {
                                            RemoveFacilities(existing[i], true);
                                        }
                                        existing[0].ValueId = b;

                                        return;
                                    }


                                }

                                this.AddFacilities(new vacancies_facilities()
                                {
                                    vacancy_id = id,
                                    variant_id = b,
                                    facility_id = a

                                }, true);
                            }
                            );
                    }
            }

            return null;
            
        }
        #endregion
    }
}
