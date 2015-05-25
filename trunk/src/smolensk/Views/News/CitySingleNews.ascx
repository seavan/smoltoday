<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.SingleNewsViewModel>" %>
<%@ Import Namespace="smolensk.ViewModels" %>
<dd>
	<span class="data">
		<a href="<%= Model.GetItemUri().ToString() %>" title="">
        <% if (Model.HasPicture && !Model.Pictures.First().SmallThumbnail.GetImageUri().ToString().Contains("emptyImage.gif")) { %>
		<img src="<%= Model.Pictures.First().SmallThumbnail.GetImageUri() %>" width="79" height="80" alt="<%: Model.Pictures.First().Alt %>" />
        <% } %>
		<%= Model.Title %></a>
		<br/><br/>
		<%= Model.Announce %>
	</span>

	<span class="info">
		<span class="time"><%= Model.FormatRecentPublishDate()%></span>

        <% Html.RenderPartial("Widgets/Rating", Model.baseEntity); %>
		<span class="comments"><a href="<%: Model.GetCommentsUri() %>"><%= Model.CommentsCount %></a></span>
		<span class="views"><%= Model.ViewsCount %></span>
	</span>
</dd>