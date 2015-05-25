<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<div id="_partType">
    <%
        var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">
    </select>
</div>
<script>
    window.updatePartTypes = function() {
        $('#_partType select').load('/AdminLibPartTypes/GetAllJquery?_magType=' + $('#_magazineType select').val() +
        '&_selected=<%= Model %>');
    }
</script>

