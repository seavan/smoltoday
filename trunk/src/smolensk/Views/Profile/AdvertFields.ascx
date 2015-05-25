<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AdViewModel>" %>

<% for (int i = 0; i < Model.Properties.Count; i++)
    { %>
    <tr class="dynamic-advert-field">
        <td><%= Model.Properties[i].Title %></td>
        <td>
            <% if (Model.Properties[i].Values.Any())
                {%>
                    <%: Html.DropDownListFor(m => m.Properties[i].ValueId, new SelectList(Model.Properties[i].Values, "Key", "Value", Model.Properties[i].ValueId)) %>
                <%}
                else
                {%>
                    <%: Html.TextBoxFor(m => m.Properties[i].Value)%>
                <%}%>
                <%:Html.HiddenFor(m => m.Properties[i].DescriptionId)%>
        </td>
    </tr>
<% } %>