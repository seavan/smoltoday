<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.SingleNewsViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<dl>
	<dt>
		<a href="<%: Model.GetItemUri() %>" title="<%: Model.Title %>">
            <% if (Model.HasPicture) {
                   var image = Model.Pictures.First();
            %>
                <img src="<%: image.LargeThumbnail.GetImageUri() %>" width="200" height="130" alt="<%: image.Alt %>" />
            <% } %>
            <%: Model.Title %>
            <%--<span>play</span>--%>
		</a>
	</dt>
	<dd>
		<span class="data"><%= Model.Announce%></span>

		<span class="info">
			<% Html.RenderPartial("Widgets/Rating", Model.baseEntity); %>
			<span class="time"><%= Model.FormatRecentPublishDate()%></span>
			<a href="<%: Model.GetCommentsUri() %>"><span class="comments"><%= Model.CommentsCount %></span></a>
		</span>
	</dd>
</dl>
