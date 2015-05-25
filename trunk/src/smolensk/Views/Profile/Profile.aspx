<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.accounts>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <% Html.RenderPartial("ProfilePartial", Model); %>    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
