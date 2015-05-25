<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.VacancyStatisticViewModel>" %>
<%@ Import Namespace="smolensk.common" %>

<div class="advertMenu">
    <p>Сейчас на сайте:</p>
    <ul>
        <li><a href="<%: Url.Action("Vacancies", "Vacancy") %>" title=""><%: Model.Vacancies.ToString("N0") %> <%: Model.Vacancies.ToCounterWordForm(Int64Extensions.VacancyForm)%></a></li>
        <li><a href="<%: Url.Action("Resumes", "Vacancy") %>" title=""><%: Model.Resumes.ToString("N0") %> резюме</a></li>
        <li><a href="<%: Constants.VacancyCompaniesUrl %>" title=""><%: Model.Companies.ToString("N0") %> <%: Model.Companies.ToCounterWordForm(Int64Extensions.CompanyForm)%></a></li>
    </ul>
</div>

