$(function () {
    (function () {
        $targetBlogs = $('.listBlogs');
        if ($targetBlogs.length > 0) {

            $targetBlogs.addClass('preloader');

            $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/GetTopBlogs',
                complete: function () { $targetBlogs.removeClass('preloader'); },
                success: function (_data) {
                    $targetBlogs.html(_data);
                }
            });
        }

        $targetDiscussions = $('.listDiscussions');
        if ($targetDiscussions.length > 0) {

            $targetDiscussions.addClass('preloader');

            $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/GetTopDiscussions',
                //data: { id: parseInt(comId) },
                complete: function () { $targetDiscussions.removeClass('preloader'); },
                success: function (_data) {
                    $targetDiscussions.html(_data);
                }
            });
        }

        $('.leftMain span.delete').live("click", function () {

            if (!confirm("Вы действительно хотите удалить запись с главной страницы?")) { return; }

            var id = $(this).parent().attr('rel');
            //alert(id);
            //return;
            $target = $(this).closest('table').parent();

            $target.addClass('preloader');
            $target.html("");
            $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/DeleteFromTop',
                data: { id: parseInt(id) },
                complete: function () { $target.removeClass('preloader'); },
                success: function (_data) {
                    $target.html(_data);
                }
            });
        });

        var $addBtn = $('._addBlogId');
        if ($addBtn.length > 0) {
            $addBtn.get(0).gridSelect = function () {
                var $target = $('.blogsBlock .listBlogs');
                var self = this;
                self.val = $(this).val();
                $target.addClass('preloader');
                $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/AddTop',
                data: { id: parseInt(self.val) },
                complete: function () { $target.removeClass('preloader'); },
                success: function (_data) {
                    $target.html(_data);
                }
            });
            }
        }

        var $addDiscBtn = $('._addDiscId');
        if ($addDiscBtn.length > 0) {
            $addDiscBtn.get(0).gridSelect = function () {
                var $target = $('.discussionBlock .listDiscussions');
                var self = this;
                self.val = $(this).val();
                $target.addClass('preloader');
                $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/AddTop',
                data: { id: parseInt(self.val) },
                complete: function () { $target.removeClass('preloader'); },
                success: function (_data) {
                    $target.html(_data);
                }
            });
            }
        }

        $('._topEntry').live("click", function () {
            var prevId = $(this).attr('rev');
            var curId = $(this).attr('rel');
            //alert(prevId);

            $target = $(this).closest('table').parent();
            $target.addClass('preloader');
            $target.html("");

            $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/Move',
                data: { curId: parseInt(curId), prevId: parseInt(prevId), direction: 1 },
                complete: function () { $target.removeClass('preloader'); },
                success: function (_data) {
                    $target.html(_data);
                }
            });

        });
        $('._bottomEntry').live("click", function () {
            var prevId = $(this).attr('rev');
            var curId = $(this).attr('rel');
            //alert(prevId);

            $target = $(this).closest('table').parent();
            $target.addClass('preloader');
            $target.html("");

            $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/Move',
                data: { curId: parseInt(curId), prevId: parseInt(prevId), direction: 2 },
                complete: function () { $target.removeClass('preloader'); },
                success: function (_data) {
                    $target.html(_data);
                }
            });

        });

    })();

    (function () {
        var $checkMailer = $("#MailerMaterial");
        var $textMailer = $("#Text[name=Text]");
        var $templateList = $("#templateMailerContent");
        var $templateTr = $("<tr class=\"_contentMaterial\"><td style=\"text-align:right;\">Составьте список материалов для рассылки</td><td colspan=2></td></tr>");


        var $tr = $textMailer.closest('tr');
        if ($checkMailer.attr('checked')) {
            $tr.closest('tr').hide();
            if ($("._contentMaterial").length <= 0) {

                $templateList.show();
                $templateList.detach();
                $templateTr.find('td[colspan=2]').append($templateList);
                $tr.after($templateTr);
            }
            else {
                $("._contentMaterial").show();
            }
        }
        else {
            $tr.closest('tr').show();
            if ($("._contentMaterial").length > 0) {
                $("._contentMaterial").hide();
            }
        }


        var $addBtnB = $('._addBlogB');
        if ($addBtnB.length > 0) {
            $addBtnB.get(0).gridSelect = function () {
                var $target = $(this).closest('.blogsBlock').find('.listBlogsM');
                var self = this;
                self.val = $(this).val();
                var typeM = $(this).attr('rel');
                $target.addClass('preloader');
                $.ajax(
                {
                    type: 'POST',
                    traditional: true,
                    url: '/MainPage/AddMaterial',
                    data: { id: parseInt(self.val), type: typeM },
                    complete: function () { $target.removeClass('preloader'); },
                    success: function (_data) {
                        $target.html(_data);
                    }
                });
            }
        }
        var $addBtnD = $('._addBlogD');
        if ($addBtnD.length > 0) {
            $addBtnD.get(0).gridSelect = function () {
                var $target = $(this).closest('.blogsBlock').find('.listBlogsM');
                var self = this;
                self.val = $(this).val();
                var typeM = $(this).attr('rel');
                $target.addClass('preloader');
                $.ajax(
                {
                    type: 'POST',
                    traditional: true,
                    url: '/MainPage/AddMaterial',
                    data: { id: parseInt(self.val), type: typeM },
                    complete: function () { $target.removeClass('preloader'); },
                    success: function (_data) {
                        $target.html(_data);
                    }
                });
            }
        }
        var $addBtnC = $('._addBlogC');
        if ($addBtnC.length > 0) {
            $addBtnC.get(0).gridSelect = function () {
                var $target = $(this).closest('.blogsBlock').find('.listBlogsM');
                var self = this;
                self.val = $(this).val();
                var typeM = $(this).attr('rel');
                $target.addClass('preloader');
                $.ajax(
                {
                    type: 'POST',
                    traditional: true,
                    url: '/MainPage/AddMaterial',
                    data: { id: parseInt(self.val), type: typeM },
                    complete: function () { $target.removeClass('preloader'); },
                    success: function (_data) {
                        $target.html(_data);
                    }
                });
            }
        }
        var $addBtnV = $('._addBlogV');
        if ($addBtnV.length > 0) {
            $addBtnV.get(0).gridSelect = function () {
                var $target = $(this).closest('.blogsBlock').find('.listBlogsM');
                var self = this;
                self.val = $(this).val();
                var typeM = $(this).attr('rel');
                $target.addClass('preloader');
                $.ajax(
                {
                    type: 'POST',
                    traditional: true,
                    url: '/MainPage/AddMaterial',
                    data: { id: parseInt(self.val), type: typeM },
                    complete: function () { $target.removeClass('preloader'); },
                    success: function (_data) {
                        $target.html(_data);
                    }
                });
            }
        }

        $('#templateMailerContent span.delete').live("click", function () {

            if (!confirm("Вы действительно хотите удалить запись из рассылки?")) { return; }

            var id = $(this).parent().attr('rel');
            var typeM = $(this).parent().attr('rev');

            $target = $(this).closest('table').parent();

            $target.addClass('preloader');
            $target.html("");
            $.ajax(
            {
                type: 'POST',
                traditional: true,
                url: '/MainPage/DelMaterial',
                data: { id: parseInt(id), type: typeM },
                complete: function () { $target.removeClass('preloader'); },
                success: function (_data) {
                    $target.html(_data);
                }
            });
        });

    })();
});