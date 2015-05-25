<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Profile.ObtainedPhotoList>" %>
<%@Import namespace="smolensk.Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Фотографии</h3>

        <div class="profileTools">
            <%if(!Model.HasProfile){%>
            <div>
                <span class="button createPortfolio">Создать портфолио</span>
            </div>
            <%} %>

            <form action="#">
                <div class="formLine">
                    <ul class="radioLine">
                        <li><span class="radio" data-url="<%: Url.Action("PhotoBank") %>" ><input type="radio" name="photo" value="1" checked="checked"/> Приобретенные фото</span></li>
                        <li><span class="radio" data-url="<%: Url.Action("PhotoProfile") %>" ><input type="radio" name="photo" value="2"  /> Мои фото</span></li>     
                    </ul>
                </div>
            </form>

        </div>

    </div>
           
    <%if(Model.ObtainedPhotos != null && Model.ObtainedPhotos.Count() > 0){%>
    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>N</th>
                <th></th>
                <th>ID</th>
                <th>Лицензия</th>
                <th>Размер фото</th>
                <th>Цена</th>
                <th>Дата покупки</th>
            </tr>
            
            <% foreach (var obtainedPhoto in Model.ObtainedPhotos.Select((o,i)=> new {Photo = o, Index = i}))
               {
                   var priceO = obtainedPhoto.Photo.GetPhotoPrices();
                   var relatedP = priceO.GetPricesPhotobank_related_photo();
                   var photo = priceO.Photo;
                   %>
            <tr>
                <td class="date"><%: obtainedPhoto.Index + 1%></td>                                    
                <td><a href="<%: relatedP.PhotoUrl %>" title="Фото"><img src="<%: photo.PreviewUrl %>" width="138" height="96" alt="<%: photo.title %>"/></a></td>
                <td class="date">#<%: relatedP.id %></td>
                <td><%: priceO.GetLicensesPhotobank_license().title%></td>                                    
                <td class="date"><%: relatedP.width %>*<%: relatedP.height %></td>
                <td class="date"><%:priceO.price%> руб.</td>
                <td class="date"><%: Formatter.FormatLongDateTimeDifline(obtainedPhoto.Photo.buy_date)%></td>
            </tr>
            <%} %>

        </table>
    </div>
    <%} %>                                      
                        
    <div class="blockLine">
		<%: Html.Pager(Model.CurrentPage, Model.TotalPages, "ProfileObtainedPhotoList", null, "page")%>
	</div>   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
