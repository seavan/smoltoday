﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminRestaurants.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle"> // События</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
<a class="_link" href="/RestaurantsEventsAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("RestaurantsEventsGrid", ViewData) %>

</asp:Content>