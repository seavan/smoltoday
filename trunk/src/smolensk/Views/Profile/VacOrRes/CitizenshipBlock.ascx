<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<VacancyEntryViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<td style="vertical-align:top;">Гражданство</td>
<td>
    <% for (int i = 0; i <  Model.Count; i++)
       { %>
<span class="checkbox">
<%: Html.CheckBox("Citizenship[" + i + "].Selected", Model[i].Selected)%>
<%: Model[i].Title %>
<%: Html.Hidden("Citizenship[" + i + "].Id", Model[i].Id)%>
</span><br/>  
        <% } %>                                               	
</td>