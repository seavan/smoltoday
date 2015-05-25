<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<% var f = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty); %>
<div>
<textarea id="<%= f %>" name="<%= f %>" rows="30" cols="120" class="_visual">
<%= Model %>
</textarea>
</div>
<script language="javascript" type="text/javascript">

</script>