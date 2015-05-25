<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>

<div id="_magazineType">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">        
    </select>
</div>
<script type="text/javascript">
    $('#_magazineType select').load('/AdminLibMagazineType/GetAllJquery', { _selected: <%= Model != null ? Model : 0 %> });
</script>