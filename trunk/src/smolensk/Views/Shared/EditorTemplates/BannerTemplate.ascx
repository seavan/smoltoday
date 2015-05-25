<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<div id="_bannerType">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">        
        <option value="1" <%= Model == 1 ? "selected=\"selected\"" : "" %>>Простой</option>
        <option value="2" <%= Model == 2 ? "selected=\"selected\"" : "" %>>Стрелка - орёл</option>
        <option value="3" <%= Model == 3 ? "selected=\"selected\"" : "" %>>Стрелка - форум</option>
        <option value="4" <%= Model == 4 ? "selected=\"selected\"" : "" %>>Стрелка</option>
    </select>
</div>
