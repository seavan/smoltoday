<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Profile.UserPhotoAlbumList>" %>
<%@ Import Namespace="smolensk.Domain" %>
    <div class="photoList">
        <div class="blockLine">
        <%
            int index = 0;
            foreach (var album in Model.Albums){
                if(index > 3)
                {
                    index = 0;
                    %>
                    </div>
                    <div class="blockLine">
                    <%
                }
                %>
                    
                <div>
                    <div class="imgBlock">
                        <table>
                            <tr>
                                <td><a href="/Profile/PhotoAlbum/<%: album.id %>" title="<%: album.title %>"><img src="<%: album.PreviewUrl %>" width="138" alt="<%: album.title %>" /></a></td>
                            </tr>
                        </table>
                    </div>
                    <span class="info">
                        <span><%: album.title %></span>
			            <span><%= Formatter.FormatCompanyPublishDate(album.shoot_date)%></span>
			            <a href="/Profile/PhotoAlbum/<%: album.id %>" title="редактировать">редактировать</a>
                    </span>
                </div>
                
        <% ++index;} %>
        </div>
    </div>
            
    <div class="blockLine">
        <%: Html.Pager(Model.CurrentPage, Model.TotalPages, "ProfileAlbumsList", null, "page")%>
    </div>
