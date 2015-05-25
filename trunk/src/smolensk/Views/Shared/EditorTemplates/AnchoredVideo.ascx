<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<div id="_video"></div>
<script language="javascript" type="text/javascript">

    jwplayer("_video").setup({
        flashplayer: "/Content/js/jwplayer/player.swf",
        wmode: 'transparent',
        image: "http://video.zakon.ru/<%= Model %>.jpg",
        file: "http://video.zakon.ru/<%= Model %>.flv",
        provider: 'http',
        skin: '/Content/js/jwplayer/modieus.zip',
        height: 251,
        width: 335,
        events: {
            
        }
    });

</script>
<div><i>Расстановка ключевых точек. Для добавления ключевой точки поставьте плеер на паузу на нужном моменте, введите краткое наименование ключевой точки и нажмите кнопку "ДобавитЬ". Ключевая точка будет добавлена, а список - обновлен</i><br />
<span>Заголовок:</span><input type="text" id="_title" name="_title" /><a class="_link _linkAnchor">Добавить</a>
</div>
<br />
<div><i>Текущие ключевые точки:</i></div>
<div class="_currentKeys keys"></div>
<script language="javascript" type="text/javascript">
    var GLOBAL_OBJECT_ID;

    function reloadKeys(videoId) {
        $.ajax(
            {
                url: "/AdminFrontVideo/GetAnchors",
                data: { id: GLOBAL_OBJECT_ID },
                success: function (_data) {
                    var i = 0;
                    var $ck = $('._currentKeys');
                    $ck.html('');
                    for (i = 0; i < _data.length; ++i) {
                        var item = _data[i];
                        $ck.append('<a class="_link" rel=' + item.id + '>' + Math.floor(item.position / 60) + 'm : ' + (item.position % 60) + 's - ' + item.title + ' (удалить)</a>');
                    }

                    $ck.find('a').button().click(deleteAnchor);
                }
            }
        )
        }

        function deleteAnchor() {
            var $a = $(this);
            var rel = $a.attr('rel');
            $.ajax(
                {
                    url: "/AdminFrontVideo/RemoveAnchor",
                    data: { id: rel },
                    success: function (_data) {
                        reloadKeys(GLOBAL_OBJECT_ID);
                    }
                }
            );
            }

        function addAnchor() {
            var title = $('#_title').val();
            var pos = Math.floor(jwplayer().getPosition());
            var vid = GLOBAL_OBJECT_ID;

            $.ajax(
            {
                url: "/AdminFrontVideo/AddAnchor",
                data: { 
                        _videoId: vid,
                        _position: pos,
                        _title: title    
                    },
                type: 'POST',
                success: function (_data) {
                    reloadKeys(GLOBAL_OBJECT_ID);
                }
            }
        );
        }

        $(document).ready(
            function () {
                GLOBAL_OBJECT_ID = <%= ViewData["ObjectId"] %>;
                reloadKeys();
                $('._linkAnchor').click(addAnchor);
            });

</script>