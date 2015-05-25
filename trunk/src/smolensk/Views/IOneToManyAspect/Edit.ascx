<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IOneToManyAspect>" %>
<%
    var prefix = Model.FieldName;
    var id = prefix + "OneToMany";
    var saveFunction = "save" + id;
    var controller = "IOneToManyAspect";
    var method = "Save";
    var parentProto = Model.GetParent().ProtoName;
    var parentId = Model.GetParent().id;
%>
<div id="<%= id %>" data-uri="/<%= controller %>/<%= method %>" data-prefix="<%= prefix %>"
    data-parent-id="<%= parentId %>" data-parent-proto="<%= parentProto %>">
    <table>
        <%

            var availableValues = Model.GetAvalableValues();
            var selectedValues = Model.GetSelectedValues();
            var fieldName = String.Format("{0}.value", prefix);
        %>
        <tr>
            <%
                var index = 0;
                foreach (var v in availableValues)
                {
                    var cbFieldName = String.Format("{0}.{1}", fieldName, v.id);
            %>
            <td style="width: 25%">
                <input type="checkbox" id="<%= cbFieldName %>" name="<%= cbFieldName %>" <%= selectedValues.Any(s => s.id.Equals(v.id)) ? "checked" : "" %> /><label
                    for="<%= cbFieldName %>">
                    <%= v.lookup_title %></label>
            </td>
            <%
                    if (index++ > 2)
                    {
                        index = 0;
            %>
        </tr>
        <tr>
            <%
                    }


                }
            %>
        </tr>
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
</script>
