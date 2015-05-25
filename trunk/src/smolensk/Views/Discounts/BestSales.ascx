<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SalesListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<% if (Model.Items.Count() > 0) { %>
<dl class="sale">
	<dt><a href="<%: Url.Action("Index", "Discounts") %>" title="Лучшие скидки">Лучшие скидки</a></dt>
    <% foreach (var s in Model.Items) { %>
	<dd>
		<span class="data">
            <a href="<%= s.GetUri() %>" title="<%=s.GetHrefTitle()%>">
                <img src="<%= s.Image %>" width="79" height="80" alt="5" /></a>
            <span>
                <span class="saleValue <%=s.PercentLabel %>"><%=s.PersentText %></span>
            </span>
			<a href="<%= s.GetUri() %>" title="<%=s.GetHrefTitle()%>"><%=s.ShortTitle%></a>
			<br/><br/>
            <%=s.DateAsInterval%>
		</span>
	</dd>
	<% } %>
</dl>
<% } %>