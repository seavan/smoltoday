<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.CodeModels.Security.OAuthModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="blockContent security">
        <div class="widthContent">
            <h2>Авторизация - заключительный этап</h2>
            <p class="infoOAuth">Здравствуйте<%= string.IsNullOrEmpty(Model.UserFirstName) ? "" : ", " + Model.UserFirstName%>.</p>
            <p class="infoOAuth">К сожалению, выбранная вами социальная сеть в рамках своей политики безопасности не предоставляет полный набор данных, необходимый нам для того, чтобы авторизовать вас прямо сейчас.</p>
            <p class="infoOAuth">Пожалуйста, укажите свой электронный адрес. Это необходимо сделать всего один раз. В дальнейшем, авторизация через выбранную вами социальную сеть будет происходить без как-либо вопросов с нашей стороны.</p>
            <br/>
            <form action="<%: Url.Action("OAuthSignInForm", "Security")%>" method="post" class="changePasswordForm">
        
                <span class="field">
				    <%= Html.LabelFor(m => m.UserEmail, new { @class = "_autohide" })%>
                    <%= Html.TextBoxFor(m => m.UserEmail)%>
                    <%= Html.ValidationMessageFor(m => m.UserEmail)%>
			    </span>
			    <span class="field">
                   <%: Html.HiddenFor(m => m.ServerAccessToken)%>
                   <%: Html.HiddenFor(m => m.UserFirstName)%>
			    </span>

                <span class="button" onclick="$(this).parent().submit();">Войти</span>
                    
            </form>
        </div>

        <div class="waveEdge"></div>
    </div>

</asp:Content>
