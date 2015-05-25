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
                            
		<div class="oneNews">
                            	
            <div class="datetime">24 апреля 2013, 12:20</div>
            <h3>Кьюриосити» получил самый важный результат своей миссии</h3>
                                
            <div class="photoVideoBlock">
                <ul>
                    <li>Фотографии оп теме (4)</li>
                    <li>Видео (1)</li>    
                    <li class="socialLinks">
                        <span>Поделиться</span>
                        <span>
                            <a href="#" class="facebook" title="facebook">facebook</a>
                            <a href="#" class="vk" title="vkontakte">vkontakte</a>
                            <a href="#" class="twitter" title="twitter">twitter</a>
                            <a href="#" class="odnkl" title="odnoklassniki">odnoklassniki</a>								
                        </span>							
                    </li>                                    
                </ul>
                                    
                <div class="photo">
                    <span>
                                        
                        <span class="lArrow">
                            <span class="bg"></span>
                            <span class="arrow"></span>
                        </span>
                        <span class="rArrow">
                            <span class="bg"></span>
                            <span class="arrow"></span>
                        </span>
                                            
                        <img src="/content/images/newsPage_1.jpg" width="463" height="296" alt="1" />
                        <small>Владимир Познер в боулинге, фото ИТАР-ТАСС 2013</small>
                    </span>
                    <span>
                        <span><img src="/content/images/newsPage_2.jpg" width="137" height="87" alt="2" /></span>
                        <span><img src="/content/images/newsPage_3.jpg" width="137" height="87" alt="3" /></span>
                        <span><img src="/content/images/newsPage_4.jpg" width="137" height="87" alt="4" /></span>
                    </span>
                </div>
            </div>
                                
            <p><strong>Команда ученых и инженеров, управляющих «Кьюриосити», сообщила на пресс-конференции в Вашингтоне о том, что древний Марс был пригоден для существования жизни. Фактически, это означает, что ровер, опустившийся на поверхность Красной планеты в августе прошлого года, уже выполнил свою миссию.</strong></p>
            <p>Сразу следует оговориться, что «Кьюриосити» не собирается останавливаться на достигнутом. В апреле он уходит в вынужденный «отпуск», вызванный тем, что Марс будет заслонен Солнцем и связь с Землей станет невозможна. После этого, в мае, ученые собираются повторить бурение осадочных пород (того самого «Джона Клейна», камня, выбранного за свои необычные светлые прожилки) и вновь провести анализ полученных образцов. Возможно, «Кьюриосити» проведет даже несколько таких бурений, однако рано или поздно он продолжит свое путешествие к подножию горы Шарп, расположенной в центре кратера Гейла. Пока же вторая фаза исследовательской миссии не началась, имеет смысл подвести некоторые итоги пребывания ровера на поверхности Красной планеты и подумать, что же означают полученные результаты.</p>
                                
            <div class="video">
                <img src="/content/images/video.jpg" width="640" height="390" alt="v" />
            </div>
                                
            <p><strong>Не так быстро</strong></p>
            <p>Следует подчеркнуть, что обнаружение условий, пригодных для жизни, безусловно, не означает самого наличия жизни (хотя легкость путешествия метеоритов с планеты на планету заставляет задуматься на эту тему). Точно так же о наличии микроорганизмов ничего не говорит существование для них источника энергии — до сих пор «Кьюриосити» не получил ни одного однозначного сttвидетельства в пользу их существования. Тем не менее, пока что полученные результаты выглядят очень обнадеживающе и в данном случае звучат как твердое «может быть».</p>
                                
            <p class="authorNews">Материал подготовил Александр Ершов</p>
        </div>
                          
        <dl class="moreMaterials">
        <dt>Материалы по теме:</dt>
        <dd>
            <span><a href="#" title="Том Круз теперь ВКонтакте">Том Круз теперь ВКонтакте</a> <span class="comments">25</span></span>
            <span class="datetime">12 июля 2012</span>
        </dd>
        <dd>
            <span><a href="#" title="Том Круз теперь ВКонтакте">Том Круз теперь ВКонтакте</a> <span class="comments">25</span></span>
            <span class="datetime">12 июля 2012</span>
        </dd>
        </dl>
                          
        <div class="commentsNews">
        <p><strong>Комментарии к новости</strong> (84)</p>                            
                            
        <div class="allComments">
                            
            <div class="oneComment">
                <span class="avatar"><a href="#" title="автор"><img src="/content/images/avatar_2.jpg" width="45" height="45" alt="2" /></a></span>
                <form action="#">
                    <div class="commentBody">                                    	
                        <span class="arrowBuble"></span> 
                        <textarea name="commentText" rows="" cols=""></textarea>
                    </div>
                    <small>не более 300 символов, все сообщения модерируются</small>
                    <span class="button" onclick="$(this).parent().submit();">Отправляем</span>
                </form>
            </div>
                                
            <div class="oneComment">
                <span class="avatar"><a href="#" title="автор"><img src="/content/images/avatar_1.jpg" width="45" height="45" alt="1" /></a></span>
                <div class="commentBody">
                    <span class="arrowBuble"></span>
                    <span class="datetime">14 мая 14:45</span>
                    <span class="raringBlock">
                            <span class="minus">-</span>
                        <span class="rating">6</span>
                        <span class="plus">+</span>                                           
                    </span>
                    Мне всё понравилось, и хорошо, что у вас тут нет смайликов. Смайликами пользуются средних умов люди. неспособные словами выражать свои эмоции и мысли. Да.
                </div>
            </div>
                            	
            <div class="oneComment">
                <span class="avatar"><a href="#" title="автор"><img src="/content/images/avatar_2.jpg" width="45" height="45" alt="2" /></a></span>
                <div class="commentBody">
                    <span class="arrowBuble"></span>
                    <span class="datetime">14 мая 14:45</span>
                    <span class="raringBlock">
                            <span class="minus">-</span>
                        <span class="rating">27</span>
                        <span class="plus">+</span>                                           
                    </span>
                                        
                        Такие микроорганизмы хорошо известны на Земле — они переводят одно вещество в другое и извлекают из этого энергию. Исследования показали, что они могли существовать и на Марсе.
                </div>
            </div>
                                
            <div class="oneComment">
                <span class="avatar"><a href="#" title="автор"><img src="/content/images/avatar_1.jpg" width="45" height="45" alt="1" /></a></span>
                <div class="commentBody">
                    <span class="arrowBuble"></span>
                    <span class="datetime">14 мая 14:45</span>
                    <span class="raringBlock">
                            <span class="minus">-</span>
                        <span class="rating">6</span>
                        <span class="plus">+</span>                                           
                    </span>
                                        
                    Мне всё понравилось, и хорошо, что у вас тут нет смайликов. Смайликами пользуются средних умов люди. неспособные словами выражать свои эмоции и мысли. Да.
                </div>
            </div>
                                
                                
        </div>
                            
        <span class="button">Показать все (84)</span>
                            
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
						
	<dl class="quiz">
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
	</dl>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="BottomContent">
    <div class="most_discussed">
        <div class="widthContent">
            <h3>Самые обсуждаемые</h3>
			<div class="blockLine">
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/most_1.jpg" width="141" height="94" alt="1" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
						<span class="info">
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
						
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/most_2.jpg" width="141" height="94" alt="1" />
							Жильё Яровой стоит 3 млн. долларов
						</a>								
					</dt>
					<dd>
						<span class="data">Близкие к РЖД эксперты устроили слив «Единой России»</span>
						<span class="info">
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
						
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/most_3.jpg" width="141" height="94" alt="1" />
							Распилим как Брюс Уиллис
						</a>								
					</dt>
					<dd>
						<span class="data">В России решили создать противометеоритную систему</span>
						<span class="info">
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
						
				<dl>
					<dt>								
						<a href="#" title="Жильё Яровой стоит 3 млн. долларов">
							<img src="/content/images/most_4.jpg" width="141" height="94" alt="1" />
							Госдума передумала запрещать снимать фильмы в России
						</a>								
					</dt>
					<dd>
						<span class="data">В России решили создать противометеоритную систему</span>
						<span class="info">
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
						
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/most_5.jpg" width="141" height="94" alt="1" />
							Остатки былой роскоши
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
						<span class="info">
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
						
				<dl>
					<dt>								
						<a href="#" title="Остатки былой роскоши">
							<img src="/content/images/most_6.jpg" width="141" height="94" alt="1" />
							Старинное оружие Минобороны выставят на продажу
							<span>play</span>
						</a>								
					</dt>
					<dd>
						<span class="data">Во что превратилась Британская империя в XXI веке</span>
						<span class="info">
							<span class="time">17.02.2013</span>								  
							<span class="comments">25</span>
						</span>
					</dd>
				</dl>
			</div>
					
        </div>
        <div class="waveEdge"></div>
    </div>
</asp:Content>