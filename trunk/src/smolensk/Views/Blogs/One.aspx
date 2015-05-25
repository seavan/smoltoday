<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Blogs.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.blogs>" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.title %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Blog" runat="server">
                        
    <div class="clear"></div>

    <% Html.RenderPartial("AuthorInfo", Model.GetUser()); %>
    
    <div class="oneBlog">
        <span class="info">
            <span class="date"><%: Model.PublishDateWithTime() %></span>
                                
            <span class="views">Просмотров: <%:Model.views %></span>
                                
            <% Html.RenderPartial("Widgets/Rating", Model); %>
                                
            <span class="descr">Рейтинг</span>
        </span>
        <div class="clear"></div>
                            
        <h3><%= Model.title %></h3>
        <%= Model.text %>
                            
    </div>
    
    <% Html.RenderPartial("CommentsList", Model); %>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TopContentBlog" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <div class="beginBlog authBlock">
                    
        <%if (Request.IsAuthenticated) { %>
        <span class="button begin">Начать</span>   
        <% } else { %>
        <span class="button begin enter">Начать</span>  
        <% } %>
	</div> 

    <%Html.RenderPartial("Widgets/Banner240x400"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
