<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%@ Import Namespace="admin.db" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var model = Model;
    var parent = ViewData["parentModel"] as ILookupValueAspectProvider;
%>
<div>
    <%
        if (parent != null)
        {
            var aspect = parent.GetLookupValueAspect(fname);
    %>
    <select name="<%=fname%>">
        
        <%if(aspect.ShowIsNoSelect){%>
        <option value="0">не выбрано</option>
        <%} %>

        <%
            foreach (var v in aspect.GetValues())
            {
        %>
        <option <%= v.lookup_value_disabled ? "disabled='disabled'" : ""%> value="<%= v.id %>" <%= v.id == Model
                                 ? "selected" : "" %>>
            <%= new String('.', v.lookup_value_level * 5) %><%= v.lookup_title %></option>
        <%
            }
        %>
    </select>
    <%}else {%>Cохраните объект перед редактированием<%}%>
</div>
