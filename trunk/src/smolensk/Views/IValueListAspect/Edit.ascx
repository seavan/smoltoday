<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IValueListAspect>" %>
<%

    var prefix = Model.FieldName;
    var id = prefix + "ValueList";
    var saveFunction = "save" + id;
    var deleteFunction = "delete" + id;
    var addFunction = "add" + id;
    var controller = "IValueListAspect";
    var method = "Save";
    var parentProto = Model.GetParent().ProtoName;
    var parentId = Model.GetParent().id;
%>
<div>
    <table id="<%= id %>" data-uri="/<%= controller %>/<%= method %>" data-prefix="<%= prefix %>"
        data-parent-id="<%= parentId %>" data-parent-proto="<%= parentProto %>">
        <tbody>
            <% foreach (var item in Model.GetAllValues())
               {
            %>
            <tr>
                <td>
                    <input type="text" value="<%= item.Value %>" name="<%= Model.FieldName %>.<%= item.id %>" />
                </td>
                <td>
                    <a class="_link" onclick="<%= deleteFunction %>(<%= item.id %>)">удалить</a>
                </td>
                <td id="<%= Model.FieldName %>.<%= item.id %>.result">
                </td>
            </tr>
            <%
               } %>
            <tr class="_template _insert">
                <td>
                    <input type="text" value="" name="<%= Model.FieldName %>.new" />
                </td>
                <td>
                    новое значение
                </td>
                <td></td>
            </tr>
            <tr class="_adder">
                <td></td>
                <td><a class="_link" onclick="<%= addFunction %>()">добавить еще 10</a></td>
            </tr>
        </tbody>
    </table>

</div>
<div>
    <a class="_link" href="#" onclick="return saveFunction('#<%= id %>')" style="float: right">
        Сохранить справочник</a>
</div>
<script>
    if (saveCallbacks) {
        saveCallbacks.push(function () {
            saveFunction('#<%= id %>');
        });
    }
    
    function <%= deleteFunction %>(id) {
        $("input[name='<%= Model.FieldName %>." + id + "']").val('');
    }

    function <%= addFunction %>() {
        var $obj = $('#<%= id %>');
        var $template = $obj.find('._template');
        var $adder = $obj.find('._adder');
        var html = $template.html();
        var index = $obj.find('._insert').length - 1;
        
        for (var i = 0; i < 10; ++i) {
            $('<tr>' + html.replace(/\.new/g, '.new.' + (index++)) + '</tr>').insertBefore($adder);
        }
    }

    

</script>
