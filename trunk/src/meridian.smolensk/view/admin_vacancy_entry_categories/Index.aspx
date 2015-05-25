
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/admin_vacancy_entry_categories/Single">Создать</a></div>
    <%=
        Html.Partial("vacancy_entry_categories_grid", ViewData) %>

</asp:Content>
