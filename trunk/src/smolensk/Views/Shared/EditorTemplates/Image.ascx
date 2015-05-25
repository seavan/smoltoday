<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="admin.db" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var parent = ViewData["parentModel"] as IDatabaseEntity;
%>
<% if (parent.id > 0)
{ %>
<div style="float: right" id="<%= fname %>Image">
</div>
<div>
    <span>Загрузить изображение: </span>
    <%= Html.Telerik().Upload().Async(async => async
                                                   .Save("UploadTelerik", "IAttachedPhotoAspect", new {fieldName = fname, id = parent.id, protoName = parent.ProtoName})
                                                   .AutoUpload(true)
                                     )
    .Name(fname)
    .Multiple(false)
            .ClientEvents(s => s.OnSuccess(String.Format("{0}ImageUpdate", fname))).Enable(true)
     %>
</div>
<script>
    function <%= fname %>ImageUpdate() {
        $('.t-upload-files').hide();
        var $gallery = $('#<%= fname %>Image');
        $gallery.load("/IAttachedPhotoAspect/ImageEdit", { id: <%= parent.id %>, protoName: '<%= parent.ProtoName %>', fieldName: '<%= fname %>' }, function() {
            $('#<%= fname %>Image ._action').click(function() {
                var $this = $(this);
                var url = '/' + $this.attr('data-controller') + '/' + $this.attr('data-action');
                var params = $.parseJSON($this.attr('data-params'));
                                                    
                $.post(url, params, function() {
                    <%= fname %>ImageUpdate();
                });
                                                   
                return false;
            });
        });
    };

    <%= fname %>ImageUpdate();
</script>
<% }else{ %>Сохраните объект перед редактированием<% } %>
