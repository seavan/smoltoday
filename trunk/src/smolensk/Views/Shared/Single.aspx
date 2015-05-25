<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" ValidateRequest="false"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm())
   {
       %>
       <%= Html.EditorForModel()       %>
       <div class="_controlRow">
       <%= Html.ActionLink("К списку", "Index", new { }, new { @class = "_link" })%>

       <input type="submit" value="Сохранить" />
       </div>
       <%
   } %>
</asp:Content>
