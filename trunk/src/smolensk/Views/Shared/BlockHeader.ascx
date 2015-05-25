<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="blockHeader v2">
    <div class="widthContent">
		<div class="infoBlock">
		    
			<div class="logoBlock">
				<a href="/" title="SmolToDay">SmolToDay</a>
			</div>

			<% Html.RenderPartial("Widgets/TimeWeather"); %>	

            <% Html.RenderAction("Informer", "Main"); %>
            
            <div class="smollforum"><a href="http://smolforum.ru/" target="_blank"><img alt="" src="/content/i/smollforum_logo.png" /></a></div>
		</div>
		
        <% Html.RenderPartial("Widgets/SiteMenu"); %>
	</div>
</div>
