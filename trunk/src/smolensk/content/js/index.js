$(function () {
    (function () {

        var $container = $('.photoBlock');
        var $nextA = $container.find('.rArrow');
        var $prevA = $container.find('.lArrow');
        var $lenta = $container.find('.lenta.cur');
        var lock = false;
        var interval;

        var slideSlider = function () {
            if ($nextA.length) {
                $nextA.click();
            }
        };

        interval = window.setInterval(slideSlider, 9000);

        $nextA.click(function () {
            if (lock || $lenta.children().length < 2) return false;
            lock = true;
            $lenta.find('.imgBlock:first').animate({
                marginLeft: '-650px'
            }, 1000, function () {
                $(this).detach().css('marginLeft', '0px').appendTo($lenta);
                lock = false;
            });
            return false;
        });

        $prevA.click(function () {
            if (lock || $lenta.children().length < 2) return false;
            lock = true;
            $lenta.find('.imgBlock:last').detach().prependTo($lenta).css('marginLeft', '-650px');
            $lenta.find('.imgBlock:first').animate({
                marginLeft: '0px'
            }, 1000, function () {
                lock = false;
            });
            return false;
        });

        var $selectors = $('.selectorNews > span');
        $selectors.click(function () {

            window.clearInterval(interval);

            $cur = $(this);
            $all = $cur.parent().children('span');
            $all.removeClass('cur');
            $cur.addClass('cur');

            var index = simpleDeterminantIndex($all, $cur);

            $container.find('.lenta').removeClass('cur');
            $container.find('.lenta').eq(index).addClass('cur');
            $lenta = $container.find('.lenta.cur');

            interval = window.setInterval(slideSlider, 3000);
        });

        var $dateSelectors = $container.find('.dateSelector li');

        $dateSelectors.click(function () {

            if (lock || $lenta.children().length < 2) return false;


            $li = $(this);
            if (!$li.hasClass('cur')) {
                lock = true;
                var $curLi = $li.parent().children().filter('.cur');
                var index = simpleDeterminantIndex($li.parent().children(), $li);
                var curIndex = simpleDeterminantIndex($curLi.parent().children(), $curLi);
                var step = index - curIndex;
                var stepCounter = 1;
                if (step > 0) {

                    $lenta.find('.imgBlock:first').animate(
					{
					    marginLeft: '-' + (650 * step) + 'px'
					},
					{
					    duration: 1000,
					    step: function (now, fx) {
					        if (now < (-650 * stepCounter)) {
					            $lenta.find('.imgBlock').eq(stepCounter).css('marginLeft', now + (650 * stepCounter) + 'px');
					        }
					    },
					    complete: function () {
					        for (var i = 0; i < step; ++i) {
					            $lenta.find('.imgBlock:first').detach().css('marginLeft', '0px').appendTo($lenta);
					        }
					        lock = false;
					    }
					}
					);

                } else {
                    for (var i = 0; i < Math.abs(step); ++i) {
                        $lenta.find('.imgBlock:last').detach().prependTo($lenta).css('marginLeft', '-' + (650 * (i + 1)) + 'px');
                    }
                    $lenta.find('.imgBlock:first').animate(
					{
					    marginLeft: '0px'
					},
					{
					    duration: 1000,
					    step: function (now, fx) {
					        if (now <= (-650 * stepCounter)) {
					            $lenta.find('.imgBlock').eq(stepCounter).css('marginLeft', now + (650 * stepCounter) + 'px');
					        }
					    },
					    complete: function () {
					        lock = false;
					    }
					}
					);
                }
            }
        });

    })();

    (function () {

        var $container = $('.blockPrice');
        var $nextA = $container.find('.rArrow');
        var $prevA = $container.find('.lArrow');
        var $lenta = $container.find('.lenta');
        var lock = false;

        $nextA.click(function () {
            if (lock || $lenta.children().length < 6) return false;
            lock = true;
            $lenta.children().eq(0).animate({
                marginLeft: '-155px'
            }, 500, function () {
                $(this).detach().css('marginLeft', '0px').appendTo($lenta);
                lock = false;
            });
            return false;
        });

        $prevA.click(function () {
            if (lock || $lenta.children().length < 6) return false;
            lock = true;
            $lenta.children().eq($lenta.children().length - 1).detach().prependTo($lenta).css('marginLeft', '-155px');
            $lenta.children().eq(0).animate({
                marginLeft: '0px'
            }, 500, function () {
                lock = false;
            });
            return false;
        });



        /* zakon foreva ;) */

        $pricePanel = $('#priceCityPanel');

        if ($pricePanel.length <= 0) {
            $pricePanel = $('<div id="priceCityPanel" style="z-index:5000"></div>')
            $('body').append($pricePanel);
        }

        $('.blockPrice .prices .lenta > .price').live('mouseleave', function (e) {

            if ($price.find('.moreInfo').length > 0 && $price.data('id')) {
                var $pricePopup = $pricePanel.children('.moreInfo[data-id=' + $price.data('id') + ']');

                if ($pricePopup.length > 0) {

                    var x1 = $pricePopup.offset().left;
                    var x2 = x1 + $pricePopup.width();

                    var y1 = $pricePopup.offset().top;
                    var y2 = y1 + $pricePopup.height();

                    if (e.pageX < x1 || e.pageX > x2 || e.pageY < y1 || e.pageY > y2)
                        $pricePopup.hide();
                    // $pricePanel.children('.aboutMan[data-id=' + $price.data('id') + ']').hide();
                }
            }
        });

        $('#priceCityPanel .moreInfo').live('mouseleave', function (e) {
            $(this).hide();
        });

        $('.blockPrice .prices .lenta > .price').live('mouseenter', function (e) {

            $price = $(this);

            if ($price.find('.moreInfo').length > 0) {
                if (!$price.data('id') || $pricePanel.children('.moreInfo[data-id=' + $price.data('id') + ']').length <= 0) {
                    $oldPrice = $price.find('.moreInfo');
                    $newPrice = $oldPrice.clone();

                    $price.data('id', $pricePanel.children().length + 1);
                    $newPrice.attr('data-id', $price.data('id'));
                    $newPrice.css('z-index', 5000);
                    $oldPrice.show();
                    $newPrice.css('left', $oldPrice.offset().left);
                    $newPrice.css('top', $oldPrice.offset().top);
                    $newPrice.css('margin-left', 0);
                    $oldPrice.hide();   

                    $pricePanel.append($newPrice);
                } else if ($pricePanel.children('.moreInfo[data-id=' + $price.data('id') + ']').length > 0) {
                    $oldPrice = $price.find('.moreInfo');
                    $newPrice = $pricePanel.children('.moreInfo[data-id=' + $price.data('id') + ']').eq(0);
                    
                    $oldPrice.show();
                    $newPrice.css('left', $oldPrice.offset().left);
                    $newPrice.css('top', $oldPrice.offset().top);
                    $newPrice.css('margin-left', 0);
                    $oldPrice.hide();
                }

                $pricePanel.children('.moreInfo[data-id=' + $price.data('id') + ']').show();
            }

        });

    })();
});