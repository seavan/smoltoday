<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.MaterialComplaintMailModel>" %>

<div class="enterForm no_resume complain _closest">
    <p>Пожаловаться</p>
    <%using (Html.BeginForm("Complain", "Utility", FormMethod.Post))
      { %>
        <% Model.MaterialLink = Request.Url.AbsoluteUri;%>
        <%= Html.HiddenFor(m => m.MaterialLink)%>
        <%= Html.ValidationMessageFor(m => m.Message, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">
            <label for="Message" class="_autohide">Сообщение</label>  
            <%= Html.TextAreaFor(m=>m.Message) %>
        </div>
        <span class="button">Отправить</span>
    <% } %>
</div>
