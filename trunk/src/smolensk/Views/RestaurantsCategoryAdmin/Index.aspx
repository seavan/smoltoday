<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminRestaurants.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle"> // Категории</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
            <a class="_link" href="/RestaurantsCategoryAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("RestaurantsCategoryGrid", ViewData) %>

</asp:Content>
