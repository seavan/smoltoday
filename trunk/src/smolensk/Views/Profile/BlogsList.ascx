<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Blogs.BlogsListViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Blogs" %>
<%@ Import Namespace="smolensk.common" %>

<div class="blogsList">
    
    
    <h3>Записи в блоге «<%: Html.UserPrincipal().ShortName %>»</h3>

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
            
            <img src="<%: blog.GetThumbnailImage() %>" width="200" height="365" alt="" />
                                    
            <span class="shadow"></span>
            
            <div class="blogTools">
                <span class="edit" title="Редактировать" data-url="<%:Url.Action("BlogEdit", new{id = blog.id})%>"></span>
                <span class="delete" title="Удалить" data-url="<%:Url.Action("BlogDelete", new{id = blog.id})%>"></span>
            </div>
                                    
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
	<%: Html.Pager(Model.CurrentPage, Model.TotalPages, "ProfileBlogsList", null, "page")%>
</div>
<%}%>