<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="smolensk.Models.CodeModels.Security" %>

<%--<div class="overlayBlock">
    <div class="overlayLayer"></div>
                
    <div class="overlayForm">
        <span class="close"></span>
                    
        <div class="formBody">
            <div class="enterSocial _closest">
                <p>Войти как пользователь</p>
                <span class="socialLinks">
                    <a href="<%: OAuthFbService.SignInUrl%>" class="facebook" title="facebook">facebook</a>
                    <a href="<%: OAuthGpService.SignInUrl%>" class="google" title="google">google</a>
					<a href="<%: OAuthVkService.SignInUrl %>" class="vk" title="vkontakte">vkontakte</a>
                </span>
            </div>
                
            <% Html.RenderPartial("Widgets/Authorization", new UserAuthenticationModel()); %>
                        
            <% Html.RenderPartial("Widgets/Registration", new UserRegistrationModel()); %>   
            
            <% Html.RenderPartial("Widgets/Remember", new RegainModel()); %>   
            
            <% Html.RenderPartial("Widgets/Remember", new RegainModel(){repeatActivation = true}); %>   
            
            <% Html.RenderPartial("Widgets/NoResumeForm"); %>

            <% Html.RenderPartial("Widgets/ResumeSend"); %>

            <% Html.RenderPartial("Widgets/AddQuestionAboutActions"); %>

            <% Html.RenderPartial("Widgets/AddAction"); %>
                        
            
            
            
            <div class="getsession _closest"></div>
        </div>
    </div>
</div>--%>
        
<% Html.RenderPartial("Blocks/StickyHeaderRow"); %>          
            
<div class="bannerTop">
    <%--<a href="#" title="MTS"><img src="/content/images/mts_top.jpg" width="1400" height="50" alt="MTS" /></a>--%>
    <embed src="/Content/swf/gagarinsky.swf" quality="high"
      type="application/x-shockwave-flash"
      wmode="opaque" width="1400" height="50"
      pluginspage="http://www.macromedia.com/go/getflashplayer" allowScriptAccess="always">
     </embed>
</div>
            