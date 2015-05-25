<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.ResumeListViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Резюме</h3>
        <div class="profileTools">
                <div class="sortingTools">
                    <ul>
                        <li><a href="<%: Url.Action("CreateResume", "Profile") %>" title="Создать резюме"><span>Создать резюме</span></a></li>
                    </ul>
                </div>
                <div class="formLine">
                    <ul class="radioLine">
                        <li><span class="radio" data-url="<%: Url.Action("ResumeList","Profile",new {onlyFavorites=false}) %>">
                                <input type="radio" name="photo" value="1" <%=!Model.OnlyFavorites ? "checked = 'checked'" : "" %>/>Мои резюме</span></li>
                        <li><span class="radio" data-url="<%: Url.Action("ResumeList","Profile",new {onlyFavorites=true}) %>">
                                <input type="radio" name="photo" value="1" <%=Model.OnlyFavorites ? "checked = 'checked'" : "" %>/>Избранные</span></li>
                    </ul>
                </div>
        </div>
    </div>

    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>Должность</th>
                <th>Дата<br/>публикации</th>
                <th>Обновлено</th>
                <th>Ссылка</th>
                <% if (!Model.OnlyFavorites)
                   {%>
                <th>Статус</th>
                <th>&nbsp;</th>
                <% } %>
            </tr>
            <% for (int i = 0; i < Model.Resumes.Count; i++)
               {
                   ResumeViewModel resume = Model.Resumes[i];%>
                <tr>
                    <td>
                        <%: resume.Post %>
                        <!-- NOTE: Судя по шаблону должно быть это, но называется должность. Раскомментить, если я ошибся -->
<%--                       <% foreach (var proRoot in resume.Professionals)
                        for (int i = 0; i< proRoot.Children.Count; i++)
                        {
                            var pro = proRoot.Children[i];
                            %>
                            <span><%: pro.Title %></span>
                            <% if (i != proRoot.Children.Count - 1) 
                                { %>
                                /<br/>
                            <% } %>
                        <% }%> --%>       
                    </td>                                    
                    <td class="date"><%= Formatter.FormatResumeDate(resume.Created) %></td>
                    <td class="date"><%= Formatter.FormatResumeDate(resume.Edited) %></td>
                    <td><a href="<%:Url.Action("Resume","Vacancy", new {Id = resume.Id}) %>" title="Перейти">Перейти</a></td>
                <% if (!Model.OnlyFavorites)
                   {%>
                    <td><span class="checkbox <%: resume.IsPublish ? "hide" : "" %>" data-url="<%: Url.Action("TogglePublishResume", new {id = resume.Id}) %>">
                            <input type="checkbox" <%: resume.IsPublish ? "checked=checked" : "" %>/>опубликовано
                        </span></td>
                    <td>
                        <a href="<%: Url.Action("EditResume", "Profile", new {Id = resume.Id}) %>"><span class="edit" title="Редактировать" ></span></a>
                        <span class="delete" title="Удалить" data-url="<%: Url.Action("DeleteResume", "Profile", new { Id=resume.Id }) %>"></span>
                    </td>
                    <% } %>
                </tr>
               <%} %>
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
