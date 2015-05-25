<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.PhotoListViewModel>" %>
<%@ Import Namespace="smolensk.common" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<div class="blockLine">
    <div class="categoryBlock">
        <div class="categoryName">
            <h3>
                <%= Model.Title %></h3>
            <div class="selectorCount">
                <form action="#">
                <label for="selector_count">
                    Выводить по</label>
                <select id="selector_count" name="selector_count">
                    <%
                        int pageSize = Request.QueryString["pageSize"] != null
                                            ? Convert.ToInt32(Request.QueryString["pageSize"])
                                            : Constants.PhotosPageSize;
                            
                        foreach (int count in Constants.PageSizes)
                        {
                            string selected = count == pageSize ? "selected" : string.Empty;
                            %>
                            <option value="<%= count %>" <%= selected %>><%= count %></option>
                    <% } %>
                </select>
                </form>
            </div>
        </div>
        <div class="photoList">
            <% if (Model.Photos.Any()) {%>
            <%  int row = 0;
                foreach (var photo in Model.Photos) 
                { %>
                <% if (row++ == 0) { %>
                    <div class="blockLine">
                <% } %>
                <div>
                    <div class="imgBlock">
                        <table>
                            <tr>
                                <td>
                                    <a href="<%: photo.ItemUri() %>" title="<%= photo.title %>">
                                        <img src="<%= photo.PreviewSquareUrl %>" width="138" height="138" alt="<%= photo.title %>" />
                                    </a>
                                </td>
                                <td>
                                    <span class="bigPreview">
                                        <a href="<%: photo.ItemUri() %>" title="<%= photo.title %>">
                                            <img src="<%= photo.PreviewMainUrl %>" width="325" height="211" alt="preview" />
                                        </a>
                                        <span class="info">
                                            <span>
                                                <span class="photoNum">#<%= photo.id %></span>
                                                <span class="photoName"><%= photo.title %></span> 
                                            </span>
                                            <span>
                                                <span class="photoAuth">
                                                    <a href="<%: Url.Action("Profile","PhotoBank", new { id = photo.account_id }) %>" title="<%=photo.Account.ShortName %>">
                                                        <%=photo.Account.ShortName %>
                                                    </a>
                                                </span>
                                                <%--TODO: что за размеры?--%>
                                                <span class="photoSize">
                                                    <a href="#" title="S">S</a>, 
                                                    <a href="#" title="M">M</a>, 
                                                    <a href="#" title="L">L</a>, 
                                                    <a href="#" title="XL">XL</a>, 
                                                    <a href="#" title="XXL">XXL</a> 
                                                </span>
                                            </span>
                                        </span>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <span class="info">
                        <span>
                            <span class="photoNum">#<%=photo.id %></span>
                            <% Html.RenderPartial("Widgets/Rating", photo); %>
                        </span>
                        <% if (photo.MainPhoto != null)
                           {
                               Html.RenderPartial("Widgets/AddToCart", new AddToCartViewModel{ Id = photo.MainPhoto.id, PriceId = 0});
                           }
                        %>
                    </span>
                </div>
                <%if (row == 4)
                    {
                        row = 0; %>
                    </div>
                <% } %>
            <% } %>
            <%if (row != 0) {%>
                </div>
            <% } %>
            <%} else {%>
                <%= Model.NoPhotoTitle %>
            <%} %>
        </div>
    </div>
</div>
<div class="blockLine">
    <% Html.RenderPartial("Widgets/Pager", new { pageN = Model.CurrentPage, pageTotal = Model.TotalPages }); %>
</div>

<% string query = Request.QueryString["q"] != null
    ? "?q=" + Request.QueryString["q"] + "&pageSize="
    : "?pageSize=";
%>
<script>
    $(function() {
        $("#selector_count").on("change", function() {
            window.location = "<%= query %>" + $(this).val();
        });
    });
</script>