<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IEnumerable<smolensk.Models.ViewModels.VacancyViewModel>>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<p class="header">Похожие вакансии</p>
<table class="relatedVacancy">
    <% foreach (VacancyViewModel model in Model)
       {%>
        <tr>
            <td><a href="<%= model.GetItemUri() %>" title="<%:model.Title %>"><%:model.Title %></a></td>
            <td class="date"><%:Formatter.FormatVacancyDate(model.Created) %></td>
            <td class="price"><%:model.GetCompensationTitle() %></td>
        </tr>  
       <%} %>
</table>