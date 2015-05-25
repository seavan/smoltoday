<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/News.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.news>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<asp:Content ID="Content0" runat="server" ContentPlaceHolderID="ContentCssClass">photoPage</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="News">
<div class="blockLine">
    <%: Html.MvcSiteMap().SiteMapPath() %>  
    <div class="photoThemeName">
        <div class="descr">Видео по теме:</div>
        <h3><%: Model.tags %></h3>	
        <a href="<%: Model.ItemUri() %>" title="Вернуться на страницу новости">Вернуться на страницу новости</a>	                                    
    </div>    
    
    <%
        var videos = Model.GetVideosByTheme(0, 13);
    %>
    <div class="categoryBlock">
                            	                                
        <div class="categoryList">
            <%Html.RenderPartial("VideosList", videos.Take(12)); %> 
        </div>

    </div>
    
    <%if (videos.Count() > 12){%>
    <div class="blockLine">
	    <span class="button moreThemePhoto" data-page="0" data-url="VideosList" data-id="<%: Model.id %>">Показать следующие</span>
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

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="RightBlockHeader">
    <% Html.RenderAction("CategoryMenu", new { categoryId = Model.category_id }); %>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="NewsBottom">
    <% Html.RenderAction("BuzzedNews"); %>
</asp:Content>

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="InnerScripts">
    
</asp:Content>
