<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AdsListViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<% if (Model.Advertisments.Any()) 
   {
       foreach (var ad in Model.Advertisments) { %>
<div class="oneAdvert <%=ad.pin_to_list ? "fav" : string.Empty %>">
    <div class="date">
        <%= (ad.created_date.Date == DateTime.Today.Date) ? "Сегодня" : ad.created_date.ToString("dd.MM.yy") %><br/>
        <%= Formatter.FormatTime(ad.created_date) %>
    </div>
    <div class="img">
        <a href="<%: ad.ItemUri() %>" title="<%= ad.title %>">
            <img src="<%= ad.PreviewPhotoUrl %>" width="100" height="65" alt="<%= ad.title %>" />
        </a>
    </div>
    <div class="info">
        <p>
            <a href="<%: ad.ItemUri() %>" title="<%= ad.title %>">
                <%= ad.title %>
            </a>
        </p>
        <p class="category">
            <%= ad.GetAdvertismentsAd_categorie().title %>
        </p>
    </div>
    <div class="price">
        <% if (ad.price > 0)
           { %>
            <strong><%= Formatter.FormatPrice(ad.price) %><span> руб.</span></strong>
        <% } %>
    </div>
</div>
<% } %>
<% } else { %>
<div>
    Нет объявлений по заданным критериям
</div>
<% } %>

<div class="blockLine">
    <% Html.RenderPartial("Widgets/Pager", new { pageN = Model.CurrentPage, pageTotal = Model.TotalPages }); %>
</div>