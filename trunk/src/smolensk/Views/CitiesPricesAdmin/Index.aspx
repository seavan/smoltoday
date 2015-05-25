<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminMain.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content runat="server" ContentPlaceHolderID="AdminTitle"> // Цены в городе</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("CitiesPricesGrid", ViewData) %>
</asp:Content>
