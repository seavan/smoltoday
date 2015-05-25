<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<VacancyViewModel>" %>
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
    <% Html.RenderPartial("Widgets/NoResumeForm", new NoResumeMailModel
                                                    {
                                                        CompanyTitle = Model.Company.Title,
                                                        Vacancy = Meridian.Default.vacanciesStore.Get(Model.Id),
                                                    });%>
                                                    
    <% accounts user = Html.UserPrincipal();
       if (user != null)
       {
           Html.RenderPartial("Widgets/ResumeSend", new ResumeSendModel
                                                        {
                                                            Vacancy = Meridian.Default.vacanciesStore.Get(Model.Id),
                                                            Resume = user.GetPublishResumes()
                                                                .Select(r => Meridian.Default.ToResumeViewModel(r))
                                                                .ToList(),
                                                        });
       }%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">
    <script src="/content/js/vacancies.js" type="text/javascript"></script>
    <script type="text/javascript">
        $().ready(function () {
            InitVacancyOne('<%= Url.Action("GetPhoneImage", new {vacancyId=Model.Id}) %>');
        });
    </script>


    <div class="vacancyOne">
        <h3><%: Model.Title %></h3>
        <p class="vacancyNum">#<%: Model.Id %></p>
        <p class="companyName"><%: Model.Company.Title %></p>
        <p class="salary"><%: Model.GetCompensationTitle() %></p>
        <div class="buttonPanel">
            <%--<span class="button answer">Откликнуться</span>--%>
            <%--<span class="button print"><span></span>Печать страницы</span>--%>
            <% Html.RenderPartial("ButtonFavorite", Model.Favorite); %>
            <%--<span class="button tofriend">Предложить другу</span>--%>
        </div>
                            
        <div class="grayBlock">
            <table class="requirements">
                <%if (Model.Experience.Any()){%>
                <tr>
                    <td>Требуемый опыт:</td>
                    <td><%: Model.Experience.First().Title %></td>
                </tr>
                <%} %>
                <%if (Model.Education != null){%>
                <tr>
                    <td>Образование:</td>
                    <td><%: Model.Education.Title %></td>
                </tr>
                <%} %>
                <%if (Model.WorkMode.Any()){%>
                <tr>
                    <td>График:</td>
                    <td><%: VacancyViewModel.Enumerate(Model.WorkMode) %></td>
                </tr>
                <%} %>
            </table>
        </div>

        <p><%: Model.Description %></p>
 
	    <p class="nospace"><b>Обязанности:</b></p>
        <ul>
            <% foreach (string line in Model.Responsibility.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) { %>
               <li><%= line %></li>
            <% } %>
        </ul>
 
	    <% if (string.IsNullOrEmpty(Model.Requirements)) { %>
        <p class="nospace"><b>Требования:</b></p>
        <ul>
            <% foreach (string line in Model.Requirements.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) { %>
               <li><%= line %></li>
            <% } %>
        </ul>
        <% } %>
 
	    <p class="nospace"><b>Условия:</b></p>
        <ul>
            <% foreach (string line in Model.Terms.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) {%>
               <li><%= line %></li>
            <% } %>
        </ul>
 
	    <p><b>Профессиональные области:</b></p>
        <% foreach (VacancyProfessionalViewModel pro in Model.Professionals) { %>
            <p class="nospace"><b><%: pro.Title %></b></p>
            <ul class="marker">
             <% foreach (VacancyProfessionalViewModel sub in pro.Children) { %>
                <li><%: sub.Title %></li>
             <% } %>
           </ul>
        <% } %>

	    <% if (Model.ShouldDisplayPreferences) { %>
        <p><b>Предпочтения:</b> Возраст <%: Model.GetAgeTitle()%> лет, <%: Model.GetSexTitle()%></p>
        <% } %>

        <% var workPlaceList = new List<string>();
           if (Model.WorkRegion != null && !string.IsNullOrEmpty(Model.WorkRegion.Value))
                workPlaceList.Add(Model.WorkRegion.Value);
           if (Model.WorkCity != null && !string.IsNullOrEmpty(Model.WorkCity.Value))
                workPlaceList.Add(Model.WorkCity.Value);
           if (!string.IsNullOrEmpty(Model.WorkAddress))
                workPlaceList.Add(Model.WorkAddress);
        %>

        <% if (workPlaceList.Count > 0) { %>
	    <p><b>Место работы:</b><%: string.Join(", ", workPlaceList) %></p>
        <%} %>

        <% if (!string.IsNullOrEmpty(Model.ContactPerson)) { %>
        <p><b>Контактное лицо:</b> <%: Model.ContactPerson %></p>
        <% } %>
 
	    <p><span class="phoneHide">(<%: Model.GetHideContactPhone()%>) показать телефон</span></p>
        <br/>
        <div class="grayBlock">
            <% if (Html.UserPrincipal() != null && Html.UserPrincipal().GetPublishResumes().Any()) { %>
            <span class="button sendResume">Отправить резюме</span>
            <% } %>
            <span class="noResume">Откликнуться без резюме</span>
        </div>
       <%-- <div class="buttonPanel">
            <span class="button print"><span></span>Печать страницы</span>
            <%Html.RenderPartial("ButtonFavorite", Model.Favorite); %>
            <span class="button tofriend">Предложить другу</span>
        </div>--%>
        <br/>
        <% Html.RenderPartial("SimilarJobs", Model.GetSimilarVacancies()); %>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <div class="companyInfo">
        <span class="arrow"></span>
        <div class="companyName">
            <a href="<%= Model.Company.GetItemUri() %>"><img src="<%= Model.Company.LogoUrl %>" width="142" alt="<%= Model.Company.Title %>" /><br/> 
            <%= Model.Company.Title %></a>
            <%= Model.City.Value %>
        </div>
        <div class="info">
            <em>Контактное лицо</em>
			<p><%= Model.ContactPerson %></p>
            <p class="phone">
                <span class="phoneHide">(<%: Model.GetHideContactPhone() %>) показать телефон</span>
            </p>
            <a href="<%: Model.Company.GetItemVacancyUri() %>" title="Все вакансии компании (<%:Model.CountVacancies %>)">Все вакансии компании (<%:Model.CountVacancies %>)</a>
        </div>
    </div>

    <div class="vacancyInfo">
        <p>ID вакансии #<%: Model.Id %></p>
		<p>Опубликовано <%: Formatter.FormatVacancyPublishDate(Model.Created) %></p>
		<p>Обновлено <%: Formatter.FormatVacancyPublishDate(Model.Edited) %></p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
<% Html.RenderPartial("PopularityVacancies", Meridian.Default.GetPopularityVacancies()); %>
</asp:Content>
