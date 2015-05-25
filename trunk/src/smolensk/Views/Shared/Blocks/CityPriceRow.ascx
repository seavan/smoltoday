<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%
    var rand = new Random();
    var prices = Meridian.Default.city_pricesStore.All().OrderBy(s => rand.Next());
%>
<div class="blockPrice index">
    <div class="waveEdge"></div>
    <div class="widthContent">
        
        <%if (prices.Count() > 5) {%>
        <span class="lArrow"></span>
        <span class="rArrow"></span>
        <%}%>

        <div class="name">
            Цены<br />
            в городе</div>
        <div class="prices">
            <div class="lenta">
                <%  foreach (var item in prices) {%>
                <span class="price <%= item.GetIconClass() %>">
                    <span class="num"><%= item.value %></span> 
                    <span class="txt">руб.</span> 
                    <small><%= item.title %></small> 

                    <span class="moreInfo">
                        <a class="price <%= item.GetIconClass() %>"  href="<%= item.url_icon %>">
                            <span class="num"><%= item.value %></span>
                            <span class="txt">руб.</span>
                            <small><%= item.title %></small>
                        </a>
                            <%--<% if (!String.IsNullOrEmpty(item.html) || !String.IsNullOrEmpty(item.url_showall)) { %>--%>
                        <span class="moreList">
                            <%= item.html %>
                        </span>
                           <%-- <% if (!string.IsNullOrEmpty(item.url_showall))
                               { %>
                            <a href="<%= item.url_showall %>" title="Показать всё" class="moreLink">Показать всё
                                →</a>
                            <% } %>--%>
                            <%--<% } %>--%>
                    </span>
                </span>
                <%}%>
            </div>
        </div>
    </div>
</div>
