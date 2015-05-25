<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="footer">
    <div class="footer_links">
		<div class="widthContent">
			<div class="siteLinks">
				<ul>
					<li><a href="<%: Url.Action("Index", "News") %>" title="Новости">Новости</a></li>
					<li><a href="<%: Url.Action("Index","PhotoBank") %>" title="Фотобанк">Фотобанк</a></li>
					<li><a href="<%: Url.Action("List","Restaurants") %>" title="Рестораны">Рестораны</a></li>
				</ul>
				<ul>
					<li><a href="<%: Url.Action("Index","Adverts") %>" title="Объявления">Объявления</a></li>
					<li><a href="<%: Url.Action("Index","Poster") %>" title="Афиша">Афиша</a></li>
					<li><a href="<%: Url.Action("Categories","Companies") %>" title="Компании">Компании</a></li>
				</ul>
				<ul class="small">
					<li><a href="<%: Url.Action("Index","Discounts") %>" title="Скидки">Скидки</a></li>
					<li><a href="<%: Url.Action("Index","Blogs") %>" title="Блоги">Блоги</a></li>								
				</ul>
				<ul class="red">
					<li><a href="/about" title="О проекте">О проекте</a></li>

				</ul>
			</div>
			<div class="socialLinks" style="display: none">
				<span>Мы в сети</span>
				<span>
					<a href="#" class="facebook" title="facebook">facebook</a>
					<a href="#" class="vk" title="vkontakte">vkontakte</a>
					<a href="#" class="twitter" title="twitter">twitter</a>								
				</span>							
			</div>
		</div>
	</div>
	<div class="copyright">
		<div class="widthContent">
			<div class="copy">2013 Смоленский портал</div>
			<%--<div class="authBlock"><a href="#" title="Войти">Войти</a> / <a href="#" title="Зарегистрироваться">Зарегистрироваться</a></div>--%>
			<div class="creator"><a href="http://etcetera.ws/" title="Создание и поддержка etcetera">Создание и поддержка</a></div>
		</div>
	</div>
</div>

