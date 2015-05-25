<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.CodeModels.Security.UserRegistrationModel>" %>

<%@ Import Namespace="smolensk.common.Captcha" %>

<div class="enterForm registr _closest">
    <%if(Model == null || (Model != null && !Model.Success)) {%>
    <p>Регистрация</p>
    <small>Уже есть логин на “SMOLTODAY.ru”? <span>Войти</span></small>
    
    <form action="#" class="ajaxForm" data-action="<%: Url.Action("Registration", "Security")%>" data-target=".enterForm.registr" >
        <span class="leftBlock">
			<span class="field">
			    <%= Html.LabelFor(m => m.FirstName, new { @class = "_autohide" })%>
                <%= Html.TextBoxFor(m => m.FirstName)%>
                <%= Html.ValidationMessageFor(m => m.FirstName)%>
			</span>
			<span class="field">
				<%= Html.LabelFor(m => m.LastName, new { @class = "_autohide" })%>
                <%= Html.TextBoxFor(m => m.LastName)%>
                <%= Html.ValidationMessageFor(m => m.LastName)%>
			</span>
			<span class="field">
				<%= Html.LabelFor(m => m.EMailReg, new { @class = "_autohide" })%>
                <%= Html.TextBoxFor(m => m.EMailReg)%>
                <%= Html.ValidationMessageFor(m => m.EMailReg)%>
			</span>
			<span class="field">
				<%= Html.LabelFor(m => m.Password, new { @class = "_autohide" })%>
                <%= Html.PasswordFor(m => m.Password)%>
                <%= Html.ValidationMessageFor(m => m.Password)%>
			</span>
			<span class="field">
				<%= Html.LabelFor(m => m.PasswordConfirmation, new { @class = "_autohide" })%>
                <%= Html.PasswordFor(m => m.PasswordConfirmation)%>
                <%= Html.ValidationMessageFor(m => m.PasswordConfirmation)%>
			</span>
		</span>
		<span class="rightBlock">
			<span class="captcha"><%= Html.CaptchaImage(80, 250, 5, "/Security/ImageCaptcha")%></span>
			<span class="field">
			    <% using (Html.BeginLabelFor(m => m.Captcha, null, InsertAt.Begin, "Введите текст: ")){%>
                <%= Html.TextBoxFor(m => m.Captcha, new { @class = "_autoclear" })%>
                <% } %>
                <%= Html.ValidationMessageFor(m => m.Captcha)%>
			</span>
		</span>
        <span class="button">Готово</span>
    </form>
    <% } else if(Model != null && Model.Success){%>
        <p>Регистрация</p>
        <small>Регистрация завершена успешно. На указанный вами адрес электронной почты отправлена ссылка, перейдя по которой вы сможете активировать свою страницу.</small>
    <% }%>
</div>
