<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Discounts.Master" Inherits="System.Web.Mvc.ViewPage<SaleViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Extensions" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Title %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Discounts" runat="server">

    <div class="saleOne">
		<h3><%=Model.Title %></h3>
						
		<div class="blockLine">
			<dl>
				<dt>
				    <%if (!string.IsNullOrEmpty(Model.Image)){%>
		            <a href="<%: Model.GetUri() %>" title="<%=Model.Title %>">
                        <img src="<%=Model.Image %>" alt="<%=Model.Title %>" />
                    </a>
                    <%} else{%>
                    <a href="<%: Model.GetUri() %>" title="<%= Model.Title %>" class="noLogo">&nbsp;</a>    
                    <%}%>
				</dt>
				<dd>
					<%if (Model.Company!=null) {%>
                        <p><a href="<%: Model.Company.GetItemUri() %>" title="<%=Model.Company.Title %>"><%=Model.Company.Title %></a></p>
					    <p><a href="<%: Url.Action("Company", "Discounts", new { companyId = Model.Company.Id }) %>" title="Все акции компании">Все акции компании</a></p>
					    <%--<p><a href="#" title="Подписаться на акции и скидки компании">Подписаться на акции и скидки компании</a></p>--%>
                    <%} %>
				</dd>
				<dd>
					<%if (!string.IsNullOrEmpty(Model.PersentText)){%>
                    <span class="sale_value <%=Model.PercentLabel %>"><%=Model.PersentText%></span>
                    <%} %>
                    <%if (!string.IsNullOrEmpty(Model.DateAsInterval) && !Model.Unlimited) { %>
					<p class="date">Период действия<br/><%=Model.DateAsInterval%></p>
                    <%} %>
                    
                    <%Html.RenderPartial("LinkFavorite", Model.Favorite); %>
				</dd>
			</dl>
		</div>
		<%if (!string.IsNullOrEmpty(Model.DateAsInterval) && !Model.Unlimited)
    { %>			
		<div>
			<p>Период действия акции <%=Model.DateAsText %></p>
		</div>
        <%} %>

		<div>
			<p>Условия акции:</p>
			<p><%=Model.Text %></p>
		</div>
        <%if (!string.IsNullOrEmpty(Model.Products)) { %>
		<div>
			<p>Товары/услуги:</p>
			<p><%=Model.Products %></p>
		</div>
        <%} %>
		<%if (!string.IsNullOrEmpty(Model.Site)) { %>					
		<div>
		<p>Сайт:</p>
		<p><a href="<%=Model.Site.LinkToUrlFormat()%>" target="_blank" title="<%=Model.Site%>"><%=Model.Site%></a></p>
		</div>
        <%} %>
							
		<div>
            <%if (!string.IsNullOrEmpty(Model.WorkTime)) { %>	
			<p>Время работы: <%= Model.WorkTime%></p>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.Phone)) { %>	
			<p>Телефон: <%= Model.Phone%></p>
            <%} %>
		</div>
		
        <%if (!string.IsNullOrEmpty(Model.SalesOffices)) { %>				
		<div>
			<p>Офисы продаж</p>
			<p class="nospace"><%= Model.SalesOffices%></p>			
		</div>
        <%} %>
							
		<%--<div class="buttonPanel">                                
            <span class="button print"><span></span>Печать страницы</span>
            <%Html.RenderPartial("ButtonFavorite", Model.Favorite); %>
            <span class="button tofriend"><span></span>Предложить другу</span>
        </div>--%>
							
	</div>
                        
    <% Html.RenderPartial("CommentsList", Model.Comments); %>                
</asp:Content>
