<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% if (Request.IsAuthenticated){%>
<div class="searchBlock is_auth">
	<form action="#">
		<input type="text" value="" name="search" id="search" />
	</form>
</div>
<%}else {%>
<div class="searchBlock">
	<p>Поиск по сайту</p>
	<form action="#">								
		<label for="search" class="_autohide">например: <i>Кинотеатры</i></label>
		<input type="text" value="" name="search" id="search" />
	</form>
</div>
<%} %>

