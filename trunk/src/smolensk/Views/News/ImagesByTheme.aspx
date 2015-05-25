<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/News.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.news>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="News" runat="server">
<div class="blockLine">
    <%: Html.MvcSiteMap().SiteMapPath() %>  
    <div class="photoThemeName">
        <div class="descr">Фотографии по теме:</div>
        <h3><%: Model.tags %></h3>	
        <a href="<%: Model.ItemUri() %>" title="Вернуться на страницу новости">Вернуться на страницу новости</a>
    </div>
    
    <%
        var images = Model.GetImagesByTheme(0, true, 17);
    %>
    <div class="photoList">
    <%Html.RenderPartial("ImagesList", images.Take(16)); %>
    </div>  
    
    <%if (images.Count() > 16){%>
    <div class="blockLine">
	    <span class="button moreThemePhoto" data-page="0" data-url="ImagesList" data-id="<%: Model.id %>">Показать следующие</span>
    </div>
    <%} %>
            
    <%
        var related = Model.GetRelatedNews();
        if(related.Count() > 0){
    %>                        
    <div class="blockLine">
        <dl class="moreMaterials">
        <dt>Материалы по теме:</dt>
        <% foreach (var rel in related) { %>
        <dd>
            <span><a href="<%: rel.ItemUri() %>" title="<%: rel.title %>"><%: rel.title %></a> <span class="comments"><%: rel.comment_count %></span></span>
            <span class="datetime"><%: smolensk.Domain.Formatter.FormatLongDateTime(rel.publish_date) %></span>
        </dd>
        <%} %>
        </dl>
    </div>
    <%} %>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TopContentNews" runat="server">
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="RightBlockHeader">
    <% Html.RenderAction("CategoryMenu", new { categoryId = Model.category_id }); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="NewsBottom" runat="server">
    <% Html.RenderAction("BuzzedNews"); %>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="InnerScripts" runat="server">
</asp:Content>
