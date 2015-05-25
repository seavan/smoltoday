<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Advert.Master" Inherits="System.Web.Mvc.ViewPage<List<meridian.smolensk.proto.ad_categories>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <h3>Объявления <span><%= ViewBag.AdvertsCount %> объявлений</span></h3>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Advert" runat="server">

    <div class="advertCategoryList">
        <h3>Категории</h3>
        
        <div class="vacancyTools authBlock">
            
            <% if (Request.IsAuthenticated){ %>
                    <span class="button" onClick="window.location.href='<%: Url.Action("CreateAdvert", "Profile") %>'">Создать объявление</span>
            <% } else {%>
                <span class="button enter">Создать объявление</span>
            <%}%>

        </div>

        <%  int row = 0;
            foreach (var category in Model)
            { %>
           <% if (row++ == 0)
              { %>
               <div>
           <% } %>
            <dl>
                <dt><a href="<%: Url.Action("Category", "Adverts", new { category.id }) %>" title="<%= category.title %>"><%= category.title %></a><%= category.AdsCount.ToCounterWordForm(Int64Extensions.AdvertForm, false)%></dt>
                <dd>
                    <% 
                        var subcategories = category.GetPopularSubcategories().Where(s => s.AdsCount > 0).ToList();
                        for (int i = 0; i < subcategories.Count; i++)
                       { %>
                        <a href="<%: Url.Action("Category", "Adverts", new { subcategories[i].id }) %>" title="<%= subcategories[i].title %>"><%= subcategories[i].title %></a><% if (i < subcategories.Count - 1){%>,<% } %>
                    <% } %>
                </dd>
            </dl>
            <% if (row == 3) { row = 0; %>
                </div>
            <% } %>
        <% } %>
        <%if (row != 0) {%>
            </div>
        <% } %>
    </div>
    
    <% Html.RenderAction("InterestingAds", "Adverts", new { type = "main" }); %>
    
</asp:Content>
