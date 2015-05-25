<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="blockNews">
    <div class="widthContent">
        <div class="newsBlock">
            <div class="headerBlock">
                <h3>
                    Веб-камеры города</h3>
                
            </div>
            <div class="photoBlock">
                <div class="imgContainer">
                    <img src="/content/images/webcam1.jpg" width="650" height="288" alt="" id="cam1"/>
                </div>
                <div class="titleNews">
                    <a href="#" title="Глава российского МВД назвал смертную казнь нормальной реакцией общества">
                        Глава российского МВД назвал смертную казнь «нормальной реакцией общества»</a>
                </div>
                <div class="shadow">
                </div>
            </div>
            <a href="#" title="Все новости" class="allNews">Все новости <span>&rarr;</span></a>
        </div>
        <div class="bannerBlock">
            <div class="socialLinks">
                <span>Поделиться</span> <span><a href="#" class="facebook" title="facebook">facebook</a>
                    <a href="#" class="vk" title="vkontakte">vkontakte</a> <a href="#" class="twitter"
                        title="twitter">twitter</a> <a href="#" class="odnkl" title="odnoklassniki">odnoklassniki</a>
                </span>
            </div>
            <div class="banner">
                <a href="#" title="Ваш баннер 240*400">
                    <img src="/content/images/banner_240_400.png" width="240" height="400" alt="Ваш баннер 240*400"/>
                </a>
            </div>
        </div>
    </div>
    <div class="waveEdge">
    </div>
    
    <script type="text/javascript">
        window.setInterval(function() {
            d = new Date();
            $("#cam1").attr("src", "/content/images/webcam1.jpg?" + d.getTime());
        }, 1000)

    </script>
</div>
