<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<VacancyEntryViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<td style="vertical-align:top;">Тип занятости</td>
<td>
    <% for (int i = 0; i <  Model.Count; i++)
       { %>
<span class="checkbox">
<%: Html.CheckBox("WorkType["+i+"].Selected", Model[i].Selected)%>
<%: Model[i].Title %>
<%: Html.Hidden("WorkType["+i+"].Id", Model[i].Id) %>
</span><br/>  
        <% } %>                                               	
</td>