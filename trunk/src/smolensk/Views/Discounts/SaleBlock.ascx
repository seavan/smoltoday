<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SaleViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<dl>
	<dt>
        <%if (!string.IsNullOrEmpty(Model.Image)){%>
		<a href="<%: Model.GetUri() %>" title="<%=Model.Title %>">
            <img src="<%=Model.Image %>" alt="<%=Model.Title %>" />
        </a>
        <%} else{%>
        <a href="<%: Model.GetUri() %>" title="<%= Model.Title %>" class="noLogo">&nbsp;</a>    
        <%}%>
	</dt>
	<dd>
        <%if (!string.IsNullOrEmpty(Model.PersentText)){%>
		<span class="sale_value <%= Model.PercentLabel %>"><%= Model.PersentText %></span>
        <%} %>
        <% if (!Model.Unlimited)
           { %>
		<p class="date"><%= Model.DateAsInterval %></p>
        <% } %>
		<p><a href="<%= Model.GetUri() %>" title="<%= Model.GetHrefTitle() %>"><%= Model.Title %></a></p>
	</dd>
</dl>