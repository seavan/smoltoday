<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<meridian.smolensk.proto.companies>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<div class="inCompany">
<dl>
    <dt>Работа в компаниях</dt>
    <% foreach (companies company in Model)
        {%>
<dd><a href="<%: company.ItemVacancyUri()%>" title="<%:company.title %>"><%= HttpUtility.HtmlDecode(company.title) %></a><span><%: company.CountOfActualVacancies().ToCounterWordForm(Int64Extensions.VacancyForm, false)%></span></dd>
        <%} %>
</dl>
<br/>
<a href="<%: Url.Action("SearchCompany","Vacancy") %>" title="Все компании">Все компании</a> 
<%--<a href="#" title="Все отрасли">Все отрасли***</a>--%>
</div>