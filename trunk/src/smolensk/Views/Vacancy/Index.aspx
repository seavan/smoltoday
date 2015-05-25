<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.SearchVacancyViewModel>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Mappers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

    <div class="vacancyList">
        <h3>Вакансии</h3>
        <div class="vacancyTools authBlock">
            <% if (Request.IsAuthenticated){ %>
                    <span class="button resume" onClick="window.location.href='<%: Url.Action("CreateResume", "Profile") %>'">Создать резюме</span>
                    <span class="button vacancy" onClick="window.location.href='<%: Url.Action("CreateVacancy", "Profile") %>'">Создать вакансию</span>
            <% } else {%>
                <span class="button resume enter">Создать резюме</span>
                <span class="button vacancy enter">Создать вакансию</span>
            <%}%>
        </div>

        <% Html.RenderPartial("SearchBlock", Model.SearchBlock); %>

        <% Html.RenderPartial("HowSearchWork"); %>

        <div class="randomVacancy">
            <% Html.RenderPartial("WorkInCompanies", Model.WorkInCompanies); %>
            <% Html.RenderPartial("VacanciesOfWeek", Model.WeekVacancies); %>
        </div>
        <div class="clear"></div>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <% Html.RenderPartial("Statistics", Meridian.Default.ToVacancyStatistic()); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
<% Html.RenderPartial("PopularityVacancies", Meridian.Default.GetPopularityVacancies()); %>
</asp:Content>
