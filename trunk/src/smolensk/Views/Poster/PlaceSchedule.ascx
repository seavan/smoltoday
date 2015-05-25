<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ActionsListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>

<% 
    var place_id = Page.RouteData.Values["id"];
    var day_count = Model.Date.DayCount + 1;
    var current_filter = day_count.ToDayCount();
    var routeName = "PlaceSchedule";
    var block = "#scheduleBlock";
    var keyName = "filter";
%>
<div id="scheduleBlock">
    <div class="schedule day">
        <p class="header">Расписание</p>
        <div class="sortingTools">								
		    <ul>	
                <%= Html.FilterTypeSelectorLink(current_filter, ScheduleFilterType.In3Days, routeName, new { id = place_id }, keyName, null, block, true)%>								
                <%= Html.FilterTypeSelectorLink(current_filter, ScheduleFilterType.InWeek, routeName, new { id = place_id }, keyName, null, block, true)%>								
                <%= Html.FilterTypeSelectorLink(current_filter, ScheduleFilterType.In2Weeks, routeName, new { id = place_id }, keyName, null, block, true)%>								
		    </ul>									
	    </div>
        <table class="placeTable">
            <%  var d = Model.Date.From.Value;
                for (var j = 0; j < day_count; j=j+7) { %>
                <%if (j > 0) {%>
                <tr style="height: 40px;"></tr>
                <%} %>
                <tr>
                    <th>Название</th>
                    <%if (j == 0){%>
                    <th>Сегодня</th>
                    <%} %>
                    <%for (var i = j == 0 ? 1 : j; i < day_count && i < j+7; i++) { %>
                    <th><%=Formatter.GetNameOfDayOfMonth(d.AddDays(i))%></th>   
                    <%} %>                                   
                </tr>
                <%foreach (var action in Model.Actions)
                  { %>
                <tr>
                    <td>
                        <span class="descr"><%=action.Category.Title%>, <%=action.AgeLimitPlus%></span>
                        <a href="<%: action.GetUri() %>" title="<%=action.Title%>"><%=action.Title%></a>
                    </td>
                    <%for (var i = j; i < day_count && i < j+7; i++) { %>
                    <td><%= action.GetSchedule(long.Parse(place_id.ToString()), d.AddDays(i).Date, "HH:mm")%></td>   
                    <%} %>  
                </tr>
                <%} %>
            <%} %>
        </table>
    </div>
</div>
