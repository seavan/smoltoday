<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.SingleNewsViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<dl>
	<dt>
		<a href="<%: Model.GetItemUri() %>" title="<%: Model.Title %>">
            <% if (Model.HasPicture) { %>
			<img src="<%= Model.Pictures.First().LargeThumbnail.GetImageUri() %>" width="141" height="94" alt="<%: Model.Pictures.First().Alt %>" />
            <% } %>
			<%= Model.Title %>
			<%--<span>play</span>--%>
		</a>
	</dt>
	<dd>
		<span class="data"><%= Model.Announce %></span>
		<span class="info">
			<span class="time"><%= Model.FormatRecentPublishDate()%></span>
			<a href="<%: Model.GetCommentsUri() %>"><span class="comments"><%= Model.CommentsCount %></span></a>
		</span>
	</dd>
</dl>
