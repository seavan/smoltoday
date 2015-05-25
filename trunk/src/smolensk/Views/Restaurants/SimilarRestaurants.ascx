<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<RestaurantViewModel>>" %>
<dl class="similarRest">
    <dt>Похожие рестораны</dt>
    <% foreach (RestaurantViewModel rest in Model)
       {%>
    <dd>
        <a href="<%: rest.GetItemUri() %>" title="<%= rest.Title %>">
            <img src="<%: rest.ThumbnailUrl %>" width="240" height="132" alt="1" />
            <span class="name"><%= rest.Title %></span> </a>
            <span class="info">
                <% Html.RenderPartial("Widgets/Rating", rest.Marks); %>
                <span class="comments"><%:rest.Comments.GetComments().Count() %> отзывов</span>
            </span>
    </dd>
      <% } %>
</dl>
