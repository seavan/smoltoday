<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<smolensk.Models.ViewModels.VacancyViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<dl class="popVacancy">
    <dt>Популярные вакансии</dt>
    <% foreach (VacancyViewModel model in Model)
        {%>
        <dd>
            <a href="<%: model.GetItemUri() %>" title="<%:model.Title %>"><%= HttpUtility.HtmlDecode(model.Title) %></a>
            <span class="price"><%:model.GetCompensationTitle() %></span>
            <p><%= HttpUtility.HtmlDecode(model.Company.Title) %></p>   
        </dd>
        <%}%>     
</dl>