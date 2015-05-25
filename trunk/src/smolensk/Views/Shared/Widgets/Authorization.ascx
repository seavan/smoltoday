<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.CodeModels.Security.UserAuthenticationModel>" %>

<div class="enterForm auth _closest">
    
    <p>Войти по логину “SMOLTODAY.ru”</p>
    <small>Еще нет логина на “SMOLTODAY.ru”? <span>Зарегистрируйтесь!</span></small>

    <form action="#" class="ajaxForm" data-action="<%: Url.Action("SignIn", "Security")%>" data-target=".enterForm.auth" >
        
        <div class="field">
            <%= Html.ValidationMessage("AuthenticateError")%>
        </div><br/>

        <div class="field">
            <%= Html.LabelFor(m => m.EMailAuth, new { @class = "_autohide" })%>
            <%= Html.TextBoxFor(m => m.EMailAuth)%>
            <%= Html.ValidationMessageFor(m => m.EMailAuth)%>
        </div>
        <div class="field">
            <%= Html.LabelFor(m => m.Password, new { @class = "_autohide" })%>
            <%= Html.PasswordFor(m => m.Password)%>
            <%= Html.ValidationMessageFor(m => m.Password)%>
            
            <%if(Model == null || Model.isActivate){ %>
            <a href="#" title="Забыли пароль?" class="remember_pass">Забыли пароль?</a>
            <%} else {%>
            <a href="#" title="Повторная активация" class="repeat_code" style="right:-125px;">Повторная активация</a>
            <% } %>
        </div>

        <div class="field">
            <% using (Html.BeginLabelFor(m => m.Remember, null, InsertAt.End, "Запомнить меня")){%>
            <%: Html.CheckBoxFor(m => m.Remember)%>
            <% } %>
        </div>

        <span class="button">Войти</span>

        <%: Html.HiddenFor(m=>m.currentUrlToReturn) %>
    </form>
    
    <script type="text/javascript">
        //if (typeof jQuery == "object" )
        $(function() {
            $('#currentUrlToReturn').val(window.location);
        });
    </script>
</div>
