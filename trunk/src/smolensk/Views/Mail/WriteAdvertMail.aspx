<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.AdvMailModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<h2><%: Model.Theme %></h2>
<p>
<%: Model.Message %>
</p>
</asp:Content>
