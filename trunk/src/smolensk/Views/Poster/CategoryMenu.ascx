<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ActionCategoryViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%if (Model.Count() > 0) {%>
<ul class="profileMenu poster">
    <li>Афиша</li>
    <% foreach (var item in Model) { %>
    <li>
        <a href="<%: Url.Action("Category","Poster", new { id = item.Id, from = item.Date.From.HasValue ? item.Date.From.Value.ToString("dd.MM.yyyy") : string.Empty, to = item.Date.To.HasValue ? item.Date.To.Value.ToString("dd.MM.yyyy") : string.Empty }) %>" title="<%= item.Title %>"><%= item.Title%></a> 
        <span class="counter new"><%=item.ActionsCount%></span>
    </li>
    <% } %>					
</ul>
<%} %>
    