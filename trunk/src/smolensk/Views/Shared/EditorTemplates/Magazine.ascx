<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<div id="_magazineType">
    <select size="1" >
    </select>
</div>
<script>
    var updateMagazine = function () {
        var v = ($('#_magazineType select').val());
        if(window.updatePartTypes) {
            updatePartTypes();
        }
        $('#_magazine select').load('/AdminLibMagazine/GetAllJquery', { _magType: v, _selected: <%= Model != null ? Model : 0 %> });

    };

    var initMagType = function () {
    $.get('/AdminLibMagazine/GetSelectedMagazineType', { _selected: <%= Model != null ? Model : 0 %> }, function (_data) {
                $('#_magazineType select').val(_data);
                updateMagazine();
    });    
    };


    $(document).ready( function() {
        $('#_magazineType select').change(updateMagazine);

        $('#_magazineType select').load('/AdminLibMagazineType/GetAllJquery', null, initMagType);
    });
</script>
<div id="_magazine">
    <%
        var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    %>
    <select name="<%= fname %>" id="<%= fname %>" size="1">
    </select>
</div>

