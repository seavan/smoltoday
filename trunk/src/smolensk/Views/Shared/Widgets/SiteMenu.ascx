<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="siteMenu">
	<table>
		<tr>
			<td>
				<div>
					<a href="/News/Index" title="Новости">
						<span class="counter"><%= meridian.smolensk.system.Meridian.Default.newsStore.GetAllVisible().Count() %></span>
						<img src="/content/i/menuNews.png" width="48" height="38" alt="Новости"/>									
						Новости
					</a>
				</div>
			</td>
			<td>	
				<div>	
					<a href="/PhotoBank/Index" title="Фотобанк">
						<span class="counter"><%= meridian.smolensk.system.Meridian.Default.photobank_photosStore.All().Count %></span>
						<img src="/content/i/menuPhoto.png" width="48" height="38" alt="Фотобанк"/>									
						Фотобанк
					</a>
				</div>
			</td>
			<td>
				<div>
					<a href="/Restaurants/List" title="Рестораны">
						<span class="counter"><%= meridian.smolensk.system.Meridian.Default.restaurantsStore.All().Count %></span>
						<img src="/content/i/menuRestaurant.png" width="48" height="38" alt="Рестораны"/>										
						Рестораны
					</a>
				</div>
			</td>
			<td>
				<div>
					<a href="/Adverts/Index" title="Объявления">
						<span class="counter"><%= meridian.smolensk.system.Meridian.Default.ad_fieldsStore.All().GroupBy(f=>f.ad_id).Count() %></span>
						<img src="/content/i/menuAdvert.png" width="48" height="38" alt="Объявления"/>										
						Объявления
					</a>
				</div>
			</td>
			<td>
				<div>
					<a href="/Poster/Index" title="Афиша">
					    <%
					        int countActions = 0;
                            if (ViewBag != null && ViewBag.ActionsCount != null)
                            {
                                countActions = ViewBag.ActionsCount;
                            }
                            else 
                            {
                                var range = new smolensk.Models.CodeModels.DateRange(DateTime.Now.Date);
                                countActions = smolensk.Mappers.ActionsMapper.GetAcionsCount((long?)null, range.From, range.To);
                            }
                        %>
						<span class="counter"><%:countActions%></span>
						<img src="/content/i/menuPoster.png" width="48" height="38" alt="Афиша"/>										
						Афиша
					</a>
				</div>
			</td>
			<td>
				<div>
					<a href="/Companies/Categories" title="Компании">
						<span class="counter"><%= meridian.smolensk.system.Meridian.Default.companiesStore.All().Count %></span>
						<img src="/content/i/menuCompany.png" width="48" height="38" alt="Компании"/>										
						Компании
					</a>
				</div>
			</td>
			<td>
				<div>
					<a href="/Discounts/Index" title="Скидки">
                    <span class="counter"><%= meridian.smolensk.system.Meridian.Default.salesStore.All().Count %></span>
                    <img src="/content/i/menuDiscount.png" width="48" height="38" alt="Скидки"/>Скидки</a>
				</div>
				</td>									
			<td>
				<div>
					<a href="/Blogs/Index" title="Блоги">
                    <span class="counter"><%= meridian.smolensk.system.Meridian.Default.blogsStore.AllVisible().Count()%></span>
                    <img src="/content/i/menuBlogs.png" width="48" height="38" alt="Блоги"/>Блоги</a>
				</div>
			</td>
            <td>
				<div>
					<a href="<%: Url.Action("Index","Vacancy") %>">
                    <span class="counter"><%= meridian.smolensk.system.Meridian.Default.vacanciesStore.All().Count(v=>v.is_publish && !v.closed)%></span>
                    <img src="/content/i/menuVacancy.png" width="48" height="38" alt="Вакансии"/>Вакансии</a>
				</div>
			</td>
		</tr>
	</table>
</div>
