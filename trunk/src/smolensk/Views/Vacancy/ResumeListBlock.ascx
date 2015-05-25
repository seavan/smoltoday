<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<smolensk.Models.ViewModels.ResumeViewModel>>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<% foreach (ResumeViewModel resume in Model)
           { %>
            <div class="resumeResult">
                <div class="avatar">
                    <a href="<%:resume.GetItemUri() %>">
                        <img src="<%: resume.PhotoUrl %>" width="76" height="76" alt="1" />
                    </a>
                    <p><%: resume.Salary.ToString("N0") %> р.</p>
                </div>
                <div class="infoBlock">
                    <p class="specialization"><a href="<%: resume.GetItemUri() %>" title="<%: resume.Post %>"><%:resume.Post %></a></p>
                    <p>
                        <% foreach (var proRoot in resume.Professionals)
                            for (int i = 0; i< proRoot.Children.Count; i++)
                            {
                                var pro = proRoot.Children[i];
                                %>
                                <span><%: pro.Title %></span>
                                <% if (i != proRoot.Children.Count - 1) 
                                   { %>
                                   /
                                <% } %>
                           <% }%>                        
                    </p>
                    <p>&nbsp;</p>
                    <p><%:resume.GetTitle() %></p>
                    <p>Регион: <%:resume.GetRegion() %></p>
                    <p>Опыт работы: <%:resume.GetExpTitle() %></p>
                    <p>Образование: <%:resume.GetEducationTitle() %></p>
                    <p>График работы: <%:resume.GetWorkModeTitle()%></p>
                                    
                    <span class="date">Обновлено <%:Formatter.FormatVacancyPublishDate(resume.Edited) %></span>
                </div>
            </div>   
           <%} %>  