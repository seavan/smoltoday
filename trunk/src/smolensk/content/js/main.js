function simpleDeterminantIndex($collection, $element) {
    var index = $element.index();
    /*fix IE7-8*/
    if (window.navigator.userAgent.indexOf('MSIE 7') > -1 || window.navigator.userAgent.indexOf('MSIE 8') > -1) {
        index = 0;
        for (var i = 0; i < $collection.length; i++) {
            if ($collection.eq(i).text() == $element.text()) {
                break;
            }
            ++index;
        }
    }
    return index;
}

$(function () {
    if ($.fn.dgStyle) {
        $(".radio").dgStyle();
        $(".checkbox").dgStyle();
    } else {
        console.log('dg style not found');
    }


    /*autohide */
    (function () {

        var $elems = $('label._autohide ~ input, label._autohide ~ textarea');
        var hdr = function () {
            var $fld = $(this);
            $('label._autohide[for="' + $fld.attr('id') + '"]').toggle($fld.val() == '');
        };

        $elems.live('focus', function () { var $fld = $(this); $('label._autohide[for="' + $fld.attr('id') + '"]').hide(); });

        $elems.live('blur', hdr);
        $elems.live('change', hdr);

        $elems.each(hdr);

        $elems.prev().click(function () {
            $(this).next().focus();
        });

        setTimeout(function () {
            $elems.blur();
        }, 510);

    })();

    /*Fix for mozilla*/
    if ($.browser.mozilla) {

    }
    /*Fix for chrome*/
    if ($.browser.safari) {
        $('.searchBlock input[type=text]').addClass('chromHack');
        $('.yourmail input[type=text]').addClass('chromHack');
        $('.formBody .enterForm input[type=text]').addClass('chromHack');
        $('.formBody .enterForm input[type=password]').addClass('chromHack');
        $('.changePasswordForm input[type=password], .changePasswordForm input[type=text]').addClass('chromHack');
        $('.vacancySearch .searchLine input[type=text]').addClass('chromHack');
    }
    if (window.chrome) {
        $('.advertSelection input[type=text]').addClass('chrome-fix');
        $('.vacancyOne .createBlock input[type=text]').addClass('chrome-fix');
    }
    /*Fix for opera*/
    if ($.browser.opera) {

    }

    /*Fix for fucking IE */
    if ($.browser.msie) {
        $('.blockPrice .prices .price, .blockPrice.photo .name').mouseenter(function () {
            $(this).find('.moreInfo').show();
        });
        $('.blockPrice .prices .price, .blockPrice.photo .name').mouseleave(function () {
            $(this).find('.moreInfo').hide();
        });

        $('.randomVacancy > div').eq(0).css("margin-left", "0");
    }


    $('a[href=#]').attr('href', 'javascript:void(0);');

    (function () {
        $('.blockMap .showMap').click(function () {
            $(this).parent().next().slideToggle(500);
        });
    })();

    (function () {
        $('.weatherPopUp .close').click(function () {
            $(this).parent().hide();
        });

        $('.selectedInfo .weather').click(function () {
            $(this).parent().next().show();
        });
    })();

    (function () {
        $('.overlayBlock .close, .overlayLayer').click(function () {
            var $block = $(this).closest('.overlayBlock');
            $block.hide().find('._closest').hide();
            $block.find('.input-validation-error').removeClass('input-validation-error');
            $block.find('.field-validation-error').remove();
            $block.find('input[type=text], input[type=password], textarea').val('').blur();
            $block.find('input[type=checkbox]:checked').removeAttr('checked');
        });
    })();

    (function () {
        $('.formBody .enterForm.auth small span').live("click", function () {
            $('.formBody .enterForm').hide();
            $('.formBody .enterForm.registr').show();
        });
        $('.formBody .enterForm.registr small span').live("click", function () {
            $('.formBody .enterForm').hide();
            $('.formBody .enterForm.auth').show();
        });
        $('.formBody .enterForm .button').live("click", function () {
            $(this).parent().submit();
        });
        $('.formBody .enterForm.auth .remember_pass').live("click", function () {
            $('.formBody .enterForm').hide();
            $('.formBody .enterForm.remember').show();
            return false;
        });
        $('.formBody .enterForm.auth .repeat_code').live("click", function () {
            $('.formBody .enterForm').hide();
            $('.formBody .enterForm.repeat').show();
            return false;
        });


        $('.searchBlock .button').click(function () {
            $(this).parent().submit();
        });

        $('.authBlock .register').click(function () {
            $('.overlayBlock').show();
            $('.overlayBlock .enterForm.registr').show();
            $('.overlayBlock .enterSocial').show();
        });
        $('.authBlock .enter').click(function () {
            $('.overlayBlock').show();
            $('.overlayBlock .enterForm.auth').show();
            $('.overlayBlock .enterSocial').show();
        });

    })();


    /* что здесь было переехало в index*/


    (function () {
        var _offset = '-9px';
        if ($.browser.opera) {
            _offset = '-5px';
        }
        if ($.browser.msie && $.browser.version.indexOf('7') > -1) {
            _offset = '42px';
        }
        //$.waypoints.settings.scrollThrottle = 30;
        try {
            $('.widthSite').waypoint(function (event, direction) {
                $(this).find('.stickyheader.hasBanner').toggleClass('fix', direction === "down");
                var $sth = $(this).find('.stickyheader.hasBanner');
                if (direction === "up") {
                    //$sth.slideUp({duration: 1000, easing: 'easeInQuad'});
                    $sth.animate({ top: '50px' }, 0, 'swing', function () {

                    });
                }
                else {
                    //$sth.slideDown({duration: 1000, easing: 'easeOutQuad'});
                    $sth.animate({ top: '0px' }, 0, 'swing', function () {

                    });
                }
                event.stopPropagation();
            }, {
                offset: _offset
            });
        } catch (e) { }
    })();

    (function () {
        try {
            $('.tagCloud').tagcloud({ centrex: 120, centrey: 80, init_motion_x: 10, init_motion_y: 10, fps: 24 });
        } catch (e) { }
    })();
    (function () {
        $(".photoList .imgBlock table").mouseenter(function () {
            $table = $(this);
            $preview = $table.find('.bigPreview');
            $preview.css('left', $table.position().left + 69 + 'px')
            $preview.css('top', $table.position().top + 69 + 'px')
            $preview.show();
        });
        $(".photoList .imgBlock table").mouseleave(function () {
            $(this).find('.bigPreview').hide();
        });
    })();

    (function () {
        $('.languageSelector span').click(function () {
            $but = $(this);
            if ($but.hasClass('cur'))
                return;

            var index = $but.index();
            $buttons = $but.parent().find('span');
            $buttons.removeClass('cur');
            $but.addClass('cur');

            for (var i = 0; i < $buttons.length; ++i) {
                if ($buttons.eq(i).hasClass('cur')) {
                    index = i;
                    break;
                }
            }


            $but.parent().parent().find('.letters').hide().eq(index).show();

        });
    })();

    (function () {
        try {
            $('.searchBlock.company .categorySelect').ddslick(
				{
				    width: 270,
				    background: "#efefef",
				    onSelected: function (data) {
				        data.selectedItem.parent().parent().next().val(data.selectedData.value);
				    }
				});

            $('.advertSelection .selectorRange select').ddslick(
				{
				    width: 75,
				    background: "#f6f6f6 url(/content/i/bg_selector.gif) 0 bottom repeat-x",
				    onSelected: function (data) {
				        data.selectedItem.parent().parent().next().val(data.selectedData.value);
				    }
				});
            $('.advertSelection .wideSelector select').ddslick(
				{
				    width: 210,
				    background: "#f6f6f6 url(/content/i/bg_selector.gif) 0 bottom repeat-x",
				    onSelected: function (data) {
				        data.selectedItem.parent().parent().next().val(data.selectedData.value);
				    }
				});

            $('.advertSelection .periodRange input.rangeFrom, .advertSelection .periodRange input.rangeTo').datepicker({ onClose: function (selectedDate) {
                var $input = $(this);
                if ($input.hasClass('rangeTo')) {
                    $input.parent().find('input.rangeFrom').datepicker("option", "maxDate", selectedDate);
                }
                if ($input.hasClass('rangeFrom')) {
                    $input.parent().find('input.rangeTo').datepicker("option", "minDate", selectedDate);
                }
            }
            });

        } catch (ex) { }
    })();

    (function () {
        try {
            $('.advertOne .carausel_photo ul').jcarousel({
                start: 0,
                vertical: true,
                scroll: 2
            });
        } catch (ex) { }
    })();


    /*анимация звёздочек рейтинга при наведении*/
    (function () {

        //var wait = true;
        $('.info .rating').each(function () {

            //wait = true;
            var $stars = $(this).find('span');
            $stars.data('cur', '');
            var $cur = $(this).find('span.cur');
            $cur.data('cur', 'cur');

            //console.log("chislo zvjozd cur: " + $cur.length);
            //wait = false;
        });

        $('.info .rating span').mouseenter(function () {
            var $this = $(this);
            //window.setTimeout(function () {
            //if (!wait) {
            var $stars = $this.parent().find('span');
            $stars.removeClass('cur');

            for (var i = 0; i < $stars.length; ++i) {

                $stars.eq(i).addClass('cur');
                if ($stars.eq(i).text() == $this.text()) break;
            }
            //}
            //}, 10);


        });

        $('.info .rating').mouseleave(function () {
            var $this = $(this);
            //window.setTimeout(function () {
            //if (!wait) {
            var $stars = $this.find('span');
            $stars.removeClass('cur');
            //console.log("chislo zvjozd pole uvoda: " + $stars.length);
            for (var i = 0; i < $stars.length; ++i) {
                //console.log(i);
                if ($stars.eq(i).data('cur') == 'cur') {
                    $stars.eq(i).addClass('cur');
                }
            }
            //wait = true;
            //}
            //}, 200);
        });

        $('.info .rating.isAuth span').click(function () {
            var $this = $(this);
            var $parent = $this.parent();

            var $stars = $parent.find('span');
            $stars.data('cur', '');
            var rating = 0;
            for (var i = 0; i < $stars.length; ++i) {
                ++rating;
                $stars.eq(i).data('cur', 'cur');
                if ($stars.eq(i).text() == $this.text()) break;
            }
            //console.log(rating);

            $.ajax({
                type: 'POST',
                url: "/Marks/SetMark",
                data: { MaterialId: parseInt($parent.attr('data-id')), ProtoName: $parent.attr('data-proto'), CMark: rating }
            });


        });

        $('.info .rating span').click(function () {
            if (!$(this).parent().hasClass('isAuth')) {
                alert('Только авторизованные пользователи могут ставить оценки.');
            }
        });

    })();
    /* звёздочик рейтинга - конец */

    /*new vacancy*/
    (function () {

        var $file = $('.inputFileWrapper .fileInput');
        /* IE8 BUG. <input type=file> event :: change */
        var node = $file[0];
        var $tmp;
        var $input;

        var _hdr = function (ev) {

            if ($file.length == 1) { $tmp = $file; }
            else { $tmp = $(this); }

            $input = $(ev.target || ev.srcElement);

            $tmp.parent().find('.text').text($input.val());
        };

        /**/
        if ($file.length == 1) {
            if (typeof node.addEventListener != 'undefined') {
                node.addEventListener('change', _hdr, false);
            } else if (typeof node.attachEvent != 'undefined') {
                node.attachEvent('on' + 'change', _hdr);
            }
        } else {
            $('.inputFileWrapper input[type=file].fileInput').live('change', _hdr);
        }

        $('.createBlock .radio').click(function () {
            var $curRadio = $(this);
            var $groupRadio = $("input[name='" + $curRadio.children().attr("name") + "']").parent();
            $groupRadio.parent().find('input[type="text"]').attr("disabled", "disabled");
            $curRadio.parent().find('input[type="text"]').removeAttr("disabled");
        });

        $('.createBlock .windowFrame .checkbox').click(function () {
            var $curWrapCh = $(this);
            var $par = $curWrapCh.parent();
            var $input = $curWrapCh.children();
            window.setTimeout(function () {
                if ($input.attr('checked')) {
                    $par.find('ul').show();
                } else {
                    $par.find('ul').hide();
                }

            }, 100);

        });

        $('.createBlock .phone+.checkbox').click(function () {
            var $curWrapCh = $(this);
            var $field = $curWrapCh.next();
            var $input = $curWrapCh.children();
            window.setTimeout(function () {
                if ($input.attr('checked')) {
                    $field.removeAttr("disabled");
                } else {
                    $field.attr("disabled", "disabled");
                }

            }, 100);
        });

        $('.createBlock .experience .checkbox').click(function () {
            var $curWrapCh = $(this);
            var $par = $curWrapCh.closest('.experience');
            var $input = $curWrapCh.children();
            window.setTimeout(function () {
                if ($input.attr('checked')) {
                    $par.find('input[type="text"]').attr("disabled", "disabled");
                } else {
                    $par.find('input[type="text"]').removeAttr("disabled");
                }

            }, 100);
        });

        $('.createSubForm .nowJob .checkbox').click(function () {
            var $curWrapCh = $(this);
            var $par = $curWrapCh.closest('.body');
            var $input = $curWrapCh.children();
            window.setTimeout(function () {
                if ($input.attr('checked')) {
                    $par.find('input[type="text"].toDateJob').attr("disabled", "disabled");
                } else {
                    $par.find('input[type="text"].toDateJob').removeAttr("disabled");
                }

            }, 100);
        });

        try {
            $('.windowFrame > div').mCustomScrollbar({
                set_height: "260px",
                scrollInertia: 150
            });
        } catch (e) { }

        $('.createBlock .datepicker').datepicker({ buttonImage: "/content/i/datepicker_black_ico.png", showOn: "both", buttonImageOnly: true, changeYear: true, changeMonth: true });
        $('.createBlock .datepicker_range').datepicker({ buttonImage: "/content/i/datepicker_black_ico.png", showOn: "both", buttonImageOnly: true, changeYear: true, changeMonth: true,
            onClose: function (selectedDate) {
                var $input = $(this);
                if ($input.hasClass('toDate')) {
                    $input.parent().find('input.fromDate').datepicker("option", "maxDate", selectedDate);
                }
                if ($input.hasClass('fromDate')) {
                    $input.parent().find('input.toDate').datepicker("option", "minDate", selectedDate);
                }
            }
        });

        /*формы ajax добавления*/
        $('.createSubForm .addSubFormButton').click(function () {
            $(this).parent().toggleClass('show');
        });

        $('.button.reset').click(function () {
            $(this).parent().prev('.windowFrame').resetFormBlock();
        });

        $('.createSubForm .button.save').click(function () {

            $bt = $(this);

            $wr = $bt.closest('._cloneWrapper');
            $newLine = $wr.cloneFormBlock();

            $form = $bt.closest('.createSubForm');

            var $strEl = $form.find('[data-clone-data^=tmp_str]')
            var $datarEl = $form.find('[data-clone-data^=tmp_date]');

            for (var i = 0; i < $strEl.length; ++i) {
                $newStr = $newLine.find('.' + $strEl.eq(i).attr('data-clone-data'));
                $newStr.html($strEl.eq(i).val());
            }
            for (var j = 0; j < $datarEl.length; ++j) {
                $newD = $newLine.find('.' + $datarEl.eq(j).attr('data-clone-data'));
                if ($newD.html().length <= 0) {
                    $newD.html($datarEl.eq(j).val());
                } else {
                    $newD.html($newD.html() + " - " + $datarEl.eq(j).val());
                }
            }


            //Это в конце - очистка
            $form.resetFormBlock();

            $form.removeClass('show');
        });



    })();

    /*комментирование комментариев*/
    (function () {
        $('.show_parentComment').live('click', function () {
            $trg = $($(this).attr('href'));
            $('html, body').stop().animate({ scrollTop: $trg.offset().top - 40 }, 500);
            $('.allComments .oneComment .commentBody').css('background-color', '#F6F6F6');
            $('.allComments .oneComment form .commentBody').css('background-color', 'transparent');
            $trg.parent().find('.commentBody').css('background-color', '#FFF5BF');
            return false;
        });
        $('.write_review').live('click', function () {
            $bt = $(this);
            $form = $bt.closest('.oneComment').next('.oneComment.replyForm');
            $('.oneComment.replyForm').filter(function (index) {
                return $(this).find('input[name="ParentId"]').val() != $form.find('input[name="ParentId"]').val();
            }).slideUp();
            $form.slideToggle();

        });
        $('.oneComment.replyForm .button').live('click', function () {
            $(this).closest('.oneComment.replyForm').slideUp();
            $('html, body').stop().animate({ scrollTop: $('.oneComment:first').offset().top }, 500);
        });
    })();

    /*Поиск вакансий - форма*/
    (function () {
        $('._prof_area').click(function () {
            $span = $(this);
            $tr = $span.parent().parent().next();
            $ch = $span.find('input');
            window.setTimeout(function () {
                if ($ch.attr('checked')) {
                    $tr.hide().resetFormBlock();
                }
                else {
                    $tr.show();
                }
            }, 10);
        });

        $('._custom_check_radio .radio').click(function () {
            $(this).parent().find('div').resetFormBlock();
        });
        $('._custom_check_radio .checkbox').click(function () {
            $ch = $(this);
            $rd = $ch.closest('td').find('.radio');

            $rd.children('input').removeAttr('checked');

            $rd.css('background-position', '0 0').data("checked", false);
        });
    })();

    $('.posterPage .selectorDate .datepicker').datepicker({ buttonImage: "/content/i/datepicker_gray_ico.png", showOn: "both", buttonImageOnly: true });

    $('.moreSelector li').each(function (index, element) {
        var $this = $(this);
        var $parent = $this.closest('.moreList');
        if ($this.hasClass('cur')) {
            $parent.find('.placeTable').hide();
            $parent.find('.placeTable').eq(index).show();
        }
    });

    $('.moreSelector li:not(.cur)').live('click', function () {
        var $this = $(this);
        $this.parent().children().removeClass('cur');
        $this.addClass('cur');

        var index = $this.index();

        var $parent = $this.closest('.moreList');
        $parent.find('.placeTable').hide();
        $parent.find('.placeTable').eq(index).show();
    });

    $('.visitors > span').click(function () {
        $(this).parent().find('.visitorsList').slideToggle(200);
    });
    $('.posterPage .description a.more').click(function () {
        $(this).closest('.description').find('div').show();
        $(this).hide();
        $(this).parent('p').hide();
    });

    $('.posterPage .addQuestion').click(function () {
        $('.overlayBlock').show();
        $('.overlayBlock .enterForm.add_question').show().closest('.getsession').show();
    });

    $('.posterPage .addAction, .profilePage .addAction').click(function () {
        $('.overlayBlock').show();
        $('.overlayBlock .enterForm.add_action').show().closest('.getsession').show();
    });

    $('.advertOne .button.mail').click(function () {
        $('.overlayBlock').show();
        $('.overlayBlock .enterForm.write_mail').show().closest('.getsession').show();
    });

    $('.vacancyOne .noResume').click(function () {
        $('.overlayBlock').show();
        //$('.overlayBlock .enterForm.no_resume').show();
        $("#vacancy_no_resume_form").show();

    });

    $('.vacancyOne .answer').click(function () {
        $('.overlayBlock').show();
        $('.overlayBlock .enterForm.invitation').show().closest('.getsession').show();

    });

    try {
        $('.enterForm.send_resume .resumeList .wrapper').mCustomScrollbar({
            set_height: "250px",
            scrollInertia: 150
        });
    } catch (e) { }
    $('.vacancyOne .button.sendResume, .vacancyOne .button.answer, .vacancyCompany .button.vacancy').click(function () {
        $('.overlayBlock').show();
        $('.overlayBlock .enterForm.send_resume').show().closest('.getsession').show();

    });
    $('.complaintLink').click(function () {
        $('.overlayBlock').show();
        $(".overlayBlock .enterForm.complain").show().closest('.getsession').show();
    });

    /*блоги*/
    $('.blogsMenu li.more').click(function () {
        $(this).find('.moreBlogsMenu').slideToggle();
    });
    $('.blogsPresentation .button.begin').not('.enter').click(function () {
        location.href = '/Profile/BlogEdit';
    });
    $('.beginBlog .button.begin').not('.enter').click(function () {
        location.href = '/Profile/BlogEdit';
    });


    /*фото-видео по теме*/
    (function () {

        /*$('.archive .datepicker').datepicker();*/
        $('._photoForTheme .imgBlock a').live('click', function () {

            $link = $(this);
            $parent = $link.closest('.imgBlock');
            $('.imgBlock').removeClass('cur');
            $parent.addClass('cur');

            $photoForTheme = $link.closest('._photoForTheme');
            $curshow = $photoForTheme.find('.showBlock');
            $curshow.removeClass('isShow');
            $('.showBlock.isShow').slideUp();

            //$curshow.find('img').attr("src", $link.attr("href"));	
            //$curshow.find('a').attr("href", $link.attr("data-url"));
            //$curshow.find('a').text($link.attr("title"));
            ChangeImg($link, $curshow.find('img'));

            $curshow.slideDown();
            $curshow.addClass('isShow');

            return false;
        });

        $('._photoForTheme .showBlock img').live('click', function () {

            $img = $(this);
            $all = $('.imgBlock');

            var index = 0;

            for (var i = 0; i < $all.length; ++i) {
                $block = $all.eq(i);
                if ($block.hasClass('cur')) {
                    if ((i + 1) <= ($all.length - 1)) {
                        index = i + 1;
                    }
                    else {
                        index = 0;
                    }
                    break;
                }
            }

            $all.removeClass('cur');
            $cur = $all.eq(index);
            $cur.addClass('cur');
            //$img.attr("src", $cur.find('a').attr("href"));
            //$img.parent().find('a').attr("href", $cur.find('a').attr("data-url"));
            //$img.parent().find('a').text($cur.find('a').attr("title"));
            ChangeImg($cur.find('a'), $img);

        });

        function ChangeImg($src, $dst) {
            $dst.attr("src", $src.attr("href"));
            $dst.parent().find('a').attr("href", $src.attr("data-url"));
            $dst.parent().find('a').text($src.attr("title"));
        }

        $('._videoForTheme > a').live('click', function () {
            $link = $(this);
            $parent = $link.parent();
            $('._videoForTheme > a').removeClass('cur');
            $link.addClass('cur');

            $curshow = $parent.find('.showBlock');
            $curshow.removeClass('isShow');
            $('.showBlock.isShow').slideUp();

            //$curshow.find('span').html($link.find('.videoInfo').html());
            $curshow.find('span iframe').attr('src', $link.find('.videoInfo').text());
            $curshow.find('a').attr("href", $link.attr("href"));
            $curshow.find('a').text($link.attr("title"));


            $curshow.slideDown();
            $curshow.addClass('isShow');

            return false;
        });
    })();

    $('.visitorsSend').live("click", function () {
        $(this).parent().hide();
        $.ajax({
            type: 'POST',
            url: "/Poster/AddParticipiants",
            data: { action_id: parseInt($(this).attr('rel')) },
            success: function (data) {
                if (data && data != -1)
                    $('.visitorsResult').text(data);
            }
        });
    });

    $('.button.moreThemePhoto').live("click", function () {
        $but = $(this);
        $target = $but.parent().prev();
        var page = parseInt($but.attr('data-page'));
        ++page;
        $but.attr('data-page', page);

        $.ajax({
            type: 'POST',
            url: "/News/" + $but.attr('data-url'),
            data: { id: parseInt($but.attr('data-id')), page: page },
            success: function (data) {
                if (data) {
                    $wrapper = $('<div>' + data + '</div>');

                    if ($wrapper.find('._photoForTheme .imgBlock').length < 16 || $wrapper.find('._videoForTheme > a').length < 12) {
                        $but.hide();
                    }

                    $wrapper.find('._photoForTheme').each(function () {
                        $(this).appendTo($target);
                    });

                    $wrapper.find('._videoForTheme').each(function () {
                        $(this).appendTo($target.find('.categoryList'));
                    });
                }
            }
        });
    });




    $('.posterPage .howFind .button').click(function () {
        $('.overlayBlock').show();
        $('.overlayBlock .formBody .getsession').show();
    });

    $('.linkFavor a, .button.favorite, .favorStar').live("click", function () {
        $link = $(this);
        $target = $link.parent();

        $.ajax({
            type: 'POST',
            url: $link.attr('data-url'),
            data: { id: parseInt($target.attr('data-id')), proto: $target.attr('data-name'), view: $target.attr('data-view') },
            success: function (data) {
                if (data)
                    $target.html($(data).html());
            }
        });
    });
});

function updateBlock(selector, url) {
    $.ajax({
        url: url,
        type: 'POST',
        async: true,
        success: function (res) {
            if (res)
                $(selector).html(res);
        }
    });
}

function checkFileSize(thisFile) {

    var checkSize = true;
    var maxFileSize = 104857600;

    if (thisFile.value != "") {

        if ($(thisFile).attr('data-maxsize')) {
            try {
                maxFileSize = parseInt($(thisFile).attr('data-maxsize'));
            } catch (e) {
            }
        }
        if (/msie/i.test(navigator.userAgent)) {
            //            try {
            //                var fso = new ActiveXObject("Scripting.FileSystemObject");
            //                var filepath = thisFile.value;
            //                var thefile = fso.getFile(filepath);
            //                var size = thefile.size;
            //                if (size > maxFileSize) checkSize = false;
            //            } catch (e) {
            //                alert("Загрузка невозможна. Разрешите выполнение ActiveX объекта. Upload unavailable. Give permission for ActiveX Object.");
            //                return false;
            //            }
            return true;
        } else {
            try {
                var size = thisFile.files[0].size;
                if (size > maxFileSize) checkSize = false;
            } catch (e) {
                alert("Error: " + e);
                return false;
            }
        }

        if (!checkSize) {
            alert("Загрузка невозможна. Превышен допустимый размер файла.");
            return false;
        }
    }
    return true;
}
