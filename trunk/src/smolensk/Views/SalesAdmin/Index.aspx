<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminSales.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
            <a class="_link" href="/SalesCategoryAdmin">Справочник категорий</a><a class="_link" href="/SalesAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("SalesGrid", ViewData) %>

</asp:Content>
