<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IEnumerable<meridian.smolensk.proto.IAttachedPhoto>>" %>
<%
    if (Model != null)
    {
        foreach (var p in Model)
        {
            %>
            <div style="background:  <%= p.IsMain ? "gold" : "#EFEFEF" %>; padding: 15px; margin: 10px; border: 1px dotted silver; float: right; position: relative">
                
                <a href="return javacript:null;" 
                style="position: absolute; top: 0px; right: 0px; color: red; z-index: 100" 
                data-params=' { "photoId": "<%= p.Id %>", "fieldName": "<%= ViewData["fieldName"] %>", "protoName": "<%= p.AttachedPhotoContainer.ProtoName %>", "id": <%= p.AttachedPhotoContainer.id %>}' ' 
                data-controller="IAttachedPhotoAspect"
                data-action="RemovePhoto"
                class="_delete _action">удалить</a>
                
                <%if (p.ShowIsMain){%>
                <a href="return javacript:null;" style="position: absolute; bottom: 0px; left: 0px; z-index: 100"
                data-params=' { "photoId": "<%= p.Id %>", "fieldName": "<%= ViewData["fieldName"] %>", "protoName": "<%= p.AttachedPhotoContainer.ProtoName %>", "id": <%= p.AttachedPhotoContainer.id %>}' 
                data-controller="IAttachedPhotoAspect"
                data-action="SetMain"
                class="_setMain _action"
                >главная</a>
                <%} %>
                
                <%if (!string.IsNullOrEmpty(p.EditLink)){%>
                <a href="<%:p.EditLink %>" style="position: absolute; bottom: 0px; right: 0px; z-index: 100">редактировать</a>
                <%} %>

                <img width="140px" src="<%= p.ThumbUrl %>" data-id="<%= p.Id %>" alt />

            </div>
            <%
        }
    }
     %>


