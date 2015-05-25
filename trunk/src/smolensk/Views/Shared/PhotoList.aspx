<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.PhotoListViewModel>" MasterPageFile="~/Views/Master/PhotoBank.Master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="PhotoBank" runat="server">
    <% Html.RenderPartial("PhotoListPartial", Model); %>
</asp:Content>