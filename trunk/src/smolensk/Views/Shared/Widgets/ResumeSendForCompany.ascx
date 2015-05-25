<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Mail.ResumeSendForCompanyModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<div class="enterForm send_resume _closest">
    <p>Отправить резюме</p>
    <small><b>Компания:</b> <%: Model.Company.title %></small>
                            
    <% using (Html.BeginForm("ResumeSendForCompany", "Vacancy"))
       {%>
       <%: Html.HiddenFor(m=>m.Company.id) %>
        <div class="resumeList">
            <p>Выберите резюме из списка:</p>
            <div id="scroll1" class="wrapper">
                <table>
                    <tr>
                        <th></th>
                        <th><span>Должность</span></th>
                        <th><span>Дата публикации</span></th>
                        <th class="cur up"><span>Дата последнего<br/>редактирования</span></th>
                    </tr>
                <% foreach (ResumeViewModel resume in Model.Resume)
                   {%>
                    <tr>
                        <td><span class="radio">
                                <%: Html.RadioButtonFor(m => m.ResumeId, resume.Id) %>
                            </span></td>
                        <td>
                            <%: resume.Post %>
<%--                            <% foreach (var proRoot in resume.Professionals)
                                   for (int i = 0; i < proRoot.Children.Count; i++)
                                   {
                                       var pro = proRoot.Children[i]; %>
                                    <a href="#" title="<%: pro.Title %>"><%: pro.Title %></a>
                                    <% if (i != proRoot.Children.Count - 1)
                                       { %>
                                       /
                                    <% } %>
                               <% }%>    --%>                        
                        </td>
                        <td><%: smolensk.Domain.Formatter.FormatVacancyPublishDate(resume.Created) %></td>
                        <td><%: smolensk.Domain.Formatter.FormatVacancyPublishDate(resume.Edited) %></td>
                    </tr>  
                    <% } %>
                </table>
            </div>
        </div>
                               
        <span class="button" onclick="$(this).closest('form').submit();">Отправить</span>
    <% } %>
</div>