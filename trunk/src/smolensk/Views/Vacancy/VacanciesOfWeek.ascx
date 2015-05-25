<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<smolensk.Models.ViewModels.VacancyViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<div class="fromWeek">                                	
    <dl>
        <dt>Вакансии недели</dt>
        <% foreach (VacancyViewModel vacancy in Model){ %>
            <dd>
            <a href="<%: vacancy.GetItemUri() %>" title="<%:vacancy.Title %>"><%= HttpUtility.HtmlDecode(vacancy.Title)%></a>
            <span><%:vacancy.GetCompensationTitle() %></span>
            <span class="company"><%= HttpUtility.HtmlDecode(vacancy.Company.Title) %></span>
        </dd>
            <%} %>
    </dl>
    <br/>
    <a href="<%: Url.Action("Vacancies","Vacancy") %>" title="Все вакансии">Все вакансии</a>
</div>