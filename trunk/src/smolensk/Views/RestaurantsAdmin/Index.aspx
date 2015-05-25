<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminRestaurants.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
            <a class="_link" href="/RestaurantsCategoryAdmin">Справочник категорий</a><a class="_link" href="/RestaurantsAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("RestaurantsGrid", ViewData) %>

</asp:Content>
