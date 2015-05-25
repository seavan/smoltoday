<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>

<div id="_magazineType">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var selected = Model != null ? Model.Value : 0;
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">
        <%
            foreach (var item in meridian.smolensk.system.Meridian.Default.news_categoriesStore.All())
            {
                %>
                <option value="<%= item.id %>" <%= item.id == selected ? "selected=\"selected\"" : ""%>><%= item.title %></option>
                <%
            }
             %>        
    </select>
</div>
