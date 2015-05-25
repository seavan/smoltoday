<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminMain.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle"> // Регионы и города</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="topToolbar">
            <a class="_link" href="/RegionCityAdmin/Single">Создать</a></div>
    <%=
        Html.Partial("RegionCityAdminGrid", ViewData)%>

</asp:Content>
