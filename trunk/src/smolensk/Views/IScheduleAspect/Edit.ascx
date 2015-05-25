<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IScheduleAspect>" %>
<%
    var prefix = Model.FieldName;
    var id = prefix + "Schedule";
    var saveFunction = "save" + id;
    var controller = "IScheduleAspect";
    var method = "Save";
    var parentProto = Model.GetParent().ProtoName;
    var parentId = Model.GetParent().id;
%>
<div class="posterPage"> 
<div id="<%= id %>" data-uri="/<%= controller %>/<%= method %>" data-prefix="<%= prefix %>"
    data-parent-id="<%= parentId %>" data-parent-proto="<%= parentProto %>" style="width: 750px; overflow-x: scroll">
  <table>
      
  <%
      var places = Model.GetAvalablePlaces();
      var scheduleAll = Model.GetPlacesSchedule();
      %>
      <tr>
          <th>место</th>
          <th>ред.</th>
      </tr>
      <%
        foreach (var p in places)
        {
            var fname = String.Format("{0}.{1}.", Model.FieldName, p.id);
            var schedule = scheduleAll.IndexOfKey(p.id) != -1 ? scheduleAll[p.id] : new List<DateTime>();
          %>
          <tr>
              <td style="width: 150px"><%= p.lookup_title%></td>
              <td class="place" data-name="<%= fname%>">
                <input type="button" value="добавить дату" onclick="addScheduleItem(this)"/>
                <%foreach (var dt in schedule.GroupBy(d => d.Date)) { %>
                    <% Html.RenderPartial("ScheduleItem", dt);  %>
                <%} %>
              </td>
          </tr>
          <%
         }
       %>
  </table>
</div>
<div>
    <a class="_link" href="#" onclick="setFname(); return saveFunction('#<%= id %>')" style="float: right">
        Сохранить расписание (автоматическое сохранение отключено)</a>
</div>
</div>
<div class="_calendarTemplate" style="display: none">
	<% Html.RenderPartial("ScheduleItem", new DateTime[] { });  %>
</div>

<script>
	function addScheduleItem(elem, fname) {
		var t = $("._calendarTemplate>div").clone().appendTo($(elem).parent());
		installDatepicker();
	}
	function setFname() {
	    $('.place').each(function () {
	        var fname = $(this).attr('data-name');
	        var schedList = $(this).find('.scheduleItem');
	        for (var i = 1; i <= schedList.length; i++) {
	            schedList.eq(i - 1).find('.date').attr('name', fname + 'date.' + i);
	            schedList.eq(i - 1).find('.time').attr('name', fname + 'time.' + i);
	        }
	    });
	}
	function installDatepicker(){
		$("._datepicker").not("._calendarTemplate ._datepicker").addClass('datepicker').removeClass('_datepicker')
			.datepicker({ buttonImage: "/content/i/datepicker_gray_ico.png",
			              showOn: "both", 
                          buttonImageOnly: true,
                          dateFormat: "dd.mm.yy", 
                          firstDay: 1
                      });
	}

	$(function () {
		installDatepicker();
	});

	/*    if (saveCallbacks) {
        saveCallbacks.push(function () {
            saveFunction('#<%= id %>');
        }); 
    } */
</script>
