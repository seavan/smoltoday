<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<meridian.smolensk.proto.vacancy_facilities>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

                          	
<tr>
    <td style="vertical-align:top;">Выберите категорию<br/>льгот</td>
    <td>
        <% for (int i = 0; i < Model.Count; i++)
            {
                var facility = Model[i];
                %>
            <div class="facilities">
                <span class="checkbox">
<%: Html.CheckBox("Facilities["+i+"].Checked", facility.Checked) %>
<%: Html.Hidden("Facilities["+i+"].id", facility.id) %>
                </span><%: Model[i].title %>

<%: Html.DropDownList("Facilities["+i+"].SelectedVariant.id", facility.GetVariants()
.Select(v => new SelectListItem
{
    Text = v.title,
    Value = v.id.ToString(),
    Selected = v.id == facility.SelectedVariant.id
}))%>
            </div> 
           <%} %>
    </td>
</tr>
