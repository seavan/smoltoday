<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.AdViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Создание объявления</h3>
    </div>
    
    <div class="profileBody">
        <div class="grayCreateBlock">
            <% Html.BeginForm("CreateAdvert", "Profile", FormMethod.Post, new { enctype = "multipart/form-data" });%>
                <% Html.RenderPartial("AdvertsForm", Model); %>
            <% Html.EndForm(); %>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
