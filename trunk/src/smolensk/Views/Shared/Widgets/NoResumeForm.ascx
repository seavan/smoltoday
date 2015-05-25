<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.NoResumeMailModel>" %>

<div id="vacancy_no_resume_form" class="enterForm no_resume _closest">
    <p>Откликнуться на вакансию без резюме</p>
    <small><b>Вакансия:</b> <%: Model.Vacancy.title %></small><br/>
    <small><b>Компания:</b> <%: Model.CompanyTitle %></small>
    <%using (Html.BeginForm("SendNoResumeMail", "Vacancy", FormMethod.Post))
      { %>
      <%= Html.HiddenFor(m => m.Vacancy.id) %>
        <%= Html.ValidationMessageFor(m => m.Theme, string.Empty, new {@class = "validatorMessage"}) %>
        <div class="field">   
            <label for="Theme" class="_autohide">Тема</label>   
            <%= Html.TextBoxFor(m => m.Theme) %>
        </div>
        <%= Html.ValidationMessageFor(m => m.Message, string.Empty, new {@class = "validatorMessage"}) %>
        <div class="field">
            <label for="Message" class="_autohide">Сообщение</label>  
            <%= Html.TextAreaFor(m => m.Message) %>
        </div>
        <span class="button" onclick="$(this).closest('form').submit();">Откликнуться</span>
    <% } %>
</div>
