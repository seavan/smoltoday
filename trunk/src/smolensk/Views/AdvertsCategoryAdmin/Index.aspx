<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminAdverts.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Категории</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
            <a class="_link" href="/AdvertsCategoryAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("AdvertsCategoryGrid", ViewData) %>

</asp:Content>
