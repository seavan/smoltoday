<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.SearchAdViewModel>" %>

<% Html.BeginForm("Search", "Adverts", FormMethod.Get, new { id = "searchForm" }); %>  	
<div>
    <%: Html.HiddenFor(m => m.Page) %>							
    <%: Html.HiddenFor(m => m.PageSize) %>							
    <%: Html.LabelFor(m => m.Q, new { @class="_autohide" }) %>					
    <%: Html.TextBoxFor(m => m.Q)%>
</div>
<div>
    <%: Html.DropDownListFor(m => m.Category, Model.Categories, new { @class = "categorySelect" })%>
    <input type="hidden" value="<%= Model.Category %>" name="category" id="category" />
</div>
<div>			
    <span class="button" onclick="$(this).closest('form').submit();">Поиск</span>
</div>
<% Html.EndForm(); %>

<script>
    $(function() {
        $("#searchForm").on("submit", function () {
            return $("#Q").val() != "";
        });
    })
</script>
