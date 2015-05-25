<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string[]>" %>
<div>
    <p>Введите имя автора и нажмите Enter: <br /><input type="text" id="authorUnregSearch" style="width:250px"/></p>
    <%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>
     <p>Выбранные авторы (щелкните два раза, чтобы удалить):<br />
    <select id="authorUnregSelection" multiple="multiple" style="width:250px">
        <% if (Model != null)
           { %>
            <% foreach (var a in Model)
               { %>        
               <option value="<%= a %>"><%= a %></option>
            <% } %>
            <% } %>
    </select>
    <div id="selectedAuthorsUnregHidden">
        <% if(Model != null)
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
    $('#authorUnregSearch').keydown(function (e) {
        var keyCode = e.keyCode || e.which;

        if (keyCode == 13) {
            var val = $('#authorUnregSearch').val();
            $('#authorUnregSelection').append('<option value="' + val + '">' + val + '</option>');
            $('#selectedAuthorsUnregHidden').append('<input type="hidden" name="<%= fname %>" value="' + val + '"/>');
            return false;
        }
    });

    $('#authorUnregSelection').dblclick(function () {
        var $this = $('#authorUnregSelection');
        var $sel = $this.find(':selected');
        var $iVal = $('#selectedAuthorsUnregHidden').find('input[value="' + $sel.val() + '"]');


        $iVal.remove();
        $sel.remove();
    });


</script>