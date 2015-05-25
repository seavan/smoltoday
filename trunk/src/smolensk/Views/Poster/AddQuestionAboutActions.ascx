﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.SimpleMailModel>" %>
<% Model.Subject = "Вопрос по мероприятиям";%>

<div class="enterForm add_question _closest">
    <p>Задать вопрос по мероприятиям</p>
    <%using (Html.BeginForm("SendMail", "Poster", FormMethod.Post))
      { %>
        <%= Html.HiddenFor(m => m.Subject) %>
        <%= Html.ValidationMessageFor(m => m.Title, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">   
            <label for="Title" class="_autohide">Тема</label>   
            <%= Html.TextBoxFor(m=>m.Title) %>
        </div>
        <%= Html.ValidationMessageFor(m => m.Message, string.Empty, new { @class = "validatorMessage" })%>
        <div class="field">
            <label for="Message" class="_autohide">Вопрос</label>  
            <%= Html.TextAreaFor(m=>m.Message) %>
        </div>
        <span class="button">Задать</span>
    <% } %>
</div>