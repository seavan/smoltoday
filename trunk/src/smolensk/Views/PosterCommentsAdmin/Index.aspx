<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminPoster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content runat="server" ContentPlaceHolderID="AdminTitle"> // Комментарии</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=
        Html.Partial("PosterCommentsGrid", ViewData) %>
</asp:Content>
