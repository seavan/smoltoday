<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="headerRest">
	    <div class="widthContent">
		    <div class="breadcrumbs">
			    <ul>                                	
				    <li><a href="#" title="Главная">Главная</a> <span>&rarr;</span></li>                                    
				    <li>Рестораны</li>
			    </ul>
		    </div>
		    <h2>Кафе и рестораны Смоленска</h2>
	    </div>
	    <div class="waveEdge"></div>
    </div>

    <div class="blockPrice rest">
        <div class="waveEdge"></div>
		<div class="widthContent">					
					
			<div class="name">Поиск по<br/>параметрам</div>
					
			<div class="prices">
                <div class="lenta">
                    <span class="price kitchen">
                        <span class="num">кухня</span>
                                
                        <small>любая</small>
								
								
                    </span>
                    <span class="price invoice">
                        <span class="num">счет</span>
                                
                        <small>любой</small>
								
								
                    </span>
                    <span class="price sale">
                        <span class="num">скидка</span>
                                
                        <small>любая</small>
                                
                                
                    </span>
                    <span class="price features">
                        <span class="num">особенности</span>
                                
                        <small>любые</small>
								
								
                    </span>                            
                </div>
                </div>
					
		</div>
				
	</div>
    <div class="blockFilterRest">
		<div class="widthContent">
			<div class="filterHeader">
				<span class="counter">Всего заведений - 94</span>
				<span class="switcher events cur"><i>Мероприятия</i><span></span></span>
				<span class="switcher map"><i>Карта ресторанов</i><span></span></span>
			</div>
			<div class="filterBody">
				<div class="daySelector">
					<span class="day">
						<span>понедельник</span>
						<small>11 апреля</small>
					</span>
					<span class="day cur">
						<span>вторник</span>
						<small>12 апреля</small>
					</span>
					<span class="day">
						<span>среда</span>
						<small>13 апреля</small>
					</span>
					<span class="day">
						<span>четверг</span>
						<small>14 апреля</small>
					</span>
					<span class="day">
						<span>пятница</span>
						<small>15 апреля</small>
					</span>
					<span class="day off">
						<span>суббота</span>
						<small>16 апреля</small>
					</span>
					<span class="day off">
						<span>воскресенье</span>
						<small>17 апреля</small>
					</span>
					<span class="day next">
						<span>след.<br/>неделя</span>								
					</span>
				</div>
				<div class="preview">
					<div class="oneRest">
						<a href="<%: Url.Action("RestaurantOne","Main") %>" title="Ресторан Miss Marple" class="name">Ресторан Miss Marple</a>
						<span class="time">20:00</span>
						<a href="#" title="«Вечер у камина» с группой «Жуки»">«Вечер у камина» с группой «Жуки»</a>
						<span class="type">Живая музыка</span>
						<span class="button">Забронировать столик</span>								
					</div>
					<div class="oneRest">
						<a href="<%: Url.Action("RestaurantOne","Main") %>" title="Кафе DownTown" class="name">Кафе DownTown</a>
						<span class="time">20:00</span>
						<a href="#" title="«Вечер у камина» с группой «Жуки»">«Вечер у камина» с группой «Жуки»</a>
						<span class="type">Живая музыка</span>
						<span class="button">Забронировать столик</span>
					</div>
					<div class="oneRest">
						<a href="<%: Url.Action("RestaurantOne","Main") %>" title="Кафе Luxuary" class="name">Кафе Luxuary</a>
						<span class="time">20:00</span>
						<a href="#" title="Мазафака Концерт Весна">Мазафака Концерт Весна</a>
						<span class="type">Живая музыка</span>
						<span class="button">Забронировать столик</span>
					</div>
					<div class="oneRest">
						<a href="<%: Url.Action("RestaurantOne","Main") %>" title="The Pink Cadillac" class="name">The Pink Cadillac</a>
						<span class="time">20:00</span>
						<a href="#" title="DJ Hassan Chillout Week">DJ Hassan Chillout Week</a>
						<span class="type">Дискотека</span>
						<span class="button">Забронировать столик</span>
					</div>
				</div>
			</div>
		</div>
	</div>
    
    <div class="blockContent restaurants">
		<div class="widthContent">
			<div class="oneRest vip">
				<div class="blockPhoto">
					<span class="photo">
						<span class="lenta">
							<img src="/content/images/rest_1.jpg" width="200" height="130" alt="1" />
						</span>
					</span>
					<span class="prev"><span></span></span>
					<span class="next"><span></span></span>
				</div>
				<div class="infoBlock">
					<dl>
						<dt><a href="<%: Url.Action("RestaurantOne","Main") %>" title="Ресторан Miss Marple">Ресторан Miss Marple</a></dt>
						<dd>
							<span class="rating">
								<span class="cur">1</span>
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span class="cur">5</span>
							</span>
									
							<span class="typeList">
								<span>Ресторан</span>
								<span>Банкетный зал</span>
							</span>
									
							<span class="button">Забронировать столик</span>
						</dd>
					</dl>
				</div>
				<div class="extInfoBlock">
					<table>
						<tr>
							<td>Кухня:</td>
							<td>Французская</td>
						</tr>
						<tr>
							<td>Средний счет:</td>
							<td>2000-3000р</td>
						</tr>
						<tr>
							<td>Телефон:</td>
							<td>(495) 988-26-56</td>
						</tr>
						<tr>
							<td>Адрес:</td>
							<td>Москва, ул. Кузнецкий Мост, д. 6/3, стр. 3</td>
						</tr>
						<tr>
							<td>Кол-во залов:</td>
							<td>2 зала - 100 мест</td>
						</tr>
						<tr>
							<td>Время работы:</td>
							<td>пн-пт 8:00-24:00, сб-вс 12:00-24:00</td>
						</tr>
					</table>
				</div>
				<span class="favorStar cur">&nbsp;</span>
			</div>			
			<div class="oneRest vip">
				<div class="blockPhoto">
					<span class="photo">
						<span class="lenta">
							<img src="/content/images/rest_2.jpg" width="200" height="130" alt="2" />
						</span>
					</span>
					<span class="prev"><span></span></span>
					<span class="next"><span></span></span>
				</div>
				<div class="infoBlock">
					<dl>
						<dt><a href="<%: Url.Action("RestaurantOne","Main") %>" title="Кафе DownTown">Кафе DownTown</a></dt>
						<dd>
							<span class="rating">
								<span class="cur">1</span>
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span class="cur">5</span>
							</span>
									
							<span class="typeList">
								<span>Ресторан</span>
								<span>Банкетный зал</span>
							</span>
									
							<span class="button">Забронировать столик</span>
						</dd>
					</dl>
				</div>
				<div class="extInfoBlock">
					<table>
						<tr>
							<td>Кухня:</td>
							<td>Французская</td>
						</tr>
						<tr>
							<td>Средний счет:</td>
							<td>2000-3000р</td>
						</tr>
						<tr>
							<td>Телефон:</td>
							<td>(495) 988-26-56</td>
						</tr>
						<tr>
							<td>Адрес:</td>
							<td>Москва, ул. Кузнецкий Мост, д. 6/3, стр. 3</td>
						</tr>
						<tr>
							<td>Кол-во залов:</td>
							<td>2 зала - 100 мест</td>
						</tr>
						<tr>
							<td>Время работы:</td>
							<td>пн-пт 8:00-24:00, сб-вс 12:00-24:00</td>
						</tr>
					</table>
				</div>
				<span class="favorStar">&nbsp;</span>
			</div>			
			<div class="oneRest">
				<div class="blockPhoto">
					<span class="photo">
						<span class="lenta">
							<img src="/content/images/rest_3.jpg" width="200" height="130" alt="3" />
						</span>
					</span>
					<span class="prev"><span></span></span>
					<span class="next"><span></span></span>
				</div>
				<div class="infoBlock">
					<dl>
						<dt><a href="<%: Url.Action("RestaurantOne","Main") %>" title="Кафе Luxuary">Кафе Luxuary</a></dt>
						<dd>
							<span class="rating">
								<span class="cur">1</span>
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span class="cur">5</span>
							</span>
									
							<span class="typeList">
								<span>Ресторан</span>
								<span>Банкетный зал</span>
							</span>
									
							<span class="button">Забронировать столик</span>
						</dd>
					</dl>
				</div>
				<div class="extInfoBlock">
					<table>
						<tr>
							<td>Кухня:</td>
							<td>Французская</td>
						</tr>
						<tr>
							<td>Средний счет:</td>
							<td>2000-3000р</td>
						</tr>
						<tr>
							<td>Телефон:</td>
							<td>(495) 988-26-56</td>
						</tr>
						<tr>
							<td>Адрес:</td>
							<td>Москва, ул. Кузнецкий Мост, д. 6/3, стр. 3</td>
						</tr>								
					</table>
				</div>
				<span class="favorStar">&nbsp;</span>
			</div>	
			<div class='blockLine'>		
			    <div class="pager">
				    <a class="button cur" href="#" title="1">1</a>
				    <a class="button" href="#" title="2">2</a>
				    <a class="button" href="#" title="3">3</a>
				    <a class="button" href="#" title="3">4</a>
				    <a class="button" href="#" title="...">...</a>
				    <a class="button" href="#" title="9">9</a>
			    </div>	
            </div>	
		</div>
		<div class="waveEdge"></div>
	</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Meta" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
