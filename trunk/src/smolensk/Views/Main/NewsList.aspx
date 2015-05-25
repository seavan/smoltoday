<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="../Master/Inner.Master" %>

<asp:Content ID="Content0" runat="server" ContentPlaceHolderID="ContentCssClass">newsPage</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="LeftBlockContent">
    <div class="blockLine">
                        
		<div class="breadcrumbs">
            <ul>
                <li><a href="#" title="Домой">Домой</a> <span>&rarr;</span></li>                                    
                <li><a href="#" title="Новости">Новости</a> <span>&rarr;</span></li>                                    
                <li>Главное за сегодня</li>
            </ul>
        </div>
							
		<div class="listNews">
            <h3>Главные новости</h3>
                                
            <div class="photoVideoBlock">
                    <div class="photo">
                        <span>
                        <a href="<%: Url.Action("News","Main") %>" title="Глава российского МВД назвал смертную казнь нормальной реакцией общества"><img src="/content/images/newsPage_1.jpg" width="463" height="296" alt="1" /></a>
                        <span class="titleNews">
                            <span class="overlay"></span>
                            <a href="#" title="Глава российского МВД назвал смертную казнь нормальной реакцией общества">
                            Глава российского МВД назвал смертную казнь «нормальной реакцией общества»</a>
                        </span>
                        </span>
                        <span>
                            <span class="photoNews">
                            <span class="datetime">14:43</span>
                            <span class="data">Гудковых исключили из «Справедливой России»</span>
                            <span class="comments">25</span>
                            </span>
                            <span class="photoNews">
                            <span class="datetime">07:43</span>
                            <span class="data">Гудковых исключили из «Справедливой России»</span>
                            <span class="comments">0</span>
                            </span>
                            <span class="photoNews cur">
                            <span class="datetime">07:43</span>
                            <span class="data">Глава российского МВД назвал смертную казнь «нормальной реакцией ..</span>
                            <span class="comments">0</span>
                            </span>
                        </span>
                    </div>
                </div>
                                
			<div class="blockLine">
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_4.jpg" width="200" height="130" alt="1" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_5.jpg" width="200" height="130" alt="1" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_6.jpg" width="200" height="130" alt="1" />
							Распилим как Брюс Уиллис
						</a>								
					</dt>
					<dd>
						<span class="data">В России решили создать противометеоритную систему</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
			</div>
								
			<div class="blockLine">
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_7.jpg" width="200" height="130" alt="4" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_8.jpg" width="200" height="130" alt="5" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_9.jpg" width="200" height="130" alt="6" />
							Распилим как Брюс Уиллис
						</a>								
					</dt>
					<dd>
						<span class="data">В России решили создать противометеоритную систему</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
			</div>
								
            <div class="blockLine"><span class="category"><a href="#" title="Политика" class="policy">Политика</a></span></div>
			<div class="blockLine">                                	
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_4.jpg" width="200" height="130" alt="1" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_5.jpg" width="200" height="130" alt="1" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<div class="popularNewsBlock">
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_3.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Закон о запрете запретов внесен в госдуру</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">                                            
                            <table><tr><td>Шойгу надоели портянки, предложение внесено в повестку дня</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_2.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Ходорковский заказал шаурму в камеру пыток и анальных казней</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_1.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Путин улетел в тёплые края</td></tr></table>
                        </a>
                    </span>
                </div>
			</div>
								
            <div class="blockLine"><span class="category"><a href="#" title="Спорт" class="sport">Спорт</a></span></div>
			<div class="blockLine">
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_7.jpg" width="200" height="130" alt="4" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_8.jpg" width="200" height="130" alt="5" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<div class="popularNewsBlock">
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_3.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Закон о запрете запретов внесен в госдуру</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">                                            
                            <table><tr><td>Шойгу надоели портянки, предложение внесено в повестку дня</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_2.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Ходорковский заказал шаурму в камеру пыток и анальных казней</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_1.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Путин улетел в тёплые края</td></tr></table>
                        </a>
                    </span>
                </div>
			</div>	
                                
            <div class="blockLine"><span class="category"><a href="#" title="Экономика" class="economy">Экономика</a></span></div>
			<div class="blockLine">                                	
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_4.jpg" width="200" height="130" alt="1" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_5.jpg" width="200" height="130" alt="1" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<div class="popularNewsBlock">
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_3.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Закон о запрете запретов внесен в госдуру</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">                                            
                            <table><tr><td>Шойгу надоели портянки, предложение внесено в повестку дня</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_2.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Ходорковский заказал шаурму в камеру пыток и анальных казней</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_1.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Путин улетел в тёплые края</td></tr></table>
                        </a>
                    </span>
                </div>
			</div>
								
            <div class="blockLine"><span class="category"><a href="#" title="Общество" class="society">Общество</a></span></div>
			<div class="blockLine">
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_7.jpg" width="200" height="130" alt="4" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_8.jpg" width="200" height="130" alt="5" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<div class="popularNewsBlock">
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_3.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Закон о запрете запретов внесен в госдуру</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">                                            
                            <table><tr><td>Шойгу надоели портянки, предложение внесено в повестку дня</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_2.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Ходорковский заказал шаурму в камеру пыток и анальных казней</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_1.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Путин улетел в тёплые края</td></tr></table>
                        </a>
                    </span>
                </div>
			</div>	
                                
            <div class="blockLine"><span class="category"><a href="#" title="Спорт" class="sport">Спорт</a></span></div>
			<div class="blockLine">
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/news_7.jpg" width="200" height="130" alt="4" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Политика" class="policy">Политика</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">14:25</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/news_8.jpg" width="200" height="130" alt="5" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
											
						<span class="info">
							<span class="tag"><a href="#" title="Спорт" class="sport">Спорт</a></span>
							<span class="rating">
								<span class="cur">1</span>	
								<span class="cur">2</span>
								<span class="cur">3</span>
								<span class="cur">4</span>
								<span>5</span>										
							</span>
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
									
				<div class="popularNewsBlock">
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_3.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Закон о запрете запретов внесен в госдуру</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">                                            
                            <table><tr><td>Шойгу надоели портянки, предложение внесено в повестку дня</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_2.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Ходорковский заказал шаурму в камеру пыток и анальных казней</td></tr></table>
                        </a>
                    </span>
                    <span class="popular_news">
                        <a href="#" title="1">
                            <img src="/content/images/pop_news_1.jpg" width="48" height="48" alt="1" />
                            <table><tr><td>Путин улетел в тёплые края</td></tr></table>
                        </a>
                    </span>
                </div>
			</div>						
								
		</div>                          
                            
	</div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="RightBlockContent">
    <ul class="newsMenu">
		<li class="cur"><a href="#" title="Главное">Главное</a></li>
		<li><a href="<%: Url.Action("NewsCategory","Main") %>" title="Политика">Политика</a></li>
		<li><a href="#" title="Экономика">Экономика</a></li>
		<li><a href="#" title="Общество">Общество</a></li>
		<li><a href="#" title="В мире">В мире</a></li>
		<li><a href="#" title="Происшествия">Происшествия</a></li>
		<li><a href="#" title="Спорт">Спорт</a></li>
		<li><a href="#" title="Культура">Культура</a></li>
		<li><a href="#" title="Наука">Наука</a></li>
		<li>
			<a href="#" title="Интервью">Интервью</a>
			<span class="subMenu">&nbsp;</span>
		</li>
	</ul>
                        
    <div class="banner"><a href="#" title="MTS"><img src="/content/images/mts_left.jpg" width="240" height="400" alt="MTS" /></a></div>
						
	<dl class="yourmail">
		<dt>Подписаться на новости:</dt>
		<dd>
		<form action="#">
			<label for="mail" class="_autohide">Введите email</label>
			<input type="text"  name="mail" id="mail"/>
		</form>
		</dd>
	</dl>
    
    <dl class="archive">
		<dt><a href="<%: Url.Action("NewsArchive","Main") %>" title="Наука">Архив</a></dt>
		<dd>
			<img src="/content/images/calendar.png" width="214" height="189" alt="Календарь" />
		</dd>
	</dl>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="BottomContent">
    <div class="most_discussed">            	
        <div class="waveEdge"></div>
    </div>
</asp:Content>
