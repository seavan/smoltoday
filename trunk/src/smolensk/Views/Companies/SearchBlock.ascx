<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.SearchCompanyBlockViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<div class="searchBlock company">
                      
    <% using (Html.BeginForm("Search","Companies", FormMethod.Get))
       {%>
        <div>							
            <label for="filterQuery" class="_autohide">Поиск по компаниям и услугам</label>
            <input type="text" value="<%:Model.Query %>" name="filterQuery" id="filterQuery" />
        </div>
        <div>		
            <select class="categorySelect">
                <option value="0">Все категории</option>
                <%
                    foreach (CompanyCategoryViewModel category in Model.Categories)
                    {%>
                <option value="<%: category.Id %>" 
                <%:Model.CategoryId == category.Id ? "selected" : "" %>><%: category.Title %></option>
                   <% } %>
            </select>
            <input type="hidden" value="" name="filterCategory" id="filterCategory" />
        </div>
        <div>			
            <span class="button" onclick="$(this).closest('form').submit()">Поиск</span>
        </div>
    <% } %>
</div>