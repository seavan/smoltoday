<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IBreadCrumbsProvider>" %>

<div class="breadcrumbs">
    <ul>
        <li><a href="/" title="Домой">Домой</a></li>
        <%
            if (Model != null)
            {
                foreach (var item in Model.GetBreadCrumbs())
                {
                    %>
        <li>&nbsp;<span>&rarr;</span><a href="<%= item.GetUri() %>" title="<%= item.GetHrefTitle() %>"><%= item.GetHrefTitle() %></a></li>
                    <%
                }
            }
             %>
    </ul>
</div>