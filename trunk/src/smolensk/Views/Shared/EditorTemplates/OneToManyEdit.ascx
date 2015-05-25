<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="admin.db" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var parent = ViewData["parentModel"] as IDatabaseEntity;
%>
<div>
    <% if(Model != null && parent.id > 0) Html.RenderAction("Edit", "IOneToManyAspect", new { parentProto = parent.ProtoName, parentId = parent.id, field = fname });%>
    <%if(parent.id <=0){%>Cохраните объект перед редактированием<%} %>
</div>
