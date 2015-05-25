<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%
    SortedList<string, string> types = new SortedList<string, string>();
    types["citation"] = "Цитата";
    types["interview"] = "Интервью";
    types["magazine"] = "Журнал";
    types["conference"] = "Мероприятие";
    types["video_blog"] = "Видео из блога";
    types["video_standalone"] = "Видео";
    
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
%>
<div data-field="<%= fname %>">
    <input type="hidden" value="<%= Model %>" name="<%= fname %>" id="<%= fname %>"/>
    <% foreach (var item in types)
       {
           %>    
    <a style="float: left; font-size: 11px" class="_link" data-value="<%= item.Key %>"><%= item.Value %></a>
    <% } %>
       <br style="clear: both"/>
</div>
<script>
    var $field = $('*[data-field=<%= fname %>]');
    $field.selectTab = function ($obj) {
        $obj.parent().find('a').removeClass('_tabSelected');
        $obj.addClass('_tabSelected');

        var val = $obj.attr('data-value').split(',');
        var $fields = $('*[data-group=<%= fname %>]');
        var filter = '*[data-group-value*=' + val + ']';
        $fields.not(filter).hide();
        $fields.not(filter).find('input, textarea').val('');
        $fields.not(filter).find('._thisDisplay').html('');
        $fields.filter(filter).show();
        $('#<%= fname %>').val(val);
    };

    $field.find('a').click(function () {
        var $this = $(this);
        $field.selectTab($this);
    });

    $(document).ready(function () {
        var selected = $('#<%= fname %>').val();
        var $tabToSelect = $field.find('a[data-value=' + selected + ']');
        if ($tabToSelect.length == 0) {
            $tabToSelect = $field.find('a').first();
        }
        $field.selectTab($tabToSelect);
    });
</script>