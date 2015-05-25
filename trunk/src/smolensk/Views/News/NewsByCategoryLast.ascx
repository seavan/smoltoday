<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>
<%  foreach (var item in Model.Items) { %>
<dl>
	<dt>
		<a href="<%= item.GetItemUri() %>" title="<%= item.Title %>">
			<img src="<%= item.Pictures.First().MediumThumbnail.GetImageUri() %>" width="200" height="130" alt="<%= item.Pictures.First().Alt %>" />
			<%= item.Title %>
			<%--<span>play</span>--%>
		</a>
	</dt>
	<dd>
		<span class="data"><%= item.Announce %></span>

		<span class="info">
			<!--span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span-->
            <% Html.RenderPartial("Widgets/Rating", item.baseEntity); %>
			<span class="time"><%= item.FormatRecentPublishDate() %></span>
			<a href="<%: item.GetCommentsUri() %>"><span class="comments"><%= item.CommentsCount %></span></a>
		</span>
	</dd>
</dl>
<% } %>