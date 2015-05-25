<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<RestaurantEventsListViewModel>>" %>

<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Extensions" %>

    <script type="text/javascript">
    // Формируем даты, которые имеют события, чтобы обозначить их отдельно в календаре
        var valueDays = [<%= String.Join(",",Model.Where(e => e.Day.Date < DateTime.Now.Date && e.Events.Count != 0).Select(t=>String.Format("\"{0:dd.MM.yyyy}\"",t.Day.Date)))%>];

        $().ready(function () {
            InitRestaurantEvents('<%: DateTime.Now.ToString("dd.MM.yyyy") %>');
        });

    </script>

<div class="filterBody events">
    <div class="daySelector">
        <span class="day" onclick="showEvent('<%:DateTime.Now.AddDays(-1).ToShortDateString() %>', this)"><span>архив</span><small>&nbsp;</small></span>
        <%
            int i = 0;
            int quad;

            var events = Model.Where(e => e.Day.Date.Date >= DateTime.Now.Date).ToList();
            int totalGroups = events.Count/4;
            foreach (RestaurantEventsListViewModel @event in events)
            {
                quad = i / 4;
                i++;
                string dateTitle = @event.Day.Date.Date == DateTime.Now.Date ||
                                   @event.Day.Date.Date == DateTime.Now.Date.AddDays(1)
                                       ? Formatter.GetWeekDayAndNameOfDayOfMonth(@event.Day.Date)
                                       : @event.Day.DayOfMonth;
                
        %>
        <span class="day <%: @event.Day.Date.Date == DateTime.Now.Date ? "cur" : "" %> <%: @event.Day.IsHoliday ? "off" : "" %> <%:@event.Events.Count == 0 ? "empty" : "" %>"
            onclick="showEvent('<%:@event.Day.Date.ToShortDateString() %>', this)" group="<%: quad %>"
            <%: i<=4 ? "" : "style=display:none" %>><span>
                <%: @event.Day.Date.Date == DateTime.Now.Date ? "cегодня" : @event.Day.Date.Date == DateTime.Now.Date.AddDays(1) ? "завтра" : @event.Day.Title %></span>
            <small>
                <%: dateTitle%>
            </small></span>
        <%} %>
        <span class="day select">
            <span class="prev disable" id="prevGroup" prevgroup="-1" onclick="changeGroup(-1,<%: totalGroups %>)"></span>
            <span class="next" id="nextGroup" nextgroup="1" onclick="changeGroup(+1,<%: totalGroups %>)"></span>
        </span>
    </div>
    <% foreach (var @event in Model.Where(e => e.Day.Date >= DateTime.Now.Date)){ %>
    <div class="preview" date="<%: @event.Day.Date.ToShortDateString() %>" <%: @event.Day.Date.Date == DateTime.Now.Date ? "" : "style=display:none;"%>>
        <% if (@event.Events.Count != 0)
           {
               foreach (var evnt in @event.Events)
               { %>
        <div class="oneRest">
            <span class="time"><%: evnt.Date.ToString("hh:mm") %></span> 
            <a><%: evnt.Title %></a> 
            <span class="type"><%: evnt.ShortDescription %></span> 
            <span class="button" data-id="<%: evnt.Restaurant.Id %>" data-title="<%: evnt.Restaurant.Title %>" data-date="<%:evnt.Date.ToString("dd.MM.yyyy hh:mm") %>">Бронирование</span>
            
            <%if (!string.IsNullOrEmpty(evnt.Description)){%>
            <span class="descr"><%: evnt.Description %></span>
            <%} %>
            

        </div>
        <% }}else{ %>
        <div class="oneRest">
            <span>К сожалению, сегодня мероприятий нет.</span>
        </div>
        <% } %>
    </div>
    <% } %>

    <div class="preview" id="archiveContainer" style="display:none;" date="<%:DateTime.Now.AddDays(-1).ToShortDateString() %>">
        
        <div class="_calendarEvent"></div>

    <% foreach (var @event in Model.Where(e => e.Day.Date < DateTime.Now.Date && e.Events.Count != 0))
       {  
           foreach (var evnt in @event.Events)
               { %>
                <div class="oneRest" date="<%: @event.Day.Date.ToShortDateString() %>" style="display:none;">
                    <span class="time"><%: evnt.Date.ToString("hh:mm") %></span> 
                    <a href="#" title="<%: evnt.Title %>"><%: evnt.Title %></a> 
                    <span class="type"><%: evnt.ShortDescription %></span> 

                    <%if (!string.IsNullOrEmpty(evnt.Description)){%>
                    <span class="descr"><%: evnt.Description %></span>
                    <%} %>
            
                </div>
            <% }}%>

    </div>
</div>