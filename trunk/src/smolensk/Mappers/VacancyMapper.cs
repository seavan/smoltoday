using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.impl.Interfaces;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Extensions;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using smolensk.common;

namespace smolensk.Mappers
{
    public static class VacancyMapper
    {
        public enum EntityType
        {
            Vacancy,
            Resume,
        }

        #region Profile

        #region Resume

        public static ResumeListViewModel GetResumePageByUser(this Meridian meridian, bool onlyFavorites, long accountId, int page = 1)
        {
            var model = new ResumeListViewModel();

            IEnumerable<resumes> query = meridian.resumesStore.All();
            if (onlyFavorites)
            {
                List<long> favs = meridian.accounts_favoritesStore.All()
                    .Where(a => a.account_id == accountId)
                    .Select(a => a.resume_id)
                    .ToList();

                query = query.Where(r => favs.Contains(r.id));
            }
            else
            {
                query = query.Where(r => r.account_id == accountId);
            }

            IList<resumes> result = query.ToList();
            int totalFound = result.Count;

            model.Resumes = MappingUtils.TakePage(result.Select(v => meridian.GetResume(v.id)), page, Constants.ResumesPageSize).ToList();
            model.CurrentPage = page;
            model.TotalPages = MappingUtils.CalculatePagesCount(totalFound, Constants.ResumesPageSize);
            model.TotalResumes = totalFound;
            model.OnlyFavorites = onlyFavorites;

            return model;
        }

        public static ResumeViewModel GetResumeForEdit(this Meridian meridian, long? resumeId)
        {
            ResumeViewModel resume = null;
            if (resumeId.HasValue)
            {
                resume = meridian.GetResume(resumeId.Value);

                var workModes = GetAllEntries(meridian, VacancyEntryCategory.WorkMode, EntityType.Resume).ToList();
                foreach (var wm in workModes)
                {
                    wm.Selected = resume.WorkMode.Any(m => m.Id == wm.Id);
                }
                resume.WorkMode = workModes;

                var workTypes = GetAllEntries(meridian, VacancyEntryCategory.WorkType, EntityType.Resume).ToList();
                foreach (var wt in workTypes)
                {
                    wt.Selected = resume.WorkType.Any(m => m.Id == wt.Id);
                }
                resume.WorkType = workTypes;

                //Т.к в существующее резюме загружаются только отмеченные навыки
                //то их необходимо объединить со всеми существующими для формы редактирования
                var profs = GetAllProfessionals(meridian);
                foreach (var root in profs)
                {
                    var rProf = resume.Professionals.FirstOrDefault(p => p.Id == root.Id);
                    if (rProf != null)
                    {
                        root.Selected = true;

                        foreach (var child in root.Children)
                        {
                            child.Selected = rProf.Children.Any(c => c.Id == child.Id);
                        }
                    }
                }
                resume.Professionals = profs;

                //Т.к в существующее резюме загружаются только отмеченные льготы
                //то их необходимо объединить со всеми существующими для формы редактирования
                var facilities = meridian.GetFacilities().ToList();
                foreach (vacancy_facilities facility in facilities)
                {
                    var vFac = resume.Facilities.FirstOrDefault(f => f.id == facility.id);
                    if (vFac != null)
                    {
                        facility.Checked = true;
                        long varId = meridian.resumes_facilitiesStore.All()
                            .Single(v => v.resume_id == resume.Id && v.facility_id == vFac.id).variant_id;
                        facility.SelectedVariant = meridian.vacancy_facility_variantsStore.Get(varId);
                    }
                }

                resume.Facilities = facilities;
            }
            else
            {
                resume = new ResumeViewModel
                             {
                                 Sex = 0,
                                 WorkRegion = new DictionaryElement(0, ""),
                                 WorkCity = new DictionaryElement(0, "", 0),
                                 Education = new VacancyEntryViewModel(0),
                                 Experience = new VacancyEntryViewModel(0),
                                 FamilyStatus = new VacancyEntryViewModel(0),
                                 Citizenship = new VacancyEntryViewModel(0),
                                 Works = new List<resume_works>(0),
                                 Educations = new List<resume_educations>(0),
                                 Trainings = new List<resume_trainings>(0),
                                 Links = new string[0],
                             };
                resume.Professionals = GetAllProfessionals(meridian);
                resume.Facilities = GetFacilities(meridian).ToList();
                resume.WorkType = GetAllEntries(meridian, VacancyEntryCategory.WorkType, EntityType.Resume).ToList();
                resume.WorkMode = GetAllEntries(meridian, VacancyEntryCategory.WorkMode, EntityType.Resume).ToList();
            }

            resume.WorkTypesList = GetAllEntries(meridian, VacancyEntryCategory.WorkType, EntityType.Resume)
                .Select(e => e.ToSelectListItem());
            resume.EducationsList = GetAllEntries(meridian, VacancyEntryCategory.Education, EntityType.Resume)
                            .Select(e => e.ToSelectListItem());
            resume.FamilyStatusesList = GetAllEntries(meridian, VacancyEntryCategory.FamilyStatus, EntityType.Resume)
                            .Select(e => e.ToSelectListItem());
            resume.CitizenshipsList = GetAllEntries(meridian, VacancyEntryCategory.Citizenship, EntityType.Resume)
                            .Select(e => e.ToSelectListItem());
            resume.EducationLevelsList = GetAllEntries(meridian, VacancyEntryCategory.EducationLevel, EntityType.Resume)
                            .Select(e => e.ToSelectListItem());
            resume.LearningFormsList = GetAllEntries(meridian, VacancyEntryCategory.LearningType, EntityType.Resume)
                            .Select(e => e.ToSelectListItem());
            resume.ExperiencesList = GetAllEntries(meridian, VacancyEntryCategory.Experience, EntityType.Resume)
                .Select(e => e.ToSelectListItem());

            return resume;
        }

        public static void CreateOrUpdateResume(this Meridian meridian, ResumeViewModel model)
        {
            resumes resume = model.Id == 0
                                 ? meridian.resumesStore.Persist(new resumes())
                                 : meridian.resumesStore.Get(model.Id);
            if (model.Id == 0)
            {
                model.Created = resume.created = DateTime.Now;
            }

            try
            {
                if (model.PhotoFile != null)
                {
                    model.PhotoUrl = ImageHelper.SaveResumePhoto(model.PhotoFile,
                                                                 model.Id == 0 ? null : resume.photo_url);
                }

                CopyToResume(model, resume);

                resume.edited = DateTime.Now;

                meridian.resumesStore.Persist(resume);
            }
            catch (Exception ex)
            {
                if (model.Id == 0)
                {
                    meridian.resumesStore.Delete(resume);
                }

                throw ex;
            }
        }

        private static void CopyToResume(ResumeViewModel r, resumes resume)
        {
            resume.account_id = r.User.id;
            resume.is_publish = r.IsPublish;
            //resume.created = r.Created;
            //resume.edited = r.Edited;
            resume.post = r.Post;
            resume.first_name = r.FirstName;
            resume.middle_name = r.MiddleName;
            resume.last_name = r.LastName;
            resume.birth_date = r.BirthDate;
            resume.sex = (int)r.Sex;
            resume.salary = r.Salary;
            if (!string.IsNullOrEmpty(r.PhotoUrl))
                resume.photo_url = r.PhotoUrl;
            resume.languages = r.Languages;
            resume.region_id = r.WorkRegion.Id;
            resume.city_id = r.WorkCity.Id;
            resume.success_description = r.SuccessDescription;
            resume.about = r.AboutMySelf;
            resume.address = r.Address;
            resume.phone = r.Phone;
            resume.phone2 = r.Phone2;
            resume.email = r.Email;

            Meridian meridian = Meridian.Default;

            foreach (resume_works rwork in resume.Works.ToList())
            {
                meridian.resume_worksStore.Delete(rwork);
            }
            if (r.Works != null)
            {
                foreach (resume_works work in r.Works)
                {
                    work.resume_id = resume.id;
                    meridian.resume_worksStore.Insert(work);
                }
            }

            foreach (resume_educations edu in resume.Educations.ToList())
            {
                meridian.resume_educationsStore.Delete(edu);
            }
            if (r.Educations != null)
            {
                foreach (resume_educations edu in r.Educations)
                {
                    edu.resume_id = resume.id;
                    meridian.resume_educationsStore.Insert(edu);
                }
            }

            foreach (resume_trainings train in resume.Trainings.ToList())
            {
                meridian.resume_trainingsStore.Delete(train);
            }
            if (r.Trainings != null)
            {
                foreach (resume_trainings train in r.Trainings)
                {
                    train.resume_id = resume.id;
                    meridian.resume_trainingsStore.Insert(train);
                }
            }

            foreach (resume_links rlink in resume.Links.ToList())
            {
                meridian.resume_linksStore.Delete(rlink);
            }
            if (r.Links != null)
            {
                foreach (string link in r.Links)
                {
                    if (!string.IsNullOrEmpty(link))
                    {
                        meridian.resume_linksStore.Insert(new resume_links
                                                              {
                                                                  resume_id = resume.id,
                                                                  url = link,
                                                              });
                    }
                }
            }

            var entries = new List<VacancyEntryViewModel>();
            entries.Add(r.Education);
            entries.Add(r.FamilyStatus);
            entries.Add(r.Citizenship);
            entries.Add(r.Experience);
            entries.AddRange(r.WorkMode.Where(wm => wm.Selected));
            entries.AddRange(r.WorkType.Where(wt => wt.Selected));
            var oldEntries = resume.GetEntries().ToList();
            foreach (resumes_entries rEntry in oldEntries)
            {
                meridian.resumes_entriesStore.Delete(rEntry);
            }
            foreach (VacancyEntryViewModel entry in entries)
            {
                meridian.resumes_entriesStore.Insert(new resumes_entries
                                                         {
                                                             resume_id = resume.id,
                                                             resume_entry_id = entry.Id,
                                                         });
            }

            foreach (resumes_professionals prof in resume.GetProfressionals().ToList())
            {
                meridian.resumes_professionalsStore.Delete(prof);
            }
            foreach (VacancyProfessionalViewModel root in r.Professionals.Where(p => p.Selected))
            {
                meridian.resumes_professionalsStore.Insert(new resumes_professionals
                                                               {
                                                                   professional_id = root.Id,
                                                                   resume_id = resume.id,
                                                               });
                foreach (VacancyProfessionalViewModel child in root.Children.Where(p => p.Selected))
                {
                    meridian.resumes_professionalsStore.Insert(new resumes_professionals
                                                                   {
                                                                       professional_id = child.Id,
                                                                       resume_id = resume.id,
                                                                   });
                }
            }

            foreach (resumes_facilities facility in resume.GetFacilities().ToList())
            {
                meridian.resumes_facilitiesStore.Delete(facility);
            }
            if (r.Facilities != null)
            {
                foreach (vacancy_facilities facility in r.Facilities.Where(p => p.Checked))
                {
                    meridian.resumes_facilitiesStore.Insert(new resumes_facilities()
                                                                {
                                                                    facility_id = facility.id,
                                                                    resume_id = resume.id,
                                                                    variant_id = facility.SelectedVariant.id,
                                                                });
                }
            }
        }

        #endregion

        #region Vacancy

        public static VacancyListViewModel GetVacanciesPageByUser(this Meridian meridian, bool onlyFavorites, long accountId, int page = 1)
        {
            var model = new VacancyListViewModel();

            IEnumerable<vacancies> query = meridian.vacanciesStore.All();
            if (onlyFavorites)
            {
                List<long> favs = meridian.accounts_favoritesStore.All()
                    .Where(a => a.account_id == accountId)
                    .Select(a => a.vacancy_id)
                    .ToList();

                query = query.Where(v => favs.Contains(v.id));
            }
            else
            {
                query = query.Where(r => r.account_id == accountId);
            }

            IList<vacancies> result = query.ToList();
            int totalFound = result.Count;

            model.Vacancies = MappingUtils.TakePage(result.Select(v => meridian.GetVacancy(v.id)),
                                                    page,
                                                    Constants.VacanciesPageSize)
                .ToList();
            model.CurrentPage = page;
            model.TotalPages = MappingUtils.CalculatePagesCount(totalFound, Constants.ResumesPageSize);
            model.TotalVacancies = totalFound;
            model.OnlyFavorites = onlyFavorites;

            return model;
        } 
        
        public static VacancyViewModel GetVacancyForEdit(this Meridian meridian, long? vacancyId)
        {
            VacancyViewModel vacancy = null;
            if (vacancyId.HasValue)
            {
                vacancy = meridian.GetVacancy(vacancyId.Value);

                var experiences = GetAllEntries(meridian, VacancyEntryCategory.Experience, EntityType.Vacancy).ToList();
                foreach (var wt in experiences)
                {
                    wt.Selected = vacancy.Experience.Any(m => m.Id == wt.Id);
                }
                vacancy.Experience = experiences;

                var citizenships = GetAllEntries(meridian, VacancyEntryCategory.Citizenship, EntityType.Vacancy).ToList();
                foreach (var wt in citizenships)
                {
                    wt.Selected = vacancy.Citizenship.Any(m => m.Id == wt.Id);
                }
                vacancy.Citizenship = citizenships;

                var workModes = GetAllEntries(meridian, VacancyEntryCategory.WorkMode, EntityType.Vacancy).ToList();
                foreach (var wm in workModes)
                {
                    wm.Selected = vacancy.WorkMode.Any(m => m.Id == wm.Id);
                }
                vacancy.WorkMode = workModes;

                var workTypes = GetAllEntries(meridian, VacancyEntryCategory.WorkType, EntityType.Vacancy).ToList();
                foreach (var wt in workTypes)
                {
                    wt.Selected = vacancy.WorkType.Any(m => m.Id == wt.Id);
                }
                vacancy.WorkType = workTypes;

                //Т.к в существующее резюме загружаются только отмеченные навыки
                //то их необходимо объединить со всеми существующими для формы редактирования
                var profs = GetAllProfessionals(meridian);
                foreach (var root in profs)
                {
                    var rProf = vacancy.Professionals.FirstOrDefault(p => p.Id == root.Id);
                    if (rProf != null)
                    {
                        root.Selected = true;

                        foreach (var child in root.Children)
                        {
                            child.Selected = rProf.Children.Any(c => c.Id == child.Id);
                        }
                    }
                }

                vacancy.Professionals = profs;

                //Т.к в существующее резюме загружаются только отмеченные льготы
                //то их необходимо объединить со всеми существующими для формы редактирования
                var facilities = meridian.GetFacilities().ToList();
                foreach (vacancy_facilities facility in facilities)
                {
                    var vFac = vacancy.Facilities.FirstOrDefault(f => f.id == facility.id);
                    if (vFac != null)
                    {
                        facility.Checked = true;
                        long varId = meridian.vacancies_facilitiesStore.All()
                            .Single(v => v.vacancy_id == vacancy.Id && v.facility_id == vFac.id).variant_id;
                        facility.SelectedVariant = meridian.vacancy_facility_variantsStore.Get(varId);
                    }
                }

                vacancy.Facilities = facilities;
            }
            else
            {
                vacancy = new VacancyViewModel
                {
                    Sex = 0,
                    WorkRegion = new DictionaryElement(0, ""),
                    WorkCity = new DictionaryElement(0, "", 0),
                    Education = new VacancyEntryViewModel(0),
                    Company = new CompanyViewModel(),
                    City = new DictionaryElement(0,"",0),
                };

                vacancy.Professionals = GetAllProfessionals(meridian);
                vacancy.Facilities = GetFacilities(meridian).ToList();
                vacancy.WorkType = GetAllEntries(meridian, VacancyEntryCategory.WorkType, EntityType.Vacancy).ToList();
                vacancy.WorkMode = GetAllEntries(meridian, VacancyEntryCategory.WorkMode, EntityType.Vacancy).ToList();
                vacancy.Experience = GetAllEntries(meridian, VacancyEntryCategory.Experience, EntityType.Vacancy).ToList();
                vacancy.Citizenship = GetAllEntries(meridian, VacancyEntryCategory.Citizenship, EntityType.Vacancy).ToList();
            }

            vacancy.EducationsList = GetAllEntries(meridian, VacancyEntryCategory.Education, EntityType.Vacancy)
                .Select(e => e.ToSelectListItem());
            vacancy.CompaniesList = meridian.companiesStore.All()
                .Select(c => new SelectListItem
                                 {
                                     Text = c.title,
                                     Value = c.id.ToString(),
                                 });

            return vacancy;
        }
        public static VacancyViewModel PrepareVacancyModel(this Meridian meridian, VacancyViewModel vacancy)
        {
            //vacancy.Education = new VacancyEntryViewModel(0);
            //vacancy.Company = new CompanyViewModel();
            vacancy.City = new DictionaryElement(0, "", 0);
            vacancy.Professionals = GetAllProfessionals(meridian);
            vacancy.Facilities = GetFacilities(meridian).ToList();
            vacancy.Experience = GetAllEntries(meridian, VacancyEntryCategory.Experience, EntityType.Vacancy).ToList();
            vacancy.Citizenship = GetAllEntries(meridian, VacancyEntryCategory.Citizenship, EntityType.Vacancy).ToList();

            vacancy.EducationsList = GetAllEntries(meridian, VacancyEntryCategory.Education, EntityType.Vacancy)
                .Select(e => e.ToSelectListItem());
            vacancy.CompaniesList = meridian.companiesStore.All()
                .Select(c => new SelectListItem
                {
                    Text = c.title,
                    Value = c.id.ToString(),
                });

            return vacancy;
        }

        public static void CreateOrUpdateVacancy(this Meridian meridian, VacancyViewModel model)
        {
            vacancies vacancy = model.Id == 0
                                 ? meridian.vacanciesStore.Persist(new vacancies())
                                 : meridian.vacanciesStore.Get(model.Id);
            if (model.Id == 0)
            {
                model.Created = vacancy.created = DateTime.Now;
            }

            try
            {
                CopyToVacancy(model, vacancy);

                vacancy.edited = DateTime.Now;

                meridian.vacanciesStore.Persist(vacancy);
            }
            catch (Exception ex)
            {
                if (model.Id == 0)
                {
                    meridian.vacanciesStore.Delete(vacancy);
                }

                throw ex;
            }
        }

        private static void CopyToVacancy(VacancyViewModel v, vacancies vacancy)
        {
            var comp = CompaniesMapper.GetCompany(v.Company.Id, v.Company.Title);
            if (comp == null)
            {
                comp = new companies
                           {
                               title = v.Company.Title,
                               publish_date = DateTime.Now
                           };
                Meridian.Default.companiesStore.Insert(comp);
            }

            vacancy.account_id = v.User.id;
            vacancy.is_publish = v.IsPublish;
            vacancy.title = v.Title;
            vacancy.company_id = comp.id;
            vacancy.city_id = v.City.Id;
            vacancy.contact_person = v.ContactPerson;
            vacancy.contact_phone = v.ContactPhone;
            vacancy.contact_phone2 = v.ContactPhone2;
            vacancy.compensation1 = v.Compensation1.HasValue ? v.Compensation1.Value : 0;
            vacancy.compensation2 = v.Compensation2.HasValue ? v.Compensation2.Value : 0;
            vacancy.age1 = v.Age1.HasValue ? v.Age1.Value : 0;
            vacancy.age2 = v.Age2.HasValue ? v.Age2.Value : 0;
            vacancy.sex = v.Sex == null ? 0 : (int) v.Sex;
            vacancy.description = v.Description;
            vacancy.responsibility = v.Responsibility;
            vacancy.requirements = v.Requirements;
            vacancy.terms = v.Terms;
           

            Meridian meridian = Meridian.Default;

            var entries = new List<VacancyEntryViewModel>();
            entries.Add(v.Education);
            entries.AddRange(v.Experience.Where(m=>m.Selected));
            entries.AddRange(v.Citizenship.Where(m => m.Selected));
            entries.AddRange(v.WorkMode.Where(m => m.Selected));
            entries.AddRange(v.WorkType.Where(m => m.Selected));
            var oldEntries = vacancy.GetEntries().ToList();
            foreach (vacancies_entries rEntry in oldEntries)
            {
                meridian.vacancies_entriesStore.Delete(rEntry);
            }
            foreach (VacancyEntryViewModel entry in entries)
            {
                meridian.vacancies_entriesStore.Insert(new vacancies_entries
                                                           {
                                                               vacancy_id = vacancy.id,
                                                               vacancy_entry_id = entry.Id,
                                                           });
            }

            foreach (vacancies_professionals prof in vacancy.GetProfressionals().ToList())
            {
                meridian.vacancies_professionalsStore.Delete(prof);
            }
            foreach (VacancyProfessionalViewModel root in v.Professionals.Where(p => p.Selected))
            {
                meridian.vacancies_professionalsStore.Insert(new vacancies_professionals
                                                                 {
                                                                     professional_id = root.Id,
                                                                     vacancy_id = vacancy.id,
                                                                 });
                foreach (VacancyProfessionalViewModel child in root.Children.Where(p => p.Selected))
                {
                    meridian.vacancies_professionalsStore.Insert(new vacancies_professionals
                                                                     {
                                                                         professional_id = child.Id,
                                                                         vacancy_id = vacancy.id,
                                                                     });
                }
            }

            foreach (vacancies_facilities facility in vacancy.GetFacilities().ToList())
            {
                meridian.vacancies_facilitiesStore.Delete(facility);
            }
            foreach (vacancy_facilities facility in v.Facilities.Where(p=>p.Checked))
            {
                meridian.vacancies_facilitiesStore.Insert(new vacancies_facilities
                                                              {
                                                                  facility_id = facility.id,
                                                                  vacancy_id = vacancy.id,
                                                                  variant_id = facility.SelectedVariant.id,
                                                              });
            }
        }

        #endregion

        private static SelectListItem ToSelectListItem(this VacancyEntryViewModel m)
        {
            return new SelectListItem
            {
                Selected = m.Selected,
                Text = m.Title,
                Value = m.Id.ToString(),
            };
        }

        #endregion


        #region Resumes

        public static ResumeViewModel GetResume(this Meridian meridian, long resumeId)
        {
            if (meridian.resumesStore.Exists(resumeId))
            {
                return meridian.ToResumeViewModel(meridian.resumesStore.Get(resumeId));
            }

            return null;
        }

        public static ResumeViewModel ToResumeViewModel(this Meridian meridian, resumes resume)
        {
            regions workRegion = resume.GetResumesRegion();
            cities workCity = resume.GetResumesCitie();

            var region = workRegion == null
                             ? new DictionaryElement(0, "Любой")
                             : new DictionaryElement(workRegion.id, workRegion.title);
            var city = workCity == null
                           ? new DictionaryElement(0, "Любой")
                           : new DictionaryElement(workCity.id, workCity.title);

            var model = new ResumeViewModel(resume.id)
                            {
                                DbEntity = resume,
                                User = resume.GetResumesAccount(),
                                Created = resume.created,
                                Edited = resume.edited,
                                Post = resume.post,
                                FirstName = resume.first_name,
                                MiddleName = resume.middle_name,
                                LastName = resume.last_name,
                                BirthDate = resume.birth_date,
                                Sex = (Sex) resume.sex,
                                Salary = resume.salary,
                                PhotoUrl = string.IsNullOrEmpty(resume.photo_url)
                                               ? String.Format("{0}{1}", Constants.UserDataFolder, "noImg138_138.gif")
                                               : Constants.ResumeFolder + resume.photo_url,
                                WorkCity = city,
                                WorkRegion = region,
                                //ExpYears = resume.exp_years,
                                //ExpMonthes = resume.exp_months,
                                Children = resume.children,
                                SuccessDescription = resume.success_description,
                                AboutMySelf = resume.about,
                                Address = resume.address,
                                Phone = resume.phone,
                                Phone2 = resume.phone2,
                                Email = resume.email,
                                IsPublish = resume.is_publish,
                            };

            model.Professionals = meridian.GetProfessionalsFor(resume.id, EntityType.Resume);
            model.Facilities = GetFacilitiesFor(meridian, resume.id, EntityType.Resume).ToList();
            model.Education = meridian.GetVacancyEntryFor(resume.id, VacancyEntryCategory.Education, EntityType.Resume);
            model.Experience = meridian.GetVacancyEntryFor(resume.id, VacancyEntryCategory.Experience, EntityType.Resume);
            model.WorkMode = meridian.GetVacancyEntriesFor(resume.id, VacancyEntryCategory.WorkMode, EntityType.Resume).ToList();
            model.WorkType = meridian.GetVacancyEntriesFor(resume.id, VacancyEntryCategory.WorkType, EntityType.Resume).ToList();
            model.FamilyStatus = meridian.GetVacancyEntryFor(resume.id, VacancyEntryCategory.FamilyStatus, EntityType.Resume);
            model.Citizenship = meridian.GetVacancyEntryFor(resume.id, VacancyEntryCategory.Citizenship, EntityType.Resume);

            model.Works = resume.GetWorks().ToList();
            model.Educations = resume.GetEducations().ToList();
            model.Trainings = resume.GetTrainings().ToList();
            model.Links = resume.GetLinks().Select(l => l.url).ToArray();

            return model;
        }

        public static IEnumerable<ResumeViewModel> GetResumesPage(Meridian meridian, int page, int pageSize, 
            string q, int prof, int compensation1, int compensation2, out int totalFound)
        {
            IEnumerable<resumes> query = meridian.resumesStore.All();

            query = query.Where(r => r.is_publish);

            query = ApplyFilter(meridian, query, q, prof, compensation1, compensation2);

            IList<resumes> result = query.ToList();

            totalFound = result.Count;

            return MappingUtils.TakePage(result.Select(v => meridian.GetResume(v.id)), page, pageSize);
        }

        private static IEnumerable<resumes> ApplyFilter(Meridian meridian, IEnumerable<resumes> query, string q, int prof, int compensation1, int compensation2)
        {
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(v => v.post.IndexOf(q, 0, StringComparison.InvariantCultureIgnoreCase) != -1);
            }

            if (prof > 0)
            {
                query = query.Where(v => v.Profressionals.Any(p => p.professional_id == prof));
            }

            query = FilterSalaries(query, compensation1, compensation2);

            return query;
        }

        public static ResumeListViewModel ToSearchResumeResultViewModel(this Meridian meridian, string q, int prof, int salaryId, int page)
        {
            var model = new ResumeListViewModel()
                            {
                                SearchBlock = ToSearchVacancyBlockViewModel(meridian, q, 2, prof, salaryId),
                            };

            int comp1 = model.SearchBlock.Compensation1;
            int comp2 = model.SearchBlock.Compensation2;

            int totalRecords;
            IEnumerable<ResumeViewModel> resumePage = GetResumesPage(meridian, page, Constants.DefaultListPageSize, q, prof, comp1, comp2, out totalRecords);

            model.Resumes = resumePage.ToList();
            model.CurrentPage = page;
            model.TotalPages = MappingUtils.CalculatePagesCount(totalRecords, Constants.DefaultListPageSize);
            model.TotalResumes = totalRecords;

            return model;
        }

        public static IEnumerable<ResumeViewModel> GetSimilarResumes(this ResumeViewModel resume)
        {
            var meridian = Meridian.Default;
            List<long> ids = GetAllProfsIds(meridian.resumesStore.Get(resume.Id));
            return meridian.resumesStore.All()
                .Where(r=>r.is_publish)
                .Where(r => r.id != resume.Id)
                .OrderByDescending(v => GetAllProfsIds(v).Intersect(ids).Count())
                .Take(Constants.SimilarResumesCount)
                .Select(r => GetResume(meridian, r.id));
        }

        #endregion

        #region Vacancies

        public static VacancyViewModel GetVacancy(this Meridian meridian, long id)
        {
            if (meridian.vacanciesStore.Exists(id))
            {
                return meridian.ToVacancyViewModel(meridian.vacanciesStore.Get(id));
            }

            return null;
        }

        public static VacancyViewModel ToVacancyViewModel(this Meridian meridian, vacancies vacancy)
        {
            cities city = meridian.citiesStore.Get(vacancy.city_id);
            
            var model = new VacancyViewModel(vacancy.id)
            {
                User = vacancy.GetVacanciesAccount(),
                IsPublish = vacancy.is_publish,
                Created = vacancy.created,
                Edited = vacancy.edited,
                Title = vacancy.title,
                Company = vacancy.GetVacanciesCompanie().ToCompanyViewModel(true),
                City = new DictionaryElement(city.id, city.title, city.region_id),
                Age1 = vacancy.age1.HasValue() ? vacancy.age1 : (int?)null,
                Age2 = vacancy.age2.HasValue() ? vacancy.age2 : (int?)null,
                Compensation1 = vacancy.compensation1.HasValue() ? vacancy.compensation1 : (int?)null,
                Compensation2 = vacancy.compensation2.HasValue() ? vacancy.compensation2 : (int?)null,
                ContactPerson = vacancy.contact_person,
                ContactPhone = vacancy.contact_phone,
                ContactPhone2 = vacancy.contact_phone2,
                Description = vacancy.description,
                Requirements = vacancy.requirements,
                Responsibility = vacancy.responsibility,
                Terms = vacancy.terms,
                Sex = !vacancy.sex.HasValue() ? null : (Sex?)vacancy.sex,
                ShowInBanner = vacancy.show_in_banner,
                Favorite = vacancy,
            };

            model.CountVacancies = vacancy.GetVacanciesCompanie().CountOfActualVacancies();

            model.Experience = meridian.GetVacancyEntriesFor(vacancy.id, VacancyEntryCategory.Experience, EntityType.Vacancy).ToList();
            model.Citizenship = meridian.GetVacancyEntriesFor(vacancy.id, VacancyEntryCategory.Citizenship, EntityType.Vacancy).ToList();
            model.WorkType = meridian.GetVacancyEntriesFor(vacancy.id, VacancyEntryCategory.WorkType, EntityType.Vacancy).ToList();
            model.WorkMode = meridian.GetVacancyEntriesFor(vacancy.id, VacancyEntryCategory.WorkMode, EntityType.Vacancy).ToList();
            model.Education = meridian.GetVacancyEntryFor(vacancy.id, VacancyEntryCategory.Education, EntityType.Vacancy);

            model.Professionals = GetProfessionalsFor(meridian, vacancy.id, EntityType.Vacancy);
            model.Facilities = GetFacilitiesFor(meridian, vacancy.id, EntityType.Vacancy).ToList();

            return model;
        }

        private static IEnumerable<VacancyViewModel> GetVacanciesPage(Meridian meridian, int page, int pageSize, 
            string q, int prof, int compensation1, int compensation2, out int totalFounded)
        {
            IEnumerable<vacancies> query = meridian.vacanciesStore.All();

            query = query.Where(v => v.IsActual);

            query = ApplyFilter(meridian, query, q, prof, compensation1, compensation2);

            IList<vacancies> result = query.ToList();

            totalFounded = result.Count;

            return MappingUtils.TakePage(result.Select(v => meridian.GetVacancy(v.id)), page, pageSize);
        }

        private static IEnumerable<vacancies> ApplyFilter(Meridian meridian, IEnumerable<vacancies> query, string q, int prof, int compensation1, int compensation2)
        {
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(v => v.title.IndexOf(q, 0, StringComparison.InvariantCultureIgnoreCase) != -1);
            }

            if (prof > 0)
            {
                query = query.Where(v => v.Profressionals.Any(p => p.professional_id == prof));
            }

            query = FilterSalaries(query, compensation1, compensation2);

            return query;
        }

        public static IEnumerable<VacancyViewModel> GetSimilarVacancies(this VacancyViewModel vacancy)
        {
            var meridian = Meridian.Default;
            List<long> ids = GetAllProfsIds(meridian.vacanciesStore.Get(vacancy.Id));
            return meridian.vacanciesStore.All()
                .Where(v=>v.IsActual)
                .Where(v=>v.id != vacancy.Id)
                .OrderByDescending(v => GetAllProfsIds(v).Intersect(ids).Count())
                .Take(Constants.SimilarVacanciesCount)
                .Select(v => GetVacancy(meridian, v.id));

        }

        public static VacancyListViewModel ToSearchVacancyResultViewModel(this Meridian meridian, string q, int prof, int salaryId, int page)
        {
            var model = new VacancyListViewModel
            {
                SearchBlock = ToSearchVacancyBlockViewModel(meridian, q, 1, prof, salaryId),
            };

            int comp1 = model.SearchBlock.Compensation1;
            int comp2 = model.SearchBlock.Compensation2;

            int totalRecords;
            IEnumerable<VacancyViewModel> vacancyPage = GetVacanciesPage(meridian, page, Constants.DefaultListPageSize, q, prof, comp1, comp2, out totalRecords);

            model.Vacancies = vacancyPage.ToList();
            model.CurrentPage = page;
            model.TotalPages = MappingUtils.CalculatePagesCount(totalRecords, Constants.DefaultListPageSize);
            model.TotalVacancies = totalRecords;

            return model;
        }

        #endregion

        #region Shared methods

        #region Ext Search
        
        public static SearchVacancyOrResumeViewModel ToSearchVacancyExt(this Meridian meridian, EntityType type)
        {
            var model = new SearchVacancyOrResumeViewModel
                            {
                                EducationId = meridian.GetDefaultEntry(VacancyEntryCategory.Education, type).Id,
                                CitizenshipId = meridian.GetDefaultEntry(VacancyEntryCategory.Citizenship, type).Id,
                                ExperienceId = type == EntityType.Vacancy 
                                ? meridian.GetDefaultEntry(VacancyEntryCategory.Experience, type).Id
                                : 0,
                                WorkTypeIds = new List<long>(),
                                WorkModeIds = new List<long>(),
                                Professionals = new List<long>(),
                                Type = type == EntityType.Vacancy ? "v" : "r",
                                PageSize = Constants.PageSize,
                                Print = VacancyPrintType.Month,
                            };

            model.ProfessionalsList = meridian.GetAllProfessionals();
            model.Experiences = meridian.GetAllEntries(VacancyEntryCategory.Experience, type).ToList();
            //NOTE: Костыль. Из-за не совсем корректно спланированного справочника на начальном этапе разработки 
            if (type == EntityType.Resume)
            {
                model.Experiences.Insert(0, new VacancyEntryViewModel(0) {Title = "Не имеет значения"});
            }

            model.Citizenships = meridian.GetAllEntries(VacancyEntryCategory.Citizenship, type).ToList();
            model.WorkTypes = meridian.GetAllEntries(VacancyEntryCategory.WorkType, type).ToList();
            model.WorkModes = meridian.GetAllEntries(VacancyEntryCategory.WorkMode, type).ToList();
            model.OwnershipsList = meridian.GetOwnerships();

            model.Facilities = meridian.GetFacilities().ToList();
            model.FacilityIds = new List<long>();
            model.FacilityValueIds = new List<long>();

            if (type == EntityType.Vacancy)
            {
                model.EducationsList = meridian.GetAllEntries(VacancyEntryCategory.Education, EntityType.Vacancy)
                    .Select(v => new SelectListItem
                                     {
                                         Text = v.Title,
                                         Value = v.Id.ToString(),
                                     });
            }

            return model;
        }
       
        #region Vacancy

        public static VacancyListViewModel ToSearchVacancyResultViewModel(this Meridian meridian, SearchVacancyOrResumeViewModel model, int page = 1)
        {
            List<vacancies> items = GetVacanciesFilter(meridian, model).ToList();
            FilterWithCountOfAccordance(items, model);
            IEnumerable<vacancies> query = ApplySorting(items, model.Sorting);

            var vacancies = MappingUtils.TakePage(query, page, model.PageSize)
                .Select(v => meridian.ToVacancyViewModel(v))
                .ToList();

            var result = new VacancyListViewModel
                             {
                                 CurrentPage = page,
                                 SearchBlock = meridian.ToSearchVacancyBlockViewModel(null, 1),
                                 TotalPages = MappingUtils.CalculatePagesCount(items.Count, model.PageSize),
                                 TotalVacancies = items.Count,
                                 Vacancies = vacancies,
                             };
            return result;
        }

        private static IEnumerable<vacancies> GetVacanciesFilter(this Meridian meridian, SearchVacancyOrResumeViewModel model)
        {
            IEnumerable<vacancies> query = meridian.vacanciesStore.All();

            query = query.Where(v => v.IsActual);

            int days = (int)model.Print;
            query = query.Where(q => DateTime.Now.Date.Subtract(q.edited.Date).TotalDays < days);

            if (!string.IsNullOrEmpty(model.Keywords))
            {
                string[] keywords = model.Keywords.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                query = query.Where(q => model.InTitle
                                         && StringArrayCompare(keywords, q.title)
                                         || model.InDescription
                                            && StringArrayCompare(keywords, q.description)
                                         || model.InCompanyTitle
                                         && StringArrayCompare(keywords, q.GetVacanciesCompanie().title));

            }

            if (model.Professionals != null && model.Professionals.Any())
            {
                query = query.Where(q =>
                                    CompareProfessionals(
                                        q.Profressionals.Select(p => p.GetVacanciesVacancy_professional()),
                                        model.Professionals.Select(p => meridian.vacancy_professionalsStore.Get(p))));
            }

            if (model.RegionId > 0)
            {
                query = query.Where(q => q.work_region_id == model.RegionId);
            }

            if (model.CityId > 0)
            {
                query = query.Where(q => q.work_city_id == model.CityId);
            }

            //Vacancy only
            if (model.EducationId != meridian.GetDefaultEntry(VacancyEntryCategory.Education, EntityType.Vacancy).Id)
            {
                // TODO
                //query = query.Where(q => meridian.GetVacancyEntriesFor(q.id, VacancyEntryCategory.Education, EntityType.Vacancy).First().Id == model.EducationId);
            }

            if (model.HideWithoutSalary)
            {
                query = query.Where(q => q.compensation1.HasValue() || q.compensation2.HasValue());
            }

            //for resume use other method
            query = FilterSalaries(query, model.Compensation1, 0);

            if (model.HideWithoutAge)
            {
                query = query.Where(q => q.age1.HasValue() || q.age2.HasValue());
            }

            //for resume use other method
            query = FilterAges(query, model.Age1, 0);

            if (model.ExperienceId != meridian.GetDefaultEntry(VacancyEntryCategory.Experience, EntityType.Vacancy).Id)
            {
                query = query.Where(q => meridian.GetVacancyEntryFor(q.id, VacancyEntryCategory.Experience, EntityType.Vacancy).Id == model.ExperienceId);
            }

            //Если ищем только для русских, то выполняем точный поиск
            if (model.HideForNational)
            {
                long id = meridian.vacancy_entriesStore.GetEntryГражданинРФ().id;
                query = query.Where(v => meridian.GetVacancyEntryFor(v.id, VacancyEntryCategory.Citizenship,
                                                                EntityType.Vacancy).Id == id);
            }

            if (model.WorkTypeIds != null && model.WorkTypeIds.Any())
            {
                //Хотя бы одно совпадение должно быть
                query = query.Where(v => meridian.GetVacancyEntriesFor(v.id, VacancyEntryCategory.WorkType, EntityType.Vacancy).Select(e => e.Id)
                    .Intersect(model.WorkTypeIds).Any());
            }

            if (model.WorkModeIds != null && model.WorkModeIds.Any())
            {
                //Хотя бы одно совпадение должно быть
                query = query.Where(v => meridian.GetVacancyEntriesFor(v.id, VacancyEntryCategory.WorkMode, EntityType.Vacancy).Select(e => e.Id)
                    .Intersect(model.WorkModeIds).Any());
            }

            if (model.HideAgents)//Only Vacancy
            {

            }

            if (model.HideDisabled)//Only Vacancy
            {

            }

            return query;
        }

        private static void FilterWithCountOfAccordance(List<vacancies> query, SearchVacancyOrResumeViewModel model)
        {
            var meridian = Meridian.Default;
            foreach (vacancies v in query)
            {
                v.Weight = 0;
                //Если не было выбрано Скрывать для иностранцев, то выполняем не точный поиск
                if (!model.HideForNational)
                {
                    if (model.CitizenshipId !=
                        meridian.GetDefaultEntry(VacancyEntryCategory.Citizenship, EntityType.Vacancy).Id)
                    {
                        var entry = meridian.GetVacancyEntryFor(v.id, VacancyEntryCategory.Citizenship,
                                                                EntityType.Vacancy);
                        v.Weight += entry.Id == model.CitizenshipId ? 1 : 0;
                    }
                }

                CompareFacilities(meridian, v, model);

                if (model.UseOwnership)
                {
                    v.Weight += (v.GetVacanciesCompanie().ownership_id == model.OwnershipId) ? 1 : 0;
                }

                //TODO: nmwind: Не понятно с чем сверять
                if (model.OwnerExtInform)
                {

                }
            }
        }

        private static IEnumerable<vacancies> ApplySorting(List<vacancies> list, VacancySortingType sorting)
        {
            switch (sorting)
            {
                case VacancySortingType.ChangeDate:
                    return list.OrderByDescending(q => q.edited);
                case VacancySortingType.SalaryDescending:
                    return list.OrderByDescending(q => q.compensation2 > q.compensation1
                                                           ? q.compensation2
                                                           : q.compensation1);
                case VacancySortingType.SalaryAscending:
                    return list.OrderBy(q => q.compensation2 > q.compensation1
                                                 ? q.compensation2
                                                 : q.compensation1);
                case VacancySortingType.Accordance:
                    return list.OrderByDescending(q => q.Weight);
            }

            return list;
        }

        private static IEnumerable<vacancies> FilterAges(IEnumerable<vacancies> query, int age1, int age2)
        {
            if (age1 > 0 || age2 > 0)
            {
                if (age1 > 0 && age2 > 0)
                {
                    query = query.Where(v => v.age1 >= age1 && v.age1 <= age2 ||
                                             v.age2 >= age1 && v.age2 <= age2);
                }
                else
                {
                    if (age1 > 0)
                    {
                        query = query.Where(v => v.age1 >= age1 || v.age2 >= age1);
                    }
                    else if (age2 > 0)
                    {
                        query = query.Where(v => v.age1 <= age2
                                                 || v.age2 <= age2);
                    }
                }
            }

            return query;
        }

        #endregion

        #region Resume

        public static ResumeListViewModel ToSearchResumeResultViewModel(this Meridian meridian, SearchVacancyOrResumeViewModel model, int page = 1)
        {
            List<resumes> items = GetResumesFilter(meridian, model).ToList();
            FilterWithCountOfAccordance(items, model);
            IEnumerable<resumes> query = ApplySorting(items, model.Sorting);

            var resumes = MappingUtils.TakePage(query, page, model.PageSize)
                .Select(r => meridian.ToResumeViewModel(r))
                .ToList();

            var result = new ResumeListViewModel
                             {
                                 CurrentPage = page,
                                 SearchBlock = meridian.ToSearchVacancyBlockViewModel(null, 2),
                                 TotalPages = MappingUtils.CalculatePagesCount(items.Count, model.PageSize),
                                 TotalResumes = items.Count,
                                 Resumes = resumes,
                             };
            return result;
        }

        private static IEnumerable<resumes> GetResumesFilter(this Meridian meridian, SearchVacancyOrResumeViewModel model)
        {
            IEnumerable<resumes> query = meridian.resumesStore.All();
            
            query = query.Where(q => q.is_publish);

            int days = (int)model.Print;
            query = query.Where(q => DateTime.Now.Date.Subtract(q.edited.Date).TotalDays < days);

            if (!string.IsNullOrEmpty(model.Keywords))
            {
                string[] keywords = model.Keywords.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                query = query.Where(q => model.InTitle
                                         && StringArrayCompare(keywords, q.post)
                                         || model.InDescription
                                         && StringArrayCompare(keywords, q.success_description));
            }

            if (model.Professionals != null && model.Professionals.Any())
            {
                query = query.Where(q =>
                                    CompareProfessionals(
                                        q.Profressionals.Select(p => p.GetResumesVacancy_professional()),
                                        model.Professionals.Select(p => meridian.vacancy_professionalsStore.Get(p))));
            }

            if (model.RegionId > 0)
            {
                query = query.Where(q => q.region_id == model.RegionId);
            }

            if (model.CityId > 0)
            {
                query = query.Where(q => q.city_id == model.CityId);
            }

            if (model.HideWithoutSalary)
            {
                query = query.Where(q => q.salary.HasValue());
            }

            //for vacancy use other method
            query = FilterSalaries(query, model.Compensation1, model.Compensation2);

            if (model.HideWithoutAge)
            {
                query = query.Where(q => q.birth_date.HasValue());
            }

            //for vacancy use other method
            query = FilterAges(query, model.Age1, model.Age2);

            if (model.ExperienceId != 0)
            //if (model.ExperienceId != meridian.GetDefaultEntry(VacancyEntryCategory.Experience, EntityType.Resume).Id)
            {
                query = query.Where(q => meridian.GetVacancyEntryFor(q.id, VacancyEntryCategory.Experience, EntityType.Resume).Id == model.ExperienceId);
            }

            //Если ищем только для русских, то выполняем точный поиск
            if (model.HideForNational)
            {
                long id = meridian.vacancy_entriesStore.GetEntryГражданинРФ().id;
                query = query.Where(v => meridian.GetVacancyEntryFor(v.id, VacancyEntryCategory.Citizenship,
                                                                EntityType.Resume).Id == id);
            }

            if (model.WorkTypeIds != null && model.WorkTypeIds.Any())
            {
                //Хотя бы одно совпадение должно быть
                query = query.Where(v => meridian.GetVacancyEntriesFor(v.id, VacancyEntryCategory.WorkType, EntityType.Resume).Select(e => e.Id)
                    .Intersect(model.WorkTypeIds).Any());
            }

            if (model.WorkModeIds != null && model.WorkModeIds.Any())
            {
                //Хотя бы одно совпадение должно быть
                query = query.Where(v => meridian.GetVacancyEntriesFor(v.id, VacancyEntryCategory.WorkMode, EntityType.Resume).Select(e => e.Id)
                    .Intersect(model.WorkModeIds).Any());
            }

            return query;
        }

        private static void FilterWithCountOfAccordance(List<resumes> query, SearchVacancyOrResumeViewModel model)
        {
            var meridian = Meridian.Default;
            foreach (resumes r in query)
            {
                r.Weight = 0;
                //Если не было выбрано Скрывать для иностранцев, то выполняем не точный поиск
                if (!model.HideForNational)
                {
                    if (model.CitizenshipId !=
                        meridian.GetDefaultEntry(VacancyEntryCategory.Citizenship, EntityType.Resume).Id)
                    {
                        var entry = meridian.GetVacancyEntryFor(r.id, VacancyEntryCategory.Citizenship,
                                                                EntityType.Resume);
                        r.Weight += entry.Id == model.CitizenshipId ? 1 : 0;
                    }
                }

                CompareFacilities(meridian, r, model);
            }
        }

        private static IEnumerable<resumes> FilterAges(IEnumerable<resumes> query, int age1, int age2)
        {
            if (age1 > 0 || age2 > 0)
            {
                if (age1 > 0 && age2 > 0)
                {
                    query = query.Where(r => r.GetAge() >= age1 && r.GetAge() <= age2);
                }
                else
                {
                    if (age1 > 0)
                    {
                        query = query.Where(r => r.GetAge() >= age1);
                    }
                    else if (age2 > 0)
                    {
                        query = query.Where(r => r.GetAge() <= age2);
                    }
                }
            }

            return query;
        }

        private static IEnumerable<resumes> ApplySorting(List<resumes> list, VacancySortingType sorting)
        {
            switch (sorting)
            {
                case VacancySortingType.ChangeDate:
                    return list.OrderByDescending(q => q.edited);
                case VacancySortingType.SalaryDescending:
                    return list.OrderByDescending(q => q.salary);
                case VacancySortingType.SalaryAscending:
                    return list.OrderBy(q => q.salary);
                case VacancySortingType.Accordance:
                    return list.OrderByDescending(q => q.Weight);
            }

            return list;
        }

        #endregion

        private static bool StringArrayCompare(string[] keywords, string q)
        {
            foreach (string keyword in keywords)
            {
                if (q.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CompareProfessionals(IEnumerable<vacancy_professionals> entitySkills, IEnumerable<vacancy_professionals> selectedSkills)
        {
            var list = entitySkills.Select(v=>v.id).ToList();
            foreach (vacancy_professionals selectedSkill in selectedSkills)
            {
                if (!list.Contains(selectedSkill.id))
                {
                    return false;
                }
            }

            return true;
        }

        private static void CompareFacilities(Meridian meridian, IVacancyOrResume vr, SearchVacancyOrResumeViewModel model)
        {
            if (model.FacilityIds == null || model.FacilityIds.Count == 0)
            {
                return;
            }

            List<long> facilities = vr.GetFacilityList().Select(f => f.id).ToList();
            IEnumerable<vacancy_facilities> selectedFacilities =
                model.FacilityIds.Select(f => meridian.vacancy_facilitiesStore.Get(f));

            List<vacancy_facility_variants> selectedVariants =
                model.FacilityValueIds.Select(f => meridian.vacancy_facility_variantsStore.Get(f))
                    .ToList();
            foreach (vacancy_facilities facility in selectedFacilities)
            {
                if (facilities.Contains(facility.id))
                {
                    vr.Weight++;
                    var selectedVariant = selectedVariants.First(f => f.facility_id == facility.id);
                    //Если вариант "Любые льготы" НЕ выбран, то только тогда МОЖЕТ БЫТЬ добавляем вес
                    if (selectedVariant.id != facility.GetDefaultVariant().id)
                    {
                        vr.Weight += vr.GetVariant(facility.id).id == selectedVariant.id ? 1 : 0;
                    }
                }
            }
        }

        #endregion

        public static JobInSmolenskViewModel ToJobInSmolenskViewModel(this Meridian meridian)
        {
            vacancies vacancy = meridian.vacanciesStore.All()
                .Where(v => v.show_in_banner)
                .OrderByDescending(v => v.edited)
                .FirstOrDefault();

            if (vacancy == null)
            {
                return null;
            }

            var model = new JobInSmolenskViewModel
                            {
                                VacanciesCount = meridian.vacanciesStore.All()
                                    .Count(v => !v.closed),
                                Vacancy = meridian.ToVacancyViewModel(vacancy),
                            };

            return model;
        }

        public static IEnumerable<VacancyEntryViewModel> GetVacancyEntriesFor(this Meridian meridian, long entryId, VacancyEntryCategory category, EntityType type)
        {
            if (type == EntityType.Vacancy)
            {
                return meridian.vacanciesStore.Get(entryId).GetEntries()
                    .Select(v => meridian.vacancy_entriesStore.Get(v.vacancy_entry_id))
                    .Where(v => v.vacancy_entry_category_id == (long)category
                        && (string.IsNullOrEmpty(v.only) || v.only == "v"))
                    .Select(e => e.ToVacancyEntryViewModel());
            }
            else
            {
                return meridian.resumesStore.Get(entryId).GetEntries()
                    .Select(v => meridian.vacancy_entriesStore.Get(v.resume_entry_id))
                    .Where(v => v.vacancy_entry_category_id == (long)category
                        && (string.IsNullOrEmpty(v.only) || v.only == "r"))
                    .Select(e => e.ToVacancyEntryViewModel());
            }
        }

        public static VacancyEntryViewModel GetVacancyEntryFor(this Meridian meridian, long entryId, VacancyEntryCategory category, EntityType type)
        {
            return GetVacancyEntriesFor(meridian, entryId, category, type).First();
        }

        public static IList<VacancyProfessionalViewModel> GetRootProfessionals(this Meridian meridian)
        {
            return meridian.vacancy_professionalsStore.All()
                .Where(p => !p.parent_id.HasValue())
                .Select(p => new VacancyProfessionalViewModel(p.id)
                {
                    Title = p.title,
                })
                .ToList();
        }

        public static IEnumerable<vacancy_facilities> GetFacilitiesFor(this Meridian meridian,
            long entityId, EntityType type)
        {
            IVacancyOrResume entity = type == EntityType.Vacancy
                                          ? (IVacancyOrResume)meridian.vacanciesStore.Get(entityId)
                                          : (IVacancyOrResume)meridian.resumesStore.Get(entityId);

            List<vacancy_facilities> list = entity.GetFacilityList();

            foreach (vacancy_facilities facility in list)
            {
                facility.Checked = true;
                facility.SelectedVariant = entity.GetVariant(facility.id);
            }

            return list;
        }

        /// <summary>
        /// Возвращает рутовые професиональные области для конкретной вакансии или резюме
        /// </summary>
        /// <param name="meridian"></param>
        /// <param name="entityId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IList<VacancyProfessionalViewModel> GetProfessionalsFor(this Meridian meridian, long entityId, EntityType type)
        {
            IEnumerable<long> entitySkills = type == EntityType.Vacancy
                                                 ? meridian.vacanciesStore.Get(entityId).GetProfressionals()
                                                       .Select(v => v.professional_id)
                                                 : meridian.resumesStore.Get(entityId).GetProfressionals()
                                                       .Select(r => r.professional_id);

            Dictionary<long, VacancyProfessionalViewModel> skills = entitySkills
                .Select(t => new VacancyProfessionalViewModel(t)
                {
                    Parent = new VacancyProfessionalViewModel(meridian.vacancy_professionalsStore.Get(t).parent_id),
                    Title = meridian.vacancy_professionalsStore.Get(t).title,
                })
                .ToDictionary(k => k.Id, v => v);


            IList<VacancyProfessionalViewModel> roots = skills.Values.Where(s => !s.Parent.Id.HasValue()).ToList();

            foreach (VacancyProfessionalViewModel root in roots)
            {
                FillProfessionals(skills, root);
            }

            return roots;
        }

        private static IList<VacancyProfessionalViewModel> GetAllProfessionals(this Meridian meridian)
        {
            Dictionary<long, VacancyProfessionalViewModel> skills = meridian.vacancy_professionalsStore.All()
                .Select(t => new VacancyProfessionalViewModel(t.id)
                                 {
                                     Parent =
                                         new VacancyProfessionalViewModel(
                                         t.parent_id),
                                     Title = t.title,
                                 })
                .ToDictionary(k => k.Id, v => v);

            IList<VacancyProfessionalViewModel> roots = skills.Values.Where(s => !s.Parent.Id.HasValue()).ToList();

            foreach (VacancyProfessionalViewModel root in roots)
            {
                FillProfessionals(skills, root);
            }

            return roots;
        }

        public static VacancyEntryViewModel ToVacancyEntryViewModel(this vacancy_entries entry)
        {
            return new VacancyEntryViewModel(entry.id)
            {
                Category = (VacancyEntryCategory)entry.vacancy_entry_category_id,
                Title = entry.title,
            };
        }


        public static SearchVacancyBlockViewModel ToSearchVacancyBlockViewModel(this Meridian meridian, string q = null, int searchType = 1, int profId = 0, int salaryId = -1)
        {
            var model = new SearchVacancyBlockViewModel
            {
                Query = q,
                SearchType = searchType,
                ProfessionId = profId,
                SelectedSalaryId = salaryId,
            };
            model.Professionals = Meridian.Default.GetRootProfessionals();

            return model;
        }

        public static VacancyCompanySearchViewModel GetVacancyCompanySearchViewModel(this Meridian meridian,
            int regionId, int cityId, string filter, bool allCompanies, string letter)
        {
            var model = new VacancyCompanySearchViewModel
            {
                AllCompanies = allCompanies,
                RegionId = regionId,
                CityId = cityId,
                Filter = filter,
            };

            IEnumerable<companies> query = meridian.companiesStore.All();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(c => c.title.ToLower().Contains(filter));
            }

            if (letter != Constants.AnyLetter)
            {
                query = query.Where(c => c.title.StartsWith(letter, StringComparison.CurrentCultureIgnoreCase));
            }

            if (regionId > 0)
            {
                query = query.Where(c => c.GetActualVacancies().Select(v => v.work_region_id).Contains(regionId));
            }

            if (cityId > 0)
            {
                query = query.Where(c => c.GetActualVacancies().Select(v => v.work_city_id).Contains(cityId));                
            }

            model.Companies = query.ToList();

            return model;
        }

        public static VacancyStatisticViewModel ToVacancyStatistic(this Meridian meridian)
        {
            return new VacancyStatisticViewModel
            {
                Companies = meridian.companiesStore.All()
                    .Count(c => c.GetActualVacancies().Any()),
                Vacancies = meridian.vacanciesStore.All()
                    .Count(v => v.IsActual),
                Resumes = meridian.resumesStore.All().Count(q=>q.is_publish),
            };
        }

        public static SearchVacancyViewModel ToSearchVacancyViewModel(this Meridian meridian)
        {
            var model = new SearchVacancyViewModel
            {
                SearchBlock = ToSearchVacancyBlockViewModel(meridian),
                WeekVacancies = GetWeekVacancies(meridian),
                WorkInCompanies = GetWorkInCompanies(meridian),
            };

            return model;
        }

        private static void FillProfessionals(Dictionary<long, VacancyProfessionalViewModel> source, VacancyProfessionalViewModel node)
        {
            if (node.Children == null)
            {
                if (node.Parent.Id.HasValue())
                {
                    node.Parent = source[node.Parent.Id];
                }

                node.Children = source.Values.Where(v => v.Parent.Id.HasValue() && v.Parent.Id == node.Id).ToList();

                foreach (VacancyProfessionalViewModel child in node.Children)
                {
                    FillProfessionals(source, child);
                }
            }
        }

        /// <summary>
        /// Возвращает список энтрисов для указанной категории и/или указанного типа сущности(вакансии или резюме)
        /// </summary>
        /// <param name="meridian"></param>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IEnumerable<VacancyEntryViewModel> GetAllEntries(this Meridian meridian, VacancyEntryCategory category, EntityType? type = null)
        {
            var query = meridian.vacancy_entriesStore.All().Where(v => v.vacancy_entry_category_id == (long) category);
            if (type != null)
            {
                string ch = type.Value == EntityType.Vacancy ? "v" : "r";
                query = query.Where(v => string.IsNullOrEmpty(v.only) || v.only == ch);
            }

            return query.Select(v => v.ToVacancyEntryViewModel());
        }

        private static VacancyEntryViewModel GetDefaultEntry(this Meridian meridian, VacancyEntryCategory category, EntityType type)
        {
            var entry = meridian.GetAllEntries(category, type).FirstOrDefault();
            if (entry == null)
            {
                entry = new VacancyEntryViewModel(0);
            }

            return entry;
        }

        private static IEnumerable<vacancy_facilities> GetFacilities(this Meridian meridian)
        {
            var list = meridian.vacancy_facilitiesStore.All()
                .Skip(1)
                .Union(meridian.vacancy_facilitiesStore.All().Take(1)).ToList();

            foreach (vacancy_facilities f in list)
            {
                f.Checked = false;
                f.SelectedVariant = f.GetDefaultVariant();
            }

            return list;
        }

        #endregion
        
        #region Auxiliary methods

        private static IList<VacancyViewModel> GetWeekVacancies(this Meridian meridian, int count = Constants.CountOfWeekVacancies)
        {
            var now = DateTime.Now.Date;
            return meridian.vacanciesStore.All()
                .Where(v=>v.IsActual)
                .Where(v => now.Subtract(v.created.Date).TotalDays <= 7 || now.Subtract(v.edited.Date).TotalDays <= 7)
                .OrderByDescending(v => v.edited)
                .Take(count)
                .Select(v => meridian.ToVacancyViewModel(v))
                .ToList();
        }

        private static IList<companies> GetWorkInCompanies(this Meridian meridian, int count = Constants.CountOfWorkInCompanies)
        {
            return meridian.companiesStore.All()
                .OrderByDescending(c => c.stable_order)
                .ThenByDescending(c => c.GetPopularityByVacancies())
                .Take(count)
                .ToList();
        }

        private static IEnumerable<vacancies> FilterSalaries(IEnumerable<vacancies> query, int compensation1, int compensation2)
        {
            if (compensation1 > 0 || compensation2 > 0)
            {
                if (compensation1 > 0 && compensation2 > 0)
                {
                    query = query.Where(v => v.compensation1 >= compensation1 && v.compensation1 <= compensation2 ||
                                             v.compensation2 >= compensation1 && v.compensation2 <= compensation2);
                }
                else
                {
                    if (compensation1 > 0)
                    {
                        query = query.Where(v => v.compensation1 >= compensation1 || v.compensation2 >= compensation1);
                    }
                    else if (compensation2 > 0)
                    {
                        query = query.Where(v => v.compensation1 <= compensation2
                                                 && v.compensation2 <= compensation2);
                    }
                }
            }

            return query;
        }

        private static IEnumerable<resumes> FilterSalaries(IEnumerable<resumes> query, int compensation1, int compensation2)
        {
            if (compensation1 > 0 || compensation2 > 0)
            {
                if (compensation1 > 0 && compensation2 > 0)
                {
                    query = query.Where(r => r.salary >= compensation1 && r.salary <= compensation2);
                }
                else
                {
                    if (compensation1 > 0)
                    {
                        query = query.Where(r => r.salary >= compensation1);
                    }
                    else if (compensation2 > 0)
                    {
                        query = query.Where(r => r.salary <= compensation2);
                    }
                }
            }

            return query;
        }

        /// <summary>
        /// Кол-во совпадений навыков у одной сущности и другой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int GetProfessionalsNumberOfMatches(IVacancyOrResume x, IVacancyOrResume y)
        {
            int i = GetAllProfsIds(x).Intersect(GetAllProfsIds(y)).Count();
            return i;
        }

        private static List<long> GetAllProfsIds(IVacancyOrResume v)
        {
            var roots = v.GetRootProfessionals().ToList();
            var list = new List<long>();
            foreach (IEnumerable<long> ids in roots.Select(t => t.GetChildren().Select(c => c.id)))
            {
                list.AddRange(ids);
            }

            list.AddRange(roots.Select(r => r.id));

            return list;
        }

        #endregion

        public static IList<VacancyViewModel> GetPopularityVacancies(this Meridian meridian, int count = Constants.CountOfPopularityVacancies)
        {
            return meridian.vacanciesStore.All()
                .Where(v=>v.IsActual)
                .OrderByDescending(v => v.ViewsCount)
                .Take(count)
                .Select(v => meridian.GetVacancy(v.id))
                .ToList();
        }

        public static IEnumerable<DictionaryElement> GetRegions(this Meridian meridian)
        {
            return meridian.regionsStore.All()
                .Select(r => new DictionaryElement(r.id, r.title));
        }

        public static IEnumerable<DictionaryElement> GetCities(this Meridian meridian)
        {
            return meridian.citiesStore.All()
                .Select(c => new DictionaryElement(c.id, c.title, c.region_id));
        }

    }
}