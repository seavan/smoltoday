<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<smolensk.Models.ViewModels.CompanyViewModel>>" %>
<% foreach (var company in Model) { %>
<div class="oneCompany <%: company.IsPaid ? "fav": "" %>">
    <a href="<%: company.GetItemUri() %>" title="<%: company.Title %>">
        <img src="<%: company.LogoUrl %>" width="104" alt="<%: company.Title %>" /></a>
    <div class="infoBlock">
        <p>
            <span class="name"><a href="<%: company.GetItemUri() %>" title="<%: company.Title %>">
                <%= HttpUtility.HtmlDecode(company.Title)%></a>
            </span> 
            <span class="info">
                <% Html.RenderPartial("Widgets/Rating", company.Marks); %>
            </span>
            <br />
        </p>
        <p><%= HttpUtility.HtmlDecode(company.Description) %></p>
        <p>
            <% if (!string.IsNullOrEmpty(company.Www)) { %>
            <a href="<%: company.Www %>" title="<%: company.Www %>" class="site"><%: company.Www %></a>
            <% } %>
            <% if (!string.IsNullOrEmpty(company.Email)) { %>
            <a href="mailto:<%: company.Email %>" title="<%: company.Email %>" class="mail"><%: company.Email %></a>
            <% } %>

            <span class="info">
                <span class="button" onclick="window.location.href='<%: Url.Action("One", "Companies", new {id = company.Id}) %>#comments'">+</span> 
                <% long countComments = company.Comments.GetComments().Count(); %>
                <span class="comments<%: countComments > 0 ? "" : " no" %>"><%: countComments.ToCounterWordForm(Int64Extensions.ReviewForm,false)%></span> 
            </span>
        </p>
        <%if (!string.IsNullOrEmpty(company.Phones)) { %>
        <p class="phone"><b><%: company.Phones %></b></p>
        <% } %>
    </div>
</div>
<% } %>
