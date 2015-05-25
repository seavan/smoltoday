<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IDictionaryValuesAspect>" %>

<div>
    <%
        var cats = Model.GetCategories();
        var values = Model.GetValues();
        var prefix = Model.FieldName;
        var id = prefix + "Dictionary";
        var saveFunction = "save" + id;
        var controller = "IFixedDictionaryAspect";
        var method = "Save";
        var parentProto = Model.GetParent().ProtoName;
        var parentId = Model.GetParent().id;
    %>
    <table id="<%= id %>" data-uri="/<%= controller %>/<%= method %>" data-prefix="<%= prefix %>" data-parent-id="<%= parentId %>" data-parent-proto="<%= parentProto %>">
    <%
        foreach (var cat in cats)
        {
            var availableValues = cat.GetAllValues();
            var fieldName = String.Format("{0}.{1}.value", prefix, cat.id);
            %>
            <tr>
                <%if (cat.Selectable){%>
                <td>
                    <label for="<%= fieldName %>_c"><input type="checkbox" id="<%= fieldName %>_c" name="<%= fieldName %>_c"  <%= values.Any(s => s.Category != null && s.Category.id.Equals(cat.id)) ? "checked" : "" %>/> <%= cat.title %></label>
                </td>
                <%}else{%>
                <td><%= cat.title %></td>
                <%} %>
                
                <td>
                    <% if (cat.MultiValue)
                       {
                           foreach (var v in availableValues)
                           {
                               var cbFieldName = String.Format("{0}.{1}", fieldName, v.ValueId);
                    %>
                            <label for="<%= cbFieldName %>" ><input type="checkbox" id="<%=cbFieldName%>" name="<%=cbFieldName%>" <%= values.Any(s => s.ValueId.Equals(v.ValueId)) ? "checked" : "" %>/><%= v.Value %></label><br/>
                       
                    <%
                           }
                       } else { 
                           if(cat.FreeValue)
                           {
                               var value = values.FirstOrDefault(s => s.Category != null && s.Category.id.Equals(cat.id));
                               
                               %>
                           
                           <input type="text" name="<%=fieldName%>" value="<%:value!=null ? value.FreeValue : string.Empty %>" style="width:100px;"/>
                           
                           <%} else {%>

                            <select name="<%=fieldName%>">
                                <%if (cat.ShowIsNoSelect){%>
                                <option value="0">не выбрано</option>
                                <%} %>
                                <%
                            
                                    foreach (var v in availableValues)
                                    {
                                %>
                                        <option value="<%= v.id %>" <%= values.Any(s => s.Category != null && s.Category.id.Equals(cat.id) && s.ValueId.Equals(v.id)) 
                                         ? "selected" : "" %>><%= v.Value %></option>
                                            <%
                                    }
                                            %>
                        
                            </select>
                        <%}%>
                    <% } %>
                </td>
            </tr>
            <%
        }
         %>
    </table>
    <div>
        <a class="_link" href="#" onclick="return saveFunction('#<%= id %>')" style="float: right">Сохранить справочник</a>
    </div>
</div>
<script>
    if (saveCallbacks) {
        saveCallbacks.push(function () {
            saveFunction('#<%= id %>');
        });
    }
</script>