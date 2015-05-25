using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Domain;
using smolensk.Extensions;
using smolensk.Mappers;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using smolensk.Models.ViewModels.Mail;
using smolensk.Services;
using smolensk.common;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Controllers
{
    public class VacancyController : BaseController
    {
        public ActionResult Index()
        {
            var model = Meridian.Default.ToSearchVacancyViewModel();

            return View("Index", model);
        }

        public ActionResult Vacancy(long id)
        {
            VacancyViewModel model = Meridian.Default.GetVacancy(id);

            if (model == null)
            {
                return new HttpNotFoundResult();
            }

            Meridian.Default.vacanciesStore.Get(id).IncrementViewsCount();

            return View("Vacancy", model);
        }

        public ActionResult Resume(long id)
        {
            ResumeViewModel model = Meridian.Default.GetResume(id);

            if (model == null)
            {
                return new HttpNotFoundResult();
            }

            return View("Resume", model);
        }

        public ActionResult SearchCompany(int regionId, int cityId,
            string allCompanies, string letter, string filter)
        {
            VacancyCompanySearchViewModel model = Meridian.Default.GetVacancyCompanySearchViewModel(
                regionId, cityId, filter, allCompanies == "on", letter);
            var routeData = RouteData.Values;
            model.Alphabet = new AlphabetViewModel("VacancyCompanyList", routeData, "letter")
                                 {
                                     Letter = letter,
                                 };

            return View(model);
        }

        public ActionResult Company(long id)
        {
            CompanyViewModel model = Meridian.Default.GetCompany(id);

            if (model == null)
            {
                return new HttpNotFoundResult();
            }

            return View("Company", model);
        }

        public ActionResult Search(string q=null, int searchType=1, int prof=0, int salaryId=-1)
        { 
            if (searchType == 1)//Вакансии
            {
                return RedirectToAction("SearchVacancyResult", new { q = q, prof = prof, salaryId = salaryId });
            }
            else//резюме
            {
                return RedirectToAction("SearchResumeResult", new { q = q, prof = prof, salaryId = salaryId });
            }
        }

        public ActionResult Vacancies(int page=1)
        {
            var model = Meridian.Default.ToSearchVacancyResultViewModel(null, 0, -1, page);
            
            return View("VacancyList", model);
        }

        public ActionResult Resumes(int page=1)
        {
            var model = Meridian.Default.ToSearchResumeResultViewModel(null, 0, -1, page);
            
            return View("ResumeList", model);
        }

        public ActionResult SearchVacancy(SearchVacancyOrResumeViewModel model, int page = 1)
        {
            if (model.IsEmpty)
            {
                model = Meridian.Default.ToSearchVacancyExt(VacancyMapper.EntityType.Vacancy);

                return View("SearchVacancy", model);
            }

            var result = Meridian.Default.ToSearchVacancyResultViewModel(model, page);

            return View("SearchVacancyResult", result);
        }

        public ActionResult SearchResume(SearchVacancyOrResumeViewModel model, int page = 1)
        {
            if (model.IsEmpty)
            {
                model = Meridian.Default.ToSearchVacancyExt(VacancyMapper.EntityType.Resume);

                return View("SearchResume", model);
            }

            var result = Meridian.Default.ToSearchResumeResultViewModel(model, page);

            return View("SearchResumeResult", result);
        }

        public ActionResult SearchVacancyResult(int page = 1, string q = null, int prof = 0, int salaryId = -1, int pageSize = Constants.PageSize)
        {
            var model = Meridian.Default.ToSearchVacancyResultViewModel(q, prof, salaryId, page);

            return View("SearchVacancyResult", model);
        }

        public ActionResult SearchResumeResult(int page = 1, string q = null, int prof = 0, int salaryId = -1, int pageSize = Constants.PageSize)
        {
            var model = Meridian.Default.ToSearchResumeResultViewModel(q, prof, salaryId, page);

            return View("SearchResumeResult", model);
        }

        [HttpPost]
        public ActionResult SendNoResumeMail(NoResumeMailModel model)
        {
            var store = meridian.vacanciesStore;
            if (!store.Exists(model.Vacancy.id))
                return HttpNotFound();

            model.Vacancy = store.Get(model.Vacancy.id);
            model.User = HttpContext.UserPrincipal();

            new Mailer(this).SendMessageNoResume(model);

            return RedirectToAction("Vacancy", "Vacancy", new { Id = model.Vacancy.id });
        }

        [HttpPost]
        public ActionResult ResumeSend(ResumeSendModel model)
        {
            if (!meridian.resumesStore.Exists(model.ResumeId) || !meridian.vacanciesStore.Exists(model.Vacancy.id))
                return HttpNotFound();

            model.User = HttpContext.UserPrincipal();
            model.Vacancy = meridian.vacanciesStore.Get(model.Vacancy.id);

            new Mailer(this).SendMessageResume(model);

            return RedirectToAction("Vacancy", "Vacancy", new { Id = model.Vacancy.id });
        }

        [HttpPost]
        public ActionResult ResumeSendForCompany(ResumeSendForCompanyModel model)
        {
            if (!meridian.resumesStore.Exists(model.ResumeId) 
                || !meridian.companiesStore.Exists(model.Company.id))
                return HttpNotFound();

            model.User = HttpContext.UserPrincipal();
            model.Company = meridian.companiesStore.Get(model.Company.id);

            new Mailer(this).SendMessageResumeForCompany(model);

            return RedirectToAction("Company", "Vacancy", new { Id = model.Company.id });
        }

        [HttpGet]
        public FileResult GetPhoneImage(long vacancyId)
        {
            VacancyViewModel vacancy = Meridian.Default.GetVacancy(vacancyId);
            string phone = vacancy.GetContactPhone();

            byte[] data;
            using (Bitmap bmp = ImageHelper.CreateTextImage(phone))
            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
                data = new byte[stream.Length];
                stream.Read(data, 0, (int)stream.Length);
                
            }

            return File(data, "image/png");
        }

        [HttpPost]
        public ActionResult InvitationSend(InvitationSendMailModel model)
        {
            if (!Meridian.Default.resumesStore.Exists(model.ResumeId))
                return new HttpNotFoundResult();

            model.Resume = Meridian.Default.resumesStore.Get(model.ResumeId);

            model.Sender = HttpContext.UserPrincipal();            

            new Mailer(this).SendInvitationMail(model);
            return RedirectToAction("Resume", new { id = model.ResumeId });
        }


    } 
}
