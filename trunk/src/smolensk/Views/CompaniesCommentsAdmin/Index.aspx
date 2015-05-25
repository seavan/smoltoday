<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminCompanies.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content runat="server" ContentPlaceHolderID="AdminTitle"> // Комментарии</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("CompaniesCommentsGrid", ViewData) %>
</asp:Content>
