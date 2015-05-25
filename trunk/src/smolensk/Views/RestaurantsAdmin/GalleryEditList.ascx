<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IEnumerable<meridian.smolensk.proto.restaurant_photos>>" %>
<%
    if (Model != null)
    {
        foreach (var p in Model)
        {
            %>
            <div style="background:  <%= p.is_main ? "gold" : "#EFEFEF" %>; padding: 15px; margin: 10px; border: 1px dotted silver; float: right; position: relative">
                <a href="return javacript:null;" 
                style="position: absolute; top: 0px; right: 0px; color: red" 
                data-params=' { "id": "<%= p.Id %>", "proto": "<%= p.ProtoName %>"}' 
                data-controller="IAttachedPhotoAspect"
                data-action="Delete"
                class="_delete _action">удалить</a>, 
                <a href="return javacript:null;" style="position: absolute; bottom: 0px; left: 0px; z-index: 100"
                data-params=' { "id": "<%= p.Id %>", "proto": "<%= p.ProtoName %>"}' 
                data-controller="IAttachedPhotoAspect"
                data-action="SetMain"
                class="_setMain _action"
                >главная</a>
            <img width="140px" src="<%= p.ThumbUrl %>" data-id="<%= p.Id %>"/>
            </div>
            <%
        }
    }
     %>
