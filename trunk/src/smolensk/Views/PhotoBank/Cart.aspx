<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.CartViewModel>"
    MasterPageFile="~/Views/Master/PhotoBank.Master" %>

<asp:Content runat="server" ID="BreadCrumbs" ContentPlaceHolderID="BreadCrumbsContent">
     <div class="blockLine">
        <%: Html.MvcSiteMap().SiteMapPath() %>  
    </div>
</asp:Content>
<asp:Content runat="server" ID="PhotoBank" ContentPlaceHolderID="PhotoBank">
    <div class="blockLine">
        <div class="categoryBlock">
            <div class="categoryName">
                <h3>
                    Корзина</h3>
                <a href="<%: Url.Action("License","PhotoBank") %>" title="Лицензия" class="licenseLink">
                    Информаци о лицензии</a>
            </div>
            <form action="#" style="float: left;">
            
            <table class="basketTable">
                <tr>
                <th>
                    Фото
                </th>
                <th>
                    ID
                </th>
                <th>
                    Лицензия
                </th>
                <th>
                    Размер
                </th>
                <th>
                    Цена
                </th>
                <th>
                    Удалить
                </th>
            </tr>
            <% if (Model.Items.Any())
               { %>
                <% foreach (var item in Model.Items)
                   { %>
                        <tr>
                            <td>
                                <a href="<%: item.Photo.ItemUri() %>" title="<%: item.Photo.title %>">
                                    <img src="<%= item.Photo.PreviewUrl %>" width="138" height="96" alt="<%: item.Photo.title %>" /></a>
                            </td>
                            <td>
                                #<%= item.rel_photo_id %>
                            </td>
                            <td>
                                <select name="selector_license" id="licenses-<%= item.id %>" data-id="<%= item.id %>">
                                    <% foreach (var license in Model.Licenses)
                                       { %>
                                        <option value="<%= license.id %>" <%= license.id == item.license_id ? "selected='selected'" : string.Empty %>><%= license.title %></option>
                                    <% } %>
                                </select>
                            </td>
                            <td>
                                <select name="selector_size" id="sizes-<%= item.id %>" data-id="<%= item.id %>">
                                    <% foreach (var related in item.Photo.GetPhotos())
                                       { %>
                                        <option value="<%= related.id %>" <%= related.id == item.rel_photo_id ? "selected='selected'" : string.Empty %>><%= related.width %>x<%= related.height %></option>
                                    <% } %>
                                </select>
                            </td>
                            <td>
                                <span id="price-<%= item.id %>" class="item-price"><%= item.price %></span> р.
                            </td>
                            <td style="text-align: center;">
                                <span id="delete-<%= item.id %>" class="photo_delete button" data-id="<%= item.id %>"><span></span></span>
                            </td>
                        </tr>
                <% } %>
            
            <% } else
               { %>
               <tr>
                   <td colspan="6" style="text-align: center;">Корзина пуста</td>
               </tr>
            <% } %>
            </table>
            <div class="blockLine">
                <span class="fullPrice">Итого: <span id="total-count"><%= Model.Total %></span> руб.</span>
                <% if (Model.Items.Any())
                   { %>
                    <span class="photo_order_confirm button cart-order">Оформить заказ</span>
                <% } %>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Scripts" ContentPlaceHolderID="ContentScript">
    <script>
        function getPrice(licenseId, relPhotoId, oldLicenseId, oldRelPhotoId) {
            var json;
            $.ajax({
                url: '<%: Url.Action("CalcPrice", "Photobank") %>',
                type: "POST",
                async: false,
                data: { licenseId: licenseId, relPhotoId: relPhotoId, oldLicenseId: oldLicenseId, oldRelPhotoId: oldRelPhotoId },
                success: function(result) {
                    json = result;
                }
            });

            return json;
        }

        function updateCartView() {
            $.ajax({
                url: '<%: Url.Action("CartInfo", "PhotoBank") %>',
                success: function(result) {
                    $("#cart-info").html(result);
                }
            });
        }
        
        function setDefaultValues() {
            $("[id^=licenses],[id^=sizes]").each(function (i, obj) {
                $(obj).data("val", $(obj).val());
            });
        }

        function calcTotal() {
            var total = 0;
            $(".basketTable").find(".item-price").each(function () {
                total += parseFloat($(this).text());
            });

            $("#total-count").text(total);
        }

        $(function () {
            setDefaultValues();
            $(".photo_delete").on("click", function () {
                var $this = $(this);
                $.ajax({
                    url: '<%: Url.Action("DeleteCartItem", "Photobank") %>',
                    type: "POST",
                    data: { id: $this.data("id") },
                    success: function(result) {
                        $this.closest("tr").remove();
                        updateCartView();
                        calcTotal();
                        if (result.count == 0) {
                            $(".basketTable").append("<tr></tr>").append("<td colspan='6' style='text-align: center;'>Корзина пуста</td>");
                            $(".cart-order").hide();
                        }
                    }
                });
            });

            $("[id^=licenses],[id^=sizes]").on("change", function () {
                var $this = $(this);
                var id = $this.data("id");
                var result = getPrice($("#licenses-" + id).val(), $("#sizes-" + id).val(), $("#licenses-" + id).data("val"), $("#sizes-" + id).data("val"));
                $("#price-" + id).text(result.price);
                $("#delete-" + id).data("id", result.priceId);
                $this.data("val", $this.val());
                calcTotal();
                updateCartView();
            });
        });
    </script>
</asp:Content>
