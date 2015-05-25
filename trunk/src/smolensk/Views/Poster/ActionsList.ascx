<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ActionsListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common.HtmlHelpers" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%
    var routeValues = new { id = Model.Category.Id, from = Model.Date.From, to = Model.Date.To };
    var routeName = "ActionsListBlock";    
    var sortingKey = "sorting";
    var sortingDirKey = "sortingDir";
    var selector = "#actionsListBlock";
%>
<div id="actionsListBlock">
<table class="placeTable">
    <tr>
        <%= Html.SortingColumn(Model.Sorting, ActionSortingType.Alphabet, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Мероприятие", selector)%>
        <%= Html.SortingColumn(Model.Sorting, ActionSortingType.AgeLimit, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Возраст", selector) %>
        <%= Html.SortingColumn(Model.Sorting, ActionSortingType.Genre, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Жанр", selector)%>
        <%= Html.SortingColumn(Model.Sorting, ActionSortingType.Place, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Место", selector) %>
        <%= Html.SortingColumn(Model.Sorting, ActionSortingType.Time, Model.sortingDirection, routeName, routeValues, sortingKey, sortingDirKey, "Время", selector) %>
    </tr>
<%foreach (var action in Model.Actions)
  { %>
    <tr>
        <td>
            <div><a href="<%:action.GetUri() %>" title="<%= action.Title %>"><%= action.Title %></a></div>
                                        
            <span class="info">                                        	
                <% Html.RenderPartial("Widgets/Rating", action.Marks); %>
                <span class="descr">Идут <%=action.ParticipiantsCount %> чел.</span>
            </span>	
        </td>
        <td class="age"><%=action.AgeLimitPlus%></td>
        <td class="genre"><%=action.GenresList %></td>
        <td>
            <%foreach (var p in action.Places) { %>
                <a href="<%: p.GetItemUri() %>" title="<%=p.Title %>"><%=p.Title%></a>
            <%} %>
        </td>
        <%--TODO: уточнить какое время выводить--%>
        <td><%=action.Schedule.FirstOrDefault().datetime.ToShortTimeString() %></td>
    </tr>
    <%} %>
</table>
</div>