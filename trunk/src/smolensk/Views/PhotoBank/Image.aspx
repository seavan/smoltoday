<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.PhotoViewModel>"
    MasterPageFile="~/Views/Master/PhotoBank.Master" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Photo.title %>
</asp:Content>

<asp:Content runat="server" ID="Css" ContentPlaceHolderID="CssContent">
    
</asp:Content>
<asp:Content runat="server" ID="PhotoBank" ContentPlaceHolderID="PhotoBank">
    <div class="blockLine">
        <div class="categoryBlock">
            <div class="categoryName">
                <h3><%= Model.Photo.title %> #<%= Model.Photo.id %></h3>
            </div>
            <div class="photoOneBlock">
                <div>
                    <img src="<%= Model.Photo.PreviewMainUrl %>" width="325" height="210" alt="<%= Model.Photo.title %>" />
                    <div class="infoBlock">
                        <span class="author">Автор: <%= Model.Photo.Account.ShortName %><br />
                            <a href="<%: Url.Action("Profile","PhotoBank", new { id = Model.Photo.account_id }) %>" title="Портфолио">Портфолио автора</a>
                        </span>
                        <ul class="info">
                            <% if (Model.OriginalPhoto != null)
                               { %>
                            <li>Размер оригинала: <%=Model.OriginalPhoto.width %>x<%=Model.OriginalPhoto.height %></li>
                            <% } %>
                            <li>Просмотрено: <%= Model.Photo.view_count %></li>
                            <li>Загрузки: <%= Model.Photo.download_count%></li>
                            <li>Опубликовано: <%= Model.Photo.publish_date.ToShortDateString()%></li>
                            <li><span>Рейтинг:</span> <% Html.RenderPartial("Widgets/Rating", Model.Photo); %></li>
                        </ul>
                        <% if (Model.PhotoScrollModel.Photos.Any())
                           { %>
                            <div class="blockPhoto">
                                <p>Связанные изображения</p>
                                <% Html.RenderPartial("Widgets/PhotoScroller", Model.PhotoScrollModel); %>
                            </div>
                        <% } %>
                        <div class="socialLinks">
                            <span>Поделиться</span> 
                        </div>
                        <% Html.RenderPartial("Widgets/AddThis"); %>
                    </div>
                </div>
                <div>
                    <% foreach(var license in Model.RelatedPhotos.Keys) {
                           if (Model.RelatedPhotos[license].Count > 0){ %>
                       <table class="basketTable" id="license-table-<%= license.id %>">
                        <tr>
                            <th>
                                Размер
                            </th>
                            <th>
                                Цена
                            </th>
                            <th>
                                Купить
                            </th>
                        </tr>
                        <% foreach (var item in Model.RelatedPhotos[license])
                           { %>
                           <tr>
                            <td>
                                <%=item.Width %>*<%=item.Height %>
                            </td>
                            <td>
                                <%=item.Price %> р.
                            </td>
                            <td style="text-align: center; width: 30px; padding: 5px 10px;">
                                <%Html.RenderPartial("Widgets/AddToCart", new AddToCartViewModel{ Id = 0, PriceId = item.PriceId }); %>
                            </td>
                        </tr>
                        <% } %>
                    </table>
                    <% }} %>
                    
                    <div class="license">
                        <form action="#">
                        <p>
                            <a href="<%: Url.Action("License","PhotoBank") %>" title="Лицензия">Лицензия</a>
                            #<span id="license-id"></span></p>
                            <% int count = 0;
                               foreach (var license in Model.RelatedPhotos.Keys)
                               { 
                                   if (Model.RelatedPhotos[license].Count > 0){ %>
                                <label for="license<%=license.id %>">
                                <input type="radio" class="table-switcher" name="license" id="license<%=license.id %>" <%= count == 0 ? "checked" : string.Empty %> data-id="#license-table-<%=license.id %>" data-licenseid="<%=license.id %>" /><%=license.title %></label>
                            <% count++;
                               }} %>
                        </form>
                    </div>
                    <div class="additionalInfo">
                        <ul>
                            <%if (!string.IsNullOrEmpty(Model.Photo.description)){%>
                            <li>Описание: <%=Model.Photo.description %></li>
                            <%} %>

                            <%if (Model.Photo.Tags.Count >  0){%>
                            <li>Ключевые слова: 
                            <% for (int i = 0; i < Model.Photo.Tags.Count; i++)
                               { %>
                               <a href="<%: Url.Action("Search", "Photobank", new { q = Model.Photo.Tags[i].title}) %>" title="<%= Model.Photo.Tags[i].title %>"><%= Model.Photo.Tags[i].title %></a><%= i < Model.Photo.Tags.Count -1 ? "," : string.Empty%>
                            <% } %>
                            </li>
                            <%} %>

                            <li>Категория: <a href="<%: Url.Action("Category", "Photobank", new { id = Model.Photo.category_id }) %>" title="<%=Model.Photo.Category.title %>"><%=Model.Photo.Category.title %></a></li>
                        </ul>
                        
                        <%if (Model.Exif!=null){%>
                        <a href="javascript:void(0);" id="exif">Показать EXIF информацию</a>
                        <div id="exif-info" style="display:none;">
                            <% foreach (var val in Model.Exif)
                               { %>
                               <span><%=val.Key %></span>:<span><%=val.Value %></span><br/>
                            <% } %>
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Scripts" ContentPlaceHolderID="ContentScript">
    <script type="text/javascript">
        function swapRelatedPhotos() {
            $(".table-switcher").each(function (i, obj) {
                var $this = $(obj);
                if ($this.is(":checked")) {
                    $($this.data("id")).show();
                    $("#license-id").text($this.data("licenseid"));
                } else {
                    $($this.data("id")).hide();
                }
            });
        }
        
        $(function() {
            swapRelatedPhotos();
            $(".table-switcher").on("click", function () { swapRelatedPhotos(); });
            $("#exif").on("click", function() {
                $("#exif-info").toggle();
                $("#exif-info").is(":visible")
                    ? $(this).text("Скрыть EXIF информацию")
                    : $(this).text("Показать EXIF информацию");
            });
        });
    </script>
</asp:Content>
