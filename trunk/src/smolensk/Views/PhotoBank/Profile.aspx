<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.ProfileViewModel>" MasterPageFile="~/Views/Master/PhotoBank.Master" %>
<asp:Content runat="server" ID="PhotoBank" ContentPlaceHolderID="PhotoBank">
    <div class="blockLine">
        <div class="profileBlock">
            <p><%= Model.Profile.ShortName %></p>
            <img src="<%= Model.Profile.AvatarUrlMid %>" width="139" height="139" alt="1" /> 
            <div class="infoBlock">
                <ul>
                    <li><span>Имя:</span> <%= Model.Profile.ShortName %></li>
                    <li><span>Адрес:</span> <%= Model.Profile.address %></li>
                    <li><span>Вебсайт:</span> <%= Model.Profile.website %></li>
                    <li><span>Дата регистрации:</span> <%= Model.Profile.created.ToShortDateString() %></li>
                    <li><span>Компания:</span> <%= Model.Profile.company %></li>
                </ul>
                <ul>
                    <li><span>Фото:</span> <%= Model.PhotosCount %></li>
                    <li><span>Просмотрено:</span> <%= Model.ViewsCount %></li>
                    <li><span>Загрузки:</span> <%= Model.DownloadCount %></li>
                </ul>
                                    
                <dl>
                    <dt>О себе:</dt>
                    <dd><%= Model.Profile.description %></dd>
                </dl>
            </div>
        </div>
        <% Html.RenderPartial("PhotoListPartial", Model.PhotosList); %>                        
    </div>     
</asp:Content>
