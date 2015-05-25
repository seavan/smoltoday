<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CategoriesListViewModel>" %>

<ul class="newsMenu">
	<li <%= Model.SetHighlight(!Model.SelectedCategoryId.HasValue) %>><a href="<%: Url.Action("Categories","Companies") %>" title="Все категории">Все категории</a></li>

    <% foreach (var category in Model.Categories) { %>
    <li <%= Model.SetHighlight(Model.SelectedCategoryId.HasValue && Model.SelectedCategoryId.Value == category.Id) %>>
        <a href="<%: Url.Action("List","Companies",new { category = category.Id}) %>" title="<%: category.Title %>"><%: category.Title %></a>
    </li>
    <% } %>

</ul>