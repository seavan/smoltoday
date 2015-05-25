<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<char>" %>
<div id="_videoType">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">        
        <option value="a" <%= Model == 'a' ? "selected=\"selected\"" : "" %>>Арбитражный суд</option>
        <option value="n" <%= Model == 'n' ? "selected=\"selected\"" : "" %>>Сетевизор</option>
        <option value="t" <%= Model == 't' ? "selected=\"selected\"" : "" %>>Закон-тв</option>
        <option value="c" <%= Model == 'c' ? "selected=\"selected\"" : "" %>>Конференци</option>
        <option value="l" <%= Model == 'l' ? "selected=\"selected\"" : "" %>>Лекции</option>
    </select>
</div>
