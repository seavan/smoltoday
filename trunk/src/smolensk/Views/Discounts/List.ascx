<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.SalesListViewModel>" %>

 <% int i = 0;
    int length = 3;
    var items = Model.Items.ToArray();
    foreach (var sale in items)
    {
        bool isStartLine = i % length == 0;
        bool isEndLine = i % length == length - 1 || i == items.Length - 1;
        i++;
        if (isStartLine) { %>
        <div class="blockLine">
        <% } %>
            
        <% Html.RenderPartial("~/Views/Discounts/SaleBlock.ascx", sale); %>
        <%if (isEndLine) { %>
        </div>
       <% } %>
  <%} %>