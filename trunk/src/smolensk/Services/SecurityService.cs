using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml.Serialization;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common.Security;
using smolensk.Domain;
using smolensk.Mappers;
using System.Web.Security;
using smolensk.Models.CodeModels.Security;
using System.Web.Mvc;
using smolensk.common.HtmlHelpers;
using smolensk.common.Captcha;

namespace smolensk.Services
{
    public static class SecurityService
    {
        #region Регистрация
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registerData">данные регистрации</param>
        /// <param name="needActivation">признак необходимости активации аккаунта</param>
        public static accounts Register(UserRegistrationModel registerData, bool needActivation = true)
        {
            accounts newAccount = new accounts()
            {
                firstname = registerData.FirstName,
                lastname = registerData.LastName,
                email = registerData.EMailReg,
                created = DateTime.Now,
                role_id = 1,
                salt = Guid.NewGuid(),
                activation_guid = needActivation ? Guid.NewGuid() : Guid.Empty
            };

            newAccount.password = CalculateHash(registerData.Password, newAccount.salt.ToString());

            Meridian.Default.accountsStore.Insert(newAccount);

            return newAccount;
        }
        #endregion

        #region Активация
        /// <summary>
        /// Подтвердить статус аккаунта
        /// </summary>
        /// <param name="_email">логин аккаунта (email)</param>
        /// <param name="_guid">активационны ключ</param>
        /// <param name="errorMessage">сообщение об ошибках</param>
        /// <returns></returns>
        public static accounts ActivateAccount(string _email, Guid _guid, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(_email))
                {
                    errorMessage = "Не указан логин (email) пользователя.";
                    return null;
                }
                var account = Meridian.Default.accountsStore.GetAccountsByLogin(_email);
                if (account == null)
                {
                    errorMessage = String.Format("Аккаунт с email {0} не существует.", _email);
                    return null;
                }
                if (account.activation_guid.Equals(Guid.Empty))
                {
                    errorMessage = "Этот аккаунт уже активирован.";
                    return null;
                }
                if (!account.activation_guid.Equals(_guid))
                {
                    errorMessage = "Неверный активационный код.";
                    return null;
                }

                account.activation_guid = Guid.Empty;
                Meridian.Default.accountsStore.Update(account);

                return account;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return null;
            }
        }
        /// <summary>
        /// Запрос на повторную активацию
        /// </summary>
        /// <param name="_email">логин аккаунта (email)</param>
        public static void RepeatActivation(string _email)
        {
            var acc = Meridian.Default.accountsStore.GetAccountsByLogin(_email);
            if (acc != null)
            {
                //Выслать на почту новое письмо с кодом активации
            }
        }
        #endregion

        #region Авторизация/Аутентификация
        /// <summary>
        /// Получение текущего пользователя
        /// </summary>
        /// <returns>аккаунт</returns>
        public static accounts UserPrincipal(this HttpContextBase _helper)
        {
            var existing = _helper.Items["lz_account"] as accounts;

            if (existing != null)
                return existing;
            
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return null;

            try
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var xs = new XmlSerializer(typeof(TicketUserData));
                StringReader sr = new StringReader(authTicket.UserData);
                TicketUserData data = (TicketUserData)xs.Deserialize(sr);

                var accountId = data.Id;

                if (Meridian.Default.accountsStore.Exists(accountId))
                {
                    var account = Meridian.Default.accountsStore.Get(accountId);

                    if (!account.IsActivated)
                        return null;

                    _helper.Items["lz_account"] = account;

                    return account;
                }
            }
            catch (Exception)
            {
            }

            return null;
        }
        /// <summary>
        /// Получение текущего пользователя
        /// </summary>
        /// <returns>аккаунт</returns>
        public static accounts UserPrincipal(this HtmlHelper _helper)
        {
            return _helper.ViewContext.HttpContext.UserPrincipal();
        }
        /// <summary>
        /// Проверка наличия пользователя
        /// </summary>
        /// <returns></returns>
        public static bool ExistPrincipal(this HtmlHelper _helper)
        {
            return UserPrincipal(_helper) != null;
        }

        /// <summary>
        /// Проверка текущей авторизации
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthorize
        {
            get { return HttpContext.Current.Request.IsAuthenticated; }
        }

        /// <summary>
        /// Аутентификация пользователя по логину (e-mail) и паролю
        /// </summary>
        /// <param name="_email">логин (e-mail)</param>
        /// <param name="_password">пароль</param>
        /// <param name="_message">сообщение об ошибке</param>
        /// <returns>результат авторизации</returns>
        public static bool Authenticate(string _email, string _password, out string _message)
        {
            var acc = Meridian.Default.accountsStore.GetAccountsByLogin(_email);
            _message = null;

            /*Неверные логи/пароль*/
            if ((acc == null) || (acc.password != CalculateHash(_password, acc.salt.ToString())))
            {
                _message = "Неверное имя пользователя или пароль";
                return false;
            }

            /*Неактивированный аккаунт*/
            if (!acc.IsActivated)
            {
                _message = "Ваш аккаунт не активирован. Для активации пройдите по ссылке, которая была отправлена Вам на электронный адрес. Вы можете повторно выслать себе активационное письмо, воспользовавшись ссылкой, расположенной ниже.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Вход в систему. Определение ролей и установка необходимых cookies
        /// </summary>
        /// <param name="_email">логин (email) пользователя</param>
        /// <param name="_persist">запоминать ли авторизацию</param>
        public static void SignIn(string _email, bool _persist)
        {
            SignIn(Meridian.Default.accountsStore.GetAccountsByLogin(_email), _persist);
        }

        /// <summary>
        /// Вход в систему. Определение ролей и установка необходимых cookies
        /// </summary>
        /// <param name="_account">аккаунт, который входит</param>
        /// <param name="_persist">запоминать ли авторизацию</param>
        public static void SignIn(accounts _account, bool _persist)
        {
            if (_account != null)
            {
                // получим роли для нашего аккаунта
                List<string> roles = GetRoles(_account);
                SetAuthenticationCookie(_account.id, _account.email, _account.ShortName, _persist, roles);
            }
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        public static void SignOut()
        {
            FormsAuthentication.SignOut();
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            authCookie.Expires = DateTime.Now.AddDays(-1);
            //authCookie.Domain = ZakonExtension.GetHost();
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        /// <summary>
        /// Установка cookie 
        /// </summary>
        /// <param name="_id">ID аккаунта</param>
        /// <param name="_email">email</param>
        /// <param name="_friendlyName">ФИО</param>
        /// <param name="_persist">запоминать ли авторизацию</param>
        /// <param name="_roles">список ролей</param>
        public static void SetAuthenticationCookie(long _id, string _email, string _friendlyName, bool _persist, List<string> _roles)
        {
            AuthenticationSection authenticationSection = (AuthenticationSection)ConfigurationManager.GetSection("system.web/authentication");

            var xs = new XmlSerializer(typeof(TicketUserData));
            StringWriter stringWriter = new StringWriter();

            TicketUserData data = new TicketUserData
            {
                FriendlyName = _friendlyName,
                Roles = _roles,
                Id = _id,
                Persist = _persist
            };

            xs.Serialize(stringWriter, data);

            FormsAuthenticationTicket authTicket =
                new FormsAuthenticationTicket(
                1, _email, DateTime.Now, DateTime.Now.AddMinutes(authenticationSection.Forms.Timeout.TotalMinutes),
                _persist, stringWriter.ToString());

            String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            
            DateTime now = DateTime.Now;
            authCookie.Expires = now.AddDays(7);
            
            if (authTicket.IsPersistent)
            {
                authCookie.Expires = authTicket.Expiration;
            }

            HttpContext.Current.Response.Cookies.Add(authCookie);

        }
        #endregion


        #region Восстановление пароля
        /// <summary>
        /// Проверка пользователя по логину (e-mail) и CAPTHCA тексту перед восстановлением пароля
        /// </summary>
        /// <param name="_email">логин (e-mail)</param>
        /// <param name="_capthca">CAPTHCA</param>
        /// <param name="_message">сообщение об ошибке</param>
        /// <returns>результат проверки</returns>
        public static bool ValidateUser(string _email, string _capthca, bool isRepeat, ModelStateDictionary modelState)
        {
            var acc = Meridian.Default.accountsStore.GetAccountsByLogin(_email);

            if (acc == null)
            {
                modelState.AddModelError("EMailRem", "Электронный адрес не зарегистирован в системе");
                return false;
            }

            if (!acc.IsActivated && !isRepeat)
            {
                modelState.AddModelError("EMailRem", "Ваш аккаунт не активирован");
                return false;
            }
            else if (acc.IsActivated && isRepeat)
            {
                modelState.AddModelError("EMailRem", "Ваш аккаунт уже активирован");
                return false;
            }

            return ValidateCaptcha(_capthca, modelState);
        }
        /// <summary>
        /// Валидация перед восстановлением пароля
        /// </summary>
        /// <param name="_email">логин (e-mail)</param>
        /// <param name="_guid">код восстановления</param>
        /// <param name="errorMessage">сообщение об ошибках</param>
        public static bool ValidateRegainPassword(string _email, Guid _guid, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(_email))
                {
                    errorMessage = "Не указан логин (email) пользователя.";
                    return false;
                }
                var account = Meridian.Default.accountsStore.GetAccountsByLogin(_email);
                if (account == null)
                {
                    errorMessage = String.Format("Аккаунт с email {0} не существует.", _email);
                    return false;
                }
                if (account.rememberpass_guid.Equals(Guid.Empty))
                {
                    errorMessage = "Запрос на восстановления пароля не осуществлялся.";
                    return false;
                }
                if (!account.rememberpass_guid.Equals(_guid))
                {
                    errorMessage = "Неверный код восстановления.";
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }
        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="_email">логин (e-mail)</param>
        public static accounts RememberPassword(string _email)
        {
            var account = Meridian.Default.accountsStore.GetAccountsByLogin(_email);
            if (account != null)
            {
                account.rememberpass_guid = Guid.NewGuid();
                Meridian.Default.accountsStore.Update(account);
            }

            return account;
        }

        /// <summary>
        /// Изменение пароля
        /// </summary>
        /// <param name="model">модель пароля при его смене</param>
        /// <param name="account_id">ID аккаунта</param>
        public static accounts ChangePassword(ChangePasswordModel model, long account_id)
        {
            if (!String.IsNullOrEmpty(model.Password))
            {
                var account = Meridian.Default.accountsStore.Get(account_id);
                account.rememberpass_guid = Guid.Empty;
                account.salt = Guid.NewGuid();
                account.password = CalculateHash(model.Password, account.salt.ToString());
                Meridian.Default.accountsStore.Update(account);

                return account;
            }

            return null;
        }
        #endregion


        #region OAuth
        /// <summary>
        /// Получение аккаунта пользователя, привязанного к соц.сети
        /// </summary>
        /// <param name="serviceName">имя соц.сети</param>
        /// <param name="socialId">ID пользователя в соц.сети</param>
        /// <returns></returns>
        public static accounts GetOAuthAccount(OAuthServiceName serviceName, string socialId)
        {
            if (string.IsNullOrEmpty(socialId))
                return null;

            accounts acc = null;
            switch (serviceName)
            {
                case OAuthServiceName.vkontakte: acc = Meridian.Default.accountsStore.GetAll().Where(a => a.vk_id.Equals(socialId)).FirstOrDefault(); break;
                case OAuthServiceName.facebook: acc = Meridian.Default.accountsStore.GetAll().Where(a => a.facebook_id.Equals(socialId)).FirstOrDefault(); break;
                case OAuthServiceName.googleplus: acc = Meridian.Default.accountsStore.GetAll().Where(a => a.google_id.Equals(socialId)).FirstOrDefault(); break;
            }

            return acc;
        }

        public static void UpdateOAuthAccount(string email, OAuthServiceName serviceName, string socialId)
        {
            accounts acc = Meridian.Default.accountsStore.GetAccountsByLogin(email);
            if (acc != null)
            {
                switch (serviceName)
                {
                    case OAuthServiceName.vkontakte: acc.vk_id = socialId; break;
                    case OAuthServiceName.facebook: acc.facebook_id = socialId; break;
                    case OAuthServiceName.googleplus: acc.google_id = socialId; break;
                }

                Meridian.Default.accountsStore.Update(acc);
            }
        }

        #endregion

        #region Helpers
        /// <summary>
        /// Вычислить хэш пароля
        /// </summary>
        /// <param name="_password">пароль</param>
        /// <param name="_salt">соль</param>
        /// <returns>хэш</returns>
        public static string CalculateHash(string _password, string _salt)
        {
            StringBuilder strHash = new StringBuilder();

            foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(_password)))
            {
                strHash.Append(b.ToString("x2"));
            }

            string result = strHash.ToString();

            if (!string.IsNullOrEmpty(_salt))
            {
                StringBuilder strHash2 = new StringBuilder();
                foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(String.Format("{0}{1}", result, _salt))))
                {
                    strHash2.Append(b.ToString("x2"));
                }

                result = strHash2.ToString();
            }

            return result;
        }
        /// <summary>
        /// Email (логин) по id
        /// </summary>
        /// <param name="_id">идентификатор</param>
        /// <returns>логин</returns>
        public static string GetEmailById(int _id)
        {
            return Meridian.Default.accountsStore.Exists(_id)
                ? Meridian.Default.accountsStore.Get(_id).email
                : null;
        }

        /// <summary>
        /// Получить списко ролей аккаунта
        /// </summary>
        /// <param name="_account">акканунт</param>
        /// <returns>список</returns>
        public static List<string> GetRoles(accounts _account)
        {
            List<string> roles = new List<string> { "0" };
            return roles;
        }

        /// <summary>
        /// Валидация Captcha-строки 
        /// </summary>
        /// <param name="_capthca">проверяемое значение</param>
        /// <param name="modelState">состояние модели</param>
        /// <returns></returns>
        public static bool ValidateCaptcha(string _capthca, ModelStateDictionary modelState)
        {
            CaptchaImage image = CaptchaImage.GetCachedCaptcha(CaptchaHelper.FieldNameCAPTCHA, true);
            string expectedValue = image == null ? String.Empty : image.Text;

            if (String.IsNullOrEmpty(expectedValue) || !String.Equals(_capthca, expectedValue, StringComparison.OrdinalIgnoreCase))
            {
                modelState.AddModelError("Captcha", "Неверный текст. Повторите ввод");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Автогенерация 8-символного пароля
        /// </summary>
        public static string GeneratePassword()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
        #endregion
    }
}