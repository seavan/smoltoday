<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Company.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.CompanyCategoriesViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="SeachBlockContent">
    <% Html.RenderPartial("../Companies/SearchBlock", Model.SearchBlock); %>
</asp:Content>

<asp:Content runat="server" ID="alphabet" ContentPlaceHolderID="AlphabetContent">
    <% Html.RenderPartial("Alphabet",Model.Alphabet); %>
</asp:Content>

<asp:Content runat="server" ID="categoriesMenuBlock" ContentPlaceHolderID="CategoriesMenu">
    <% Html.RenderAction("CategoriesMenu", "Companies", new {}); %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Company" runat="server">

    <div class="companyCategoryList">
        <h3>Каталог компаний</h3>
            <%
                const int line = 3;
                int count = -1;
                foreach (CompanyCategoryViewModel category in Model.Categories.Where(s => s.CountOfCompanies > 0 || s.Children.Any(a => a.CountOfCompanies > 0)))
                {
                    count++;
%>
              <% if (count % line == 0) { %>
                <div>
              <% } %>

              <dl>
                <dt style="background:url(<%: category.IconUrl %>) no-repeat 0 0;"><%: category.Title %></dt>
                <dd>
                    <%
                        foreach (var child in category.Children.Where(s => s.CountOfCompanies > 0)
                            .OrderByDescending(c => c.Popularity)
                            .Take(Constants.TopSubCompanyCategory))
                        { %>
  <a href="<%: Url.Action("List", "Companies", new {category = child.Id, page = 1}) %>" title="<%: child.Title %>"><%: child.Title %> (<%: child.CountOfCompanies %>)</a>,
                      <% } %>
                    <br/>
                    <a href="<%: Url.Action("List","Companies", new {category = category.Id}) %>" title="Все">Все <%: category.GetCalculatedCompanies() %> компании  <span>→</span></a>
                </dd>
            </dl>

                <% if (((line + 1) + (count / line) * line + count) % (line * 2) == 0) { %>
                </div>
              <% } %>
           <% } %>
            <% if (((line+1) + (count / line) * line + count) % (line * 2) != 0) { %>
            </div>
            <% } %>
    </div>
                        
    <% if (Model.Entities.Count > 0) { %>
	<div class="companyList category">
        <a name="mostReliable"></a>
		<h3>Самые надёжные</h3>
		<% Html.RenderPartial("CompaniesList", Model.Entities); %>
	</div>
	<% } %>
    <% if (Model.TotalPages > 1) { %>
    <% Html.RenderPartial("Widgets/Pager", new {pageN = Model.CurrentPage, pageTotal = Model.TotalPages, anchor = "#mostReliable"}); %>
    <% } %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BreadCrumbsContent" runat="server">
    <div class="blockLine">
    <%: Html.MvcSiteMap().SiteMapPath() %>  
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <h3>Компании</h3>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CompanyBottom" runat="server">
     <div class="most_discussed">
        <div class="waveEdge"></div>
    </div>
</asp:Content>
