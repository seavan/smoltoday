var calendarExt = function (container, month, year) {
    var _container = container;
    var _month = month;
    var _year = year;

    var calendar = document.createElement("div");
    $(_container).append(calendar);

    var date = new Date(_year, _month - 1, 1);
    var minDate = new Date(date.getFullYear(), date.getMonth(), 1);
    var maxDate = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    var instance = this;

    $(calendar).datepicker({
        firstDay: 1,
        hideIfNoPrevNext: true,
        minDate: minDate,
        maxDate: maxDate,
        onSelect: function (dateText, inst) {
            instance.onSelected(dateText);
        }
    });

    this.onSelected = function (date) {
    }

    this.hide = onHide;
    this.show = onShow;
    this.appendDayClass = onAppendDayClass;

    function onHide() {
        $(instance._calendar).hide();
    }

    function onShow() {
        $(instance._calendar).show();
    }

    function onAppendDayClass(day, style) {
        var a = $(calendar).find('table[class=ui-datepicker-calendar] td a').filter(function () { return $(this).text() == day; });
        var td = a.parent();
        var txt = $(a).text();
        $(a).remove();
        $(a).text(txt);
        $(td).click = null;
        $(td).css("cursor", "pointer");
    }
}