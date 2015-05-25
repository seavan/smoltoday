<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>

<dl class="events">
	<dt>Обсуждаемые события</dt>
	<% foreach (var item in Model.Items)
		Html.RenderPartial("~/Views/News/MostDiscussedMainSingleNews.ascx", item);
	%>
</dl>