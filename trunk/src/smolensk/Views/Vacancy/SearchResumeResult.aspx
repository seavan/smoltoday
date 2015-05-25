<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.ResumeListViewModel>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

   <div class="vacancySearchResult">
       
        <% Html.RenderPartial("SearchBlock", Model.SearchBlock); %>

        <h3>Результаты поиска по резюме</h3>
        <p class="searchName">По запросу “<%: Model.SearchBlock.Query %>”</p>
                    
        <% Html.RenderPartial("ResumeListBlock", Model.Resumes); %>
    </div>
                        
    <div style="clear:both;"><br/><br/></div>
                        
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
