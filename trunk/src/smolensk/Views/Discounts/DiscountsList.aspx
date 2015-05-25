<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Discounts.Master" Inherits="System.Web.Mvc.ViewPage<SalesListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Discounts" runat="server">
<%
    var routeData = new { type = Model.Type, sorting = Model.Sorting, page = 1, 
        categoryId = Model.Category != null ? Model.Category.Id : 0,
        companyId = Model.Company != null ? Model.Company.Id : 0,
    };
%>
    <div class="saleList">
		<h3><%=Model.Title %></h3>
							
		<div class="sortingTools">
			
            <ul>	
                <%foreach (var t in Model.AvailableTypes)
                  {%>	
                    <%= Html.FilterTypeSelectorLink(Model.Type, t, Model.RouteName, routeData, "type")%>
                <%} %>
			</ul>

            <%if (SecurityService.IsAuthorize) { %>
			<div class="linkFavor <%= Model.IsFavorite ? "cur" : "" %>">
				<a href="<%: !Model.IsFavorite ? Url.Action("Favorites","Discounts", routeData) : Url.Action("Category","Discounts", routeData) %>" title="Избранное">Избранное</a>
			</div>
            <%} %>
		</div>

		<div class="selectorSort">
            <%= Html.FilterTypeSelector(Model.Sorting, new SortingType[] { SortingType.Novelty, SortingType.Value }, Model.RouteName, 
                    routeData, "sorting", new string[] { "По дате добавления", "По величине скидки" })%>
		</div>
	    <% Html.RenderPartial("List"); %>
	</div>

    <div class="blockLine">
		<%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.RouteName, routeData, "page")%>
	</div>
</asp:Content>
