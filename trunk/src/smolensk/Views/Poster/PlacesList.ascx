<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PlacesListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common.HtmlHelpers" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%
    var routeValues = new { id = Model.Category.Id, from = Model.Date.From, to = Model.Date.To };
    var routeName = "PlacesListBlock";    
    var sortingKey = "sorting";
    var sortingDirKey = "sortingDir";
    var selector = "#placesListBlock";
%>
<div id="placesListBlock">
<table class="placeTable">
    <tr>
        <%= Html.SortingColumn(Model.Sorting, PlaceSortingType.Title, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Название", selector)%>
        <%= Html.SortingColumn(Model.Sorting, PlaceSortingType.Adress, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Адрес", selector) %>                                 
    </tr>
<%foreach (var place in Model.Places)
  { %>
    <tr>
        <td><a href="<%: place.GetItemUri() %>" title="<%=place.Title %>"><%=place.Title %></a></td>
        <td><%=place.Adress %></td>
    </tr>
     <%} %>
</table>
</div>