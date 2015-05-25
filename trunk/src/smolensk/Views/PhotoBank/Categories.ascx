<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<meridian.smolensk.proto.photobank_categories>>" %>
<%  int row = 0;
    foreach (var category in Model)
    { %>
    <% if (row++ == 0) { %>
        <div class="blockLine">
    <% } %>
    <a href="<%: Url.Action("Category", "PhotoBank", new { id = category.id }) %>" title="<%= category.title %>">
        <img src="<%= category.PhotoUrl %>" width="200" height="130" alt="<%= category.title %>" />
        <span><%= category.title %></span>
    </a>
    <%if (row == 3) { row = 0; %>
        </div>
    <% } %>
<% } %>
<%if (row != 0) { %>
    </div>
<% } %>