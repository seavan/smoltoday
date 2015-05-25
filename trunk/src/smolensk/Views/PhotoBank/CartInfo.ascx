<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.CartViewModel>" %>

<a href="<%: Url.Action("Cart","PhotoBank") %>" title="Корзина">Корзина <span><%=Model.Items.Count %> фото</span></a>
<span class="moreInfo">
    <a href="<%: Url.Action("Cart","PhotoBank") %>" title="Корзина">Корзина <span><%=Model.Items.Count %> фото</span></a>
    <span class="price">
        <span>Итого: <b><%=Model.Total %></b> руб.</span>
        <% if (Model.Items.Any())
           { %>
            <span class="button cart-order">Оформить заказ</span>
        <% } %>
    </span>
</span>