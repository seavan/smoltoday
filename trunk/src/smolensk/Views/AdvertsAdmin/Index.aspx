<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminAdverts.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
            <a class="_link" href="/AdvertsCategoryAdmin">Справочник категорий</a><a class="_link" href="/AdvertsAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("AdvertsGrid", ViewData) %>

</asp:Content>
