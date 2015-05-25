<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DateTime>>" %>

<div class="scheduleItem sortingTools">
	<span class="selectorDate" style="float:left" >
		<input type="text" class="_datepicker date" value="<%= Model.Count() > 0 ? Model.First().ToString("dd.MM.yyyy"):"" %>" placeholder="Календарь"/>
	</span>
	<input type="text" class="time" value="<%=  Model.Count() > 0 ? string.Join(", ", Model.Select(t => t.ToString("HH:mm"))): "" %>" />
	<input type="button" value="-" onclick="$(this).parent().remove()"/>
</div>