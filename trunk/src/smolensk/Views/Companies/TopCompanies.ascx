<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<smolensk.Models.ViewModels.CompanyViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<% if (Model != null && Model.Count > 0)
   { %>
<dl class="companyTop">
		<dt>Топ <%= Constants.TopCompanies %> в категории</dt>
		<dd>
            <ol>
                <% foreach (CompanyViewModel company in Model) { %>
                        <li><a href="<%= company.GetItemUri() %>" title="<%= company.Title %>"><%= company.Title %></a></li>
                <% } %>
            </ol>
        </dd>
    </dl>
    
    <% } %>