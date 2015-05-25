<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div class="stickyheader hasBanner">
    <div class="widthContent">
        <div class="headerPanelStatic">
                  
            <div class="menu">
                <a href="/about" title="О проекте">О проекте</a>
				<%--<a href="/faq" title="F.A.Q.">F.A.Q.</a>--%></div>

			<%--<% Html.RenderPartial("Widgets/Search"); %>--%>

            <%  meridian.smolensk.proto.accounts user = null;
                if (Request.IsAuthenticated){
                    user = Html.UserPrincipal(); %>
            <ul class="userMenu">
                <li><a href="<%: Url.Action("Blog", "Profile")%>" title="Личный блог">Личный блог</a></li>
                <%--<li><a href="#" title="Избранное">Избранное</a></li>--%> <% #warning Неясно, куда ведёт ссылка %>
                <li><a href="<%: Url.Action("Messages", "Profile")%>" title="Сообщения">Сообщения</a> <%--<span class="counter">3</span>--%></li>
            </ul>
            <% } %>

			<div class="authBlock">
			    <% if (Request.IsAuthenticated){
                    var returnUrl = "http://" + smolensk.Domain.Extensions.GetHost(true) + HttpContext.Current.Request.Url.PathAndQuery;
                %>
                <span class="welcome"><a href="<%: Url.Action("Index","Profile") %>">Добро пожаловать, <%=  user.firstname %>.</a></span>
                <a href="/Security/SignOut?ReturnUrl=<%= returnUrl %>" class = "exit">Выход</a>
                <% } else {%>      
				<a href="#" title="Регистрация" class="register">Регистрация</a>
				<a href="#" title="Вход" class="enter">Вход</a>
                <% } %>
			</div>

        </div>
    </div> 
	<div class="waveEdge"></div>
</div>
