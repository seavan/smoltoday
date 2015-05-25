<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.accounts>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Моё портфолио</h3>
        <div class="profileTools">
            
            <form action="#">
                <div class="formLine">
                    <ul class="radioLine">
                        <li><span class="radio" data-url="<%: Url.Action("PhotoBank") %>" ><input type="radio" name="photo" value="1" /> Приобретенные фото</span></li>
                        <li><span class="radio" data-url="<%: Url.Action("PhotoProfile") %>" ><input type="radio" name="photo" value="2"  checked="checked" /> Мои фото</span></li>     
                    </ul>
                </div>
            </form>

        </div>
							
		<div class="profileBlock">
            <p><%= Model.ShortName %></p>
            <img src="<%: Model.AvatarUrlMid %>" width="139" alt="<%= Model.ShortName %>"  />
            <div class="infoBlock">
                <ul>
                    <li><span>Имя:</span> <%= Model.ShortName %></li>
                    <li><span>Адрес:</span> <%= Model.address %></li>
                    <li><span>Вебсайт:</span> <%= Model.website %></li>
                    <li><span>Дата регистрации:</span> <%= Formatter.FormatCompanyPublishDate(Model.created)%></li>
                    <li><span>Компания:</span> <%= Model.company %></li>
                </ul>
                <ul>
                    <li><span>Фото:</span> <%: Model.PhotosCount %></li>
                    <li><span>Просмотрено:</span> <%: Model.ViewsPhotosCount %></li>
                    <li><span>Загрузки:</span> <%: Model.DownloadPhotosCount %></li>
                </ul>
                                    
                <dl>
                    <dt>О себе:</dt>
                    <dd><%= Model.description %></dd>
                </dl>
            </div>
        </div>
							
    </div>
    
    
    <div class="profileBody">
        
	    <div class="categoryName">
		    <h3>Альбомы</h3>
		    <span class="createAlbum">Создать альбом</span>
	    </div>
	    <div class="clear"></div>
      
	    <div class="grayCreateBlock" style="display:none;">
            <form action="<%: Url.Action("PhotoProfile") %>" method="post"> 
            <table class="createBlock">   
                    <tr>
                    <th colspan="2">Создание нового альбома</th>
                </tr>                 	
                <tr>
                    <td>Название альбома  <span class="need">*</span></td>
                    <td><%: Html.TextBox("title","")%></td>
                </tr>
                <tr>
                    <td>Дата съемки  <span class="need">*</span></td>
                    <td><%: Html.TextBox("shoot_date","",new{@class = "range datepicker"})%></td>
                </tr>
            </table>   
                                
                                
            <div class="buttonPanel">  
			    Для сохранения данных и добавления фотографий нажмите                                  	
                <span class="button save" onClick="$(this).closest('form').submit();">Далее</span>                                    
            </div>
                                
            </form>
        </div>
								
        <% Html.RenderAction("PhotoAlbumsList"); %>
    </div>
                        
                        
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
