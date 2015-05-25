<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Profile.AddNewPhotoModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<div class="grayCreateBlock form_addNewPhoto" style="display:none;">
    <form action="#" class="ajaxForm" data-action="<%: Url.Action("AddNewPhoto", "Profile")%>" data-target=".form_addNewPhoto" data-callback="hideOverlay">
        <%: Html.HiddenFor(m=>m.AlbumId) %> 
    <table class="createBlock">   
            <tr>
            <th colspan="2">Добавление фото</th>
        </tr>                 	
        <tr>
            <td>Название</td>
            <td>
                <%: Html.TextBoxFor(m=>m.Title) %>
                <%: Html.ValidationMessageFor(m => m.Title)%>
            </td>
        </tr>
									
		<%--<tr>
            <td>Ключевые слова</td>
            <td>
				<input type="text" value="" name="tags"  class="range" />
				<span class="button plus">+</span>
			</td>
        </tr>--%>
        <tr>
            <td style="vertical-align:top;">Категория</td>
            <td>
                <%= Html.DropDownListFor(m => m.CategoryId, new SelectList(Model.Categories.ToDictionary(str => str.id, str => str.title), "Key", "Value", Model.CategoryId))%>                     
            </td>
        </tr>
									
        <tr>
            <td style="vertical-align:top;">Лицензия</td>
            <td>
                <%= Html.DropDownListFor(m => m.LicenseId, new SelectList(Model.Licenseses.ToDictionary(str => str.id, str => str.title), "Key", "Value", Model.LicenseId))%>                     
            </td>
        </tr>
									
		<tr>
            <td>Стоимость, руб.</td>
            <td><%: Html.TextBoxFor(m => m.Price, new { @class = "range" })%></td>
        </tr>
									
		<tr>
			<td>Загрузка фотографии</td>
			<td>
				<span class="inputFileWrapper">
					<span class="text photo"></span>
					<span class="button">Выбрать фотографию</span>
					<input type="file" name="FileImg" class="fileInput" />
				</span>
                <%: Html.ValidationMessageFor(m => m.FileImg)%>
			</td>
		</tr>
    </table>   
                                
                                
    <div class="buttonPanel">    
		<span class="button reset">Отменить</span>
		<span class="button save">Сохранить</span>                                 
	</div>
                                
    </form>
</div>
<div class="overlayProfile">
    <div class="overlayLayer"></div>
    <div class="preloader"></div>
</div>

