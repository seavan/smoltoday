<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="admin.common" %>
<%@ Import Namespace="admin.db" %>
<div class="_editor">
<% if (Model == null) { %>
    <%= ViewData.ModelMetadata.NullDisplayText %>
<% } else if (ViewData.TemplateInfo.TemplateDepth > 1) { %>
    <%= ViewData.ModelMetadata.SimpleDisplayText %>
<% } else { %>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 1000px; margin: auto">
    <%
    var props = ViewData.ModelMetadata.Properties.Where(pm => pm.ShowForDisplay && !ViewData.TemplateInfo.Visited(pm) && (pm.AdditionalValues.Count(s => s.Key.Equals("HideEdit")) == 0));
    var step = ViewData["Step"];
    if (step != null)
        props = props.Where(pm => pm.AdditionalValues.SingleOrDefault(s => s.Key == "Wizard").Value != null).
            Where(
                pm =>
                (pm.AdditionalValues["Wizard"] as admin.common.WizardAttribute).Step == (int) step);
        %>
    <% foreach (var prop in props)
{

    bool optional = prop.AdditionalValues.Any(s => s.Key.Equals("Optional"));
    bool required = prop.AdditionalValues.Any(s => s.Key.Equals("Required"));
    bool creationOnly = (Model is IDatabaseEntity) && (((IDatabaseEntity)Model).id <= 0) && prop.AdditionalValues.Any(s => s.Key.Equals("CreationOnly"));
    bool nulled = prop.Model == null;

    var group = (GroupAttribute)(prop.AdditionalValues.ContainsKey("Group") ? prop.AdditionalValues["Group"] : null);
    if (group == null)
    {
        group = new GroupAttribute();
        
    }
    %>
        
        <% if (prop.HideSurroundingHtml) { %>
            <%= Html.Editor(prop.PropertyName) %>
        <% } else { %>
            
            <tr data-group="<%= group.GroupFieldName %>"  data-group-value="<%= group.GroupFieldValue %>">
                <td style="width:200px; vertical-align: top">
                <% if (optional)
{%>
                <input type="checkbox" class="_optionalEnabler" <%= prop.Model != null ? "checked" : "" %>/>
                <%
}%>
                    <div class="display-label" style="text-align: right;">
                        <%= prop.GetDisplayName() %>
                                            <%
                        if (required)
                        {
                            %>
                            <span style="color: red; font-weight: bold">*</span>
                                <%
                        }
                         %>
                    </div>
                </td>
                <td>
                    <%
                        Html.RenderPartial("ComplexEditField", Model, new ViewDataDictionary() {{"prop", prop}, {"optional", optional}, {"parentModel", Model}}); %>
                </td>

                <td style="width:70px">
                    <%= Html.ValidationMessage(prop.PropertyName) %>
                </td>
            </tr>
        <% } %>
    <% } %>
    </table>
<% } %>
</div>