<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div class="blockMap">
	<div class="widthContent">
		<p class="showMap">События и объекты на карте</p>
	</div>
	<div class="mapBlock">
		
        <% Html.RenderAction("EntityMap"); %>
		
	</div>
							
</div>
