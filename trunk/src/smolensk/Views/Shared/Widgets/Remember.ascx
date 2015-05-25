<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.CodeModels.Security.RegainModel>" %>

<%@ Import Namespace="smolensk.common.Captcha" %>

<% if (Model == null || (Model != null && !Model.repeatActivation)) {%>
<div class="enterForm remember _closest">
    <% if (Model == null || (Model != null && !Model.Success)) {%>
    <p>Восстановление пароля</p>
    <small>Если вы забыли пароль, воспользуйтесь формой ниже.</small>

    <form action="#" class="ajaxForm" data-action="<%: Url.Action("RememberPassword", "Security")%>" data-target=".enterForm.remember" >
        
        <div class="field">
            <%= Html.LabelFor(m => m.EMailRem, new { @class = "_autohide" })%>
            <%= Html.TextBoxFor(m => m.EMailRem)%>
            <%= Html.ValidationMessageFor(m => m.EMailRem)%>
        </div>
        <div class="captcha"><%= Html.CaptchaImage(96, 330, 5, "/Security/ImageCaptcha")%></div>
        <div class="field">
            <%= Html.LabelFor(m => m.Captcha, new { @class = "_autohide" })%>
            <%= Html.TextBoxFor(m => m.Captcha, new {@class = "_autoclear"})%>
            <%= Html.ValidationMessageFor(m => m.Captcha)%>
        </div>
        <span class="button">Продолжить</span>
        <%: Html.HiddenFor(m=>m.repeatActivation) %>
    </form>
    <% } else if(Model != null && Model.Success){%>
        <p>Восстановление пароля</p>
        <small>На указанный вами электронный адрес были высланы инструкции для дальнейшего действия.</small>
    <% }%>
</div>
<% }%>

<%if(Model == null || (Model != null && Model.repeatActivation)) {%>
<div class="enterForm repeat _closest">
    <%if(Model == null || (Model != null && !Model.Success)) {%>
    <p>Повторная активация</p>
    <small>Для получения кода активации воспользуйтесь формой ниже.</small>

    <form action="#" class="ajaxForm" data-action="<%: Url.Action("RepeatActivation", "Security")%>" data-target=".enterForm.repeat" >
        
        <div class="field">
            <%= Html.LabelFor(m => m.EMailRem, new { @class = "_autohide" })%>
            <%= Html.TextBoxFor(m => m.EMailRem)%>
            <%= Html.ValidationMessageFor(m => m.EMailRem)%>
        </div>
        <div class="captcha"><%= Html.CaptchaImage(96, 330, 5, "/Security/ImageCaptcha")%></div>
        <div class="field">
            <%= Html.LabelFor(m => m.Captcha, new { @class = "_autohide" })%>
            <%= Html.TextBoxFor(m => m.Captcha, new {@class = "_autoclear"})%>
            <%= Html.ValidationMessageFor(m => m.Captcha)%>
        </div>
        <span class="button">Продолжить</span>
        <%: Html.HiddenFor(m=>m.repeatActivation) %>
    </form>
    <% } else if(Model != null && Model.Success){%>
        <p>Повторная активация</p>
        <small>На указанный вами адрес электронной почты отправлена ссылка, перейдя по которой вы сможете активировать свою страницу.</small>
    <% }%>

</div>
<% }%>