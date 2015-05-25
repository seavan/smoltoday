<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ActionsListViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>
<%@ Import Namespace="smolensk.common.HtmlHelpers" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Mappers" %>

<div class="sortingTools">
	<ul>	
        <%= Html.FilterTypeSelectorLink(Model.DateFilter, ActionDateFilterType.Now, Model.RouteName, new { }, "dateFilter", "Сегодня")%>
        <%= Html.FilterTypeSelectorLink(Model.DateFilter, ActionDateFilterType.Tomorrow, Model.RouteName, new { }, "dateFilter", ActionDateFilterType.Tomorrow.ToDate().ToStringFormat(Formatter.GetNameOfDayOfMonth))%>
        <%= Html.FilterTypeSelectorLink(Model.DateFilter, ActionDateFilterType.AfterTomorrow, Model.RouteName, new { }, "dateFilter", ActionDateFilterType.AfterTomorrow.ToDate().ToStringFormat(Formatter.GetNameOfDayOfMonth))%>
	</ul>
									
	<div class="selectorDate">
		<input type="text" value="" class="datepicker" placeholder="Календарь" onchange="javascript:location='<%= Url.RouteUrl(Model.RouteName)%>'+'?from='+this.value + '&to='+this.value"/>
	</div>
</div>
