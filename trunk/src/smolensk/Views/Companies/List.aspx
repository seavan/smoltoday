<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Company.Master" Inherits="System.Web.Mvc.ViewPage<CompaniesListViewModel>" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content runat="server" ContentPlaceHolderID="SeachBlockContent">
    <% Html.RenderPartial("../Companies/SearchBlock", Model.SearchBlock); %>
</asp:Content>

<asp:Content ID="alphabet" runat="server" ContentPlaceHolderID="AlphabetContent">
    <% Html.RenderPartial("Alphabet",Model.Alphabet); %>
</asp:Content>

<asp:Content ID="topCompanies" runat="server" ContentPlaceHolderID="TopCompanies">
    <% if (Model.TopCompanies != null)
       {%>
        <% Html.RenderPartial("TopCompanies", Model.TopCompanies); %>
    <% } %>
</asp:Content>

<asp:Content runat="server" ID="categoriesMenuBlock" ContentPlaceHolderID="CategoriesMenu">
    <% Html.RenderAction("CategoriesMenu", "Companies", new
                                                          {
                                                              categoryBaseId = Model.Category != null && Model.Category.Parent != null ? (long?)Model.Category.Parent.Id : null,
                                                              selectedId = Model.Category == null ? null : (long?)Model.Category.Id
                                                          }); %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSScripts" runat="server">
    <script type="text/javascript">
        <% string query = Url.Action("List", new {pageSize = "(((pageSize)))", category = (Model.Category != null ? ((long?)Model.Category.Id) : null)}); %>
        $(function() {
            $("#selector_count").on("change", function() {
                window.location = "<%= query %>".replace("(((pageSize)))", $(this).val());
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Company" runat="server">
    <div class="blockLine">
    <%: Html.MvcSiteMap().SiteMapPath() %>  
    </div>
    <div class="companyList">
		<h3><%: Model.Category == null ? "Все" : Model.Category.Title %></h3>
        <% long? categoryId = Model.Category == null ? null : (long?) Model.Category.Id; %>
        <% var routeData = new { sorting = Model.Sorting, pageSize = Model.PageSize, letter = Model.Letter, category = categoryId }; %>
		<div class="sortingTools">
								
			<ul>
				<li class="name">Сортировка:</li>
				<%= Html.FilterTypeSelectorLink(Model.Sorting, SortingType.Rating, Model.RouteName, routeData, "sorting", "По рейтингу")%>
                <%= Html.FilterTypeSelectorLink(Model.Sorting, SortingType.Novelty, Model.RouteName, routeData, "sorting", "По новизне")%>
                <%= Html.FilterTypeSelectorLink(Model.Sorting, SortingType.Alphabet, Model.RouteName, routeData, "sorting", "По алфавиту")%>
			</ul>
			
            <%if (SecurityService.IsAuthorize) { %>			
			<div class="linkFavor <%= Model.OnlyFavorite ? "cur" : "" %>">
				<a href="<%: !Model.OnlyFavorite ? Url.Action("Favorites", routeData) : Url.Action("List", routeData) %>" title="Избранное">Избранное</a>
			</div>
            <%} %>
            			
			<div class="selectorCount">
				<form action="<%= Url.Action("List", new {pageSize=30}) %>">
				<label for="selector_count">Выводить по</label>
                <select id="selector_count" name="selector_count">
                    <%
                        foreach (int count in Constants.PageSizes)
                        {
                            string selected = count == Model.PageSize ? "selected" : string.Empty;
                            %>
                            <option value="<%= count %>" <%= selected %>><%= count %></option>
                    <% } %>
                </select>
				</form>
			</div>
		</div>

        <% Html.RenderPartial("CompaniesList", Model.Companies); %>

	</div>
    <div class="blockLine">
        <%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.RouteName, routeData, "page")%>
    </div>
    
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BreadCrumbsContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CompanyBottom" runat="server">
    <div class="blockMap companyPage">
		<div class="waveEdge top"></div>
        <div class="waveEdge"></div>
				
		<div class="widthContent">
		    <p class="showMap">Карта компаний - Банки и кредитные организации</p><br/>
		</div>

		<div class="mapBlock">
            <%if(Model.OnlyFavorite){%>
            <% Html.RenderAction("FavoriteEntityMap"); %>
            <%} else {%>
            <% Html.RenderAction("EntityMap"); %>
            <%} %>
		</div>
							
	</div>
</asp:Content>
