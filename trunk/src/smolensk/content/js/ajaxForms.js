$(function () {
    $('form.ajaxForm').live('submit', function (ev) {
        ev.preventDefault();

        //Форма и адрес запроса
        var form = $(this);
        var url = form.attr('data-action');
        var callback = form.attr('data-callback');

        //Цель (элемент) для ответа с сервера
        var $target = form.closest('' + form.attr('data-target') + '');
        if ($target.length <= 0)
            $target = $('' + form.attr('data-target') + '');

        //Метод вставки ответа
        //дефолтно без параметров - pfvtyfзамена html в data-target
        //addAfter - вставка после data-target
        //addBefor - вставка перед data-target
        var processing_metod = form.attr('data-processing');

        //Дизейблим поля, если указано, что их нужно дизейблить при отправке
        var $disabledFields = form.find('._submit_disabled');
        $disabledFields.attr('disabled', 'disabled');

        $.ajaxUpload(
            {
                url: url,
                secureuri: false,
                form: form,
                complete: function (xml, status) {
                    $disabledFields.removeAttr('disabled');
                    $disabledFields.val("");
                },
                success: function (data, status) {
                    try {

                        if (data.indexOf("ajaxScript") > -1) {
                            data = data.replace(new RegExp("&lt;", 'g'), "<");
                            data = data.replace(new RegExp("&gt;", 'g'), ">");
                            if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
                                eval($("<span>" + data + "</span>").text());
                            }
                            else{
                                $("<span>" + data + "</span>").find("ajaxScript").each(function (e) {
                                    try {
                                        eval($(this).text());
                                    } catch (e) { }
                                });
                            }

                        } else {

                            switch (processing_metod) {
                                case "addAfter":
                                    $(data).appendTo($target); break;
                                case "addBefor":
                                    $(data).prependTo($target); break;
                                default: $target.html($(data).html()); break;
                            }


                            $target.find('input[type=text], textarea').focus();
                            try {
                                $target.find('input._autoclear').val('');
                                $target.find('input[type=text][value=""], textarea[value=""]').eq(0).focus();
                            } catch (e) { }
                        }

                        if (typeof (callback) != "undefined") {
                            eval(callback + '()');
                        }

                    } catch (e) {
                        alert(e);
                    }
                },
                error: function (data, status, e) {
                    alert(e);
                }
            }
        );
    });
});