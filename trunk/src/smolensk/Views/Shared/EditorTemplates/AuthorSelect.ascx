<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long[]>" %>

<div>
    <p>Введите начальные буквы фамилии автора (мин 3): <br /><input type="text" id="authorSearch" style="width:250px"/></p>
    <p>
        Варианты (щелкните два раза, чтобы добавить):<br />
    <select id="authorSuggestion" rows="5" size="5" cols="80" style="width:250px">
    </select></p>
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
     <p>Выбранные авторы (щелкните два раза, чтобы удалить):<br />
    <select id="authorSelection" multiple="multiple" style="width:250px">        
    </select>
    <div id="selectedAuthorsHidden">
        <% if (Model != null)
           { %>
        <% foreach (var i in Model)
           { %>
           <input type="hidden" name="<%= fname %>" value="<%= i %>"/>
           <% }
           }%>
    </div>
    </p>
</div>
<script type="text/javascript">
    $('#authorSearch').keydown(function () {

        var v = $(this).val();
        if (v.length > 2) {
            $('#authorSuggestion').load('/AccountList/GetSuggestion', { _q: v });
        }

    });

    <% if(Model != null) {  %>
        $('#authorSelection').load('/AccountList/GetLibArticleAuthorList', { _ids: [<%= String.Join(", ", Model) %>] });
    <% } %>

    $('#authorSuggestion').dblclick(function () {
        var $sel = $(this).find(':selected');
        var $target = $('#authorSelection');
        var exists = $target.find('option[value=' + $sel.attr('value') + ']').length;
        if (exists) return;
        $target.append($sel.outerHTML());
        $('#selectedAuthorsHidden').append('<input type="hidden" name="<%= fname %>" value="' + $sel.val() + '"/>');
    });

    $('#authorSelection').dblclick(function () {
        var $this = $('#authorSelection');
        var $sel = $this.find(':selected');
        $('#selectedAuthorsHidden').find('input[value=' + $sel.val() + ']').remove();
        $sel.remove();
    });


</script>