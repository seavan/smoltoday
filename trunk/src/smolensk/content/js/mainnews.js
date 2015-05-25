$(document).ready(function(){
    var MN_TIMEOUT = 3000;  // Период переключения новостей в милисикундах

    var lastTime = new Date().getTime();

    var mainNewsBoxes = document.getElementsByClassName("photoNews");
    for (var i = 0; i < mainNewsBoxes.length; i++) {
        eval('mainNewsBoxes[i].addEventListener("click", function(){ switchNews(' + i + '); });')
    }

    function updateTimer(warTime) {
        var timeDelta = new Date().getTime() - lastTime;
        if (timeDelta >= MN_TIMEOUT) {
            switchNews();
        }
        setTimeout(updateTimer, MN_TIMEOUT - timeDelta);
    }
    setTimeout(updateTimer, MN_TIMEOUT);

    var newsN = 0

    function nextNewsN() {
        return newsN == mainNewsBoxes.length - 1 ? 0 : newsN + 1;;
    }

    function switchNews(newNewsN) {
        newNewsN = typeof newNewsN !== 'undefined' ? newNewsN : nextNewsN();
        newsN = newNewsN;

        // Визуализация переключения новости
        mainNews = document.getElementsByClassName("mainNews");
        for (var i = 0; i < mainNews.length; i++) {
            mn = mainNews[i];
            img = mn.getElementsByClassName("photo")[0].getElementsByTagName("img")[0];
            img.src = smolenskGlobal.mainNewsPics[newNewsN];
            img.title = smolenskGlobal.mainNewsTitles[newNewsN];
            aa = mn.getElementsByTagName("a");
            aa[0].href = smolenskGlobal.mainNewsUrls[newNewsN];
            aa[1].href = smolenskGlobal.mainNewsUrls[newNewsN];
            aa[1].innerHTML = smolenskGlobal.mainNewsTitles[newNewsN];
            newsBoxes = mn.getElementsByClassName("photoNews");
            for (var i = 0; i < newsBoxes.length; i++) {
                var classes = newsBoxes[newNewsN].className.split(' ');
                var className = '';
                for (var j = 0; j < classes.length; j++) {
                    if (classes[j] != 'cur') {
                        className += classes[j];
                    }
                }
                newsBoxes[i].className = className;
            }
            newsBoxes[newNewsN].className += ' cur';

            lastTime = new Date().getTime();
        }
    }
});