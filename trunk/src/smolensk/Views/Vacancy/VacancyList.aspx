<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.VacancyListViewModel>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

    <div class="vacancySearchResult">
        <% Html.RenderPartial("SearchBlock", Model.SearchBlock); %>
        <h3>Все вакансии</h3>
              
        <% Html.RenderPartial("VacancyListBlock", Model.Vacancies); %>                               
    </div>
                  
    <% if (Model.TotalPages > 1)
       { %>      
    <% Html.RenderPartial("Widgets/Pager", new {pageN = Model.CurrentPage, pageTotal = Model.TotalPages}); %>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
<% Html.RenderPartial("Statistics", Meridian.Default.ToVacancyStatistic()); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
