<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapPathHelperModel,MvcSiteMapProvider]]" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="MvcSiteMapProvider.Web.Html.Models" %>

<div class="breadcrumbs">
	<ul>
	    <% foreach (var node in Model) { %>
            <li>
            <%=Html.DisplayFor(m => node)%>
            <% if (node != Model.Last()) { %>
                <span>→</span>
            <% } %>
            </li>
        <% } %>
	</ul>
</div>
