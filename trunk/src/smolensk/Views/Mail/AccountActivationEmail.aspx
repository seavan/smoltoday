<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<SendLinkModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Mail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<p>Поздравляем, вы зарегистрировались на сайте <a href='http://smoltoday.ru'>SmolToday.RU</a>!</p>
<p>Чтобы закончить регистрацию, Вам необходимо пройти по <a href='<%= Model.Link %>'>активационной ссылке</a></p>
<br/><br/>
<hr/>С уважением, редакция портала SmolToday.ru
</asp:Content>
