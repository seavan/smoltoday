<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="admin.db" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var model = Model;
    var parent = ViewData["parentModel"] as IDatabaseEntity;
%>
<% if (parent.id > 0)
   {
       var multiple = false;
       if (parent is IAttachedPhotoAspectProvider)
       {
           var aspect = (parent as IAttachedPhotoAspectProvider).GetAttachedPhotoAspect(fname);
           multiple = aspect != null && aspect.Multiple;
       }
       %>
<div style="float: right" id="<%= fname %>Gallery">
</div>
<div>
    
    <span>Загрузить изображение: </span>
    <%= Html.Telerik().Upload().Async(async => async
                                                   .Save("UploadTelerik", "IAttachedPhotoAspect", new {fieldName = fname, id = parent.id, protoName = parent.ProtoName})
                                                   //.Remove("Remove", "Upload")
                                                   .AutoUpload(true)
            )
            .Name(fname)
            .Multiple(multiple).ClientEvents(s => s.OnSuccess(
                String.Format("{0}GalleryUpdate", fname))).Enable(true)
    %>
</div>
<script>
    function <%= fname %>GalleryUpdate() {
         $('.t-upload-files').hide();
        var $gallery = $('#<%= fname %>Gallery');
                                            $gallery.load("/IAttachedPhotoAspect/GalleryEditList", { id: <%= parent.id %>, protoName: '<%= parent.ProtoName %>', fieldName: '<%= fname %>' }, function() {
                                                $('#<%= fname %>Gallery ._action').click(function() {
                                                    var $this = $(this);
                                                    var url = '/' + $this.attr('data-controller') + '/' + $this.attr('data-action');
                                                    var params = $.parseJSON($this.attr('data-params'));
                                                    
                                                    $.post(url, params, function() {
                                                        <%= fname %>GalleryUpdate();
                                                    });
                                                   
                                                    return false;
                                                });
                                            });
    };

    <%= fname %>GalleryUpdate();


</script>
<% }else{ %>Сохраните объект перед редактированием галереи<% } %>