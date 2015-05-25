<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="blockNews">
    <div class="widthContent">
        <div class="newsBlock">
            <div class="headerBlock">
                <h3>Главные новости</h3>
                <%--<div class="selectorNews">
                    <span class="cur">Новости<span></span></span> 
                    <span>Афиша<span></span></span> 
                    <span>Видео<span></span></span>
                </div>--%>
            </div>
            <% Html.RenderAction("MainSlider"); %>

            <a href="/News" title="Все новости" class="allNews">Все новости <span>&rarr;</span></a>
        </div>
        <div class="bannerBlock">
            <div class="socialLinks">
                <span>Поделиться:</span>
            </div>
            <% Html.RenderPartial("Widgets/AddThis"); %>
            <div class="banner">
                <%--<a href="#" title="Ваш баннер 240*400">
                    <img src="/content/images/mts_left.jpg" width="240" height="400" alt="Ваш баннер 240*400" />
                </a>--%>
                <embed src="/Content/swf/bk.swf" quality="high"
                  type="application/x-shockwave-flash"
                  wmode="opaque" width="240" height="400"
                  pluginspage="http://www.macromedia.com/go/getflashplayer" allowScriptAccess="always">
                 </embed>
            </div>
        </div>
    </div>
    <div class="waveEdge">
    </div>
</div>
