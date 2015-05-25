
var smolenskCoords;
var groups;
var myMap;
var need_render = true;
var interval_render;

/*Меняем под нужный спрайт*/
var pointImg = "/content/i/placePoint.png";
/*Размер отдельного изображения в спрайте*/
var pointImgSize = [27, 34];
/*Классы описаны в css, нужны для меню - нужно на каждый цвет маркера прописать класс*/
/*Не стал морочиться с обходом массива в цикле, если групп больше, чем цветов, а просто размножил*/
var classNames = ['blue', 'green', 'orange', 'pink', 'lime', 'black', 'blue', 'green', 'orange', 'pink', 'lime', 'black', 'blue', 'green', 'orange', 'pink', 'lime', 'black'];

function smolenskInitMap(baseCoords, baseGroups) {
    smolenskCoords = baseCoords;
    groups = baseGroups;
    
    ymaps.ready(initMap);
}


function initMap(){

    if (typeof (smolenskCoords) == "undefined" || typeof (groups) == "undefined") return false;
    if (smolenskCoords == "") return false;

    myMap = new ymaps.Map ("yandexMap", {
        center: smolenskCoords, //долгота, широта 
        zoom: 15
    });
    
        
    myMap.controls
    // Кнопка изменения масштаба.
    .add('zoomControl', { left: 5, top: 5 })
    // Список типов карты
    .add('typeSelector')
    // Стандартный набор кнопок
    .add('mapTools', { left: 35, top: 5 });

    if (groups == "") return false;

    $menu = $('.map .tools ul');

    

    var groupCounter = 0;
    var itemCounter = 0;
    var collections = [];

    groups.forEach(function (group) {
        // Пункт меню.
        var $menuItem = $('<li class="' + classNames[groupCounter] + '"><span>' + group.name + '</span><span class="counter">' + group.items.length + '</span></li>'),
        // Коллекция для геообъектов группы.
        collection = new ymaps.GeoObjectCollection(null, { preset: group.style });
        //Помещаем в список коллекций
        collections.push(collection);
        // Добавляем коллекцию на карту.
        myMap.geoObjects.add(collection);


        $menuItem
        // Добавляем пункт в меню.
        .appendTo($menu)
        // По клику удаляем/добавляем коллекцию на карту
        .toggle(function () {
            $(this).addClass('no');
            myMap.geoObjects.remove(collection);
        }, function () {
            $(this).removeClass('no');
            myMap.geoObjects.add(collection);
        });

        // Перебираем элементы группы.
        group.items.forEach(function (item) {
            ++itemCounter;
            // Создаем метку.
            placemark = new ymaps.Placemark(
                item.center,
                { hintContent: item.balloonContentHeader, balloonContentHeader: '<a href="' + item.balloonContentHeaderLink + '">' + item.balloonContentHeader + '</a>', balloonContent: item.balloonContent },
                { iconImageHref: pointImg, iconImageSize: pointImgSize, iconImageClipRect: [[pointImgSize[0] * groupCounter, 0], [pointImgSize[0] * (groupCounter + 1), pointImgSize[1]]] }
            );

            // Добавляем метку в коллекцию.
            collection.add(placemark);

        });

        ++groupCounter;
    });
        

    $all = $('<li><span>Все объекты</span><span class="counter">' + itemCounter + '</span></li>');
    $all.prependTo($menu).toggle(function () {
        $menu.find('li').addClass('no');
        collections.forEach(function (collection) {
            myMap.geoObjects.remove(collection);
        });
    }, function () {
        $menu.find('li').removeClass('no');
        collections.forEach(function (collection) {
            myMap.geoObjects.add(collection);
        });
    });


    if (itemCounter > 1) {
    /*myMap.setBounds(myMap.geoObjects.getBounds());
    interval_render = window.setInterval(function () {
        if ($('#yandexMap').is(':visible') && need_render) {
            need_render = false;
            window.clearInterval(interval_render);
            myMap.setBounds(myMap.geoObjects.getBounds());
        }
    }, 500); */
    }

    $(window).resize(function () {
        var width = $(window).width();
        var height = $(window).height();

        myMap.container.fitToViewport();
    });

    scrollTools();
}

$(function() {

});

function scrollTools() {
    try {
        $('.map .tools #toolsScroll').mCustomScrollbar({
            set_height: "210px",
            scrollInertia: 150
        });
    } catch (e) { }
}