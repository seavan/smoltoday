<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>

<%if(Model!=null && Model.Items.Count() > 0){%>

<div class="photoVideoBlock mainNews">
<%
	var firstNews = Model.Items.First();
%>
    <div class="photo">
        <span>
            <a href="<%: firstNews.GetItemUri() %>" title="<%= firstNews.Title %>">
                <img src="<%= firstNews.Pictures.First().LargeThumbnail.GetImageUri() %>"
                        width="463" height="296" alt="<%= firstNews.Pictures.First().Description %>" />
            </a>
            <span class="titleNews">
                <span class="overlay"></span>
                <a href="<%= firstNews.GetItemUri() %>"
                   title="<%= firstNews.Title %>"><%= firstNews.Title%></a>
            </span>
        </span>
        <span>
<%  int itemIndex = 1;
    foreach (var item in Model.Items) {
        %>
            <span class="photoNews<% if (itemIndex == 1) { %> cur<% } %>">
                <span class="datetime"><%= item.FormatFullPublishDate() %></span>
                <span class="data"><a href="<%: item.GetItemUri() %>"><%= item.Title %></a></span>
                <a href="<%: item.GetCommentsUri() %>"><span class="comments"><%= item.CommentsCount %></span></a>
            </span>
        <% 
        itemIndex++; 
    } %>
        </span>
    </div>
</div>
<script type="text/javascript">
    smolenskGlobal.mainNewsPics = [<% foreach (var item in Model.Items) { %>"<%= item.Pictures.First().LargeThumbnail.GetImageUri() %>", <% } %>];
    smolenskGlobal.mainNewsTitles = [<% foreach (var item in Model.Items) { %>"<%= item.Title %>", <% } %>];
    smolenskGlobal.mainNewsUrls = [<% foreach (var item in Model.Items) { %>"<%= item.GetItemUri() %>", <% } %>];
</script>
<script type="text/javascript" src="/content/js/mainnews.js"></script>
<%} %>