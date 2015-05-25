<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.ReserveTableViewModel>" %>
<%@ Import Namespace="Kendo.Mvc.UI" %>

    <%--<script type="text/javascript" src="/content/js/jquery.js"></script>--%>
    <script type="text/javascript" src="/content/js/kendo/kendo.web.min.js"></script>
    <script type="text/javascript" src="/content/js/kendo/kendo.aspnetmvc.min.js"></script>
    <script type="text/javascript" src="/content/js/kendo/cultures/kendo.culture.ru-RU.min.js"></script>
    <script type="text/javascript" >kendo.culture("ru-RU");</script>
    <link href="/Content/css/kendo/kendo.common.min.css" rel="stylesheet"/>
    <link href="/Content/css/kendo/kendo.default.min.css" rel="stylesheet"/>
    <link href="/Content/css/kendo/kendo.rtl.min.css" rel="stylesheet"/>
    <script type="text/javascript">
        function sendPost() {
            var form = $("#ReserveTableForm");
            if (!form.valid()) {
                return;
            }
            
            var data = form.serialize();
            $.ajax({
                url: '<%= Url.Action("ReserveTable", "Restaurants") %>',
                type: "POST",
                data: data,
                success: function (d) {
                    $("#reserveTableDialog").dialog('close');
                    alert('Ваша заявка отправлена в ресторан. С Вами скоро свяжутся...');
                }
            });
        }
    </script>
<div style="display:none">
        
<div id="reserveTableDialog">
   <% using (Html.BeginForm("ReserveTable", "Restaurants", FormMethod.Post, new {id="ReserveTableForm"}))
      { %>
 <%= Html.HiddenFor(m=>m.RestaurantId) %>
    <table>
        <tr>
            <td>Дата</td>
            <td><%= Html.Kendo().DateTimePickerFor(m=>m.Date)
                .Min(DateTime.Now)
                .Value(DateTime.Now.AddDays(1))
                .Culture("RU-ru")%></td>
                <td></td>
        </tr>
        <tr>
            <td>Кол-во персон</td>
            <td><%= Html.Kendo().NumericTextBoxFor(m=>m.Persons)
                .Min(1).Value(1)
                .IncreaseButtonTitle("+")
                .DecreaseButtonTitle("-")
                .Culture("RU-ru")
                .Format("#")
                .Step(1)%></td>
                <td></td>
        </tr>
        <tr>
            <td>Контактный номер</td>
            <td><%= Html.TextBoxFor(m=>m.Phone) %>
            <%= Html.ValidationMessageFor(m => m.Phone)%></td>
        </tr>
        <tr>
            <td>Имя контактного лица</td>
            <td><%= Html.TextBoxFor(m=>m.ContactName) %>
            <%= Html.ValidationMessageFor(m=>m.ContactName)  %></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="button" title="Отправить запрос" onclick="sendPost()" value="Отправить запрос" /></td>
        </tr>
    </table>   
   <% } %>
</div>

</div>