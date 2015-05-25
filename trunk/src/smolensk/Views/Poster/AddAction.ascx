<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.SimpleMailModel>" %>
<% Model.Subject = "Добавить мероприятие";%>

<div class="enterForm add_action _closest">
    <p>Добавить мероприятие</p>
    <%using (Html.BeginForm("SendMail", "Poster", FormMethod.Post))
      { %>
        <%= Html.HiddenFor(m => m.Subject) %>
        <%= Html.ValidationMessageFor(m => m.Title, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">   
            <label for="Title" class="_autohide">Название мероприятия</label>   
            <%= Html.TextBoxFor(m=>m.Title) %>
        </div>
        <%= Html.ValidationMessageFor(m => m.Message, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">
            <label for="Message" class="_autohide">Описание</label>  
            <%= Html.TextAreaFor(m=>m.Message) %>
        </div>
        <span class="button">Отправить на модерацию</span>
    <% } %>
</div>