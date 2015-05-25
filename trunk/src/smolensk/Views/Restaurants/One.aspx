<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Inner.Master" Inherits="System.Web.Mvc.ViewPage<RestaurantViewModel>" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Title %>
</asp:Content>

<asp:Content ID="Content0" runat="server" ContentPlaceHolderID="ContentCssClass">restauran</asp:Content>

<asp:Content ID="Scripts1" runat="server" ContentPlaceHolderID="InnerScripts">
    <script type="text/javascript" src="/content/js/restaurants.js"></script>
    <script type="text/javascript" src="/content/js/gallery.js"></script>

    <script type="text/javascript">
        GalleryInit();
        $().ready(function() {
            InitReserveTableActions();
        });
    </script>

    <link href="/content/css/restaurants.css" rel="stylesheet" type="text/css" />    
    
    <%--<!-- for OneEvents -->
    <script  type="text/javascript" src="/content/js/kendo/kendo.web.min.js"></script>
    <script  type="text/javascript" src="/content/js/kendo/kendo.aspnetmvc.min.js"></script>
    <script  type="text/javascript" src="/content/js/kendo/cultures/kendo.culture.ru-RU.min.js"></script>
    <script type="text/javascript" >kendo.culture("ru-RU");</script>

    <link href="/Content/css/kendo/kendo.common.min.css" rel="stylesheet"/>
    <link href="/Content/css/kendo/kendo.default.min.css" rel="stylesheet"/>
    <link href="/Content/css/kendo/kendo.rtl.min.css" rel="stylesheet"/>
    
    <script type="text/javascript" src="/content/js/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="/content/css/ui-lightness/jquery-ui.css" /> --%>

</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="TopContent">
    
    <div class="headerRest">
	    <div class="widthContent">
	        <%: Html.MvcSiteMap().SiteMapPath() %>
            <a name="menuTop"></a>
		    <h2><%: Model.Title %></h2>
	    </div>				
	</div>

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="LeftBlockContent">
	<div class="infoBlock">
	    
        <%if(Model.PhotoScroller!= null && Model.PhotoScroller.Photos != null && Model.PhotoScroller.Photos.Count > 0){%>
		<div class="galleryPhoto">
			<div class="img">
            <%
                int i = 0;
                foreach (RelatedPhoto photo in Model.PhotoScroller.Photos)
               {  %>
               <a rel="fancyPhoto" href="<%: photo.Link %>" title="<%: photo.Title %>" <%= i == 0? "" : "style='display: none;'" %> index="<%: i %>">
                   <img src="<%: photo.PhotoUrl %>" alt="<%: photo.Title %>" width="325" height="210" />
               </a>
               <%
                   i++;
               } %>
               </div>

            <div class="blockPhoto">
                <% Model.PhotoScroller.Callback = "photoSelect"; %>
                <% Html.RenderPartial("Widgets/PhotoScroller", Model.PhotoScroller); %>
            </div>
        </div>
        <%} %>
		<div class="extInfoBlock">
			<table>
				<tr>
					<td>Телефон:</td>
					<td><%: Model.Phone %></td>
				</tr>
				<tr>
					<td>Адрес:</td>
					<td><%: Model.Address %></td>
				</tr>
				<tr>
					<td>Кол-во залов:</td>
					<td><%: Model.HolesCount %></td>
				</tr>
				<tr>
					<td>Время работы:</td>
					<td><%: Model.WorkTime %></td>
				</tr>
                <% foreach (var e in Model.Dictionary) { %>
                   <tr>
                       <td><%= e.Key %></td>
                       <td><%= e.Value %></td>
                   </tr>
                <% } %>
			</table>
		    <br/>
            <% if (Model.CanBookTable) { %>
            <span class="button" data-id="<%: Model.Id %>" data-title="<%: Model.Title%>">Забронировать столик</span>
            <% } %>
		</div>
	</div>

	<div class="blockFilterRest">
		<div class="widthContent">
			<div class="filterHeader">
				<span class="switcher descr cur"><i>Описание</i><span></span></span>
				<span class="switcher events"><i>Мероприятия</i><span></span></span>
				<span class="switcher map"><i>Карта ресторанов</i><span></span></span>
			</div>

            <% Html.RenderPartial("OneDescr");%>
			<% Html.RenderPartial("OneEvents", Model.Events); %>

            <div class="filterBody map">
                <% Html.RenderPartial("Widgets/YandexMap", new List<meridian.smolensk.proto.IGeoLocation> { Model.GeoLocation }); %>
            </div>
		</div>
	</div>

	<% Html.RenderPartial("CommentsList", Model.Comments); %>
    
    <% Html.RenderPartial("ReserveTable", new ReserveTableViewModel()); %>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="RightBlockContent">

	<%Html.RenderPartial("Widgets/Banner240x400"); %>

    <% Html.RenderPartial("SimilarRestaurants", Model.Similar); %>

</asp:Content>

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="BottomContent"></asp:Content>
