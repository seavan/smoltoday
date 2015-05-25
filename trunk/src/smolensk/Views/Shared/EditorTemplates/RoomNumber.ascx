<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int?>" %>
<div id="_videoRoom">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">
        <option value="">Выберите номер зала</option>
        <option value="90" <%= Model == 90 ? "selected=\"selected\"" : "" %>>Зал 90</option>
        <option value="91" <%= Model == 91 ? "selected=\"selected\"" : "" %>>Зал 91</option>
    </select>
</div>
