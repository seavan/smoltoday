<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<char?>" %>
<div id="_video">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">
        <option value="">Выберите тип видео</option>
        <option value="c" <%= Model == 'c' ? "selected=\"selected\"" : "" %>>Арбитражный суд</option>
        <option value="n" <%= Model == 'n' ? "selected=\"selected\"" : "" %>>Сетевизор</option>
    </select>
</div>
