<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.CompanyViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Mail" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Title %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="popUpLayer">
    <% accounts user = Html.UserPrincipal();
       if (user != null)
       {
           Html.RenderPartial("Widgets/ResumeSendForCompany",
                              new ResumeSendForCompanyModel
                                  {
                                      Company = Meridian.Default.companiesStore.Get(Model.Id),
                                      Resume = user.GetPublishResumes()
                                          .Select(r => Meridian.Default.ToResumeViewModel(r))
                                          .ToList(),
                                  });
       }%>    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">
    
    <script type="text/javascript">
        function showFullDescription() {
            $("p[id=desc] span[id=short]").hide();
            $("p[id=desc] span[id=full]").show();
            $("p[id=desc] a").hide();
        }
    </script>

    <div class="vacancyCompany">
        <h3><%: Model.Title %></h3>
        <div class="vacancyTools">
            <% if (Html.UserPrincipal() != null && Html.UserPrincipal().GetPublishResumes().Any())
               {%>
            <%--<span class="button sendResume">Отправить резюме</span>--%>
            <span class="button vacancy">Отправить резюме</span>
            <% } %>                                        	
        </div>
                            
                            
        <p class="oneCompanyLink">Сайт компании: <a href="http://<%=Model.Www %>" title="http://<%=Model.Www %>">http://<%=Model.Www %></a></p>
                            
        <h4>О компании</h4>
                            
       <% Html.RenderPartial("ShowDescription", Model); %>
                            
        <div class="grayLine"></div>
                          
        <h4>Вакансии компании (<%:Model.Vacancies.Count %>)</h4>
        <table class="relatedVacancy">
            <% foreach (VacancyViewModel vacancy in Model.Vacancies)
               { %>
            <tr>
                <td><a href="<%: vacancy.GetItemUri() %>" title="<%:vacancy.Title %>"><%:vacancy.Title %></a></td>
                <td class="city"><%:vacancy.City.Value %></td>
                <td class="date"><%:Formatter.FormatVacancyPublishDate(vacancy.Edited) %></td>
                <td class="price"><%: vacancy.GetCompensationTitle() %></td>
            </tr>  
               <%} %>
        </table>                           
                            
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
<% Html.RenderPartial("Statistics", Meridian.Default.ToVacancyStatistic()); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
