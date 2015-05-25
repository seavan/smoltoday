<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IFavorite>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%var user =  Html.UserPrincipal();%>

<%if (user != null){ %>
<span data-id="<%=Model.id%>" data-name="<%= Model.ProtoName %>" data-view="ButtonFavorite">
    <%if (!Model.IsFavorite(user.id)){%>
        <span class="button favorite" data-url="/Utility/AddToFavorite"><span></span>В избранное</span>
    <%}
    else {%>
        <span class="button favorite" data-url="/Utility/DeleteFromFavorite"><span></span>Удалить из избранного</span>
    <%} %>
</span>
<%} %>