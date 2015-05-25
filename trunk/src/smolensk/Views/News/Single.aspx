<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<SingleNewsViewModel>" MasterPageFile="~/Views/Master/News.Master" %>
<%@ Import Namespace="smolensk.Domain" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="TitleNews">
    <%= Model.Title %>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="News">
    <div class="blockLine">
        <%: Html.MvcSiteMap().SiteMapPath() %>  
        <div class="oneNews">
            <div class="datetime"><%: Model.FormatFullPublishDate() %></div>
            <h3><%= Model.Title %></h3>
            <% if (!String.IsNullOrEmpty(Model.Lead)) { %>
            <h4 class="lead"><%: Model.Lead %></h4>
            <% } %>
            <div class="photoVideoBlock">
                <% var photoCount = Model.baseEntity.GetImagesByTheme(0, true, int.MaxValue).Count(); %>
                <% var videoCount = Model.baseEntity.GetVideosByTheme(0, int.MaxValue).Count(); %>
                <ul>
                    <% if (photoCount > 0) { %>
                    <li><a href="/News/ImagesByTheme/<%: Model.Id %>">Фотографии по теме (<%: photoCount%>)</a></li>
                    <% } %>
                    <% if (videoCount > 0) { %>
                    <li><a href="/News/VideosByTheme/<%: Model.Id %>">Видео по теме (<%:videoCount%>)</a></li>
                    <% } %>
                    
                    <li  class="info"><span class="descr">Рейтинг </span><% Html.RenderPartial("Widgets/Rating", Model.baseEntity); %></li>
                    <li class="socialLinks">
                        <span>Поделиться</span>

                        <% Html.RenderPartial("Widgets/AddThis"); %>
                    </li>
                </ul>

                <%  if (Model.HasPicture)
                    {
                        var firstImage = Model.Pictures.First();
                        var imagesCount = Model.Pictures.Count; %>
                <div class="photo photo-switcher">
                    <span class="viewed-pic">
                        
                        <% if (imagesCount > 1) { %>
                        <span class="lArrow"><span class="bg"></span><span class="arrow"></span></span>
                        <span class="rArrow"><span class="bg"></span><span class="arrow"></span></span>
                        <% } %>

                        <img src="<%: firstImage.LargeThumbnail.GetImageUri() %>" width="463" alt="<%: firstImage.Alt %>" />

                        <small style="<%: string.IsNullOrEmpty(firstImage.Alt) ? "visibility: hidden;" : "" %>">
                            <%: firstImage.Alt %>
                        </small>

                    </span>
                    <% if (imagesCount > 1) { %>
                    <span>
                        <% foreach (var image in Model.Pictures.Take(3)) { %>
                        <span class="preview-pic">
                            <a href="<%: image.LargeThumbnail.GetImageUri() %>">
                                <img src="<%: image.MediumThumbnail.GetImageUri() %>" width="137" height="87" alt="<%: image.Alt %>" />
                            </a>
                        </span>
                        <% } %>
                    </span>
                    <% } %>
                </div>
                <% } %>
            </div>
            
            <%= Model.Text %>

            <% if (!string.IsNullOrEmpty(Model.AuthorAsText)){ %><p class="authorNews">Материал подготовлен <%= Model.AuthorAsText %></p><% } %>

        </div>
        <%if (Model.RelatedNews.Count > 0) { %>
        <dl class="moreMaterials">
            <dt>Материалы по теме:</dt>
            <% foreach (var item in Model.RelatedNews) { %>
            <dd>
                <span>
                    <a href="<%= item.GetItemUri() %>" title="<%= item.Title %>"><%= item.Title %></a> 
                    <a href="<%: item.GetCommentsUri() %>"><span class="comments"><%= item.CommentsCount %></span></a>
                </span> 
                <span class="datetime"><%= item.FormatFullPublishDate() %></span>
            </dd>
            <%}%>
        </dl>
        <% } %>
        
        <% Html.RenderPartial("CommentsList", Model.baseEntity); %>
        
    </div>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="RightBlockHeader">
    <%if (Model.Category!=null){%>
    <% Html.RenderAction("CategoryMenu", new { categoryId = Model.Category.Id }); %>
    <%}else{%>
    <% Html.RenderAction("CategoryMenu"); %>
    <%} %>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="RightBlockBottom">
    
    <!-- Не реализованы подписка, голосование -->
<%--    <dl class="yourmail">
		<dt>Подписаться на новости:</dt>
		<dd>
		<form action="#">
			<label for="mail" class="_autohide">Введите email</label>
			<input type="text"  name="mail" id="mail"/>
		</form>
		</dd>
	</dl>--%>
	

<%--	<dl class="quiz">
		<dt></dt>
		<dd>
			<i>Какой банк в Смоленске самый удобный?</i>
			<form action="">
				<ul>
					<li><span class="radio"><input type="radio" name="bank" value="1"  checked /></span><span>ВТБ 24</span></li>
				    <li><span class="radio"><input type="radio" name="bank" value="2" /></span>Смоленский банк</li>
				    <li><span class="radio"><input type="radio" name="bank" value="3" /></span>Сбербанк</li>
				</ul>
				<div class="tools">
					<span class="button">Голосовать</span>
					<span class="result">Результаты</span>
				</div>
			</form>
		</dd>
	</dl>--%>
<script>
    $('.oneNews p img[data-gallery=true]').hide();
</script>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="NewsBottom">
    <% Html.RenderAction("BuzzedNews"); %>
</asp:Content>

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="InnerScripts">
    <script type="text/javascript" src="/content/js/picture_switcher.js"></script>
</asp:Content>
