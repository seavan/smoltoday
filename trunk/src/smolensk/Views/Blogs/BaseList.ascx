<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Blogs.BlogsListViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Blogs" %>
<%@ Import Namespace="smolensk.common" %>

<div class="blogsList">
    
    
    <h3 class="<%: Model.ListType == BlogListType.Main ? "line" : "" %>"><%: Model.Category != null && Model.ListType == BlogListType.Category ? Model.Category.title : Model.ListType.GetDescription() %></h3>

    <div class="sortingTools<%: Model.ListType == BlogListType.Main ? " line" : "" %>">								
		<ul>
		    <% if(Model.ListType == BlogListType.Main){%>
            <li><a href="<%: Url.Action("Index", new {dateFilter = DateFilterTypes.ToDay}) %>" title="сегодня" class="<%: Model.dateFilter == DateFilterTypes.ToDay ? "cur" : ""%>"><span>сегодня</span></a></li>
			<li><a href="<%: Url.Action("Index", new {dateFilter = DateFilterTypes.Yesterday}) %>" title="вчера" class="<%: Model.dateFilter == DateFilterTypes.Yesterday ? "cur" : ""%>"><span>вчера</span></a></li>
			<li><a href="<%: Url.Action("Index", new {dateFilter = DateFilterTypes.InWeek}) %>" title="неделя" class="<%: Model.dateFilter == DateFilterTypes.InWeek ? "cur" : ""%>"><span>неделя</span></a></li>
            
            <%} else {%>
            <li><a href="<%: Url.Action(Model.ListType == BlogListType.Category ? "List" : "Author", new {sortingType = SortingType.Rating, categoryId = Model.Category != null ? Model.Category.id : (long?)null, authorId = Model.authorId}) %>" title="Популярные" class="<%: Model.sortingType == SortingType.Rating ? "cur" : ""%>"><span>Популярные</span></a></li>
			<li><a href="<%: Url.Action(Model.ListType == BlogListType.Category ? "List" : "Author", new {sortingType = SortingType.Novelty, categoryId = Model.Category != null ? Model.Category.id : (long?)null, authorId = Model.authorId}) %>" title="Новые" class="<%: Model.sortingType == SortingType.Novelty ? "cur" : ""%>"><span>Новые</span></a></li>
            <%}%>
		</ul>									
	</div>
   

    <% if(Model.Blogs != null) {%>
    <div class="list">
        <%
            int limiter = 0;
            foreach(var blog in Model.Blogs)
            {
                if(limiter > 2)
                {
                    limiter = 0;
                    %></div><div class="list"><%
                }
        %>
        <div class="blogAdvt">
            <%--<img src="/content/images/blogs_1.jpg" width="200" height="365" alt="" />--%>
            <img src="<%: blog.GetThumbnailImage() %>" width="200" height="365" alt="" />
                                    
            <span class="shadow"></span>
                                    
            <div class="descr">
                <span class="tag"><a href="<%: blog.GetCategoryUri() %>" title="<%: blog.CategoryName() %>"><%: blog.CategoryName() %></a></span>
                <p><a href="<%: blog.ItemUri() %>" title="<%= blog.title %>"><%= blog.title %></a></p>
                <p><%= blog.ListAnnounce() %></p>
            </div>
                                    
            <div class="info">
                <span class="overlay"></span>
                                        
                <div>
                    <a href="<%: blog.GetAuthorUri() %>" title="<%: blog.UserName() %>" class="name"><%: blog.UserName() %></a>
                    <% Html.RenderPartial("Widgets/Rating", blog); %>
                </div>
                <div><span class="date"><%: blog.PublishDate()%></span><span class="comments"><%: blog.comment_count%></span></div>
            </div>
                                    
        </div>     
        <% ++limiter;%>
        <% } %>
    </div>
    <%}%>

</div>

<%if(Model.ListType == BlogListType.Author || Model.ListType == BlogListType.Category) {%>
<div class="clear"></div>
<div class="blockLine">
	<%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.ListType == BlogListType.Category ? "BlogsList" : "BlogsAuthorList", new { sortingType = Model.sortingType, categoryId = Model.Category != null ? Model.Category.id : (long?)null, authorId = Model.authorId }, "page")%>
</div>
<%}%>