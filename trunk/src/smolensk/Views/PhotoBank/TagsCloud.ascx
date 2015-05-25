<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<smolensk.Models.CodeModels.TagModel>>" %>
<div class="tagCloud">
    <ul>
        <% foreach (var tag in Model) {%>
            <li>
                <a href="<%: Url.Action("Search", "PhotoBank", new { q = tag.Title }) %>" data-rel="<%= tag.Count %>">
                    <%= tag.Title %>
                </a>
            </li>
        <% } %>
    </ul>
</div>
