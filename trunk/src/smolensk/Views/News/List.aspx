<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<NewsListViewModel>" MasterPageFile="~/Views/Master/News.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="News">
    <div class="blockLine">
         <%: Html.MvcSiteMap().SiteMapPath() %>                 
		<div class="listNews">
		    <h3>Последние новости</h3>

            <%--<% Html.RenderAction("TodaysNews"); %>--%>
            <% Html.RenderPartial("NewsList", Model); %>
			
            <% Html.RenderAction("PopularNews"); %>					
		</div>
	</div>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="TopArchive"></asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="BottomArchive">
<dl class="archive">
	<dt>Архив</dt>
	<dd>
		<div class="datepicker"></div>
	</dd>
</dl>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="NewsBottom">
    <% Html.RenderAction("BuzzedNews"); %>
</asp:Content>
