<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.PhotoScrollViewModel>" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>
<%
    /*
     * Виджет для отображения изображений с прокруткой
     */
 %>
<%--<link href="/content/css/jquery.scrollable.css" rel="stylesheet" type="text/css" />--%> <%-- и на каждый ресторан подключается таблица - это не хорошо --%>
<div class="scrollable-wrapper">
    <span class="photo scrollable">
        <span class="lenta items">
            <%
                if (Model.Photos.Count > 0) {
                int i = 0;
                foreach (RelatedPhoto photo in Model.Photos)
                {
                    i++;%>
                    <div>
                    <a href="<%= photo.Link %>" rel="<%: Model.Args %>">
                        <img class="scrollable-photo" src="<%= photo.PhotoUrl %>" width="<%= Model.PhotoWidth %>" height="<%= Model.PhotoHeight %>" alt="<%= photo.Title %>" data-link="<%= photo.Link %>" data-index="<%: i - 1 %>"/>                        
                    </a>
                    </div>
              <% } }else{%>
              <div>
                <a href="#" >
                    <img class="scrollable-photo" src="/content/userdata/noImg200_130.gif" width="<%= Model.PhotoWidth %>" height="<%= Model.PhotoHeight %>" alt="" />                        
                </a>
              </div>
              <%} %>
        </span>
    </span>
    
    <%if ( Model.Photos.Count > 1) {%>
    <span class="prev">
        <span></span>
    </span>
    <span class="next">
        <span></span>
     </span>
     <%}%>
</div>

<%--<script src="/content/js/jquery.tools.min.js"></script>--%>

<script type="text/javascript">
    (function () {
        $(".scrollable").each(function(index, obj) {
            $(obj).scrollable();
        });
        $(".scrollable").css("width", <%=Model.PhotoWidth %> * <%=Model.PhotosCount %> + 1 * <%=Model.PhotosCount %>);

        <% if (!string.IsNullOrEmpty(Model.Callback))
            { %>
            $(".scrollable-photo").on("click", function() {
                <%=Model.Callback + "($(this));" %>
            });
        <% } %>
    })();
</script>