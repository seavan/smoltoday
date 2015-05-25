
cropper = function ($fileAva) {

    var cr = new Object();

    var smallWidth = 165;
    var url = $fileAva.attr('data-uploadurl');
    var form = $fileAva.closest('form');
    var $avaImg = form.find('._avatar');
    if ($avaImg.length <= 0)
        $avaImg = $('._avatar');
    if ($avaImg.length <= 0)
        return;
    var ddd;

    var sizeOrig;
    var sizeFake;
    var $fixIEAvaParentFile;

    cr.$blockAvatar;
    cr.$avatarCropControl;

    cr.$imgCropFull;
    cr.$btnCancel;
    cr.$btnSave;

    cr.$divPreview;
    cr.$imgCropPreview;

    cr.prepareImg = function (ev) {
        if (!checkFileSize(this))
            return;

        cr.$imgCropPreview.css({ top: 0, left: 0, position: 'absolute' });
        cr.$divPreview.css({ top: $avaImg.offset().top + 5, left: $avaImg.offset().left + 5 });
        cr.$blockAvatar.css({ top: $avaImg.offset().top, left: $fileAva.offset().left });

        cr.$avatarCropControl.hide();
        cr.$imgPreloader.show();
        cr.$blockAvatar.show();

        $fixIEAvaParentFile = $(ev.target || ev.srcElement).parent(); //Костылим из-за IE, который не понимает clone на файлы и приходится подменять fileinput и заново его переинициализировать.

        $.ajaxUpload(
        {
            url: url,
            secureuri: false,
            data: [$fileAva[0]],
            success: cr.avatarUpload,
            error: function (data, status, e) {
                alert(e);
            }
        });
    }

    cr.setEventChange = function ($file) {
        $fileAva = $file;
        var node = $file[0];

        if (typeof node.addEventListener != 'undefined') {
            node.addEventListener('change', cr.prepareImg, false);
        } else if (typeof node.attachEvent != 'undefined') {
            node.attachEvent('on' + 'change', cr.prepareImg);
        }
    }

    cr.setEventChange($fileAva);

    cr.createAvatarCropStruct = function () {

        if ($('.avatarCrop').length <= 0) {

            cr.$blockAvatar = $('<div class="avatarCrop"></div>');
            cr.$avatarCropControl = $('<div class="avatarCropControl" style="display:none;"></div>');

            cr.$imgCropFull = $('<img class="imgCropFull" src="" />');
            cr.$btnCancel = $('<span class="button btnCancel">Закрыть</span>');
            cr.$btnSave = $('<span class="button btnSave">Выбрать</span>');

            cr.$divPreview = $('<div class="previewBlock"></div>');
            cr.$imgCropPreview = $('<img class="imgCropPreview" src="" />');

            cr.$avatarCropControl.append(cr.$imgCropFull).append('<br/>').append(cr.$btnCancel).append(cr.$btnSave);
            cr.$blockAvatar.append(cr.$avatarCropControl);
            cr.$divPreview.append(cr.$imgCropPreview);
            $('body').append(cr.$blockAvatar).append(cr.$divPreview);

        } else {

            cr.$blockAvatar = $('.avatarCrop');
            cr.$avatarCropControl = $('.avatarCropControl');

            cr.$imgCropFull = $('.imgCropFull');
            cr.$btnCancel = $('.btnCancel');
            cr.$btnSave = $('.btnSave');

            cr.$divPreview = $('.previewBlock');
            cr.$imgCropPreview = $('.imgCropPreview');

        }

        cr.$imgPreloader = $('.overlayProfile');

        cr.$avatarCropControl.css({ 'display': 'none' });
        cr.$blockAvatar.css({ position: 'absolute', display: 'none' });
        cr.$divPreview.css({ width: smallWidth + 'px', height: smallWidth + 'px', overflow: 'hidden', display: 'none', position: 'absolute' });
        cr.$imgCropFull.css({ marginBottom: '10px' });

        cr.$btnCancel.unbind('click').click(function (ev) { cr.HideCrop(this, true); });

        cr.$btnSave.unbind('click').click(function (ev) { cr.SaveCrop(this); });


    }


    cr.avatarUpload = function (_data) {

        cr.setEventChange($fixIEAvaParentFile.find('input[type=file]')); //Костылим из-за IE, который не понимает clone на файлы и приходится подменять fileinput и заново его переинициализировать.

        if (_data == "Error upload file!") {
            cr.$imgPreloader.hide();
            cr.$blockAvatar.hide();
            alert('Ошибка загрузки. Возможно, превышен размер файла.');
        }
        else if (_data == "Error type file!") {
            cr.$imgPreloader.hide();
            cr.$blockAvatar.hide();
            alert('Ошибка загрузки. Неверный тип файла.');
        }
        else {
            var img = new Image();
            img.onload = function () {
                // Show controls
                cr.$imgPreloader.hide();
                cr.$divPreview.show();
                // set img src
                cr.$imgCropFull.attr('src', _data);
                cr.$imgCropPreview.attr('src', _data);

                sizeOrig = { w: img.width, h: img.height };
                sizeFake = cr.AdjustSize({ cur: sizeOrig, max: { w: 500, h: 500} });

                cr.$imgCropFull.css({ width: sizeFake.w, height: sizeFake.h });


                ddd = sizeFake.w / sizeFake.h;

                if (cr.$cropApi == null)
                    cr.$cropApi = cr.$imgCropFull.imgAreaSelect({ instance: true, aspectRatio: '1:1', onSelectChange: cr.SelectionChange });

                cr.$avatarCropControl.show(0, function () {

                    cr.$imgCropPreview.css({ top: 0, left: 0, width: cr.$imgCropFull.width(), height: cr.$imgCropFull.height() });

                    cr.$cropApi.setSelection(0, 0, smallWidth, smallWidth, true);
                    cr.$cropApi.setOptions({ show: true, movable: true, resizable: true });
                    cr.$cropApi.update();
                    cr.$blockAvatar.css({ width: cr.$imgCropFull.width() });
                });
            };

            img.src = _data;


        }
    }

    cr.AdjustSize = function (_cfg) {
        var crop = {}
        var val;
        var k = 1;

        for (val in _cfg.cur) {
            crop[val] = _cfg.cur[val];

            if (typeof _cfg.max[val] != 'undefined')
                k = Math.max(_cfg.cur[val] / _cfg.max[val], k);
        }

        if (k > 1)
            for (val in crop)
                crop[val] /= k;

        crop.k = k;

        return crop;
    }

    cr.SelectionChange = function (_img, _prm) {

        if (_prm.width == 0)
            return;

        var crop2Full = _prm.width / _img.width;
        var ico2Crop = smallWidth / _prm.width;

        var previewWidth = smallWidth / crop2Full;

        cr.$imgCropPreview.css({ top: -Math.round(_prm.y1 * ico2Crop)
              , left: -Math.round(_prm.x1 * ico2Crop)
              , height: Math.round(previewWidth / ddd)
              , width: Math.round(previewWidth)
        });
    }


    cr.HideCrop = function (_this, _hidePreview) {
        cr.$cropApi.setOptions({ hide: true });
        cr.$cropApi.update();
        cr.$blockAvatar.hide();

        if (_hidePreview == true)
            cr.$divPreview.hide();
    };

    cr.SaveCrop = function (_this) {
        var selection;
        var $block = $(_this);

        cr.HideCrop(this);

        selection = cr.$cropApi.getSelection();
        selection.url = /[\w.-]*$/.exec(cr.$imgCropFull.attr('src'))[0];

        if (sizeFake.k > 1) {
            selection.height *= sizeFake.k;
            selection.width *= sizeFake.k;

            selection.x1 *= sizeFake.k;
            selection.x2 *= sizeFake.k;
            selection.y1 *= sizeFake.k;
            selection.y2 *= sizeFake.k;
        }

        $.ajax(
            {
                type: 'POST',
                traditional: true,
                cache: false,
                url: url,
                data:
                {
                    x1: parseInt(selection.x1.toString().split('.')),
                    y1: parseInt(selection.y1.toString().split('.')),
                    width: parseInt(selection.width.toString().split('.')),
                    height: parseInt(selection.height.toString().split('.')),
                    url: selection.url
                },
                success: function (_data) {
                    $avaImg.attr('src', _data);
                    cr.$divPreview.hide();

                    $fixIEAvaParentFile.find('input[type=hidden]').val(/[\w.-]*$/.exec(_data)[0]);
                }
            });
    }


    cr.createAvatarCropStruct();
}


jQuery.fn.extend({
    cropAvatar: function () {

        $.each($(this), function () {
            _cropper = new cropper($(this));
        });
    }
});


