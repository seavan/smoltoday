<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/AdminPoster.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.actions>" ValidateRequest="false" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="AdminTitle">// Создание/Редактирование</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {
    %>
    <div class="_controlRow" style="margin-bottom: 12px">
        <%--<input type="submit" value="Сохранить" />--%>
        <input type="button" value="Сохранить" onclick="$('form').submit();" class="ui-button ui-widget ui-state-default ui-corner-all" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/PosterAdmin/Index">К списку</a></div>


    </div>
    <%= Html.EditorForModel()%>
    <div class="_controlRow">
        <%--<input type="submit" value="Сохранить" />--%>
        <input type="button" value="Сохранить" onclick="$('form').submit();" class="ui-button ui-widget ui-state-default ui-corner-all" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/PosterAdmin/Index">К списку</a></div>
    </div>
    
    <%
   } %>
</asp:Content>
