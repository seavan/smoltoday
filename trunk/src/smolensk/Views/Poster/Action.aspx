<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Poster.Master" Inherits="System.Web.Mvc.ViewPage<ActionViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Extensions" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Title %>
</asp:Content>

<asp:Content ID="Scripts1" runat="server" ContentPlaceHolderID="InnerScripts">
    <script type="text/javascript" src="/content/js/gallery.js"></script>

    <script type="text/javascript">
        GalleryInit();
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Poster" runat="server">

    <div class="actionName">
        <h3><%=Model.Title %> <span><%= Model.Category.Title %> <span><%=Model.AgeLimitPlus%></span></span></h3>

        <% Html.RenderPartial("SocialPage", Model); %>

    </div>
                        
    <div class="infoBlock">
		<div class="galleryPhoto">
			<div class="img">
            <%
                int i = 0;
                foreach (var photo in Model.PhotoScroller.Photos)
               {  %>
               <a rel="fancyPhoto" href="<%: photo.Link %>" title="<%: photo.Title %>" <%= i == 0? "" : "style='display: none;'" %> index="<%: i %>">
                   <img src="<%: photo.PhotoUrl %>" alt="<%: photo.Title %>" width="325" style="height: auto" />
               </a>
               <%
                   i++;
               } %>
               </div>

            <div class="blockPhoto">
                <% Model.PhotoScroller.Callback = "photoSelect"; %>
                <% Html.RenderPartial("Widgets/PhotoScroller", Model.PhotoScroller); %>
            </div>
        </div>
                            
		<div class="extInfoBlock">
			<table>
            <%if (!string.IsNullOrEmpty(Model.GenresList))
              {%>
				<tr>
					<td>Жанр:</td>
					<td><%= Model.GenresList%></td>
				</tr>
                <%} %>
            <%if (!string.IsNullOrEmpty(Model.Author))
            {%>
				<tr>
					<td>Автор:</td>
					<td><%= Model.Author%></td>
				</tr>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.Statement))
            {%>
				<tr>
					<td>Постановка:</td>
					<td><%= Model.Statement %></td>
				</tr>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.Producer))
            {%>
				<tr>
					<td>Режиссер:</td>
					<td><%= Model.Producer %></td>
				</tr>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.Lecturer))
            {%>
				<tr>
					<td>Лектор:</td>
					<td><%= Model.Lecturer%></td>
				</tr>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.Performers))
            {%>
				<tr>
					<td>Состав:</td>
					<td><%= Model.Performers %></td>
				</tr>
             <%} %>
            <%if (!string.IsNullOrEmpty(Model.Country))
            {%>
				<tr>
					<td>Страна:</td>
					<td><%= Model.Country %></td>
				</tr>
            <%} %>
            <%if (Model.Duration > 0)
            {%>
				<tr>
					<td>Продолжит.:</td>
					<td><%= Model.Duration %> мин.</td>
				</tr>
            <%} %>
            <%if (Model.Start_date.HasValue && Model.Start_date.Value.Year >= 2013 ){%>
                <tr>
					<td>Премьера:</td>
					<td><%=Model.Start_date.Value.ToString("dd.MM.yyyy")%></td>
				</tr>
            <%} %>
            <%if (Model.PriceMin > 0 || Model.PriceMax > 0)
            {%>
				<tr>
					<td>Цена:</td>
					<td><%=Model.PriceMin > 0 ? string.Format("от {0} руб. ", Model.PriceMin) : string.Empty%> <%=Model.PriceMax > 0 ? string.Format("до {0} руб. ", Model.PriceMax) : string.Empty%></td>
				</tr>
            <%} %>
            <%if (!string.IsNullOrEmpty(Model.Site)){%>
				<tr>
					<td>Сайт:</td>
					<td><a href="<%=Model.Site.LinkToUrlFormat()%>" target="_blank" title="<%=Model.Site%>"><%=Model.Site%></a></td>
				</tr>
            <%} %>
            <%if (Model.Places.Count() > 0){%>
                <tr class="place">
					<td>Место:</td>
					<td>
                    <%foreach (var p in Model.Places) {%>
                        <div><a href="<%:p.GetItemUri() %>" title="<%=p.Title %>"><%=p.Title%></a></div>
                    <%} %>
                    </td>
				</tr>
            <%} %>
			</table>
		</div>
	</div>   
                        
    <div class="actionInfoPanel">
        <span class="info">
            <span class="descr">Рейтинг</span>
            <% Html.RenderPartial("Widgets/Rating", Model.Marks); %>
        </span>	
                            
        <div class="visitors">
                            	
            Идут:   <span><b class="visitorsResult"><%= Model.ParticipiantsCount %></b></span>   человек
            <%--<div class="visitorsList">
                <ul>
                    <li><a href="#" title="Роман Измайлов">Роман Измайлов</a></li>
                    <li><a href="#" title="Евгений Федоринов">Евгений Федоринов</a></li>
                    <li><a href="#" title="Изя Шнеперсон">Изя Шнеперсон</a></li>
                    <li><a href="#" title="Константин Константинопольский">Константин Константинопольский</a></li>
                    <li><a href="#" title="Ирина Хакамада">Ирина Хакамада</a></li>
                    <li><a href="#" title="Анастасия Уринцевич">Анастасия Уринцевич</a></li>
                    <li class="more"><a href="#" title="И ещё 28 человек">И ещё 28 человек</a></li>
                </ul>
                <span class="arrow"></span>
            </div>--%>
        </div>
        <%if (Model.CanAddParticipiants) { %>                    
        <span><span class="visitorsSend button" rel="<%=Model.Id%>"><span></span>я пойду!</span></span>
        <%} %>
                        
<%--        <div class="socialLinks">                             
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
                        
    <div class="overview">
        <p class="header">Обзор</p>
        <p><%=Model.Text %></p>
    </div>

    <% Html.RenderAction("ActionSchedule", new { id = Model.Id }); %>                    
						
    <% Html.RenderPartial("CommentsList", Model.Comments); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <a name="menuTop"></a>
    <% Html.RenderAction("CategoryMenu"); %>                        
    <%if (SecurityService.IsAuthorize) {%>                   
    <div style="text-align:center;">
        <span class="button addAction">Добавить мероприятие</span>                            
        <span class="button addQuestion">Задать вопрос</span>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
