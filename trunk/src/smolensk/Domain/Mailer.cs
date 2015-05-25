using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CuttingEdge.Conditions;
using Footboy.Shared;
using Footboy.Shared.Messages;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.common.Infrastructure;
using smolensk.Mappers;
using smolensk.Models.ViewModels;
using smolensk.Models.ViewModels.Mail;
using smolensk.ViewModels;

namespace smolensk.Domain
{
    public class Mailer
    {
        private static readonly EndpointAddress FromAddress = new EmailAddress("SMOLTODAY.RU", "noreply@smoltoday.ru");

        private Controller controller;
        private const string AdminEmail = "test@test.com";

        public Mailer(Controller controller)
        {
            Condition.Requires(controller, "controller").IsNotNull();

            this.controller = controller;
        }

        public void SendActivationMail(string name, string email, Guid guid)
        {
            SendLinkModel model = new SendLinkModel();
            model.Link = string.Format("http://smoltoday.ru/Security/Activate?email={0}&activationKey={1}", email, guid);

            var template = GetTemplate("AccountActivationEmail.aspx");
            var text = template.Apply(model);

            SendNotification(name, email, "Активация", text);
        }

        public void SendRegainPasswordMail(string name, string email, Guid guid)
        {
            SendLinkModel model = new SendLinkModel();
            model.Link = string.Format("http://smoltoday.ru/Security/RegainPassword?email={0}&regainkey={1}", email, guid);

            var template = GetTemplate("RegainPasswordEmail.aspx");
            var text = template.Apply(model);

            SendNotification(name, email, "Восстановление пароля", text);
        }

        public void SendReserveTableMail(ReserveTableViewModel info)
        {
            var meridian = Meridian.Default;
            RestaurantViewModel restaurant = meridian.GetRestaurant(info.RestaurantId);
            info.RestaurantTitle = restaurant.Title;

            IEnumerable<AccountViewModel> moderators = meridian.GetModerators();

            var template = GetTemplate("ReserveRestaurantTableEmail.aspx");
            var text = template.Apply(info);
            var subject = "Заказ столика";

            SendNotification("Владелец", restaurant.FeedbackEmail, subject, text);

            foreach (var moder in moderators)
            {
                string nameTo = string.Format("{0} {1}", moder.FirstName, moder.LastName);
                SendNotification(nameTo, moder.Email, subject, text);
            }
        }

        public void SendGetSessionEmailMail(GetSessionModel model)
        {
            var template = GetTemplate("GetPhotosessionEmail.aspx");
            var text = template.Apply(model);

            SendNotification(model.Photographer.ShortName, model.Photographer.email, "Заказ фотосъемки с сайта smoltoday.ru", text);
        }

        public void SendMessageToCompany(CompanyMailModel model)
        {
            var template = GetTemplate("WriteCompanyMail.aspx");
            string text = template.Apply(model);

            SendNotification(model.User.ShortName, model.Company.email, model.Theme, text);
        }

        public void SendMessageToAdvOwner(AdvMailModel model)
        {
            var template = GetTemplate("WriteAdvertMail.aspx");
            string text = template.Apply(model);

            SendNotification(model.User.ShortName, model.Adv.email, model.Theme, text);
        }

        public void SendSimpleMessage(SimpleMailModel model)
        {
            var template = GetTemplate("SimpleMail.aspx");
            string text = template.Apply(model);

            SendNotification(model.ToUser.FullName, model.ToUser.email, model.Subject, text);
        }

        public void SendMessageToModerators(SimpleMailModel model)
        {
            IEnumerable<AccountViewModel> moderators = Meridian.Default.GetModerators();
            foreach (var moder in moderators)
            {
                if (Meridian.Default.accountsStore.Exists(moder.Id))
                {
                    model.ToUser = Meridian.Default.accountsStore.Get(moder.Id);
                    SendSimpleMessage(model);
                }
            }
        }

        private void SendMessageToModerators(string subject, string text)
        {
            IEnumerable<AccountViewModel> moderators = Meridian.Default.GetModerators();
            foreach (var moder in moderators)
            {
                if (Meridian.Default.accountsStore.Exists(moder.Id))
                {
                    string nameTo = string.Format("{0} {1}", moder.FirstName, moder.LastName);
                    SendNotification(nameTo, moder.Email, subject, text);
                }
            }
        }

        public void SendMessageMaterialComplaint(MaterialComplaintMailModel model)
        {
            var template = GetTemplate("ComplainMail.aspx");
            string text = template.Apply(model);

            SendMessageToModerators("Жалоба на материал", text);
        }

        public void SendInvitationMail(InvitationSendMailModel model)
        {
            var template = GetTemplate("InvitationMail.aspx");
            string text = template.Apply(model);

            var ownerResume = model.Resume.GetResumesAccount();
            var email = model.Resume.email ?? ownerResume.email;

            SendNotification(ownerResume.ShortName, email, "Предложение работы", text);
        }

        public void SendAdvertRequestEmailMail(AdvertRequestModel model)
        {
            var template = GetTemplate("AdvertRequestEmail.aspx");
            var text = template.Apply(model);
            SendMessageToModerators("Запрос по объявлению", text);
        }

        public void SendMessageNoResume(NoResumeMailModel model)
        {
            var template = GetTemplate("NoResumeMail.aspx");
            string text = template.Apply(model);

            SendNotification(model.User.ShortName, model.Vacancy.GetVacanciesAccount().email, model.Theme, text);
        }

        public void SendMessageResume(ResumeSendModel model)
        {
            var template = GetTemplate("ResumeSendMail.aspx");
            string text = template.Apply(model);

            SendNotification(model.User.ShortName, model.Vacancy.GetVacanciesAccount().email, "Отклик на вакансию", text);
        }

        public void SendMessageResumeForCompany(ResumeSendForCompanyModel model)
        {
            var template = GetTemplate("ResumeSendForCompanyMail.aspx");
            string text = template.Apply(model);

            SendNotification(model.User.ShortName, model.Company.email, "Резюме кандидата", text);
        }

        private void SendNotification(string name, string email, string subject, string text)
        {
            subject += "//уведомление от SMOLTODAY.RU";
            var notification = new Notification(Footboy.Shared.Constants.EmailNotificationType,
                FromAddress, new EmailAddress(name, email), text, subject);

            INotificationSender sender = ServiceLocator.Instance.Locate<INotificationSender>();
            sender.Send(notification);
        }

        private ITemplate GetTemplate(string templateName)
        { 
            ITemplateProvider templateProvider = ServiceLocator.Instance.Locate<ITemplateProvider>();

            return templateProvider.GetTemplate(templateName, this.controller.ControllerContext);
        }

        
    }
}