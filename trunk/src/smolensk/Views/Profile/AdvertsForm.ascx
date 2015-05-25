<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AdViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%: Html.HiddenFor(m=>m.Advertisment.account_id) %> 
<%: Html.HiddenFor(m=>m.Advertisment.id) %> 
<table class="createBlock">   
    <tr>
        <td style="vertical-align:top;">Категория</td>
        <td>
            <% if (Model.IsEdit)
               { %>
               <%= Model.Advertisment.GetAdvertismentsAd_categorie().title %>
               <%: Html.HiddenFor(m => m.Advertisment.category_id) %> 
            <% }
               else
               { %>
               <select name="Advertisment.category_Id" id="categories">
                <% foreach (ad_categories category in Model.Categories)
                    { 
                        if (category.Subcategories.Any())
                        {
                            %>
                            <optgroup label="<%= category.title %>">
                            <% foreach (var sub in category.Subcategories)
                                { %>
                            <option value="<%= sub.id %>" <%= sub.id == Model.Advertisment.category_id ? "selected='selected'" : "" %>><%= sub.title %></option>
                            <% } %>
                            </optgroup>
                    <% }
                        else
                        { %>
                        <option value="<%= category.id %>" <%= category.id == Model.Advertisment.category_id ? "selected='selected'" : "" %>><%= category.title %></option>
                    <% } %>
                <% } %>
               </select>
            <% } %>
            
        </td>
    </tr>
                                                             	
    <tr>
        <td>Название <span class="need">*</span></td>
        <td>
            <%: Html.TextBoxFor(m=>m.Advertisment.title) %>
            <%: Html.ValidationMessageFor(m => m.Advertisment.title)%>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="vertical-align:top;">Описание <span class="need">*</span></td>
                                        
    </tr>
    <tr>                                    	
        <td colspan="2">
            <%: Html.TextAreaFor(m => m.Advertisment.description, new { @class = "_ckeditor" })%>  
            <%: Html.ValidationMessageFor(m => m.Advertisment.description)%>                
        </td>
    </tr>
    <tr>
        <td>Цена, руб</td>
        <td>
            <%: Html.TextBoxFor(m => m.Advertisment.price)%>
            <%: Html.ValidationMessageFor(m => m.Advertisment.price)%>
        </td>
    </tr>
    <tr>
        <td>Изображения</td>
        <td>
            <div>
                <a href="javascript:void(0);" id="add-image">Добавить изображение</a>
            </div>
            <div id="ad-images" data-count="0"></div>
            <div>В качестве главного изображения будет использовано первое изображение</div>
            <% if (Model.Advertisment.Photos.Any())
               { %>
               
                   <% foreach (var photo in Model.Advertisment.Photos)
                      { %>
                      <div class="advert-img-preview"><img src="<%= photo.PreviewUrl %>" alt=""/><span class="btn-delete" data-id="<%= photo.id %>"></span></div>
                   <% } %>
               
            <% } %>
        </td>
    </tr>
    <%Html.RenderAction("AdvertFields", "Profile", new {categoryId = Model.Advertisment.category_id, adId = Model.Advertisment.id}); %>
    <tr id="advert-contacts">
        <td>Контактное лицо</td>
        <td>
            <%: Html.TextBoxFor(m => m.Advertisment.name)%>
            <%: Html.ValidationMessageFor(m => m.Advertisment.name)%>
        </td>
    </tr>
    <tr>
        <td>Телефон</td>
        <td>
            <%: Html.TextBoxFor(m => m.Advertisment.phone)%>
            <%: Html.ValidationMessageFor(m => m.Advertisment.phone)%>
        </td>
    </tr>
    <tr>
        <td>Электронная почта</td>
        <td>
            <%: Html.TextBoxFor(m => m.Advertisment.email)%>
            <%: Html.ValidationMessageFor(m => m.Advertisment.email)%>
        </td>
    </tr>
</table>   
<div class="buttonPanel">    
    <a href="<%: Url.Action("Adverts") %>"><span class="button">Отмена</span></a>
    <span class="button save" onClick="$(this).closest('form').submit();">Сохранить</span>                                    
</div>