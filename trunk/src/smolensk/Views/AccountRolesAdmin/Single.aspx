<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminAccounts.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.account_roles>" ValidateRequest="false" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Роли // Создание/Редактирование</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {
    %>
    <div class="_controlRow" style="margin-bottom: 12px">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/AccountRolesAdmin/Index">К списку</a></div>
    </div>
    <%= Html.EditorForModel()%>
    <div class="_controlRow">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/AccountRolesAdmin/Index">К списку</a></div>
    </div>
    <%
   } %>
</asp:Content>
