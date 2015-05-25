<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminPhotobank.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Категории </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/PhotoBankCategoryAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("PhotoCategoriesGrid", ViewData) %>

</asp:Content>
