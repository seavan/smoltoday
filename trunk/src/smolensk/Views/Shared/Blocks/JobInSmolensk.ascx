<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Mappers" %>

<% var model = Meridian.Default.ToJobInSmolenskViewModel(); %>

<% if (model != null) { %>
<dl class="jobs">
	<dt>Работа в Смоленске</dt>
	<dd>
		<a href="<%:  model.Vacancy.GetItemUri() %>" title=""><%: model.Vacancy.Title%></a>
		<span><%:model.Vacancy.GetCompensationTitle("")%></span>
		<small>р./мес</small>
		<a href="<%:  Url.Action("Vacancies", "Vacancy") %>" title="">и ещё <%: model.VacanciesCount.ToString("N0")%> вакансий</a>
	</dd>
</dl>	
<% } %>