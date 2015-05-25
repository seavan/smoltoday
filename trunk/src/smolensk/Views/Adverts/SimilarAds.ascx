<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<meridian.smolensk.proto.ad_advertisments>>" %>
<%@ Import Namespace="smolensk.Domain" %>

<% if (Model.Any()) { %>
   <dl class="adverts">
       <dt>Похожие предложения</dt>
       <% foreach (var ad in Model) { %>
           <dd>
               <span>
                   <a href="<%: ad.ItemUri() %>" title="<%= ad.title %>">
                       <img src="<%= ad.PhotoUrl %>" width="80" height="60" alt="<%= ad.title %>" />
                       <%= ad.title %><br />
                       <% if (ad.price > 0)
                           { %>
                          <span class="price"><%= Formatter.FormatPrice(ad.price) %></span> руб.
                       <% } %>
                   </a>
               </span>
           </dd>
       <% } %>
   </dl>
<% } %>