<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.photobank_photo_prices>>" %>
<%@ Import Namespace="admin.db" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var model = Model;
    var parent = ViewData["parentModel"] as IDatabaseEntity;

    photobank_photo_prices obj = Model != null && Model.Any() ? Model.First() : new photobank_photo_prices();

    var id = fname + "UID";
%>

<div id="<%: id %>_Entity" data-parent="<%:obj.rel_photo_id %>">
    <%if(parent.id <= 0){%>Cохраните объект перед редактированием<%} %>

    <% if(model != null && parent.id > 0) {%>
    
    <label for="<%: id %>_photoPrice">Цена:</label> <input type="text" name="<%: id %>_photoPrice" id="<%: id %>_photoPrice" value="<%:obj.price %>" style="width:100px;" />
    
    <label for="<%: id %>_photoPrice">Лицензия:</label>
    <select name="<%: id %>_photoLicense" id="<%: id %>_photoLicense">
        <% foreach (var v in obj.AllLicenses()) { %>
        <option value="<%= v.id %>" <%= obj.license_id == v.id ? "selected" : "" %>><%= v.title %></option>
        <% } %>         
    </select>
    
    <a class="_link" href="#" onclick="return SaveLicenseData('<%: id %>')" style="float: right">Сохранить данные</a>
    

    <% }%>
    
    <script type="text/javascript">
        function SaveLicenseData(preId) {
           
            $base = $("#" + preId + "_Entity");
            $price = $("#" + preId + "_photoPrice");
            $lic = $("#" + preId + "_photoLicense");

            var preparams = '{ "idPhoto": "' + $base.attr("data-parent") + '", "idLic": "' + $lic.val() + '", "price" : "' + $price.val() + '"}';
            var params = $.parseJSON(preparams);

            $.post("/PhotoBankPhotosAdmin/SaveLicense", params, function () {
                location.reload();
            });

            return false;
        }
    </script>
</div>