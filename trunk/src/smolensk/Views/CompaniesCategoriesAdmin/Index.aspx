﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminCompanies.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Категории</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=
     Html.Partial("CompaniesCategoriesGrid", ViewData) %>

</asp:Content>
