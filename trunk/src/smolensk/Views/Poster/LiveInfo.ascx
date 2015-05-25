<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ActionViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<% if (Model.Count() > 0) { %>
<dl class="live">
<dt><a href="<%: Url.Action("Category", "Poster", new {id = 3 }) %>" title="Концерты">Концерты</a></dt>
    <% foreach (var action in Model) { %>
    <dd>
	    <a href="<%:action.GetUri() %>" title="<%= action.Title%>">
		    <img src="<%=action.PhotoUrlForMain %>" width="310" height="114" alt="1" /> 
		    <span><%= action.Title%></span>
	    </a>
    </dd>
    <% } %>
</dl>
<% } %>