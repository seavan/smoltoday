<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IEnumerable<smolensk.Models.ViewModels.ResumeViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<dl class="popVacancy resume">
	<dt>Похожие резюме</dt>
    <% foreach (ResumeViewModel resume in Model)
       {%>
            <dd>
            <a href="<%: resume.GetItemUri() %>" title="<%:resume.GetShortName() %>"><%:resume.GetShortName() %></a>
            <p><%:resume.GetRegion() %>, <%: resume.GetAgeTitle() %></p>     
            </dd>
       <%} %>
</dl>