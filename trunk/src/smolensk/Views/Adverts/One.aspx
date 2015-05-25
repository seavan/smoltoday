<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Advert.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.AdViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Mail" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Advertisment.title %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="popUpLayer">
    <% Html.RenderPartial("WriteMailForm", new AdvMailModel() { AdvId = Model.Advertisment.id }); %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Advert" runat="server">
    <div class="advertOne">
        <h3 style="<%: Model.IsOwner ? "width: 320px;" : string.Empty %>" ><%= Model.Advertisment.title %></h3>
        <div class="advertTools">
            <span class="date">Размещено <%= Formatter.FormatLongDate(Model.Advertisment.created_date) %> г. в <%= Formatter.FormatTime(Model.Advertisment.created_date) %></span>
            <% if (Model.IsOwner) { %>
                    <span class="edit"><a href="<%: Url.Action("EditAdvert", "Profile", new { Model.Advertisment.id }) %>" title="Редактировать">Редактировать</a></span>
            <% } %>
        </div>
          
        <div class="advertOneBlock photo">
            <div class="photo_big">
                <a href="#" title="<%= Model.Advertisment.title %>"><img id="adimage" src="<%= Model.Advertisment.PhotoUrl %>" alt="" /></a>
                <div style="overflow:hidden;width:335px;">
                    <% Html.RenderPartial("Widgets/PhotoScroller", Model.PhotosModel); %>
                    <script>
                        function selectImage(el) {
                            $("#adimage").attr("src", $(el).data("link"));
                        }
                    </script>
                </div>
            </div>
            
            <div class="infoBlock">
                <% if (Model.Advertisment.price > 0)
                   { %>
                    <p><%= Formatter.FormatPrice(Model.Advertisment.price) %> <span>руб.</span></p>
                <% } %>
                
                <table>
                    <% foreach (var prop in Model.Properties) {
                           string propValue = prop.ValueId.HasValue() ? prop.Values[prop.ValueId] : prop.Value;
                    %>
                       <% if (!string.IsNullOrEmpty(propValue)) { %>
                           <tr>
                              <td><%= prop.Title %></td>
                              <td><%= propValue %></td>
                           </tr>
                       <% } %>
                    <% } %>
                </table>
            </div>
        </div>

        <div class="advertOneBlock">
            <h3>Описание</h3>
            <p><%= Model.Advertisment.description %></p>
        </div>

        <div class="advertOneBlock">
            <h3>Контакты</h3>
            <table class="contacts">
                <tr>
                    <td>Контактное лицо</td>
                    <td><%= Model.Advertisment.name %></td>
                </tr>
                <tr>
                    <td>Телефон</td>
                    <td class="phone"><%= Model.Advertisment.phone %></td>
                </tr>
            </table>
            
            <% if (!Model.IsOwner){ %>
            <div class="buttonPanel">
                <% if (SecurityService.IsAuthorize && !string.IsNullOrEmpty(Model.Advertisment.email)) { %>
                   <span class="button mail"><span></span>Написать письмо</span>
                <% } %>
                <% Html.RenderPartial("ButtonFavorite", Model.Advertisment); %>
            </div>
            <% } %>
        </div>
    </div>
    
    <% Html.RenderAction("InterestingAds", "Adverts", new { type = "interesting", categoryId = Model.Advertisment.GetAdvertismentsAd_categorie().parent_id == 0 ? Model.Advertisment.category_id : Model.Advertisment.GetAdvertismentsAd_categorie().parent_id }); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <% if (Model.IsOwner)
       { %>
        <div class="advertTools">
            <p>Премиум размещение</p>
            <ul>
                <li class="select">
                    <% if (Model.InInterestingRequest) { %>
                       <span>Запрошено размещение в интересном</span>
                    <% } else { %>
                       <a href="javascript:void(0);" class="ad-request" data-type="interesting">Выделить объявление</a>
                    <% } %>
                </li>
                <li class="top">
                    <% if (Model.PinToListRequest) { %>
                       <span>Запрошено поднятие в списках</span>
                    <% } else { %>
                       <a href="javascript:void(0);" class="ad-request" data-type="pintolist">Поднять в списке</a>
                    <% } %>
                </li>
            </ul>
        </div>
    <% } %>
    
    <script>
        $(function() {
            $(".ad-request").on("click", function() {
                var $this = $(this);
                $.ajax({
                    url: '<%: Url.Action("AdRequest", "Adverts") %>',
                    type: 'POST',
                    data: { id: <%= Model.Advertisment.id %>, type: $this.data("type") },
                    success: function(result) {
                        $this.parent().html("<span>" + result.message + "</span>");
                        alert("Запрос отправлен");
                    }
                });
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
    <% Html.RenderAction("SimilarAds", "Adverts", new { Model.Advertisment.id }); %>
</asp:Content>