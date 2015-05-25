<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SaleCategoriesListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.common" %>
<%
  var type = Page.RouteData.Values["type"] ?? SaleType.Discounts.ToString();
  var sorting = Page.Request["sorting"] ?? SortingType.Novelty.ToString();
  var company = Page.RouteData.Values["company_id"];
  var actionVal = Page.RouteData.Values["action"];      
  var action = actionVal.Equals("Index") || actionVal.Equals("One") ? "Category" : actionVal.ToString();
 %>
<ul class="saleMenu">
	<li class="name">Категории скидок</li>
    <%foreach (var c in Model.Categories){%>
	<li <%=Model.SetHighlight(Model.SelectedCategoryId.HasValue && Model.SelectedCategoryId.Value == c.Id) %>>
        <a href="<%: Url.RouteUrl("DiscountsList", new { action = action, categoryId = c.Id, page = 1, type = type, sorting = sorting, companyId = company }) %>" title="<%= c.Title%>">
            <%= c.Title %></a></li>	
    <%} %>					
</ul>