(function ($) {
    $.fn.outerHTML = function() {
        return $(this).clone().wrap('<div></div>').parent().html();
    };
})(jQuery);


var ckcreated = false;

function createCkEditor(action, param) {
    var $editors = $("._editor textarea._visual");
    if ($editors.length) {
        $editors.each(function () {

            var editorID = $(this).attr("id");
            var instance = CKEDITOR.instances[editorID];

            if (instance && (action == 'grid-edit')) {
                instance.destroy(true);
                instance = null;
            }
            if (!instance) {
                CKEDITOR.replace(editorID);
                instance = CKEDITOR.instances[editorID];
                instance.on('change', function () {
                    $('#' + editorID).val(this.getData());
                });
            }
        });
    }
}


var TELERIK_MODAL_STACK = Array();

function closeTelerikTopMost() {
    var $modalWindow = $('.t-window');
    $modalWindow.each(function () {
        pushTelerikStack($(this));
    });

    $('div[role=dialog]').remove();
}

function popTelerikStackAll() {
    while (TELERIK_MODAL_STACK.length) {
        popTelerikStack();
    }
}

function popTelerikStack() {
    if (TELERIK_MODAL_STACK.length > 0) {
        var w = TELERIK_MODAL_STACK.pop();
        w.data('tWindow').open();
        w.data('tWindow').center();
    }
}

function pushTelerikStack($_tWindow) {

    $_tWindow.data('tWindow').close();
    TELERIK_MODAL_STACK.push($_tWindow);
}

function updateGrids(e, src) {
    var action = src ? src : e;
    var param = null;
    if (e) {
        //action = "telerik";
        param = e;
    }

    createFieldButtons(action, param);
    createSubmitButtons(action, param);
    createLinkButtons(action, param);
    bindEvents(action, param);
    updateDisabled(action, param);
    createCkEditor(action, param);
}

function updateDisabled() {
    var $inp = $('._disabled input');
    $inp.attr('readonly', 'readonly');

    $inp = $inp.filter('*[name!="id"]');
    $inp.attr('id', null);
    $inp.attr('name', null);
}

function bindEvents() {
    
}

function toggleForeignField(obj) {
    var $obj = $(obj);

    var $form = $obj.parents('form').first();
    var $cont = $obj.parent().parent().find('._foreign');
    var $key = $obj.parent().parent().find('._thisKey');
    var $display = $obj.parent().parent().find('._thisDisplay');
    var controller = $obj.parent().parent().find('._controller').text();

    $.ajax(
    {
        url: controller,
        type: 'POST',
        data: $form.serialize(),
        success: function (_data) {
            // close window if any
            closeTelerikTopMost();

            $cont.html('<div class="_modal"></div>');
            $modal = $cont.find('._modal');
            $modal.html(_data);
            $modal.dialog(
            {
                width: 1000,
                autoOpen: false,
                position: ['center', 10],
                close: function () {
                    $('._modal').remove();
                }
            });
            $modal.get(0).setValue =
                function (_val, _display) {
                    $key.val(_val);
                    if ($key.length > 0) {
                        if ($key.get(0).gridSelect) {
                            $key.get(0).gridSelect();
                        }
                    }

                    $display.text(_display);
                };
            $modal.dialog('open');

        }
    });

}

function bindRow(_obj) {
    var $row = $(_obj.row);
    var $dialogCont = $row.parents('._modal').eq(0);
    if ($dialogCont.length > 0) {
        $row.click(
            function () {
                var i = $row.find('._gridId').text();
                var d = $row.find('._gridDisplay').text();

                $dialogCont.dialog('close');
                $dialogCont.get(0).setValue(i, d);
                popTelerikStackAll();
            }
        )
    }
}

function createFieldButtons() {
    var $field = $('._field ._expander');
    $field.each(
        function(index, obj) {
            $(obj).button().unbind('click').click(
                function () {
                    var $cont = $(obj).parent().parent().find('._foreign');

                    toggleForeignField(obj);
                }
            );
            });

    var $apply = $('._field ._apply');
    $apply.each(
        function (index, obj) {
            $(obj).button();
            $(obj).hide();
        });

    var $del = $('._field ._deleteLink');
    $del.each(
    function (index, obj) {
        $(obj).button().unbind('click').click(
            function () {
                //var $cont = $(obj).parent().parent().find('._foreign');

                delValueField(obj);
            }
        );
    });
}

function delValueField(obj) {
    var $obj = $(obj);

   
    var $key = $obj.parent().parent().find('._thisKey');
    var $display = $obj.parent().parent().find('._thisDisplay');

    $key.val('');
    $display.text('n/a');
    
}

function createSubmitButtons() {
    $('input:submit').button();
}

function createLinkButtons() {
    var $links = $('a._link');
    $links.button();

}

function gridEdit(e) {
    var win = $('.t-window').data('tWindow');
    if (win) {
        win.center();
        updateGrids(e, 'grid-edit');
    }
}

function gridSave(e) {
    var win = $('.t-window').data('tWindow');
    if (win) {
        win.center();
        updateGrids(e, 'grid-save');
    }
}

function fixOptional() {
    var $oe = $('._optionalEnabler');
    $oe.each(function () {
        var $this = $(this);
        var $td = $this.parents('td').next();
        $this.data('name', $td.find('input').attr('name'));

        var updateEnabler = function(_enabler) {
            var $this = $(_enabler);
            var $td = $this.parents('td').next();
            if ($this.attr('checked')) {
                $td.find('input').attr('name', $this.data('name'));
                $td.find('._optional').show();
            } else {
                $td.find('input').attr('name', 'disabled_attr');
                $td.find('._optional').hide();
            }

        };

        $this.click(function () { updateEnabler(this) });

        updateEnabler(this);

    });

}

function bindRemoveImage() {
    $('._removeImage').click(function () {
        var rel = $(this).attr('rel');
        var $parent = $(this).parent().parent();
        $parent.find('img').hide();
        $parent.find('input').val('');

    });
}

$(document).ready(

function () {
    bindRemoveImage();
    fixOptional();
    updateGrids('document-ready');
}
);

jQuery.ajaxSetup({ traditional: true });

$(document).ready(function () {
    var filters = $('.t-grid-filter');
    filters.click(function () {
        window.setTimeout(
                    function () {
                        var $sels = $('.t-filter-operator');
                        //alert($sels.length);
                        $sels.val('substringof');
                    }, 0);

    });

    $('form').submit(function () {
        $(document).remove('._blockSubmit');
        if (saveCallbacks) {

            var i = 0;
            for (i = 0; i < saveCallbacks.length; ++i) {
                (saveCallbacks[i])();
            }
        }

        if ($('._blockSubmit').length) return false;
    }
    );

});

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    console.log(a);
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function saveFunction(selector, url, prefix, parentId, parentProto) {
    var $orig = $(selector);
    $dict = $orig.find('input, select');

    url = $orig.attr('data-uri');


    var params = $dict.serializeObject();
    params['field'] = $orig.attr('data-prefix');
    params['parentId'] = $orig.attr('data-parent-id');
    params['parentProto'] = $orig.attr('data-parent-proto');

    $.ajax(url, {
        data: params,
        dataType: 'json',
        type: 'POST',
        async: false,
        success: function(response) {
            if (response) {
                for (var property in response) {
                        $('#' + property.replace(/\./g, "\\.")).html(response[property]);
                }
            }
        }
    });
    return false;
}

var saveCallbacks = new Array();

