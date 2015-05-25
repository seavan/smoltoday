$(document).ready(function () {


    $('.photo-switcher').each(function (e) {
        var $photoSwitcher = $(this);

        var $viewdPicture = $photoSwitcher.find('.viewed-pic');
        var $previewPictures = $photoSwitcher.find('.preview-pic a');

        $viewdPicture.each(function (ev) {
            $this = $(this);

            if ($this.find('.preloader').length <= 0) {
                $this.append($('<span class="preloader" style="position:absolute; top:0px; left:0px; background:#ffffff url(/content/i/100.gif) no-repeat center center; opacity:0.6; width:463px; height:296px; display:block; display:none;"></span>'));
            }
        });

        $previewPictures.each(function (ev) {
            $(this).click(function () {
                switchPicture($viewdPicture, $(this));
                return false;
            });
        });

        $viewdPicture.find('.lArrow').click(function () {
            switchPicture($viewdPicture, -1);
        });

        $viewdPicture.find('.rArrow').click(function () {
            switchPicture($viewdPicture, 1);
        });


    });

    var interval;

    function switchPicture($viewdPicture, $previewPicture) {
        window.clearInterval(interval);

        $previewPicture = typeof $previewPicture == 'number' ? nextPicture($viewdPicture, $previewPicture) : $previewPicture;

        var $imgViewd = $viewdPicture.find('img');
        var $imgPreview = $previewPicture.find('img');

        $imgViewd.attr('alt', $imgPreview.attr('alt'));

        var $descr = $viewdPicture.find('small');

        $descr.html($imgPreview.attr('alt'));

        if ($descr.html().length == 0) {
            $descr.css("visibility", "hidden");
        } else {
            $descr.css("visibility", "visible");
        }

        //$viewdPicture.children().fadeOut(500);
        $viewdPicture.find('.preloader').show();

        var pause = false;
        window.setTimeout(function () {
            pause = false;
        }, 500);

        var ni = new Image();
        ni.src = $imgPreview.parent('a').attr('href');

        interval = window.setInterval(function () {
            if (ni.complete && !pause) {

                window.clearInterval(interval);
                $imgViewd.attr('src', $(ni).attr('src'));
                $viewdPicture.find('.preloader').hide();

                //$viewdPicture.children().fadeIn(500);
                //img.parentNode.parentNode.parentNode.getElementsByTagName("div")[0].style.display = "none";
            }
        }, 250);

        //$imgViewd.attr('src', $imgPreview.parent('a').attr('href'));

    }

    function nextPicture($viewdPicture, shift) {

        var $imgViewd = $viewdPicture.find('img');
        var $previewPictures = $viewdPicture.next().find('.preview-pic');

        for (var i = 0; i < $previewPictures.length; i++) {
            if ($previewPictures.eq(i).find('a').attr('href') == $imgViewd.attr('src')) {
                i = (i + shift) % $previewPictures.length;
                if (i < 0) {
                    i = $previewPictures.length - 1;
                }
                return $previewPictures.eq(i);
            }
        }
    }



});