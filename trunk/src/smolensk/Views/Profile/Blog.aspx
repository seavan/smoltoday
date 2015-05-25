<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.accounts>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Блог</h3>
    </div>
                        
    <div class="profileBody">
        
        <% Html.RenderPartial("BlogAuthorInfo", Model); %>
        
        <div class="clear"></div>
                            
        <% Html.RenderAction("BlogsList"); %>

    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
