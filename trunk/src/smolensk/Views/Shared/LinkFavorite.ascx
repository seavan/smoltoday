<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IFavorite>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%var user =  Html.UserPrincipal();%>

<%if (user != null){ %>
<div class="linkFavor" data-id="<%=Model.id%>" data-name="<%= Model.ProtoName %>" data-view="LinkFavorite">
    <%if (!Model.IsFavorite(user.id))
      {%>
	<a href="#" data-url="/Utility/AddToFavorite" title="В избранное">В избранное</a>
    <%}
      else
      {%>
    <a href="#" data-url="/Utility/DeleteFromFavorite" title="Удалить из избранного">Удалить из избранного</a>
    <%} %>
</div>
<%} %>