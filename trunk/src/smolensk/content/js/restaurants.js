/*Общее*/
function InitReserveTableActions() {
    var func = function(obj) {
        var title = $(obj).data('title');
        $("#reserveTableDialog").dialog({ modal: true, title: title, zIndex:10000, width: 435 });
        $("#RestaurantId").val($(obj).data("id"));
        $("#reserveTableDialog input[name=Phone]").val('');
        $("#reserveTableDialog input[name=ContactName]").val('');
        $("#reserveTableDialog input[name=Date]").val($(obj).data('date'));
    };
    //Вешаем событие открытия диалогового окна для бронирования столика
    $('div[class=infoBlock] span[class=button][data-id]').click(function () {
        func(this);
    });

    $('div[class=oneRest] span[class=button][data-id]').click(function () {
        func(this);
    });
}

/*RestaurantEvents.ascx*/
var selectedPreview = null;
var selectedSpanDay = null;


/*Для страницы списка ресторанов*/

function ListRestaurantsInit(count) {
    for (var i = 0; i < count; i++) {
        initFancyBox("fancyPhoto-" + i);
    }
}

function InitRestaurantsEvents(date) {
    selectedPreview = $('div[date="'+date+'"]');
    selectedSpanDay = $('span[class*="day cur"]');
}

function showEvent(date, span) {
    if (selectedPreview != null) {
        $(selectedPreview).hide();
    }
    if (selectedSpanDay != null) {
        $(selectedSpanDay).removeClass("cur");
    }

    selectedPreview = $('div[date="' + date + '"]');
    selectedSpanDay = $(span);
    $(span).addClass("cur"); //
    $(selectedPreview).show();
}

function changeGroup(val, totalDays) {
        var totalGroups = totalDays;
        var nextSpan = $('#nextGroup');
        var prevSpan = $('#prevGroup');
        
        var nextGroup = parseInt(nextSpan.attr("nextgroup"));
        var prevGroup = parseInt(prevSpan.attr("prevgroup"));
    
        if (val > 0 && nextGroup >= totalGroups) {
            val = -1;
        }
        if (val < 0 && prevGroup <= -1) {
            val = 1;
        }
        
        if (val < 0 && prevGroup == 0) {
            //prevSpan.hide();
            prevSpan.addClass('disable');
        } else {
            //prevSpan.show();
            prevSpan.removeClass('disable');
        }
        if (val > 0 && nextGroup == totalGroups - 1) {
            //nextSpan.hide();
            nextSpan.addClass('disable');
        } else {
            //nextSpan.show();
            nextSpan.removeClass('disable');
        }
        
        nextSpan.attr("nextgroup", nextGroup+val);
        prevSpan.attr("prevgroup", prevGroup+val);
        
        var group = val > 0 ? nextGroup : prevGroup;

        $("span[group]").hide();
        $("span[group='" + group + "']").show();
    }
    
/*Restaurants.aspx*/
    
function initRestaurants(currentPage) {

    $('.blockPrice.rest .prices .price .num').mouseenter(function () {
        var $this = $(this);
        $this.parent().find('.paramList').slideDown(200);
    });
    $('.blockPrice.rest .prices .price').mouseleave(function () {
        $(this).find('.paramList').slideUp(200);
    });


    $('.rest .paramList li').click(function () {
        var $this = $(this);

        var isChecked = $this.hasClass("checked");

        if ($this.hasClass('_reset')) {
            $this.parent().find('li').removeClass('checked');
            isChecked = true;
        }

        if (isChecked) {
            $this.removeClass("checked");
        } else {
            $this.addClass("checked");
        }

        var $popup = $this.parent().parent();
        var $block = $this.closest('.price');
        var $small = $block.find('small');

        var $checkeds = $popup.find(".checked");

        if ($checkeds.length == 0) {
            $small.text('любая');
        } else {
            var arr = new Array();
            for (var i = 0; i < $checkeds.length; i++) {
                arr.push($checkeds.eq(i).text());
            }
            var str = arr.join(',');
            $small.text(((arr.length == 1) ? arr[0] : arr[0] + "..."));
        }

        $(".blockPrice.rest .prices .btn_block .button").click(function () {
            var page = currentPage;
            page = 1;
            var entriesArr = new Array();

            $(".blockPrice.rest .prices .price .checked").each(function (i, e) {
                entriesArr.push($(e).attr('data-entry-id'));
            });
            var entries = entriesArr.join(',');
            //TODO: Захардкожено
            window.location = '/Restaurants/List/!/Rus/' + page + '/' + entries;
        });
    });
}

/*Для страницы одного ресторана*/

function InitRestaurantEvents(date) {
    InitRestaurantsEvents(date);

    /*$("#calendars").jcarousel();

    //NOTE: fix two table. Предполагаю, что это баг Kendo.Calendar
    setTimeout(function () {
        $("#calendars li").each(function (i, o) {
            $(o).find('table[aria-activedescendant^=calendar_]').last().remove();
        });
        $("#calendars").css("width", "99999px");
    }, 1000);*/
    
    $("._calendarEvent").datepicker("refresh");
    fixCurDay();
        
}

function showArchiveEvent(date) {
    $('#archiveContainer div[class=oneRest]').hide();
    $('#archiveContainer div[class=oneRest][date="' + date + '"]').show();
}

function toddMMyyyy(date) {
    return (date.getDate() >= 0 && date.getDate() <= 9 ? "0" : "") + date.getDate() + "."
            + (date.getMonth() >= 0 && date.getMonth() <= 8 ? "0" : "") + (date.getMonth() + 1) + "." + date.getFullYear();
}


var firstClick = false;
function enableSpecificDates(date) {
    if (typeof (valueDays) == "undefined" || valueDays.length <= 0) return false;
    
    var month = date.getMonth() + 1;
    var day = date.getDate();
    var year = date.getFullYear();

    if (day.toString().length == 1)
        day = "0" + day;
    if (month.toString().length == 1)
        month = "0" + month;

    for (i = 0; i < valueDays.length; i++) {
        if ($.inArray(day + '.' + month + '.' + year, valueDays) != -1) {
            return [true];
        }
    }
    return [false];
}
function fixCurDay() {
    if(!firstClick) {
        $("._calendarEvent").find('a').removeClass('ui-state-active');
        $("._calendarEvent").find('.ui-datepicker-current-day').removeClass('ui-datepicker-current-day');
        $("._calendarEvent").find('.ui-datepicker-days-cell-over').removeClass('ui-datepicker-days-cell-over');
    }
}

$(function () {
    $('.filterHeader .switcher').click(function () {
        $sw = $(this);

        if ($sw.hasClass('cur')) {
            $sw.removeClass('cur');
            $sw.parent().parent().find('.filterBody').hide();
        } else {
            var blockName = $sw.attr('class').replace('switcher ', '');
            $sw.parent().parent().find('.filterBody').hide().filter(':.' + blockName).show();
            $sw.parent().children('.switcher').removeClass('cur');
            $sw.addClass('cur');

//            if (typeof (myMap) != "undefined") {
//                window.setTimeout(function () {
//                    myMap.setBounds(myMap.geoObjects.getBounds());
//                },200);

//            }
        }
    });


    if (typeof (valueDays) != "undefined" && valueDays.length > 0) {
        $("._calendarEvent").datepicker({
            beforeShowDay: enableSpecificDates,
            minDate: valueDays[0],
            maxDate: valueDays[valueDays.length - 1],
            dateFormat: 'dd.mm.yy',
            numberOfMonths: 3,
            showOtherMonths: false,
            onSelect: function (dateText, inst) {
                firstClick = true;
                showArchiveEvent(dateText);
            },
            onChangeMonthYear: function (year, month, inst) {
                fixCurDay();
            }
        });


    }
});