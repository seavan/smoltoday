<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminBlogs.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/BlogsAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("BlogsGrid", ViewData) %>

</asp:Content>
