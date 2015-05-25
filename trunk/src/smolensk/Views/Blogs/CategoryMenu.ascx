<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.blog_categories>>" %>
<%@ Import Namespace="smolensk.common" %>

<div class="blogsMenu">
    <div class="widthContent">
        <ul>
            <li class="<%: Model.Any(c=>c.IsCur) || !Request.Path.Contains("Blogs/List") ? "" : "cur"%>">
                <%if (Model.Any(c => c.IsCur) || !Request.Path.Contains("Blogs/List")){%>
                <a href="<%: Url.Action("List", new {sortingType = SortingType.Rating, page = 1, categoryId = (long?)null}) %>" title="Обо всём">Обо всём</a>
                <%}else{%>
                <span>Обо всём</span>
                <%} %>
            </li>
            
            <% foreach (var category in Model.Where(c => !c.is_sub).Take(6)) {%>
            <li <%= category.HighlightMenu() %>>
            <%if(category.IsCur){%>
            <span><%: category.title %></span>
            <%}else{%>
            <a href="<%: category.GetCategoryUri() %>" title="<%: category.title %>"><%: category.title %></a>
            <%} %>
            </li>
            <% } %>
            
            <%--<%if (Model.Any(c => c.is_sub)){%>
            <li class="more">
                <span>Ещё</span>
                <div class="moreBlogsMenu">
                    <ul>
                        <% foreach (var sub_category in Model.Where(c => c.is_sub)) {%>
                        <a href="<%: sub_category.GetCategoryUri() %>" title="<%: sub_category.title %>"><%: sub_category.title%></a>
                        <% } %>
                    </ul>
                </div>
            </li>
            <% } %>--%>
        </ul>
    </div>
</div>