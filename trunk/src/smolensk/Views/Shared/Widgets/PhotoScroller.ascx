<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.PhotoScrollViewModel>" %>
<%
    /*
     * Виджет для отображения изображений с прокруткой
     */
 %>
 <% if (Model.Photos.Any() && Model.Photos.Count > Model.ShowPhotosCount)
    { %>
    <link href="/content/css/jquery.scrollable.css" rel="stylesheet" type="text/css" />
    <div class="scrollable-wrapper">
        <span class="prev-button"><span></span></span>
        <span class="scrollable">
                <span class="items">
                <% int row = 0;
                   int i = 0;
                   foreach (var photo in Model.Photos)
                   {
                       i++; %>
                    <% if (row++ == 0)
                       { %>
                        <div>
                    <% } %>
                    <% if (string.IsNullOrEmpty(Model.Callback))
                       { %>
                        <a href="<%= photo.Link %>">
                    <% } %>
                        <img class="scrollable-photo" src="<%= photo.PhotoUrl %>" width="<%= Model.PhotoWidth %>" height="<%= Model.PhotoHeight %>" alt="<%= photo.Title %>" data-link="<%= photo.Link %>" data-index="<%: i - 1 %>"/>
                    <% if (string.IsNullOrEmpty(Model.Callback))
                       { %>
                        </a>
                    <% } %>
                
                    <% if (row == Model.PhotosCount)
                       {
                           row = 0; %>
                        </div>
                    <% } %>
                                    
                <% } %>
                <% if (row != 0)
                   { %>
                    </div>
                <% } %>
            </span>
        </span>
        <span class="next-button"><span></span></span>
    </div>
    <script src="/content/js/jquery.tools.min.js"></script>

    <script>
        (function () {
            $(".scrollable").scrollable({
                next: '.next-button',
                prev: '.prev-button'
            });
            $(".scrollable").css("width", <%= Model.PhotoWidth %> * <%= Model.PhotosCount %> + 4 * <%= Model.PhotosCount %>);

            <% if (!string.IsNullOrEmpty(Model.Callback))
               { %>
                $(".scrollable-photo").on("click", function() {
                    <%= Model.Callback + "($(this));" %>
                });
            <% } %>
        })();
    </script>
<% } %>