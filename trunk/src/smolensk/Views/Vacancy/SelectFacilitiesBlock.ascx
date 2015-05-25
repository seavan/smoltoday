<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.SearchVacancyOrResumeViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<table class="createBlock" style="margin-top:-20px;">    
    <tr>
        <td> 
            <div class="createSubForm" style="text-align: left;">
                <span class="addSubFormButton">Желаемые льготы</span>
                <div class="body">
                    <% foreach (vacancy_facilities facility in Model.Facilities)
                        {  %>
                            <div class="facilities">
                                <span class="checkbox"><%: Html.SimpleCheckBox("FacilityIds", facility.id, Model.FacilityIds.Contains(facility.id)) %><%: facility.title %></span>
                                <%: Html.DropDownList("FacilityValueIds", facility.GetVariants().Select(v => new SelectListItem { Text = v.title, Value = v.id.ToString(), Selected = Model.FacilityValueIds.Contains(v.id) }))%>
                            </div>
                        <% } %>
                    <br/>
                </div>
            </div>
        </td>
    </tr>        
</table>