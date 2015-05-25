function initFancyBox(rel) {
    $("a[rel=" + rel + "]").fancybox({
        'transitionIn': 'none',
        'transitionOut': 'none',
        'titlePosition': 'over',
        'titleFormat': function (title, currentArray, currentIndex, currentOpts) {
            return '<span id="fancybox-title-over">Фотография ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
        }
    });
}

function GalleryInit() {
    initFancyBox("fancyPhoto");
    $().ready(function () {
        initFancyBox("fancyPhoto");
    });
}

function photoSelect(p) {
    $("div[class=img] a").hide();
    $("div[class=img] a[index=" + p.data('index') + "]").show();
}