﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminPhotobank.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Лицензии </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/PhotoBankLicenseAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("PhotoBankLicenseAdminGrid", ViewData)%>

</asp:Content>
