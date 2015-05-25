<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CategoriesListViewModel>" %>

<ul class="newsMenu" data-catid="<%:Model.SelectedCategoryId %>">
    
    <%if (Model.Date == DateTime.Today){%>
	<li <%= Model.SetHighlight(!Model.SelectedCategoryId.HasValue) %>><a href="<%: Url.Action("Index") %>#menuTop" title="Главное">Главное</a></li>
    <%}else{%>
    <li <%= Model.SetHighlight(!Model.SelectedCategoryId.HasValue) %>><a href="<%: Url.Action("List", "News", new { categoryId = "!", year = Model.Date.Year, month = Model.Date.Month, day = Model.Date.Day})%>#menuTop" title="Главное">Главное</a></li>
    <%} %>
    <% foreach (var category in Model.Categories) { %>
    <li <%= Model.SetHighlight(Model.SelectedCategoryId.HasValue && Model.SelectedCategoryId.Value == category.Id) %>>
        <a href="<%: Url.Action("List", "News", new { categoryId = category.Id, year = Model.Date.Year, month = Model.Date.Month, day = Model.Date.Day})%>#menuTop" title="<%: category.Title %>"><%: category.Title %></a>
    </li>
    
    <% } %>
</ul>