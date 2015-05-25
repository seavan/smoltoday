<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<RestaurantEventsListViewModel>>" %>
<script type="text/javascript">
    $().ready(function() {
        InitRestaurantsEvents('<%: DateTime.Now.ToString("dd.MM.yyyy") %>');
    });
</script>

<div class="filterBody events">
    <div class="daySelector">
        <%
            int i = 0;
            int week;
            foreach (var restEvents in Model)
            {
                week = i/7;
                i++;
                %>
            <span class="day <%: restEvents.Day.Date.Date == DateTime.Now.Date ? "cur" : "" %> <%: restEvents.Day.IsHoliday ? "off" : "" %> <%:restEvents.Events.Count == 0 ? "empty" : "" %>" onclick="showEvent('<%:restEvents.Day.Date.ToShortDateString() %>', this)" group="<%: week %>" <%: i<=7 ? "" : "style=display:none" %>>
            <span><%: restEvents.Day.Title %><%= restEvents.Events.Count > 0 ? String.Format("<b>({0})</b>", restEvents.Events.Count) : "" %></span> <small><%: restEvents.Day.DayOfMonth %></small> </span>
        <% } %>
        
        <span class="day select">
			<span id="prevGroup" prevgroup="-1" class="prev disable" onclick="changeGroup(-1,<%: Model.Count/7 %>)"><span>след.<br/>неделя</span></span>
			<span id="nextGroup" nextgroup="1" class="next" onclick="changeGroup(+1,<%: Model.Count/7 %>)"><span>пред.<br/>неделя</span></span>
		</span>
    </div>

    <% foreach (var restEvents in Model){ %>

    <div class="preview" date="<%: restEvents.Day.Date.ToShortDateString() %>" <%: restEvents.Day.Date.Date == DateTime.Now.Date ? "" : "style=display:none;"%>>
        <% if (restEvents.Events.Count != 0) { 
               foreach (var evnt in restEvents.Events){ %>
        <div class="oneRest">
            <a href="<%: evnt.Restaurant.GetItemUri() %>" title="<%: evnt.Restaurant.Title %>" class="name"><%: evnt.Restaurant.Title%></a>
             <span class="time"><%: evnt.Date.ToString("HH:mm") %></span> 
             <a><%: evnt.Title %></a> 
             <span class="type"><%= evnt.ShortDescription %></span>
             <% if (evnt.Restaurant.CanBookTable) { %>
             <span class="button" data-id="<%: evnt.Restaurant.Id %>" data-title="<%: evnt.Restaurant.Title %>" data-date="<%:evnt.Date.ToString("dd.MM.yyyy hh:mm") %>">Забронировать столик</span>
             <% } %>
        </div>
        <% }} else { %>
        <div class="oneRest">
           <span>К сожалению, сегодня нет мероприятий в ресторанах.</span>
        </div>
        <% } %>
    </div>
    <% } %>
</div>
