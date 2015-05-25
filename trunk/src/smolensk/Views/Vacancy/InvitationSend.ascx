<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.InvitationSendMailModel>" %>

<div class="enterForm no_resume invitation _closest">
    <p>Пригласить</p>
    <%using (Html.BeginForm("InvitationSend", "Vacancy", FormMethod.Post))
      { %>
        <%= Html.HiddenFor(m => m.ResumeId) %>
        <%= Html.ValidationMessageFor(m => m.Message, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">
            <label for="Message" class="_autohide">Сообщение</label>  
            <%= Html.TextAreaFor(m=>m.Message) %>
        </div>
        <span class="button">Отправить</span>
    <% } %>
</div>
