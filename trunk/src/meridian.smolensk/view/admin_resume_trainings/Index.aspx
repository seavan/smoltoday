﻿
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/admin_resume_trainings/Single">Создать</a></div>
    <%=
        Html.Partial("resume_trainings_grid", ViewData) %>

</asp:Content>