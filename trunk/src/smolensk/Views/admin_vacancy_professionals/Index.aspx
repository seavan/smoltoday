﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminVacancy.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle"> // Профессии</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/admin_vacancy_professionals/Single">Создать</a></div>
    <%=
        Html.Partial("vacancy_professionals_grid", ViewData) %>

</asp:Content>
