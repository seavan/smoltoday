<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<IImageByTheme>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

    <div class="blockLine _photoForTheme">
    <%
        int couter = 0;
        foreach (var img in Model)
        {
            if(couter > 3)
            {
                %>
                    <div class="showBlock"><img src="<%: img.GetImgItemThemeUri() %>" alt="" /><br/><br/><a href="<%: img.GetItemThemeUri() %>"><%: img.title %></a></div>
                </div>
                <div class="blockLine _photoForTheme"><%
            }
    %>
        <div>
            <div class="imgBlock">
                <table>
                    <tr>
                        <td>
                            <a href="<%: img.GetImgItemThemeUri() %>" data-url="<%: img.GetItemThemeUri() %>" title="<%: img.ProtoName.Equals("news_images") ? "Новости" : "Фотобанк" %> / <%: img.title %>"><!-- в href ссылка на большую картинку, в title название новости, которой принадлежит картинка, в data-url ссылка на эту новость -->
                                <img src="<%: img.GetImgThumbnailItemThemeUri() %>" width="138" height="96" alt="" />
                            </a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    <%++couter;} %>
        <div class="showBlock"><img src="" alt="" /><br/><br/><a href=""></a></div>
    </div>
