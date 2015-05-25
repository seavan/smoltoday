<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>
<%  int recordPerLine = 3;
    for (var i = 0; i < (Model.Items.Count() + recordPerLine - 1) / recordPerLine; i++)
    { %>
<div class="blockLine">
<%      for (var j = i * recordPerLine; j < Math.Min(i * recordPerLine + recordPerLine, Model.Items.Count()); j++)
        {
            SingleNewsViewModel item = Model.Items.ToList()[j]; %>
	<dl>
		<dt>
			<a href="<%= item.GetItemUri() %>" title="<%= item.Title %>">
			    <%--<%if (item.HasPicture && !item.Pictures.First().MediumThumbnail.GetImageUri().ToString().Contains("emptyImage.gif")) %>--%>
				<img src="<%= item.Pictures.First().MediumThumbnail.GetImageUri() %>" width="200" height="130" alt="<%= item.Pictures.First().Description %>" />
				<%= item.Title %>
				<%--<span>play</span>--%>
			</a>
		</dt>
		<dd>
			<span class="data"><%= item.Announce %></span>

			<span class="info">
				<span class="tag"><a href="<%= item.Category.GetViewCategoryUri() %>" title="<%= item.Category.Title %>" class="<%= item.Category.CssClass %>"><%= item.Category.Title%></a></span>
				<% Html.RenderPartial("Widgets/Rating", item.baseEntity); %>
				<span class="time"><%= item.FormatRecentPublishDate()%></span>
				<a href="<%: item.GetCommentsUri() %>"><span class="comments"><%= item.CommentsCount %></span></a>
			</span>
		</dd>
	</dl>
<%      } %>
</div>
<%  } %>

<%if(!Model.mainNews){%>
<div class='blockLine'>
    <%: Html.Pager(Model.CurrentPage, Model.TotalPages, "NewsList", new { categoryId = Model.Category != null ? Model.Category.Id.ToString() : "!", year = Model.Date.Year, month = Model.Date.Month, day = Model.Date.Day}, "page")%>
</div>
<%} %>
