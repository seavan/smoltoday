<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Poster.Master" Inherits="System.Web.Mvc.ViewPage<PlaceViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Extensions" %>

<asp:Content ID="Content4" ContentPlaceHolderID="mapPopUp" runat="server">
    <% Html.RenderPartial("Widgets/YandexMap", new List<meridian.smolensk.proto.IGeoLocation> { Model.baseEntity }); %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Poster" runat="server">
    
    <div class="actionName">
        <h3><%=Model.Title %></h3>
        <% Html.RenderPartial("SocialPage", Model); %>
    </div>
                        
    <div class="infoBlock">							
                            
		<div class="extInfoBlock">                            	
			<table>
				<tr>
					<td>Билеты:</td>
					<td><%=Model.Price %></td>
				</tr>
				<tr>
					<td>Адрес:</td>
					<td><%=Model.Adress %></td>
				</tr>
				<tr>
					<td>Кассы работают:</td>
					<td><%=Model.WorkTime %></td>
				</tr>
				<tr>
					<td>Телефон:</td>
					<td><%=Model.Phone%></td>
				</tr>							
			</table>
		</div>
                            
        <div class="howFind">
            <p class="header">Как добраться</p>
            <p><%=Model.Location %></p>
            <span class="button"><span></span>показать на карте</span>
        </div>
	</div>   
                        
    <div class="actionInfoPanel">
        <span class="info">
            <span class="descr">Рейтинг</span>
            <% Html.RenderPartial("Widgets/Rating", Model.baseEntity); %>
        </span>	
        <%if (!string.IsNullOrEmpty(Model.Site)){ %>                 
        <a class="site" href="<%=Model.Site.LinkToUrlFormat() %>" target="_blank" title="<%=Model.Site %>"><%=Model.Site%></a>
        <%} %>
                        
        <%--<div class="socialLinks">                             
            <span>
            <%if (!string.IsNullOrEmpty(Model.FacebookLink)){%>
            <a href="<%= Model.FacebookLink %>" class="facebook" title="facebook">facebook</a>
            <%}%>
            <%if (!string.IsNullOrEmpty(Model.VkLink)){%>
            <a href="<%= Model.VkLink %>" class="vk" title="vkontakte">vkontakte</a>
            <%}%>
            <%if (!string.IsNullOrEmpty(Model.TwitterLink)){%>
            <a href="<%= Model.TwitterLink %>" class="twitter" title="twitter">twitter</a>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.OdnoklassnikiLink)){%>
            <a href="<%= Model.OdnoklassnikiLink %>" class="odnkl" title="odnoklassniki">odnoklassniki</a>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.MailLink)){%>
            <a href="<%= Model.MailLink %>" class="mail" title="mail">mail</a>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.GoogleLink)){%>
            <a href="<%= Model.GoogleLink %>" class="google" title="google+">google+</a>
            <%} %>
            </span>
        </div>--%>
         <% Html.RenderPartial("Widgets/AddThis"); %>
         <span class="addThisPreText">Поделиться: </span>
    </div>
                        
    <div class="clear"></div>                                           
                        
    <div class="description">
                        
        <p class="header">Описание</p>
                            
        <p><%=Model.Announce %>
        <%if (Model.Announce != Model.Text){%>
        <a class="more" href="#" title="подробнее">подробнее</a>
        <%} %>
        </p>                            
        <div style="display:none"><%=Model.Text %></div>                    
    </div>
                        
    <% Html.RenderAction("PlaceSchedule", new { id = Model.Id }); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <a name="menuTop"></a>
    <% Html.RenderAction("CategoryMenu"); %>
                        
    <%if (SecurityService.IsAuthorize){%>                   
    <div style="text-align:center;">
        <span class="button addAction">Добавить мероприятие</span>                            
        <span class="button addQuestion">Задать вопрос</span>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
