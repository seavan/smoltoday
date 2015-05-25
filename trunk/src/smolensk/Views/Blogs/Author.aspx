<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Blogs.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.accounts>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Blog" runat="server">

    <div class="clear"></div>

    <% Html.RenderPartial("AuthorInfo", Model); %>

    <div class="clear"></div>
                        
    <% Html.RenderAction("AuthorList"); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TopContentBlog" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockHeader" runat="server">
   
    <div class="beginBlog authBlock">
                    
        <%if(Request.IsAuthenticated) {%>
        <span class="button begin">Начать</span>   
        <%}else{%>
        <span class="button begin enter">Начать</span>  
        <%}%>
                									
	</div> 

    <%Html.RenderPartial("Widgets/Banner240x400"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
