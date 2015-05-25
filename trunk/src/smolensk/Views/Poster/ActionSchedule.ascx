<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ActionViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>
<% 
    var routeName = "ActionSchedule";
    var block = "#scheduleBlock";
    var keyName = "filter";
%>
<div id="scheduleBlock">
<div class="schedule">
    <p class="header">Расписание</p>
    <div class="sortingTools">
		<ul>									
			<%= Html.FilterTypeSelectorLink(Model.ScheduleFilter, ScheduleFilterType.Today, routeName, new { id = Model.Id }, keyName, null, block, true)%>								
            <%= Html.FilterTypeSelectorLink(Model.ScheduleFilter, ScheduleFilterType.InWeek, routeName, new { id = Model.Id }, keyName, null, block, true)%>								
            <%= Html.FilterTypeSelectorLink(Model.ScheduleFilter, ScheduleFilterType.In2Weeks, routeName, new { id = Model.Id }, keyName, null, block, true)%>								
		</ul>									
	</div>
    <table class="placeTable">
        <tr>
            <th>место</th>
            <th>адрес</th>
            <th>дата</th>
            <th>время</th>                                    
        </tr>
        <% foreach (var placeSched in Model.Schedule.GroupBy(s => s.action_place_id)) {
               foreach (var sch in placeSched.GroupBy(s => s.datetime.Date)) {
                   var p = sch.First().GetPlace().ToPlace(); %>
        <tr>
            <td><a href="<%: p.GetItemUri() %>" title="<%=p.Title %>"><%= p.Title%></a></td>
            <td><%= p.Adress%></td>
            <td><%= sch.Key.ToString("dd.MM")%></td>
            <td><%= string.Join(", ", sch.Where(a => a.datetime.TimeOfDay.Ticks > 0).Select(a => a.datetime.ToString("HH:mm")))%></td>
        </tr>
            <%}
          } %>
    </table>
</div>
</div>
