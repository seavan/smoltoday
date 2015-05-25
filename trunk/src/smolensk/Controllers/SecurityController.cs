using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Services;
using smolensk.common;
using smolensk.common.HtmlHelpers;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.common.Security;
using smolensk.Models.CodeModels.Security;
using smolensk.Services.Interfaces;
using smolensk.Mappers;
using smolensk.common.Captcha;
using smolensk.Domain;

namespace smolensk.Controllers
{
    public class SecurityController : BaseController
    {
        private Mailer mailer;

        public SecurityController() : base()
        {
            this.mailer = new Mailer(this);
        }

        #region Регистрация
        public ActionResult Registration()
        {
            return PartialView("Widgets/Registration", new UserRegistrationModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Registration(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (SecurityService.ValidateCaptcha(model.Captcha, ModelState))
                {
                    model.EMailReg = model.EMailReg.ToLower();

                    RegisterUser(model);

                    return PartialView("Widgets/Registration", new UserRegistrationModel() {Success = true});
                }
            }

            return PartialView("Widgets/Registration", model);
        }

        private void RegisterUser(UserRegistrationModel model, bool needActivation = true)
        {
            var account = SecurityService.Register(model, needActivation);

            if (needActivation && account != null)
                //Выслать на почту письмо с кодом активации
                mailer.SendActivationMail(account.NameAndSurname, account.email, account.activation_guid);
        }
        #endregion

        #region Активация
        /// <summary>
        /// Активация аккаунта участника
        /// </summary>
        [HttpGet]
        public ActionResult Activate(string email, Guid? activationKey)
        {
            ViewBag.Success = false;

            if (!activationKey.HasValue) { return View(model: "Не указан активационный код."); }
            string errorMessage;

            var acc = SecurityService.ActivateAccount(email, activationKey.Value, out errorMessage);

            if (string.IsNullOrEmpty(errorMessage))
            {
                try
                {
                    // если вошли до того - выходим
                    if (SecurityService.IsAuthorize)
                    {
                        SecurityService.SignOut();
                    }

                    // входим этим аккаунтом
                    SecurityService.SignIn(acc, false);
                    return RedirectToAction("ActivationSuccess", new { name = acc.ShortName });
                }
                catch (Exception ex)
                {
                    return View(model: ex.Message);
                }
            }

            return View(model: errorMessage);
        }
        [HttpGet]
        public ActionResult ActivationSuccess(String name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToRoute("Default");

            ViewBag.Success = true;
            return View("Activate", model: name);
        }

        [HttpGet]
        public ActionResult RepeatActivation()
        {
            return PartialView("Widgets/Remember", new RegainModel(){repeatActivation = true});
        }
        [HttpPost]
        public ActionResult RepeatActivation(RegainModel model)
        {
            if (ModelState.IsValid)
            {
                if (SecurityService.ValidateUser(model.EMailRem, model.Captcha, true, ModelState))
                {
                    SecurityService.RepeatActivation(model.EMailRem);
                    return PartialView("Widgets/Remember", new RegainModel() { Success = true, repeatActivation = true});
                }
            }
            
            model.Captcha = string.Empty;
            model.repeatActivation = true;

            return PartialView("Widgets/Remember", model);
        }
        #endregion

        #region Авторизация
        public ActionResult SignIn()
        {
            return PartialView("Widgets/Authorization", new UserAuthenticationModel());
        }

        [HttpPost]
        public ActionResult SignIn(UserAuthenticationModel model)
        {
            InitUniqueId(true);
            try
            {
                if (ModelState.IsValid)
                {
                    string result;

                    if (SecurityService.Authenticate(model.EMailAuth, model.Password, out result))
                    {
                        SecurityService.SignIn(model.EMailAuth, model.Remember);

                        if (string.IsNullOrEmpty(model.currentUrlToReturn))
                        {
                            return new AjaxAwareAuthRedirectResult("/");
                        }
                        return new AjaxAwareAuthRedirectResult(model.currentUrlToReturn);

                    }
                    else
                    {
                        ModelState.AddModelError("AuthenticateError", result);
                        SecurityService.SignOut();
                    }
                    if (result.Contains("Ваш аккаунт не активирован")) model.isActivate = false;
                }

                return PartialView("Widgets/Authorization", model);
            }
            catch
            {
                return RedirectToAction("SignOut");
            }
        }

        public ActionResult Autologin(int id)
        {
            if (meridian.accountsStore.Exists(id))
            {
                SecurityService.SignIn(meridian.accountsStore.Get(id).email, false);
            }
            return new RedirectResult("/");
        }

        public ActionResult SignOut(string ReturnUrl = "")
        {
            InitUniqueId(true);
            SecurityService.SignOut();
            if (!String.IsNullOrEmpty(ReturnUrl) && ReturnUrl.Contains("/Profile"))
                ReturnUrl = string.Empty;

            Response.RedirectLocation = String.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl;

            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            return new RedirectResult(Response.RedirectLocation);
        }
        #endregion

        #region Восстановление пароля
        [HttpGet]
        public ActionResult RememberPassword()
        {
            return PartialView("Widgets/Remember", new RegainModel());
        }

        [HttpPost]
        public ActionResult RememberPassword(RegainModel model)
        {
            if (ModelState.IsValid)
            {
                if (SecurityService.ValidateUser(model.EMailRem, model.Captcha, false, ModelState))
                {
                    var account = SecurityService.RememberPassword(model.EMailRem);
                    if (account != null)
                        //Выслать на почту письмо с кодом восстановления
                        mailer.SendRegainPasswordMail(account.NameAndSurname, account.email, account.rememberpass_guid);

                    return PartialView("Widgets/Remember", new RegainModel() { Success = true });
                }
            }

            model.Captcha = string.Empty;

            return PartialView("Widgets/Remember", model);
        }

        [HttpGet]
        public ActionResult RegainPassword(string email, Guid? regainkey)
        {
            if (!regainkey.HasValue) { return View(model: "Не указан код восстановления."); }
            string errorMessage;

            try
            {
                if (SecurityService.ValidateRegainPassword(email, regainkey.Value, out errorMessage))
                {
                    // если вошли до того - выходим
                    if (SecurityService.IsAuthorize)
                    {
                        SecurityService.SignOut();
                    }

                    // входим этим аккаунтом
                    SecurityService.SignIn(email, false);

                    return RedirectToAction("ChangeRegainPassword");
                }
            }
            catch (Exception ex)
            {
                return View(model: ex.Message);
            }

            return View(model: errorMessage);
        }

        [Authorize403]
        public ActionResult ChangeRegainPassword()
        {
            return View(new ChangePasswordModel());
        }

        [HttpPost]
        [Authorize403]
        [ValidateInput(false)]
        public ActionResult ChangeRegainPassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var acc = SecurityService.ChangePassword(model, HttpContext.UserPrincipal().id);
                if (acc != null)
                {
                    ViewBag.Success = true;
                    return View("RegainPassword", model: acc.ShortName);
                }
            }
            return View(model);
        }
        #endregion

        #region CAPTHCA Image
        public class CaptchaImageResult : ActionResult
        {
            public override void ExecuteResult(ControllerContext context)
            {
                CaptchaImage ci = CaptchaImage.GetCachedCaptcha(CaptchaHelper.FieldNameCAPTCHA, context.HttpContext, false);

                if (ci == null)
                {
                    context.HttpContext.Response.StatusCode = 404;
                    context.HttpContext.Response.StatusDescription = "Not Found";
                    context.HttpContext.ApplicationInstance.CompleteRequest();
                    return;
                }

                // Запись изображения в выходной поток HTTP как массива байтов                
                using (Bitmap b = ci.RenderImage())
                {
                    b.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
                }

                context.HttpContext.Response.ContentType = "image/jpeg";
                context.HttpContext.Response.StatusCode = 200;
                context.HttpContext.Response.StatusDescription = "OK";
                context.HttpContext.ApplicationInstance.CompleteRequest();
            }
        }

        public CaptchaImageResult ImageCaptcha()
        {
            return new CaptchaImageResult();
        }

        public ViewResult CaptchaScript()
        {
            return View();
        }
        #endregion

        #region OAuth
        public ActionResult OAuthSignIn(OAuthServiceName? serviceName)
        {
            string code = Request.QueryString["code"];

            if (!serviceName.HasValue || string.IsNullOrEmpty(code))
                return new RedirectResult("/");

            IOAuth service;
            switch (serviceName.Value)
            {
                case OAuthServiceName.vkontakte: service = new OAuthVkService(); break;
                case OAuthServiceName.facebook: service = new OAuthFbService(); break;
                case OAuthServiceName.googleplus: service = new OAuthGpService(); break;
                default: return new RedirectResult("/");
            }

            service.ServerCode = code;
            service.GetToken();

            //У контакта userId пользователя приходит сразу с токеном, поэтому можно сделать проверку сразу.
            //А если это другня соц.сеть, то id будет пустой
            var acc = SecurityService.GetOAuthAccount(serviceName.Value, service.UserId);
            if(acc != null)
            {
                SecurityService.SignIn(acc.email, false);
                return new RedirectResult("/");
            }

            service.GetProfile();

            //После запроса профиля и у других сетей уже должен быть передан userId
            //Для контакта просто избежали лишнего web запроса ранее
            acc = SecurityService.GetOAuthAccount(serviceName.Value, service.UserId);

            if(acc != null)
            {
                SecurityService.SignIn(acc.email, false);
                return new RedirectResult("/");
            }

            //Если пользователь не найден, остаётся шанс, что email, на который он зареген в соц.сети уже есть в нашей базе
            //Но если соц.сеть email не вернула, то нужно спросить напрямую у пользователя
            if (string.IsNullOrEmpty(service.UserEmail))
            {
                //Пишем в кеш и кидаем на страницу с вопросом
                Guid accessGuid = Guid.NewGuid();
                HttpRuntime.Cache.Add(
                    accessGuid.ToString(),
                    service,
                    null,
                    DateTime.Now.AddSeconds(CaptchaImage.CacheTimeOut),
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    System.Web.Caching.CacheItemPriority.NotRemovable,
                    null
                );

                return View("OAuthSignInForm", new OAuthModel { ServerAccessToken = accessGuid, UserFirstName = service.UserFirstName});
            }

            //Если email есть - проверяем его
            acc = meridian.accountsStore.GetAccountsByLogin(service.UserEmail);
            if (acc != null)
            {
                //Подумать - ведь без этой строки мы просто авторизуем, даже в базу к нам данных не занося по текущей соц-сети.
                SecurityService.UpdateOAuthAccount(service.UserEmail, serviceName.Value, service.UserId);
                SecurityService.SignIn(acc.email, false);
                return new RedirectResult("/");
            }

            if (!string.IsNullOrEmpty(service.UserEmail) && (!string.IsNullOrEmpty(service.UserFirstName) || !string.IsNullOrEmpty(service.UserLastName)))
            {
                //Если аккаунт так и не был создан, то его нужно создать
                RegisterUser(new UserRegistrationModel() { FirstName = service.UserFirstName, LastName = service.UserLastName, EMailReg = service.UserEmail, Password = SecurityService.GeneratePassword() }, false);
                //Обновим инфу для дальнейшей быстрой авторизации
                SecurityService.UpdateOAuthAccount(service.UserEmail, serviceName.Value, service.UserId);
                //После создания можно авторизоваться
                SecurityService.SignIn(service.UserEmail, false);
            }

            return new RedirectResult("/");
        }

        //Для тестов
        //public ActionResult OAuthSignInForm()
        //{
        //    return View(new OAuthModel());
        //}

        [HttpPost]
        public ActionResult OAuthSignInForm(OAuthModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ServerAccessToken != null && model.ServerAccessToken != Guid.Empty)
                {
                    //Достаём из кеша
                    IOAuth service = (IOAuth)HttpRuntime.Cache.Get(model.ServerAccessToken.ToString());

                    if (service != null)
                    {
                        HttpRuntime.Cache.Remove(model.ServerAccessToken.ToString());

                        var acc = meridian.accountsStore.GetAccountsByLogin(model.UserEmail);
                        if (acc != null)
                        {
                            SecurityService.SignIn(acc.email, false);
                            return new RedirectResult("/");
                        }
                        if (!string.IsNullOrEmpty(service.UserFirstName) || !string.IsNullOrEmpty(service.UserLastName))
                        {
                            //Если аккаунт так и не был создан, то его нужно создать
                            RegisterUser(new UserRegistrationModel() { FirstName = service.UserFirstName, LastName = service.UserLastName, EMailReg = model.UserEmail, Password = SecurityService.GeneratePassword() }, false);

                            //Обновим инфу для дальнейшей быстрой авторизации
                            OAuthServiceName? serviceName = (OAuthServiceName?)null;
                            if (service is OAuthVkService)
                                serviceName = OAuthServiceName.vkontakte;
                            if (service is OAuthFbService)
                                serviceName = OAuthServiceName.facebook;
                            if (service is OAuthGpService)
                                serviceName = OAuthServiceName.googleplus;

                            if (serviceName.HasValue)
                                SecurityService.UpdateOAuthAccount(model.UserEmail, serviceName.Value, service.UserId);

                            //После создания можно авторизоваться
                            SecurityService.SignIn(model.UserEmail, false);
                        }
                    }
                }

                return new RedirectResult("/");
            }

            return View(model);
        }

        #endregion

        
    }
}
