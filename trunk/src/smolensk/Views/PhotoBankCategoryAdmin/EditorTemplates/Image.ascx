<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="admin.db" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
    var parent = ViewData["parentModel"] as IDatabaseEntity;
     %>
<%if(parent.id > 0){%>
<div style="float: right" id="<%= fname %>_ID">

    <% if (String.IsNullOrEmpty(Model)) {%>
    изображение отсутствует
    <%
   }
       else
       {
    %>
    <img src="/content/userdata/photobank/<%= Model %>" alt="" style="border: 1px solid black; width: 200px"/>
    <input type="hidden" name="<%= fname %>" value="<%= Model %>" />
    <%
   }%>
</div>
<div>
    <span>Загрузить изображение: </span>
    <%= Html.Telerik().Upload().Async(async => async
                                                         .Save("UploadCover", "PhotoBankCategoryAdmin", new { id = parent.id})
                                                   .AutoUpload(true)
            )
            .Name(fname)
                    .Multiple(false).ClientEvents(s => s.OnSuccess(
                                String.Format("{0}CoverUpdate", fname))).Enable(true)
    %>


 
</div>
<div><a class="_link _removeImage" rel="<%= fname %>">удалить изображение</a></div>


<script type="text/javascript">
    function <%= fname %>CoverUpdate(value) {
        location.reload();
    }
</script>
<%}else{%>Сохраните объект перед добавлением обложки<%} %>