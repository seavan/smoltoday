<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.CodeModels.Security.ChangePasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

   <div class="blockContent security">
        <div class="widthContent">
            <h2>Изменение пароля</h2>

            <form action="<%: Url.Action("ChangeRegainPassword", "Security")%>" method="post" class="changePasswordForm">
        
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

                <span class="button" onclick="$(this).parent().submit();">Изменить</span>
                    
            </form>
        </div>

        <div class="waveEdge"></div>
    </div>

</asp:Content>
