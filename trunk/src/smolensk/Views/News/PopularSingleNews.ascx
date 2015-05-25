<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.SingleNewsViewModel>" %>
<span class="popular_news">
    <a href="<%: Model.GetItemUri() %>" title="<%= Model.Title %>">
        <% if (Model.HasPicture &&  !Model.Pictures.First().SmallThumbnail.GetImageUri().ToString().Contains("emptyImage.gif")) { %>
        <img src="<%: Model.Pictures.First().SmallThumbnail.GetImageUri() %>" width="48" height="48" alt="<%: Model.Pictures.First().Alt %>" />
        <% } %>
        <table><tr><td><%= Model.Title %></td></tr></table>
    </a>
</span>
