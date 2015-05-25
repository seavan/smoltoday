<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Blogs.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content0" ContentPlaceHolderID="TopContentBlog" runat="server">
    
    <div class="blogsPresentation">
        <div class="widthContent">
            <div class="leftBlock">
                
                <div class="authBlock">
                    
                    <% if (Request.IsAuthenticated) { %>
                    <span class="button begin">Начать</span>   
                    <% } else { %>
                    <span class="button begin enter">Начать</span>  
                    <span class="register">Зарегистрироваться</span> 
                    <% } %>
				</div>
            </div>
            <div class="rightBlock">
                <%Html.RenderPartial("Widgets/Banner240x400"); %>
            </div>
        </div>
    </div>
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Blog" runat="server">

    <% Html.RenderAction("BestList"); %>
    
    <% Html.RenderAction("InterestingList"); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
    
</asp:Content>
