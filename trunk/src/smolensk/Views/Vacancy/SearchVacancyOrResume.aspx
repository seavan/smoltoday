<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

    <div class="vacancyOne">
        <h3>Поиск вакансий</h3>                            
                            
        <div class="grayCreateBlock">
            <% using (Html.BeginForm("SearchVacancy","Vacancy", FormMethod.Get)) { %>
            <table class="createBlock">                                	
                <tr>
                    <td>Ключевые слова</td>
                    <td><input type="text" value="" name="keywords" /></td>
                </tr>                                   
                <tr>
                    <td style="vertical-align:top;">Искать только</td>
                    <td>
                        <span class="checkbox"><input type="checkbox" id="c1" name="c1" /> В названии вакансии</span><br/>
                        <span class="checkbox"><input type="checkbox" id="c2" name="c2" /> В описании вакансии</span><br/>
                        <span class="checkbox"><input type="checkbox" id="c3" name="c3" /> В названии компании</span><br/><br/>                                           
                    </td>
                </tr>
                <tr>
                    <th colspan="2">Профессиональная область</th>
                </tr>  
                <tr>      
                    <td>&nbsp;</td>                              	
                    <td><span class="_prof_area"><span class="checkbox"><input type="checkbox"  /> Не важно</span></span></td>
                </tr>                          	
                <tr>
                    <td style="vertical-align:top;">Выберите<br/>направления</td>
                    <td>
                        <div class="windowFrame">
                            <div id="scroll1">
                                <ul>
                                    <li><span class="checkbox"><input type="checkbox" checked="checked" /> Строительство и ремонт</span>
                                        <ul style="display:block;">
                                            <li><span class="checkbox"><input type="checkbox" /> Ремонт</span></li>
                                            <li><span class="checkbox"><input type="checkbox" /> Нелегальная иммиграция</span></li>
                                            <li><span class="checkbox"><input type="checkbox" /> Малярия-штукатурия</span></li>
                                            <li><span class="checkbox"><input type="checkbox" /> Сервисные услуги</span></li>
                                        </ul>
                                    </li>
                                    <li><span class="checkbox"><input type="checkbox" /> Туризм, гостиничный сервис</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Ирюсты</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Туризм, гостиничный сервис</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Ирюсты</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Туризм, гостиничный сервис</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Ирюсты</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Туризм, гостиничный сервис</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Ирюсты</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Туризм, гостиничный сервис</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Ирюсты</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Туризм, гостиничный сервис</span></li>
                                    <li><span class="checkbox"><input type="checkbox" /> Ирюсты</span></li>
                                </ul>
                            </div>
                        </div>
                        <div class="buttonPanel">    
                            <span class="button reset">Сбросить всё</span>
                            <!--<span class="button save">Сохранить</span> -->                                   
                        </div>
                    </td>
                </tr>
            </table>
                                
            <table class="createBlock">                                	
                <tr>
                    <td>Регион трудоустройства</td>
                    <td>
                        <select>
                            <option>Смоленская область</option>
                        </select>
                            <select>
                            <option>Смоленск</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">Образование</td>
                    <td>
                        <select>
                            <option>Не имеет значения</option>
                        </select>                     
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Уровень заработной<br/>платы</td>
                    <td>
                        от <input type="text" value="" class="range" /> 
                        <span class="checkbox" style="margin-left:10px;"><input type="checkbox" id="cs1" name="cs1" checked="checked" /> Скрыть вакансии без указания зарплаты</span>
                    </td>
                </tr>
                                    
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Возрастные ограничения</td>
                    <td>
                        <span class="radio"><input type="radio" value="2"  />Не имеет значения</span> <br/><br/>
                                            
                        от <input type="text" value="" class="range" /> 
                        <span class="checkbox" style="margin-left:10px;"><input type="checkbox" checked="checked" /> Скрывать вакансии без сведений<br/>о требуемом возрасте</span>
                        <br/><br/>
                    </td>
                </tr>
                                    
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Требуемый опыт работы</td>
                    <td>
                        <div class="facilities"><span class="radio"><input type="radio" value="0" name="exp" checked="checked"  /> Не имеет значения</span></div>
                        <div class="facilities"><span class="radio"><input type="radio" value="1" name="exp"  /> Нет опыта</span></div>
                        <div class="facilities"><span class="radio"><input type="radio" value="2" name="exp"  /> От 1 года до 3 лет</span></div>
                        <div class="facilities"><span class="radio"><input type="radio" value="3" name="exp"  /> От 3 до 6 лет</span></div>
                        <div class="facilities"><span class="radio"><input type="radio" value="4" name="exp"  /> Более 6 лет</span></div>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Гражданство</td>
                    <td>
                        <div class="facilities">
                            <span class="radio"><input type="radio" value="0" name="nation" checked="checked"  /> Не имеет значения</span>
                            <span class="checkbox" style="margin-left:90px;"><input type="checkbox" checked="checked" /> Скрывать вакансии<br/>для иностранных работников</span>
                                                
                        </div>
                        <div class="facilities"><span class="radio"><input type="radio" value="1" name="nation" /> Гражданин РФ</span></div>
                        <div class="facilities"><span class="radio"><input type="radio" value="2" name="nation" /> Страны с безвизовым режимом</span></div>
                        <div class="facilities"><span class="radio"><input type="radio" value="3" name="nation" /> Страны с визовым режимом</span></div>                                            
                    </td>
                </tr>
                <tr class="_custom_check_radio">
                    <td style="vertical-align:top;padding-top:5px;">Тип занятости</td>
                    <td>
                        <span class="radio"><input type="radio" value="0"  checked="checked"/> Не имеет значения</span><br/><br/>
                        <div>
                        <span class="checkbox"><input type="checkbox" id="c9" name="c9" /> Полная занятость</span><br/>
                        <span class="checkbox"><input type="checkbox" id="c10" name="c10" /> Частичная занятость</span><br/>
                        <span class="checkbox"><input type="checkbox" id="c11" name="c11" /> Проектная/Временная работа </span><br/>
                        <span class="checkbox"><input type="checkbox" id="c12" name="c12" /> Волонтерство</span><br/>       
                        <span class="checkbox"><input type="checkbox" id="c13" name="c13" /> Стажировка</span><br/>                                               
                        </div>
                    </td>
                </tr>
                <tr class="_custom_check_radio">
                    <td style="vertical-align:top;padding-top:5px;">График работы</td>
                    <td>
                        <span class="radio"><input type="radio" value="0"  checked="checked"/> Не имеет значения</span><br/><br/>
                        <div>
                        <span class="checkbox"><input type="checkbox" id="cc9" name="cc9" /> Полный день</span><br/>
                        <span class="checkbox"><input type="checkbox" id="cc10" name="cc10" /> Сменный график</span><br/>
                        <span class="checkbox"><input type="checkbox" id="cc11" name="cc11" /> Гибкий график</span><br/>
                        <span class="checkbox"><input type="checkbox" id="cc12" name="cc12" /> Удаленная работа</span><br/>      
                        </div>                                            	
                    </td>
                </tr>
                                    
                                       
            </table>      
                                
            <table class="createBlock" style="margin-top:-20px;">    
                <tr>
                    <td> 
                                        	
                        <div class="createSubForm" style="text-align: left;">
                            <span class="addSubFormButton">Желаемые льготы</span>
                            <div class="body">
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox" id="ch1" name="ch1" /> Предоставление жилья</span>
                                    <select>
                                        <option>Любые льготы</option>
                                    </select>
                                </div>
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox" id="ch2" name="ch2" /> Траспорт</span>
                                    <select>
                                        <option>Любые льготы</option>
                                    </select>
                                </div>
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox" id="ch3" name="ch3" /> Питание</span>
                                    <select>
                                        <option>Любые льготы</option>
                                    </select>
                                </div>
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox" id="ch4" name="ch4" /> Здравоохранение</span>                                            
                                    <select>
                                        <option>Любые льготы</option>
                                    </select>
                                </div>
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox" id="ch5" name="ch5" /> Другие льготы</span>                                            
                                    <select>
                                        <option>Любые льготы</option>
                                    </select>
                                </div>
                                <br/>
                            </div>
                        </div>
                    </td>
                </tr>        
            </table>
                                
            <table class="createBlock" style="margin-top:-20px;">    
                <tr>
                    <td> 
                                        	
                        <div class="createSubForm" style="text-align: left;">
                            <span class="addSubFormButton">Сведения о предприятии</span>
                            <div class="body">
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox"  /> Форма собственности</span>
                                    <select>
                                        <option>Любая</option>
                                    </select>
                                </div>
                                <div class="facilities">
                                    <span class="checkbox"><input type="checkbox"  /> Только с дополнительными сведениями о работодателе</span>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>        
            </table>                          
            <table class="createBlock" style="margin-top:-20px;">    
                <tr>
                    <td> 
                                        	
                        <div class="createSubForm" style="text-align: left;">
                            <span class="addSubFormButton">Настройки отображения результатов</span>
                            <div class="body">
                                <div class="facilities">Скрыть в результатах поиска</div>
                                <div class="facilities"><span class="checkbox"><input type="checkbox" /> Вакансии агентств</span></div>
                                <div class="facilities"><span class="checkbox"><input type="checkbox" /> Вакансии, недоступные людям с инвалидностью</span></div>
                                <br/><br/>
                                <div class="facilities">Сортировать по</div>
                                <div class="facilities"><span class="radio"><input type="radio" value="0" name="sort" checked="checked" /> Дате изменения</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="1" name="sort" /> Зарплате (от большей к меньшей)</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="2" name="sort" /> Зарплате (от меньшей к большей)</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="3" name="sort" /> Соответствию</span></div>
                                                    
                                <br/><br/>
                                <div class="facilities">Выводить</div>
                                <div class="facilities"><span class="radio"><input type="radio" value="0" name="out" checked="checked" /> За месяц</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="1" name="out" /> За неделю</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="2" name="out" /> За три дня</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="3" name="out" /> За сутки</span></div>
                                                    
                                <br/><br/>
                                <div class="facilities">Элементов на страницу</div>
                                <div class="facilities"><span class="radio"><input type="radio" value="0" name="page" checked="checked" /> 20</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="1" name="page" /> 50</span></div>
                                <div class="facilities"><span class="radio"><input type="radio" value="2" name="page" /> 100</span></div>                                                    <br/>
                            </div>
                        </div>
                    </td>
                </tr>        
            </table>  
                             
                                
            <div class="buttonPanel" style="text-align:center;">                                                            
                <span class="button publish" onClick="$(this).closest('form').submit();">Начать поиск</span>                                    
            </div>
                                
            <% } %>
        </div>
                            
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
