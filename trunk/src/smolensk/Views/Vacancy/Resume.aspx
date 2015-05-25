<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.ResumeViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Mail" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.GetTitle() %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

    <div class="vacancyOne">
        <h3><%: Model.GetFullName() %></h3>

        <p class="professionUser">
           <% foreach (var proRoot in Model.Professionals)
            for (int i = 0; i< proRoot.Children.Count; i++)
            {
                var pro = proRoot.Children[i];
                %>
                <span><%: pro.Title %></span>
                <% if (i != proRoot.Children.Count - 1) { %>
                    /
                <% } %>
            <% } %>
        </p>

        <div class="userGeneral">

            <img src="<%:Model.PhotoUrl %>" width="145" height="170" alt="1" />

			<div class="grayBlock">
                <table class="requirements resume">
                    <tr>
                        <td>Желаемый уровень зарплаты:</td>
                        <td><%: Model.Salary.ToString("N0") %> р.</td>
                    </tr>
                    <tr>
                        <td>Образование:</td>
                        <td><%:Model.Education.Title %></td>
                    </tr>
                    <tr>
                        <td>График:</td>
                        <td><%:Model.GetWorkModeTitle()%></td>
                    </tr>
                    <tr>
                        <td>Дата рождения:</td>
                        <td><%: Formatter.FormatLongDate(Model.BirthDate) %> г.</td>
                    </tr>
                    <tr>
                        <td>Гражданство:</td>
                        <td><%: Model.Citizenship.Title %></td>
                    </tr>
                    <% if (!string.IsNullOrEmpty(Model.GetPhone())) { %>
                    <tr>
                        <td>Телефон:</td>
                        <td><%: Model.GetPhone() %></td>
                    </tr>
                    <% } %>
                    <% if (!string.IsNullOrEmpty(Model.Email)) { %>
                    <tr>
                        <td>Эл. почта:</td>
                        <td><%: Model.Email %></td>
                    </tr>
                    <% } %>
                </table>
            </div>
        </div>

        <% if (Model.Educations != null && Model.Educations.Count > 0) { %>
        <h4>Образование</h4>
        <% foreach (resume_educations edu in Model.Educations)
           {
               string dateStr = string.Format("{0} - {1} г",
                                              Formatter.FormatMonthAndYear(edu.begin_date),
                                              Formatter.FormatMonthAndYear(edu.end_date));
               %>
            <dl class="userAdditional">
                <dt><%: dateStr %></dt>
                <dd><%: edu.address %>. Специальность «<%: edu.specialty %>» Квалификация: ?? </dd>
            </dl>
           <% } %>
        <% } %>

        <% if (Model.Works != null && Model.Works.Count > 0) { %>
        <h4>Опыт работы</h4>
        <% foreach (resume_works work in Model.Works)
           {
               string dateStr;
               if (work.end_date.HasValue())
               {
                   dateStr = string.Format("{0} - {1} г",
                                           Formatter.FormatMonthAndYear(work.begin_date),
                                           Formatter.FormatMonthAndYear(work.end_date));
               }
               else
               {
                   dateStr = string.Format("{0} г", Formatter.FormatMonthAndYear(work.begin_date));
               }
        %>
            <dl class="userAdditional">
                <dt><%: dateStr %></dt>
                <dd>
                    <p><%: work.company_name %></p>
				    <p><b><%: work.post %></b></p>
				    <ul>
                        <% foreach (string line in work.success_description.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) { %>
                           <li><%: line.PadLeft(1, '-').PadRight(1, ';') %></li>
                        <% } %>
                    </ul>
                </dd>
            </dl>  
           <% } %>
        <% } %>

        <% if (!string.IsNullOrEmpty(Model.AboutMySelf)) { %>
		<h4>О себе</h4>
        <%
            bool first = true;
            foreach (string line in Model.AboutMySelf.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) { %>
            <p class="<%: first ? "nospace": "" %>">
                <%: line.PadRight(1,'.') %>
            </p>
            <%
                first = false;
            } %>
		<% } %>

        <% if (Model.Links != null && Model.Links.Length > 0) { %>
        <h4>Ссылки на портфолио и личные страницы:</h4>
        <p>
            <% foreach (string link in Model.Links) { %>
                <a href="<%: link %>" title="<%: link %>" class="userPersonalLink"><%: link %></a>
            <% } %>
        </p>
        <% } %>

        <% if (!string.IsNullOrEmpty(Model.Address)) { %>
        <h4>Контакты</h4>
        <p class="nospace">Адрес: <%: Model.Address %></p>
        <% } %>
        <% if (!string.IsNullOrEmpty(Model.GetPhone())) { %>
		<p class="nospace">Телефон: <%: Model.GetPhone()%></p>
        <% } %>
        <% if (!string.IsNullOrEmpty(Model.Email)) { %>
		<p>Электронная почта: <%:Model.Email %></p>
        <% } %>
        <div class="buttonPanel resume">
            <span class="button answer">Пригласить</span>
            <%--<span class="button print"><span></span>Печать страницы</span>--%>
            <%Html.RenderPartial("ButtonFavorite", Model.DbEntity); %>
            <% if (SecurityService.IsAuthorize) { %>
            <a href="#" title="Пожаловаться" class="complaintLink">Пожаловаться</a>  
            <% } %>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <div class="vacancyInfo resume">
        <p>ID резюме #<%:Model.Id %></p>
		<p>Обновлено <%:Formatter.FormatVacancyPublishDate(Model.Edited) %></p>
    </div>
    <% Html.RenderPartial("SimilarResumes", Model.GetSimilarResumes()); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="popUpLayer">
    <% Html.RenderPartial("Widgets/ComplaintSend", new MaterialComplaintMailModel()); %>
    <% Html.RenderPartial("InvitationSend", new InvitationSendMailModel() { ResumeId = Model.Id }); %>
</asp:Content>