<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminSales.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.sales>" ValidateRequest="false" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Создание/Редактирование</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
    <div class="_controlRow" style="margin-bottom: 12px">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/SalesAdmin/Index">К списку скидок</a></div>
    </div>
    <%= Html.EditorForModel() %>
    <div class="_controlRow">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/SalesAdmin/Index">К списку скидок</a></div>
    </div>
    <% } %>
</asp:Content>
