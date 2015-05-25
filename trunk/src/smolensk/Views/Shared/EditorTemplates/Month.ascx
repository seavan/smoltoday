<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int?>" %>

<div class="_month">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1" data-selected="<%= Model %>">        
        <option value="1">������ 01</option>
        <option value="2">������� 02</option>
        <option value="3">���� 03</option>
        <option value="4">������ 04</option>
        <option value="5">��� 05</option>
        <option value="6">���� 06</option>
        <option value="7">���� 07</option>
        <option value="8">������ 08</option>
        <option value="9">�������� 09</option>
        <option value="10">������� 10</option>
        <option value="11">������ 11</option>
        <option value="12">������� 12</option>
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
