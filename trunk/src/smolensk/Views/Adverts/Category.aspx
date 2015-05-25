<%@ Page Title="" Language="C#"MasterPageFile="~/Views/Master/Advert.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.CategoryAdsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Advert" runat="server">
    <div class="advertList">
        <h3><%= Model.Category.title %> <span>(<%= Model.Category.AdsCount %>)</span></h3>
        
        <div class="vacancyTools authBlock">
            
            <% if (Request.IsAuthenticated){ %>
                    <span class="button" onClick="window.location.href='<%: Url.Action("CreateAdvert", "Profile") %>'">Создать объявление</span>
            <% } else {%>
                <span class="button enter">Создать объявление</span>
            <%}%>

        </div>
    
        <% Html.RenderPartial("Filter", Model.Filter); %>
        <% Html.RenderPartial("AdsListPartial", Model.Advertisments); %>
    </div>
    <% Html.RenderAction("InterestingAds", "Adverts", new { type = "interesting", categoryId = Model.Category.id }); %>

</asp:Content>


