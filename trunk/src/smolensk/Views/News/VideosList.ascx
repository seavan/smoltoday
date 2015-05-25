<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<IImageByTheme>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<div class="blockLine _videoForTheme">
    <%
        int couter = 0;
        foreach (var img in Model)
        {
            if(couter > 3)
            {
                %>
                    <div class="showBlock">
                        <span><iframe src="" ></iframe></span>
                        <br/><br/>
                        <a href="<%: img.GetItemThemeUri() %>"><%: img.title %></a>
                    </div>
                </div>
                <div class="blockLine _videoForTheme"><%
            }
    %>
    <a href="<%: img.GetItemThemeUri() %>" title="<%: img.title %>"><!-- в href ссылка на новость, которой принадлежит видео, в title название новости  -->
        <img src="<%: img.GetImgThumbnailItemThemeUri() %>" width="200" height="130" alt="" /> 
        <span class="videoInfo"><%: img.GetImgItemThemeUri() %></span><!-- в videoInfo  кладётся код плеера видео -->
    </a>
    <%++couter;} %>
    <div class="showBlock">
        <span><iframe width="420" height="315" frameborder="0" src="" ></iframe></span>
        <br/><br/>
        <a href="#"></a>
    </div>
</div>
