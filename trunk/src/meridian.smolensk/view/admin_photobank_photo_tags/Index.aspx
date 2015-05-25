
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" UICulture="ru-RU" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div style="text-align: right; float: right">
            <a class="_link" href="/admin_photobank_photo_tags/Single">Создать</a></div>
    <%=
        Html.Partial("photobank_photo_tags_grid", ViewData) %>

</asp:Content>
