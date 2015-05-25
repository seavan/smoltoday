<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<MaterialComplaintMailModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Mail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<p>Пользователь <%=Model.User.FullName %> ( <%=Model.User.email %> ) пожаловался на <a href='<%= Model.MaterialLink %>'>материал</a>:</p>
<br/>
<p><%= Model.Message %></p>
</asp:Content>
