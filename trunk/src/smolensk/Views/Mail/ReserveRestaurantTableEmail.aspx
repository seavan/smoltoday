<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<ReserveTableViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<h2>Заказ столика</h2>
<p>
Заведение: <a href="http://smoltoday.ru<%= Url.Action("One", "Restaurants", new { id = Model.RestaurantId }) %>"><%= Model.RestaurantTitle %></a>
</p>

<p>
Дата: <%= Model.Date.ToLongDateString() %><br />
Кол-во персон: <%= Model.Persons %><br />
Телефон: <%= Model.Phone %><br />
Контактное лицо: <%= Model.ContactName %><br />
</p>
</asp:Content>
