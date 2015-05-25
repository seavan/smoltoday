<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminSales.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content runat="server" ContentPlaceHolderID="AdminTitle"> // Комментарии</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("SalesCommentsGrid", ViewData) %>
</asp:Content>
