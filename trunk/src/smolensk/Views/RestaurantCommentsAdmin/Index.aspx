<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminRestaurants.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content runat="server" ContentPlaceHolderID="AdminTitle"> // Комментарии</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("RestaurantCommentsGrid", ViewData) %>
</asp:Content>
