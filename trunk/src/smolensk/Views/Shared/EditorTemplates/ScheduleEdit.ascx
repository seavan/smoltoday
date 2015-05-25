<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="admin.db" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var parent = ViewData["parentModel"] as IDatabaseEntity;
%>
<div>
    <% if (parent.id > 0)
       {
           Html.RenderAction("Edit", "IScheduleAspect", new {parentProto = parent.ProtoName, parentId = parent.id, field = fname});
       }
       else
       {
       %>
       сохраните объект перед редактированием расписания
       <%
       } %>
</div>
