<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Blogs.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Blog" runat="server">

    <% Html.RenderAction("CategoryList"); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TopContentBlog" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <%Html.RenderPartial("Widgets/Banner240x400"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
