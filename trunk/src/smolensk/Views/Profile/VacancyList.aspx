<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.VacancyListViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Вакансии</h3>
        <div class="profileTools">
            <div class="sortingTools">								
                <ul>
                    <li><a href="<%: Url.Action("CreateVacancy","Profile") %>" title="Создать вакансию"><span>Создать вакансию</span></a></li>			                
                </ul>									
            </div>
            <div class="formLine">
                <ul class="radioLine">
                    <li><span class="radio" data-url="<%: Url.Action("VacancyList", "Profile", new {onlyFavorites=false}) %>">
                            <input type="radio" value="1" <%: Model.OnlyFavorites? "" : "checked='checked'" %>/> Мои вакансии
                        </span></li>
                    <li><span class="radio" data-url="<%: Url.Action("VacancyList", "Profile", new {onlyFavorites=true}) %>">
                            <input type="radio" value="2" <%: !Model.OnlyFavorites? "" : "checked='checked'" %> /> Избранные
                        </span></li>                                            
                </ul>
            </div>
        </div>
    </div>
                        
    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>Должность</th>
                <th>Компания</th>
                <th>Дата<br/>публикации</th>
                <th>Обновлено</th>
                <th>Ссылка</th>
                <% if (!Model.OnlyFavorites)
                   {%>
                <th>Статус</th>
                <th>&nbsp;</th>
                <% } %>
            </tr>
            
            <% for (int i = 0; i < Model.Vacancies.Count; i++)
               {
                   VacancyViewModel vacancy = Model.Vacancies[i];%>
            <tr>
                <td><%: vacancy.Title%></td>       
                <td><%: vacancy.Company.Title %></td>                             
                <td class="date"><%= Formatter.FormatResumeDate(vacancy.Created) %></td>
                <td class="date"><%= Formatter.FormatResumeDate(vacancy.Edited)%></td>
                <td><a href="<%:Url.Action("Vacancy","Vacancy", new {Id = vacancy.Id}) %>" title="Перейти">Перейти</a></td>  
                <% if (!Model.OnlyFavorites)
                   {%>
                    <td><span class="checkbox <%: vacancy.IsPublish ? "hide" : "" %>" data-url="<%: Url.Action("TogglePublishVacancy", new {id = vacancy.Id}) %>">
                            <input type="checkbox" <%: vacancy.IsPublish ? "checked=checked" : "" %>/>опубликовано
                        </span></td>
                    <td>
                        <a href="<%: Url.Action("EditVacancy", "Profile", new {Id = vacancy.Id}) %>"><span class="edit" title="Редактировать" ></span></a>
                        <span class="delete" title="Удалить" data-url="<%: Url.Action("DeleteVacancy", "Profile", new { Id=vacancy.Id }) %>"></span>
                    </td>
                    <% } %>    
            </tr>
             <% } %>
        </table>
    </div>
                        
    <% if (Model.TotalPages > 1) { %>
            <% Html.RenderPartial("Widgets/Pager", new {pageN = Model.CurrentPage, pageTotal = Model.TotalPages}); %>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
