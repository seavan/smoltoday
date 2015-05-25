<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<IDictionaryValue>>" %>
<%@ Import Namespace="admin.db" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var model = Model;
    var parent = ViewData["parentModel"] as IDatabaseEntity;
%>
<div>
    <% if(Model != null && parent.id > 0) Html.RenderAction("Edit", "IFixedDictionaryAspect", new { parentProto = parent.ProtoName, parentId = parent.id, field = fname });%>
    <%if(parent.id <= 0){%>Cохраните объект перед редактированием<%} %>
</div>
