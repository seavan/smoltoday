<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.CategoriesListViewModel>" %>

<%  if (Model.Categories.Count() > 0)
    { %>
     <% foreach (var item in Model.Categories) { %>
<div class="blockLine">
    <span class="category">
        <a href="<%= item.GetViewCategoryUri() %>" title="<%= item.Title %>" class="<%= item.CssClass %>"><%= item.Title%></a>
    </span>
</div>
<div class="blockLine">
        <%  Html.RenderAction("NewsByCategoryLast", new { categoryId = item.Id }); %>
    <div class="popularNewsBlock">
        <%  Html.RenderAction("NewsByCategoryPopular", new { categoryId = item.Id }); %>
    </div>
</div>
        <%}} %>