jQuery.fn.extend({
    advautocomplete: function () {
        $.each($(this), function () {
            var $fld = $(this);
            var $id = $fld.next();
            while (!$id.hasClass('_autocompleteid')) {
                $id = $id.next();
            }
            var $url = $fld.attr('rel');

            var _objTitle = $fld.attr('id');
            var _objId = $id.attr('id');
            var _urlToGet = $url;

            var isSelected = false;
            var $el = $('input#' + _objTitle);


            $el.autocomplete({
                minLength: 3
            , source: function (request, response) {
                
                $el.addClass('_preloader');
                newTerm = request.term;
                $.ajax({

                    type: 'POST'
                    , dataType: 'json'
                    , url: _urlToGet
                    , data: { newTag: request.term }
                    , complete: function () { $el.removeClass('_preloader'); }
                    , success: function (data) {

                        //Создаем массив для объектов ответа
                        var suggestions = [];

                        //Новый запрос, обнуляем, что был выбор
                        isSelected = false;

                        //Обрабатываем ответ 
                        $.each(data, function (i, val) {
                            var span = {
                                'id': val.Id,
                                'title': val.Title,
                                'additional': val.Additional
                            };
                            if (span.additional == null) span.additional = "";
                            suggestions.push(span);
                        });

                        //Передаем массив обратному вызову
                        response(suggestions);
                    }
                });
            }
            , search: function () {
                //Новый запрос, обнуляем, что был выбор
                //console.log('search');
                isSelected = false;

            }
            , select: function (event, ui) {
                isSelected = true;
                this.value = ui.item.title;
                $("#" + _objId + "").val(ui.item.id);
                return false;
            }

            , focus: function (event, ui) {
                this.value = ui.item.title;
                return false;
            }
            , change: function () {
                if (!isSelected || $("#" + _objTitle).val() == "") {
                    $("#" + _objId).val("0");
                }
            }

            }).data('autocomplete')._renderItem = function (ul, item) {
                return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a>" + fnFormatResult(item.title, newTerm) + "<small>" + item.additional + "</small></a>")
				.appendTo(ul);
            };
        });
    }
});



var reEscape = new RegExp('(\\' + ['/', '.', '*', '+', '?', '|', '(', ')', '[', ']', '{', '}', '\\'].join('|\\') + ')', 'g');

function fnFormatResult(value, currentValue) {

    var words = currentValue.split(' ');
    for (var i = 0; i < words.length; ++i) {
        if (words[i] != "") {
            pattern = '(' + words[i].replace(reEscape, '\\$1') + ')';
            value = value.replace(new RegExp(pattern, 'gi'), '<strong>$1<\/strong>');
        }
    }
    return value;
}

var newTerm = "";

$(function () {
    try {
        $('input._advautocomplete').advautocomplete();    
    }catch(er) {}
});

//function autoCompleteObject( _objTitle, _objId, _urlToGet) {


//    var isSelected = false;
//    var $el = $( 'input#' + _objTitle );
//    
//    //_urlToGet = prompt(_urlToGet, _urlToGet);
///*
//    $el.attr('id', _objTitle = (new Date()).getTime() );
//*/

//    //$el.unbind();
//    /*
//    .removeClass('ui-autocomplete-input')
//    .removeAttr('autocomplete')
//    .removeAttr('role')
//    .removeAttr('aria-autocomplete')
//    .removeAttr('aria-haspopup');*/

//    $el.autocomplete({
//        minLength: 3
//        , source: function (request, response) {
//            //alert(2);
//            $el.addClass('_preloader');
//            newTerm = request.term;
//            $.ajax({

//                type: 'POST'
//                , dataType: 'json'
//                , url: _urlToGet
//                , data: { newTag: request.term }
//                , complete: function () { $el.removeClass('_preloader'); }
//                , success: function (data) {

//                    //Создаем массив для объектов ответа
//                    var suggestions = [];

//                    //Новый запрос, обнуляем, что был выбор
//                    isSelected = false;

//                    //Обрабатываем ответ 
//                    $.each(data, function (i, val) {
//                        var span = {
//                            'id': val.Id,
//                            'title': val.Title,
//                            'additional': val.Additional
//                        };
//                        if (span.additional == null) span.additional = "";
//                        suggestions.push(span);
//                    });

//                    //Передаем массив обратному вызову
//                    response(suggestions);
//                }
//            });
//        }
//        , search: function () {
//            //Новый запрос, обнуляем, что был выбор
//            //console.log('search');
//            isSelected = false;

//        }
//        , select: function (event, ui) {
//            //console.log('select');
//            //Был произведен выбор из предлагаемых данных
//            try { CheckOrganization($('._newOrgName'), $('._LawyersCount')); } catch (e) { }

//            isSelected = true;
//            this.value = ui.item.title;
//            $("#" + _objId + "").val(ui.item.id);
//            try { LoadCommunityAvatar(ui.item.id); } catch (e) { }
//            try { SetAddressPlace(ui.item.additional) } catch (e) { }
//            CheckExistOrgAndBranch($("#" + _objId + ""));
//            SelectableCommunityAvatar($("#" + _objId + ""), ui.item.additional);
//            return false;
//        }

//        , focus: function (event, ui) {
//            //console.log('focus');
//            this.value = ui.item.title;
//            return false;
//        }
//        , change: function () {
//            console.log('change');

//            if (!isSelected || $("#" + _objTitle).val() == "") {
//                $("#" + _objId).val("");
//                CheckExistOrgAndBranch($("#" + _objId + ""));
//                SelectableCommunityAvatar($("#" + _objId + ""), "");
//            }
//        }

//    }).data('autocomplete')._renderItem = function (ul, item) {
//        return $("<li></li>")
//				.data("item.autocomplete", item)
//				.append("<a>" + fnFormatResult(item.title, newTerm) + "<small>" + item.additional + "</small></a>")
//				.appendTo(ul);
//    };
//}






//function split(val) {
//    return val.split(/,\s*/);
//}
//function extractLast(term) {
//    return split(term).pop();
//}
//function autoCompleteKeyWords(_objTitle, _urlToGet) {

//    var $el = $('#' + _objTitle);

//    $el.autocomplete({
//        source: function (request, response) {
//            $el.addClass('_preloader');
//            newTerm = extractLast(request.term);
//            $.ajax({
//                url: _urlToGet,
//                data: {
//                    newTag: newTerm
//                },
//                dataType: "json",
//                type: "POST",
//                complete: function () { $el.removeClass('_preloader'); },
//                success: function (data) {
//                    response(data);
//                }
//            });
//        },
//        search: function () {
//            // custom minLength
//            var term = extractLast(this.value);
//            if (term.length < 2) {
//                return false;
//            }
//        },
//        focus: function () {
//            // prevent value inserted on focus
//            return false;
//        },
//        select: function (event, ui) {
//            var terms = split(this.value);
//            // remove the current input
//            terms.pop();
//            // add the selected item
//            terms.push(ui.item.value);
//            // add placeholder to get the comma-and-space at the end
//            terms.push("");
//            this.value = terms.join(", ");
//            return false;
//        }
//    }).data('autocomplete')._renderItem = function (ul, item) {
//        return $("<li></li>")
//				.data("item.autocomplete", item)
//				.append("<a>" + fnFormatResult(item.value, newTerm) + "</a>")
//				.appendTo(ul);
//    };
//}