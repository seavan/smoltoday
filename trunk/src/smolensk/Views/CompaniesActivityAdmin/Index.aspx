﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminCompanies.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Сферы деятельности</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.Partial("CompaniesActivityGrid", ViewData)%>

</asp:Content>
