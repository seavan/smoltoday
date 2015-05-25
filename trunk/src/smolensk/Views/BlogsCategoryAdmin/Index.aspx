<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminBlogs.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content runat="server" ContentPlaceHolderID="AdminTitle"> // Категории блогов</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="topToolbar">
            <a class="_link" href="/BlogsCategoryAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("BlogsCategoryGrid", ViewData) %>
</asp:Content>
