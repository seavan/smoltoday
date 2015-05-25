<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Company.Master" Inherits="System.Web.Mvc.ViewPage<CompaniesListViewModel>" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="SeachBlockContent">
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
        <% string query = Url.Action("Search", new {pageSize = "(((pageSize)))", category = (Model.Category != null ? ((long?)Model.Category.Id) : null) , filterQuery = Model.SearchBlock.Query, filterCategory = Model.SearchBlock.CategoryId}); %>
        $(function() {
            $("#selector_count").on("change", function() {
                window.location = "<%= query %>".replace("(((pageSize)))", $(this).val());
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Company" runat="server">
    
    <div class="blockLine">
                        	   
		<div class="breadcrumbs">
			<ul>
			<li>
				<a href="#" title="Главная">Главная</a>
				<span>→</span>
			</li>
			<li>Компании</li>                                
			</ul>
		</div>  
                            
    </div>   
    
    <div class="companyList">
		<h3>Результаты поиска по запросу: <%: Model.SearchBlock.Query %></h3>

        <% long? categoryId = Model.Category == null ? null : (long?) Model.Category.Id; %>
		<div class="sortingTools">
								
			<ul>
				<li class="name">Сортировка:</li>
				<li><a href="<%= Url.Action("Search", new {sorting = SortingType.Rating, pageSize = Model.PageSize, category=categoryId, filterQuery = Model.SearchBlock.Query, filterCategory = Model.SearchBlock.CategoryId}) %>" title="По рейтингу" class="<%: Model.Sorting == SortingType.Rating ? "cur" : "" %>"><span>По рейтингу</span></a></li>
				<li><a href="<%= Url.Action("Search", new {sorting = SortingType.Novelty, pageSize = Model.PageSize, category=categoryId, filterQuery = Model.SearchBlock.Query, filterCategory = Model.SearchBlock.CategoryId}) %>" title="По новизне" class="<%: Model.Sorting == SortingType.Novelty ? "cur" : "" %>"><span>По новизне</span></a></li>
				<li><a href="<%= Url.Action("Search", new {sorting = SortingType.Alphabet, pageSize = Model.PageSize, category=categoryId, filterQuery = Model.SearchBlock.Query, filterCategory = Model.SearchBlock.CategoryId}) %>" title="По алфавиту" class="<%: Model.Sorting == SortingType.Alphabet ? "cur" : "" %>"><span>По алфавиту</span></a></li>
			</ul>
									
			<div class="selectorCount">
				<%--<form action="<%= Url.Action("Search") %>">--%>
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
				<%--</form>--%>
			</div>
		</div>

        <% Html.RenderPartial("CompaniesList", Model.Companies); %>

	</div>

    <% if (Model.TotalPages > 1)
       { %>      
    <% Html.RenderPartial("Widgets/Pager", new {pageN = Model.CurrentPage, pageTotal = Model.TotalPages}); %>
    <% } %>

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
			<p class="showMap">Карта компаний - Банки и кредитные организации</p>
		</div>
		<div class="mapBlock">
			<div class="map">
				<img src="/content/images/googleMap.jpg" width="1400" height="438" alt="map" />
				<span class="point blue"></span>
				<span class="point green"></span>
				<span class="point orange"></span>
				<span class="point pink"></span>
				<span class="point lime"></span>
				<span class="point black"></span>
			</div>
		</div>
							
	</div>
</asp:Content>
