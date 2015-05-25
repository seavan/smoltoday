<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IEnumerable<meridian.smolensk.proto.IAttachedPhoto>>" %>
<%
    if (Model != null)
    {
        foreach (var p in Model)
        {
            %>
            <div style="background: #EFEFEF; padding: 15px; border: 1px dotted silver; float: right; position: relative">
                
                <a href="return javacript:null;" 
                style="position: absolute; top: 0px; right: 0px; color: red; z-index: 100" 
                data-params=' { "photoId": "0", "fieldName": "<%= ViewData["fieldName"] %>", "protoName": "<%= p.AttachedPhotoContainer.ProtoName %>", "id": <%= p.AttachedPhotoContainer.id %>}' 
                data-controller="IAttachedPhotoAspect"
                data-action="RemovePhoto"
                class="_delete _action">удалить</a>

                <img src="<%= p.FullUrl %>" alt style="width: 300px"/>
            </div>
            <%
        }
    }
     %>


