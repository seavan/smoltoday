<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IFavorite>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%var user =  Html.UserPrincipal();%>

<%if (user != null){ %>
<span data-id="<%=Model.id%>" data-name="<%= Model.ProtoName %>" data-view="StarFavorite">
    <%if (!Model.IsFavorite(user.id)){%>
        <span class="favorStar" data-url="/Utility/AddToFavorite">&nbsp;</span>
    <%}
    else {%>
        <span class="favorStar cur" data-url="/Utility/DeleteFromFavorite">&nbsp;</span>
    <%} %>
</span>
<%} %>