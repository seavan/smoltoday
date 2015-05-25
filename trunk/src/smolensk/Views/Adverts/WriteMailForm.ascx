<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.AdvMailModel>" %>

<div class="enterForm no_resume write_mail _closest">
    <p>Написать письмо</p>
    <%using (Html.BeginForm("WriteMail", "Adverts", FormMethod.Post))
      { %>
        <%= Html.HiddenFor(m => m.AdvId) %>
        <%= Html.ValidationMessageFor(m => m.Theme, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">   
            <label for="Theme" class="_autohide">Тема</label>   
            <%= Html.TextBoxFor(m=>m.Theme) %>
        </div>
        <%= Html.ValidationMessageFor(m => m.Message, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">
            <label for="Message" class="_autohide">Сообщение</label>  
            <%= Html.TextAreaFor(m=>m.Message) %>
        </div>
        <span class="button">Написать</span>
    <% } %>
</div>
