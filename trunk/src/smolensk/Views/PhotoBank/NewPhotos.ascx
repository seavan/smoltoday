<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<meridian.smolensk.proto.photobank_photos>>" %>

<h3>Новинки фотобанка</h3>
<div class="photoNews">
    <% foreach (var photo in Model) { %>
        <a href="<%: photo.ItemUri() %>" title="<%= photo.title %>">
            <img src="<%= photo.PreviewSquareUrl %>" width="108" height="108" alt="<%= photo.title %>" />
        </a>
    <% } %>
</div>
<div class="randomPhoto">
    <div id="randomPhotos">
        <% 
            //TODO: использовать какие-то другие фотографии для ротации?
            foreach (var photo in Model) { %>
            <a href="<%: photo.ItemUri() %>" title="<%= photo.title %>">
                <img src="<%= photo.PreviewUrl %>" width="200" height="130" alt="<%= photo.title %>" />
            </a>
        <% } %>
    </div>
    <a href="<%: Url.Action("Last","PhotoBank") %>" title="Все новинки">Все новинки <span>&rarr;</span></a>
</div>