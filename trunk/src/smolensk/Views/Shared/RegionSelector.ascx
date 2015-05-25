<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.RegionSelectorViewModel>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>

<script type="text/javascript">
    $().ready(function () {
        $("#<%:Model.RegionIdName%>").change(function () {
            var id = $("#<%:Model.RegionIdName%>").val();
            $("#<%:Model.CityIdName%> option").each(function () {
                var o = $(this);
                o.show();
                if (o.attr('parent') != id) {
                    o.hide();
                }
            });
            $("#<%:Model.CityIdName%>").val(0);
        });
    });
</script>

<select id="<%:Model.RegionIdName%>" name="<%= Model.RegionName %>">
    <% if (Model.ShowAnyVariant)
       { %>
    <option <%: Model.RegionId == 0 ? "selected" : "" %> value="<%: 0 %>">Любой</option>  
    <% } %>

    <% foreach (DictionaryElement region in Meridian.Default.GetRegions())
        { %>
        <option <%: region.Id == Model.RegionId ? "selected" : "" %> value="<%: region.Id %>"><%: region.Value %></option>  
        <% } %>
</select>
<select id="<%:Model.CityIdName%>" name="<%= Model.CityName %>">
    <% if (Model.ShowAnyVariant)
       { %>    
    <option <%: Model.CityId == 0 ? "selected" : "" %> value="<%: 0 %>">Любой</option>                          <% } %>
    <% foreach (DictionaryElement city in Meridian.Default.GetCities())
        { %>
        <option <%: city.Id == Model.CityId ? "selected" : "" %> value="<%: city.Id %>" parent="<%: city.ParentId %>" <%: city.ParentId != Model.RegionId ? "style=display:none" : "" %>><%: city.Value %></option>  
        <% } %>
</select>