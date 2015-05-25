<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ActionViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<% if (Model.Count() > 0) { %>
<dl class="cinema">
	<dt><a href="<%: Url.Action("Category", "Poster", new {id = 1 }) %>" title="В кинотеатрах">В кинотеатрах</a></dt>
    <% foreach (var action in Model) { %>
	<dd>
		<span class="img">
        <a href="<%:action.GetUri() %>" title="<%= action.Title %>">
            <img src="<%= action.PhotoUrlForMain %>" width="82" height="114" alt="1" />
        </a>
        </span>
		<span class="cinemaInfo">
			<span class="title">
				<a href="<%:action.GetUri() %>" title="<%=action.Title %>"><%=action.Title %></a>
				<span class="time"><%= action.FirstDateTitle%></span>
				<span class="genre"><%=action.GenresList %></span>
			</span>
			<%--<span class="rating">Рейтинг Кинопоиска: <span>6,679</span></span>--%>
		</span>
	</dd>
    <% } %>
</dl>
<% } %>
