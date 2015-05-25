<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<int?>" %>

<div class="_year">
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
    <select name="<%= fname %>" id="<%= fname %>" size="1" data-selected="<%= Model %>">        
    </select>
</div>
<script>
    $(document).ready(function () {
        var years = '';
        var i = 0;
        for (i = <%= DateTime.Now.Year %>; i > 1900; --i) {
            years += '<option value="' + i + '">' + i + '</option>';
        }

        $('._year select').html(years);
        $('._year select').each(function () {
            var $this = $(this);
            $this.val($this.attr('data-selected'));
        });
    });

</script>