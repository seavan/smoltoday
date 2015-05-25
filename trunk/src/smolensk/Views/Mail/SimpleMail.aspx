<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.SimpleMailModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<%if (Model.FromUser != null){%>
<p>Сообщение от пользователя <%=Model.FromUser.FullName%> (<%=Model.FromUser.email%>).</p>
<%} %>
<h2><%: Model.Title%></h2>
<p>
<%: Model.Message %>
</p>
</asp:Content>
