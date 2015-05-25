<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminMain.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.main_page_widgets>" ValidateRequest="false" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Информеры</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {
    %>
    <div class="_controlRow" style="margin-bottom: 12px">
        <input type="submit" value="Сохранить" />
    </div>
    <%= Html.EditorForModel()%>
    <div class="_controlRow">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/NewsAdmin/Index">К списку статей</a></div>
    </div>
    <%
   } %>
</asp:Content>
