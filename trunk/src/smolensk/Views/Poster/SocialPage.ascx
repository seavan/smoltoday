<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.ISocialLinks>" %>
<%@ Import Namespace="smolensk.Extensions" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<%
    if(!string.IsNullOrEmpty(Model.FacebookLink)
      || !string.IsNullOrEmpty(Model.VkLink)
      || !string.IsNullOrEmpty(Model.GoogleLink)
      || !string.IsNullOrEmpty(Model.MailLink)
      || !string.IsNullOrEmpty(Model.TwitterLink)
      || !string.IsNullOrEmpty(Model.OdnoklassnikiLink))
  {%>
<div class="socialPage">
    <span>Страница в соцсетях:</span>
    
    <%if(!string.IsNullOrEmpty(Model.FacebookLink)){%>
    <a title="Facebook" href="<%: Model.FacebookLink.LinkToUrlFormat() %>" target="_blank">
        <span class="at16nc at16t_facebook">
        <span class="at_a11y">Share on facebook</span>
        </span>
    </a>
    <%} %>
    <%if(!string.IsNullOrEmpty(Model.VkLink)){%>
    <a target="_blank" title="VKontakte" href="<%: Model.VkLink.LinkToUrlFormat() %>">
        <span class="at16nc at16t_vk">
        <span class="at_a11y">Share on vk</span>
        </span>
    </a>
    <%} %>
    <%if(!string.IsNullOrEmpty(Model.GoogleLink)){%>
    <a target="_blank" title="Google+" href="<%: Model.GoogleLink.LinkToUrlFormat() %>">
        <span class="at16nc at16t_google_plusone_share">
        <span class="at_a11y">Share on google+</span>
        </span>
    </a>
    <%} %>
    <%if(!string.IsNullOrEmpty(Model.MailLink)){%>        
    <a target="_blank" title="Mail.Ru" href="<%: Model.MailLink.LinkToUrlFormat() %>">
        <span class="at16nc at16t_mymailru">
        <span class="at_a11y">Share on mail.ru</span>
        </span>
    </a>
    <%} %>
    <%if(!string.IsNullOrEmpty(Model.TwitterLink)){%>
    <a target="_blank" title="Twitter" href="<%: Model.TwitterLink.LinkToUrlFormat() %>">
        <span class="at16nc at16t_twitter">
        <span class="at_a11y">Share on odnoklassniki</span>
        </span>
    </a>
    <%} %>
    <%if(!string.IsNullOrEmpty(Model.OdnoklassnikiLink)){%>        
    <a target="_blank" title="Odnoklassniki" href="<%: Model.OdnoklassnikiLink.LinkToUrlFormat() %>">
        <span class="at16nc at16t_odnoklassniki_ru">
        <span class="at_a11y">Share on odnoklassniki</span>
        </span>
    </a>
    <%} %>
</div>
<%} %>

