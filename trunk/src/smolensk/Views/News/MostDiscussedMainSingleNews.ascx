<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.SingleNewsViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<dd>
	<span>
		<a href="<%: Model.GetItemUri() %>" title="<%: Model.Title %>">
			<% if (Model.HasPicture) { %>
			<img src="<%= Model.Pictures.First().SmallThumbnail.GetImageUri() %>" width="40" height="40" alt="<%: Model.Pictures.First().Alt %>" />
            <% } %>
			<%= Model.Title %>
		</a>
	</span>
	<span>
		<a href="<%: Model.GetCommentsUri() %>" title="Комментарии"><%= Model.CommentsCount %> комментариев</a>
	</span>
</dd>
