<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<IValueListItem>>" %>
<%@ Import Namespace="admin.db" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var model = Model;
    var parent = ViewData["parentModel"] as IDatabaseEntity;
%>
<%if(parent.id > 0){%>
<div id="<%= fname %>Dictionary">
    <% Html.RenderAction("Edit", "IValueListAspect", new { parentProto = parent.ProtoName, parentId = parent.id, field = fname });%>
</div>
<%} %>