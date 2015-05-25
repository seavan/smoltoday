<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<NewsListViewModel>" MasterPageFile="~/Views/Master/News.Master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="News">
    <div class="blockLine">
        <%: Html.MvcSiteMap().SiteMapPath() %>  
<%
    int newsCount = Model.Items.Count();
%>

        <div class="listNews oneTheme">
            
            <%if (Model.Date == DateTime.Today){%>
            <h3>Новости сегодня <%--<%: Model.Category!=null ? "- " + Model.Category.Title : string.Empty %>--%></h3>
            <%} else{%>
            <h3>Новости за <%= Model.GetFormattedDate() %><%-- <%: Model.Category != null ? "- " + Model.Category.Title : string.Empty%>--%></h3>
            <%}%>
            

            <% if (newsCount < 1) { %>
                <div class="nodata"><p>Пока нет новостей</p></div>
            <% } %>
            
            <%if (Model.Category!=null){%>
            <div class="blockLine">
            <%  int itemIndex = 1;
                foreach (var item in Model.Items) { %>

                <% Html.RenderPartial("CategorySingleNews", item); %>

                <% if (itemIndex % 3 == 0) { %>
                    </div>
                    <div class="blockLine">
                <% } %>
            <% itemIndex++; } %>
            </div>
            <div class='blockLine'>
                <%: Html.Pager(Model.CurrentPage, Model.TotalPages, "NewsList", new { categoryId = Model.Category != null ? Model.Category.Id.ToString() : "!", year = Model.Date.Year, month = Model.Date.Month, day = Model.Date.Day}, "page")%>
            </div>
            <%} else {%>
            <% Html.RenderPartial("NewsList", Model); %>
            <%}%>

			<div class="blockLine">
				<%--<span class="button moreNews">Ещё новости</span>--%>
			</div>

			<% Html.RenderAction("PopularNews"); %>
        </div>

	</div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="RightBlockHeader">
    <%if (Model.Category!=null){%>
    <% Html.RenderAction("CategoryMenu", new { categoryId = Model.Category.Id }); %>
    <%}else{%>
    <% Html.RenderAction("CategoryMenu"); %>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="NewsBottom">
    <% Html.RenderAction("BuzzedNews"); %>
</asp:Content>
