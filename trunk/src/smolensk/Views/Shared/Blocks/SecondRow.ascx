<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Mappers" %>
<div class="blockContent mainPage">
	<div class="widthContent">
		<div class="leftBlock">
			<div class="blockLine">
                <% Html.RenderAction("CityNews", "News"); %>
				<%--<% Html.RenderAction("BestSales", "Discounts"); %>--%>
			</div>
			<div class="blockLine">
				<% Html.RenderAction("CinemaInfo", "Poster"); %>
                <% Html.RenderAction("LiveInfo", "Poster"); %>
			</div>
		</div>
		<div class="rightBlock">

            <% Html.RenderPartial("Blocks/JobInSmolensk"); %>
			<% Html.RenderAction("MostDiscussedNews"); %>
			<% Html.RenderAction("InBlogs"); %>
			<% Html.RenderAction("Current", "Quiz"); %>
		</div>
	</div>
	<div class="waveEdge"></div>
</div>
