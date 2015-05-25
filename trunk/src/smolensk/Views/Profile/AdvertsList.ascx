<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AdsListViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>

<%if (Model.Advertisments.Any()) { %>
    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>Название</th>
                <th>Описание</th>
                <th>Цена, руб.</th>
                <% if (!Model.IsFavorite) { %>
                <th></th>
                <% } %>
            </tr>
            <% foreach (var advert in Model.Advertisments) { %>
            <tr>
                <td>
                    <%= advert.title%><br/>
                    <a href="<%: advert.ItemUri() %>" title="Фото"><img src="<%: advert.PhotoUrl %>" width="138" height="96" alt="<%: advert.title %>"/></a>
                </td>
                <td><%= advert.description %></td>
                <td><%= Formatter.FormatPrice(advert.price) %></td>
                <%if (!Model.IsFavorite) { %>
                <td>
                    <a href="<%: Url.Action("EditAdvert", "Profile", new { advert.id }) %>"><span class="edit" title="Редактировать"></span></a>
                    <span class="delete" title="Удалить" data-url="<%: Url.Action("DeleteAdvert", "Profile", new { advert.id }) %>"></span>
                </td>
                <%} %>
            </tr>
            <%} %>
        </table>
    </div>
    <%} %>

    <div class="blockLine">
        <%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.RouteName, new { }, "page")%>
	</div>