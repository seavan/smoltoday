$(function () {
    $('.editProfileLink span').live('click', function () {
        if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
            $(this).parent().next().toggle();
        } else {
            $(this).parent().next().slideToggle(200);
        }

    });
    $('.grayCreateBlock.profile .buttonPanel .button.reset').live('click', function () {

        $block = $(this).closest('.grayCreateBlock');

        $block.find('form').trigger('reset');

    });
    $('.grayCreateBlock.profile .buttonPanel .button.save').live('click', function () {
        $block = $(this).closest('.grayCreateBlock');
        $block.next('.overlayProfile').show();

        if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
            $block.hide();
        }
        else {
            $block.slideUp(200);
        }
        window.setTimeout(function () {
            $block.find('form').submit();
        }, 200);

    });

    $('.createBlock .datepickerProfile').datepicker({ buttonImage: "/content/i/datepicker_black_ico.png", showOn: "both", buttonImageOnly: true, changeYear: true, changeMonth: true, dateFormat: 'dd.mm.yy' });

    $('.fileInput.avatara').cropAvatar();


    var pageLoaded = false;
    $('.profileHeader select').ddslick(
	{
	    width: 160,
	    background: "#f6f6f6 url(/content/i/bg_selector.gif) 0 bottom repeat-x",
	    onSelected: function (data) {
	        $item = data.selectedItem;
	        $item.parent().parent().next().val(data.selectedData.value);

	        $form = $item.closest('form');
	        if ($form.length > 0 && $form.hasClass('submitOnChange') && pageLoaded) {
	            $form.submit();
	        }

	        pageLoaded = true;

	    }
	});

    $('.profileBody .prfTable .checkbox').click(function () {
        $target = $(this);
        $target.toggleClass('hide');
        $.ajax({
            type: 'POST',
            url: $target.attr('data-url'),
            data: { value: $target.find(":checked").length > 0 }
        });
    });

    $(".profileBody .prfTable .delete").live("click", function () {
        if (!confirm("Вы действительно хотите удалить запись?")) return;
        $btn = $(this);
        $.ajax({
            type: 'POST',
            url: $btn.attr('data-url'),
            success: function () { $btn.closest('tr').remove(); }
        });
    });

    $('._ckeditor').ckeditor({
        customConfig: '/content/js/config.js'
    });

    $('.profilePage .grayCreateBlock .button.cancel').click(function () {
        $block = $(this).closest('.grayCreateBlock');

        $block.find('form').trigger('reset');
    });

    $('.profilePage .blogsList .blogTools .edit').click(function () {
        $but = $(this);
        var url = $but.attr('data-url');
        location.href = url;
    });

    $('.profilePage .blogsList .blogTools .delete').click(function () {
        $but = $(this);
        var url = $but.attr('data-url');
        if (window.confirm("Вы действительно хотите удалить запись?")) {
            $but.closest('.blogAdvt').remove();
            $.ajax({
                type: 'POST',
                traditional: true,
                cache: false,
                url: url
            });
        }

    });


    $('.profileHeader .createPortfolio').not('.addNewPhoto').click(function () {
        location.href = '/Profile/PhotoCreateProfile';
    });

    $('.profileHeader .profileTools .radio').click(function () {
        var $curWrapCh = $(this);
        var $input = $curWrapCh.children();
        window.setTimeout(function () {
            if ($input.attr('checked')) {
                location.href = $curWrapCh.attr('data-url');
            }

        }, 100);
    });

    $('.profileBody .createAlbum').click(function () {
        $(this).closest('.profileBody').find('.grayCreateBlock').slideToggle();
    });

    $('.profileHeader .createPortfolio.addNewPhoto').click(function () {
        if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
            $('.form_addNewPhoto').show();
            $('.form_addRelPhoto').hide();
        }
        else {
            $('.form_addNewPhoto').slideDown();
            $('.form_addRelPhoto').slideUp();
        }

    });
    $('.profileBody .photoInfo .addPhoto').click(function () {

        $but = $(this);
        var url = $but.attr('data-url');

        $target = $('.form_addRelPhoto');
        if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
            $target.hide();
            $('.form_addNewPhoto').hide();
        }else {
            $target.slideUp();
            $('.form_addNewPhoto').slideUp();
        }

        $.ajax({
            type: 'GET',
            traditional: true,
            cache: false,
            url: url,
            success: function (data) {
                $target.html($(data).html());

                if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
                    $('.form_addRelPhoto').show();
                }
                else {
                    $('.form_addRelPhoto').slideDown();
                }
            }
        });

    });


    $('.grayCreateBlock.form_addNewPhoto .buttonPanel .button.reset, .grayCreateBlock.form_addRelPhoto .buttonPanel .button.reset').live('click', function () {

        $block = $(this).closest('.grayCreateBlock');
        $block.find('form').trigger('reset');
        if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
            $block.hide();
        }
        else {
            $block.slideUp(200);
        }

    });
    $('.grayCreateBlock.form_addNewPhoto .buttonPanel .button.save, .grayCreateBlock.form_addRelPhoto .buttonPanel .button.save').live('click', function () {
        $block = $(this).closest('.grayCreateBlock');
        $block.next('.overlayProfile').show();


        window.setTimeout(function () {
            $block.find('form').submit();
        }, 200);

    });


    (function () {
        $("#categories").on("change", function () {
            updateFields($(this));
        });

        $("#add-image").on("click", function () {
            var $target = $("#ad-images");
            var template = "<span class=\"inputFileWrapper\"><span class=\"text photo\"></span><span class=\"button\">Выбрать фотографию</span><input type=\"file\" name=\"Files[" + $target.data("count") + "]\" class=\"fileInput\" /></span>";


            $target.append(template);
            $target.data("count", parseInt($target.data("count")) + 1);
        });

        $(".btn-delete").on("click", function () {
            var $this = $(this);
            if (confirm("Вы точно хотите удалить это изображение?")) {
                $.ajax({
                    url: '/Profile/DeleteAdImage',
                    type: "POST",
                    data: { id: $this.data("id") },
                    success: function () {
                        $this.closest("div").remove();
                    }
                });
            }
        });
    })();
});

function initProfileMain() {
    $('.createBlock .datepickerProfile').datepicker({ buttonImage: "/content/i/datepicker_black_ico.png", showOn: "both", buttonImageOnly: true, changeYear: true, changeMonth: true, dateFormat: 'dd.mm.yy' });
    $(".radio").dgStyle();
    $('.fileInput.avatara').cropAvatar();
}

function hideOverlay() {
    $('.overlayProfile').hide();
}


function updateFields(el) {
    $.ajax({
        url: '/Profile/AdvertFields',
        data: { categoryId: el.val(), adId: $("#Advertisment_id").val() },
        success: function (result) {
            $(".dynamic-advert-field").remove();
            $('#advert-contacts').before(result);
        }
    });
}

function uploadSuccess(xx) {
    alert(xx);
}