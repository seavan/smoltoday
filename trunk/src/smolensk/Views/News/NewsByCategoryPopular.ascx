<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>
<%  foreach (var item in Model.Items)
    { %>
<span class="popular_news">
    <a href="<%= item.GetItemUri() %>" title="<%= item.Title %>">
        <%if (item.HasPicture && !item.Pictures.First().SmallThumbnail.GetImageUri().ToString().Contains("emptyImage.gif")) {%>
        <img src="<%= item.Pictures.First().SmallThumbnail.GetImageUri() %>" width="48" height="48" alt="<%= item.Pictures.First().Alt %>" />
        <%}%>
        <table><tr><td><%= item.Title %></td></tr></table>
    </a>
</span>
<%   } %>