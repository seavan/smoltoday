<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.CompanyMailModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<p>Пользователь портала <%=Model.User.FullName %> написал вам сообщение:</p>
<h2><%: Model.Theme %></h2>
<p>
<%: Model.Message %>
</p>
</asp:Content>
