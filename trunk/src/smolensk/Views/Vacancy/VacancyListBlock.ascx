<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<smolensk.Models.ViewModels.VacancyViewModel>>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<% foreach (VacancyViewModel vacancy in Model)
    {%>
    <div class="vacancyResult">
        <a href="<%= vacancy.GetItemUri() %>"><%:vacancy.Title %></a>
        <p><%:vacancy.Company.Title %></p>
        <span class="date"><%:Formatter.FormatVacancyDate(vacancy.Created) %></span>
        <span class="price"><%:vacancy.GetCompensationTitle() %></span>
    </div>  
    <%} %>  