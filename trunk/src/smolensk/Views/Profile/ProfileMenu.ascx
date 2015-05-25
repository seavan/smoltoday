<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

    <ul class="profileMenu">
		<li><a href="<%: Url.Action("Messages") %>" title="Сообщения">Сообщения</a> <%--<span class="counter new">3</span>--%></li>
		<li><a href="<%: Url.Action("Comments") %>" title="Мои комментарии и отзывы">Мои комментарии и отзывы</a></li>
		<li><a href="<%: Url.Action("Marks") %>" title="Мои оценки">Мои оценки</a></li>
		<li><a href="<%: Url.Action("PhotoBank") %>" title="Фотобанк">Фотобанк</a></li>
		<li><a href="<%: Url.Action("Restaurants") %>" title="Забронированные рестораны">Забронированные рестораны</a></li>
		<li><a href="<%: Url.Action("Adverts") %>" title="Объявления">Объявления</a></li>
		<li><a href="<%: Url.Action("Companies") %>" title="Избранные компании"></a><%--<span class="counter">24</span>--%></li>
		<li><a href="<%: Url.Action("ResumeList") %>" title="Резюме">Резюме</a></li>
		<li><a href="<%: Url.Action("VacancyList") %>" title="Вакансии">Вакансии</a></li>	
        <li><a href="<%: Url.Action("Actions") %>" title="Мероприятия">Мероприятия</a></li>
        <li><a href="<%: Url.Action("Discounts") %>" title="Избранные скидки"></a></li>
        <li><a href="<%: Url.Action("Blog") %>" title="Блог">Блог</a></li>
	</ul>