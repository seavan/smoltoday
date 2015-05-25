<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.ad_categories>" %>
<div class="subCategoryList">
    <h3><%= Model.title %><span><%= Model.AdsCount.ToCounterWordForm(Int64Extensions.AdvertForm, false)%></span></h3>
    <% if (Model.Subcategories.Any()) { %>
    <ul>
        <% foreach (var subcategory in Model.Subcategories) { 
                string curClass = ViewBag.Id == subcategory.id ? "class=\"cur\"" : string.Empty;
				if (subcategory.AdsCount == 0)
					continue; %>
            <li <%= curClass %>><a href="<%:Url.Action("Category", "Adverts", new { subcategory.id }) %>" title="<%=subcategory.title %>"><%=subcategory.title %></a> (<%= subcategory.AdsCount %>)</li>
        <% } %>
    </ul>
    <% } %>
</div>
