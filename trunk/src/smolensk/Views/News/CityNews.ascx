<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NewsListViewModel>" %>
<%@ Import Namespace="smolensk.ViewModels" %>

<% if (Model != null && Model.Items != null && Model.Items.Any()){ %>
<% int counter = 0; %>
<dl class="news">
    <dt><a href="/News" title="Новости Смоленска">Новости Смоленска</a></dt>

    <% foreach (var item in Model.Items){ 
        if(counter == 3)
        {
            counter = 0;
            %>
            </dl><dl class="news"><dt style="line-height: 20px;"><br/></dt>
            <%
        }      
    %>
    
	<% Html.RenderPartial("CitySingleNews", item); %>
    
    <% ++counter;} %>
    

</dl>

<% } %>