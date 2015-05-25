<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int?>" %>

<div class="_month">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1" data-selected="<%= Model %>">        
        <option value="1">€нварь 01</option>
        <option value="2">ферваль 02</option>
        <option value="3">март 03</option>
        <option value="4">апрель 04</option>
        <option value="5">май 05</option>
        <option value="6">июнь 06</option>
        <option value="7">июль 07</option>
        <option value="8">август 08</option>
        <option value="9">сент€брь 09</option>
        <option value="10">окт€брь 10</option>
        <option value="11">но€брь 11</option>
        <option value="12">декабрь 12</option>
    </select>
</div>

<script>
    $(document).ready(function () {
        $('._month select').each(function () {
            var $this = $(this);
            $this.val($this.attr('data-selected'));
        });
    });
</script>
