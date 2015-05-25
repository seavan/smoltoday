<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>

<h3>Популярные новости</h3>
<div class="blockLine">
<%  int itemIndex = 1;
    foreach (var item in Model.Items) {
        Html.RenderPartial("PopularSingleNews", item);
        if (itemIndex % 3 == 0) { %>
            </div>
            <div class="blockLine">
        <% } 

       itemIndex++; 
    } %>
</div>