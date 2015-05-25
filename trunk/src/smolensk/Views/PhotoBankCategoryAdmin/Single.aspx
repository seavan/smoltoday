<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminPhotobank.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.photobank_categories>" ValidateRequest="false" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Категории // Создание/Редактирование</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {
    %>
    <div class="_controlRow" style="margin-bottom: 12px">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/PhotoBankCategoryAdmin">К списку категорий</a></div>


    </div>
    <%= Html.EditorForModel()%>
    <div class="_controlRow">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/PhotoBankCategoryAdmin">К списку категорий</a></div>
    </div>
    <%
   } %>
</asp:Content>
