﻿
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.city_prices_icons>"
    ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {
    %>
    <div class="_controlRow" style="margin-bottom: 12px">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/admin_city_prices_icons/Index">К списку</a></div>


    </div>
    <%= Html.EditorForModel()%>
    <div class="_controlRow">
        <input type="submit" value="Сохранить" />
        <div style="text-align: right; float: left">
            <a class="_link" href="/admin_city_prices_icons/Index">К списку</a></div>
    </div>
    <%
   } %>
</asp:Content>

