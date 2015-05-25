<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<VacancyEntryViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<td style="vertical-align:top;">График работы</td>
<td>
    <% for (int i = 0; i <  Model.Count; i++)
       { %>
<span class="checkbox">
<%: Html.CheckBox("WorkMode["+i+"].Selected", Model[i].Selected)%><%: Model[i].Title %>
<%: Html.Hidden("WorkMode["+i+"].Id", Model[i].Id) %>
</span><br/>  
        <% } %>                                      	
</td>