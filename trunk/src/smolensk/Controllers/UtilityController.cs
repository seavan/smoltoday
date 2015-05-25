using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Extensions;
using smolensk.Services;
using smolensk.Models.ModelValidators.Attributes;
using meridian.smolensk.proto;
using smolensk.Models.ViewModels.Mail;
using smolensk.Domain;

namespace smolensk.Controllers
{
    public class UtilityController : BaseController
    {
        public ActionResult UpdateMainPageWidgets()
        {
            var result = new ContentResult();

            var weather = WeatherHelper.GetCurrentWeatherInfo();

            CurrencyQuoteService quoteService = new CurrencyQuoteService();
            var date = DateTime.Today;
            var dollarQuote = quoteService.GetQuote(Currency.Usd, date);
            var euroQuote = quoteService.GetQuote(Currency.Eur, date);

            var activeRecord = meridian.main_page_widgetsStore.GetRecord();

            if (weather != null)
            {
                var currentWeather = weather[0];
                var morningWeather = weather[1];
                var afternoonWeather = weather[2];
                var nightWeather = weather[3];

                if (currentWeather != null)
                {
                    activeRecord.sky = currentWeather.Sky;
                    activeRecord.sky_icon = currentWeather.SkyIcon;
                    activeRecord.temperature = currentWeather.Temperature;
                }

                if (morningWeather != null)
                {
                    activeRecord.sky_morning = morningWeather.Sky;
                    activeRecord.sky_icon_morning = morningWeather.SkyIcon;
                    activeRecord.temperature_morning = morningWeather.Temperature;
                }

                if (afternoonWeather != null)
                {
                    activeRecord.sky_afternoon = afternoonWeather.Sky;
                    activeRecord.sky_icon_afternoon = afternoonWeather.SkyIcon;
                    activeRecord.temperature_afternoon = afternoonWeather.Temperature;
                }

                if (nightWeather != null)
                {
                    activeRecord.sky_evening = nightWeather.Sky;
                    activeRecord.sky_icon_evening = nightWeather.SkyIcon;
                    activeRecord.temperature_evening = nightWeather.Temperature;
                }
            }

            if (dollarQuote != null)
            {
                activeRecord.usd_price = dollarQuote.Price;
                activeRecord.usd_change = dollarQuote.PercentChange;
            }

            if (euroQuote != null)
            {
                activeRecord.eur_price = euroQuote.Price;
                activeRecord.eur_change = euroQuote.PercentChange;
            }

            meridian.main_page_widgetsStore.Update(activeRecord);

            result.Content = "Done...";

            return result;
        }

        [Authorize403]
        public ActionResult AddToFavorite(string proto, long id, string view)
        {
            var item = meridian.GetAs<IFavorite>(proto, id);
            item.AddToFavorite(HttpContext.UserPrincipal().id);
            return PartialView(view, item);
        }

        [Authorize403]
        public ActionResult DeleteFromFavorite(string proto, long id, string view)
        {
            var item = meridian.GetAs<IFavorite>(proto, id);
            item.DeleteFromFavorite(HttpContext.UserPrincipal().id);
            return PartialView(view, item);
        }

        [HttpPost]
        [Authorize403]
        public ActionResult Complain(MaterialComplaintMailModel model)
        {
            model.User = HttpContext.UserPrincipal();

            new Mailer(this).SendMessageMaterialComplaint(model);
            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            else
                return RedirectToAction("Index", "Main");
        }
    }
}
