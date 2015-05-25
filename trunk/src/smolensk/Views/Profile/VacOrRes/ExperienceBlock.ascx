<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<VacancyEntryViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<td style="vertical-align:top;">Опыт работы</td>
<td>
    <% for (int i = 0; i <  Model.Count; i++)
       { %>
<span class="checkbox">
<%: Html.CheckBox("Experience[" + i + "].Selected", Model[i].Selected)%>
<%: Model[i].Title %>
<%: Html.Hidden("Experience[" + i + "].Id", Model[i].Id)%>
</span><br/>  
        <% } %>                                               	
</td>