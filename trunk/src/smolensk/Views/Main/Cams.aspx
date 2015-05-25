<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="../Master/Smolensk.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <% Html.RenderPartial("Blocks/WebCamRow"); %>
    <% Html.RenderPartial("Blocks/SecondRow"); %>
    <% // Html.RenderPartial("Blocks/MapRow"); %>
    <% Html.RenderPartial("Blocks/PhotoBankRow"); %>

</asp:Content>

