<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.ResumeViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

<script type="text/javascript">
    $().ready(function () {
        $(".addSubFormButton").click(function () {
            var v = $(this).parents("[data-form-input]").data("form-input");
            var index = parseInt($("[data-form=" + v + "]").data("index"));
            $("[data-form=" + v + "] [class=_delete]:last").data("index", index == 0 ? 0 : index - 1);//минус 1, т.к событие отрабатывает до клонирования
        });
    });

    function saveFormHandler(form) {
        var container = $("td[data-form="+form+"]");
        var index = parseInt(container.data("index"));
        $("td[data-form-input="+form+"] [data-form="+form+"]").each(function () {
            var t = $(this);
            var v = t.val();
            container.append(hiddenFor(form, index, t.data("property"), v));
        });
        index++;
        container.data("index", index);
    }

    function deleteHandler(me) {
        var t = $(me);
        var index = t.data("delete-index");
        var form = t.parents("[data-form]").data("form");
        var container = $("td[data-form=" + form + "]");
        container.find("[data-index]").each(function() {
            var o = $(this);
            var i = parseInt(o.data("index"));
            if (i == index) {
                o.remove();
            } else if (i > index) {
                o.attr("name", nameFor(form, i - 1, o.data("property")));
                o.data("index", i - 1);
                if (o.hasClass("_delete")) {
                    o.data("delete-index", i - 1);
                }
            }
        });

        index = parseInt(container.data("index"));
        index--;
        container.data("index", index);
    }

    function deleteLink(me) {
        setTimeout(function () {
            var index = 0;
            $("[data-form=links]").find("input").each(function() {
                var o = $(this);
                o.attr("name", "links[" + index + "]");
                index++;
            });
        }, 500);
    }

    function hiddenFor(name, index, prop, value) {
        return "<input type='hidden' name='{0}' data-index='{1}' data-property='{2}' value='{3}'/>"
            .replace("{0}", nameFor(name,index,prop))
            .replace("{1}", index)
            .replace("{2}",prop)
            .replace("{3}", value);
    }

    function nameFor(name,index,prop) {
        return "{0}[{1}].{2}"
            .replace("{0}", name)
            .replace("{1}", index)
            .replace("{2}", prop);
    }
</script>

<div class="vacancyOne">
        <h3>Создать резюме</h3>                            
        <div class="grayCreateBlock">
            <% using (Html.BeginForm("SaveResume", "Profile", FormMethod.Post, new { enctype = "multipart/form-data" }))
               { %>
               <%: Html.HiddenFor(m=>m.Id) %>
            <table class="createBlock">                                	
                <tr>
                    <td>Ищу работу в должности:</td>
                    <td><%: Html.TextBoxFor(m => m.Post) %></td>
                </tr>
            </table>
                                
            <table class="createBlock">    
                <tr>
                    <th colspan="2">Личные данные</th>
                </tr>                            	
                <tr>
                    <td>Имя</td>
                    <td><%: Html.TextBoxFor(m => m.FirstName) %></td>
                </tr>
                <tr>
                    <td>Фамилия</td>
                    <td><%: Html.TextBoxFor(m => m.LastName) %></td>
                </tr>
                <tr>
                    <td>Отчество</td>
                    <td><%: Html.TextBoxFor(m => m.MiddleName) %></td>
                </tr>
                <tr>
                    <td>Дата рождения</td>
                    <td>
                        <%: Html.TextBoxFor(m => m.BirthDate, new {@class = "range datepicker"}) %>
                    </td>
                </tr>
                <tr>
                    <td>Пол</td>
                    <td>
                        <ul class="radioLine">
                            <li><span class="radio"><%: Html.RadioButtonFor(m => m.Sex, Sex.Мужской) %></span> мужской</li>
                            <li><span class="radio"><%: Html.RadioButtonFor(m => m.Sex, Sex.Женский) %></span> женский</li>                                               
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>Желаемый заработок</td>
                    <td><%: Html.TextBoxFor(m => m.Salary, new {@class = "range"}) %> руб.</td>
                </tr>
                <tr>
                    <td>Фотография</td>
                    <td>
                        <span class="inputFileWrapper">
                            <span class="text photo"></span>
                            <span class="button">Выбрать фотографию</span>
                            <%: Html.TextBoxFor(m => m.PhotoFile, new {@class="fileInput", @type="file"})%>
                        </span>
                    </td>
                </tr>
            </table>
                                
            <table class="createBlock">    
                <% Html.RenderPartial("VacOrRes/SelectProfessionalsBlock", Model.Professionals); %>
            </table>
            
            <table class="createBlock">    
                <tr>
                    <th colspan="2">Льготы</th>
                </tr>    
        
                <% Html.RenderPartial("VacOrRes/FacilitiesBlock", Model.Facilities); %>
                                	
            </table>
                                
            <table class="createBlock">                                	
                <tr>
                    <td>Регион трудоустройства</td>
                    <td>
<% Html.RenderPartial("RegionSelector", new RegionSelectorViewModel
                                              {
                                                  RegionName = "WorkRegion.Id",
                                                  CityName = "WorkCity.Id",
                                                  RegionId = Model.WorkRegion.Id,
                                                  CityId = Model.WorkCity.Id,
                                                  ShowAnyVariant = true,
                                              });
%>
                    </td>
                </tr>
                <tr>
                    <td>Образование</td>
                    <td>
                        <%: Html.DropDownListFor(m=>m.Education.Id, Model.EducationsList)%>
                    </td>
                </tr>
                <tr>
                    <td>Знание языков</td>
                    <td><%: Html.TextBoxFor(m=>m.Languages) %></td>
                </tr>
                    
<tr>
                    <td>Опыт работы</td>
                    <td class="experience">
                        <%: Html.DropDownListFor(m => m.Experience.Id, Model.ExperiencesList)%>
                    </td>
                </tr>                                    
<%--                <tr>
                    <td>Опыт работы</td>
                    <td class="experience">
                        <input type="text" value="" name="yearCount" class="range" /> лет <input type="text" value="" name="monthCount" class="range" /> месяцев
                        <span class="checkbox"><input type="checkbox" name="noexperience" />нет опыта</span>
                    </td>
                </tr>--%>                                   
                                    
                <tr>
                    <% Html.RenderPartial("VacOrRes/WorkTypeBlock", Model.WorkType); %>
                </tr>
                
                <tr>
                    <% Html.RenderPartial("VacOrRes/WorkModeBlock", Model.WorkMode); %>
                </tr>
                                    
                <tr>
                    <td>Семейное положение</td>
                    <td>
                        <%: Html.DropDownListFor(m=>m.FamilyStatus.Id, Model.FamilyStatusesList)%>
                    </td>
                </tr>
                                    
                <tr>
                    <td>Количество детей</td>
                    <td class="experience">
                        <%: Html.TextBoxFor(m=>m.Children, new {@class="range"}) %>
                        <span class="checkbox">
                            <input type="checkbox" name="noKid" />нет детей
                        </span>
                    </td>
                </tr>  
                                    
                <tr>
                    <td>Гражданство</td>
                    <td>
                        <%: Html.DropDownListFor(m=>m.Citizenship.Id, Model.CitizenshipsList)%>                    </td>
                </tr>
            </table>
                                
            <table class="createBlock _cloneWrapper">    
                <tr>
                    <th>Предыдущие места работы</th>
                </tr>                            	
                <tr>
                    <td data-form="works" data-index="<%:Model.Works.Count %>">
                        
                        <table class="job_place">
                            <!-- шаблон для клонирования, должен быть всегда, даже если нет ни одной записи -->
                            <tr class="_clonePiece _template">
                                <td class="tmp_str_1"></td>
                                <td class="tmp_date_1"></td>
                                <td class="tmp_str_2"></td>
                                <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete" style="display:none;" onclick="deleteHandler(this)" data-delete-index="<%:Model.Works.Count %>"/>
                                </td>
                            </tr> 
                            <% 
                                for (int i = 0; i < Model.Works.Count; i++)
                                {
                                    var work = Model.Works[i];%>
                                <tr class="_clonePiece">
                                    <td><%: work.company_name %></td>
                                    <td>
                                    <%:Formatter.FormatMonthAndYear(work.begin_date) %> - 
                                    <%:Formatter.FormatMonthAndYear(work.end_date)%>
                                    </td>
                                    <td><%: work.post %></td>
                                    <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete" onclick="deleteHandler(this)" data-delete-index="<%:i %>"/></td>  
                                </tr>
                               <%} %>  
                            <!-- END - шаблон для клонирования, должен быть всегда, даже если нет ни одной записи -->
                        </table>
                        <% 
                           for (int i = 0; i < Model.Works.Count; i++)
                           {
                               var work = Model.Works[i];%>
                               <input type='hidden' name='works[<%:i%>].begin_date' data-index='<%:i%>' data-property='begin_date' value='<%:work.begin_date %>'/>
                               <input type='hidden' name='works[<%:i%>].end_date' data-index='<%:i%>' data-property='end_date' value='<%:work.end_date %>'/>
                               <input type='hidden' name='works[<%:i%>].post' data-index='<%:i%>' data-property='post' value='<%:work.post %>'/>
                               <input type='hidden' name='works[<%:i%>].work_time_id' data-index='<%:i%>' data-property='work_time_id' value='<%:work.work_time_id %>'/>
                               <input type='hidden' name='works[<%:i%>].company_name' data-index='<%:i%>' data-property='company_name' value='<%:work.company_name %>'/>
                               <input type='hidden' name='works[<%:i%>].success_description' data-index='<%:i%>' data-property='success_description' value='<%:work.success_description %>'/>
                        <% } %>
                    </td>
                </tr>   
                <tr>
                    <td data-form-input="works">
                        <div class="createSubForm">
                            <span class="addSubFormButton">Добавить ещё одно место работы</span>
                            <div class="body">
                                <div>Выберите период работы</div>
                                <div>
                                    <!-- data-clone-data необходимый аттрибут для тех полей, которые попадут в отображаему таблицу. tmp_date_1 - даты. tmp_str_1 - строки -->
                                    <input type="text" value="" class="fromDate datepicker_range tmp_date_1" id="fromDateJob" data-clone-data="tmp_date_1" data-property="begin_date" data-form="works" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="text" value="" class="toDate datepicker_range" id="toDateJob" data-clone-data="tmp_date_1" data-property="end_date" data-form="works" />
                                </div>
                                <div class="nowJob"><span class="checkbox"><input type="checkbox" />Работаю по настоящее время</span></div>
                                <div>Должность <input type="text" value="" class="post" data-clone-data="tmp_str_2" data-property="post" data-form="works"/></div>
                                                    
                                <div>Занятость&nbsp; 
                                    <select data-property="work_time_id" data-form="works">
                                        <option value="0">-----</option>
                                        <% foreach (SelectListItem item in Model.WorkTypesList)
                                           {%>
                                           <option value="<%:item.Value %>"><%:item.Text %></option>
                                           <%} %>
                                    </select>
                                </div>
                                                   
                                <div>Название компании с адресом</div>
                                <div><textarea rows="1" cols="1" class="tmp_str_1" data-clone-data="tmp_str_1" data-property="company_name" data-form="works"></textarea></div>
                                <div>Должностные обязанности и достижения</div>
                                <div><textarea rows="1" cols="1" data-property="success_description" data-form="works" ></textarea></div>
                                                    
                                <div class="buttonPanel">                                                                               <span class="button save" onclick="saveFormHandler('works')">Сохранить</span>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>                      
            </table>
                                
            <table class="createBlock">
                <tr>
                    <th>Навыки и достижения</th>
                </tr>
                <tr>
                    <td style="width:auto;">
                        <%:Html.TextAreaFor(m=>m.SuccessDescription, new {rows=1,columns=1}) %>
                    </td>
                </tr>
            </table>
                                
            <table class="createBlock _cloneWrapper">    
                <tr>
                    <th>Обучение</th>
                </tr>                            	
                <tr>
                    <td data-form="educations" data-index="<%:Model.Educations.Count %>">
                        <table class="job_place">
                            <!-- шаблон для клонирования, должен быть всегда, даже если нет ни одной записи -->
                            <tr class="_clonePiece _template">
                                <td class="tmp_str_1"></td>
                                <td class="tmp_date_1"></td>
                                <td class="tmp_str_2"></td>
                                <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete" style="display:none;" onclick="deleteHandler(this)" data-delete-index="<%:Model.Educations.Count %>"/></td>
                            </tr> 
                            <!-- END - шаблон для клонирования, должен быть всегда, даже если нет ни одной записи -->
                            <% 
                                for (int i = 0; i < Model.Educations.Count; i++)
                                {
                                    var edu = Model.Educations[i];%>
                                <tr class="_clonePiece">
                                    <td><%:edu.address %></td>
                                    <td>
                                        <%:Formatter.FormatMonthAndYear(edu.begin_date) %> - 
                                        <%:Formatter.FormatMonthAndYear(edu.end_date) %>
                                    </td>
                                    <td><%:edu.specialty %></td>
                                    <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete"  onclick="deleteHandler(this)" data-delete-index="<%: i %>"/></td>
                                </tr>  
                               <%} %>                                               
                        </table>
                            <% 
                           for (int i = 0; i < Model.Educations.Count; i++)
                           {
                               var edu = Model.Educations[i];%>
                               <input type='hidden' name='educations[<%:i%>].begin_date' data-index='<%:i%>' data-property='begin_date' value='<%:edu.begin_date %>'/>
                               <input type='hidden' name='educations[<%:i%>].end_date' data-index='<%:i%>' data-property='end_date' value='<%:edu.end_date %>'/>
                               <input type='hidden' name='educations[<%:i%>].address' data-index='<%:i%>' data-property='address' value='<%:edu.address %>'/>
                               <input type='hidden' name='educations[<%:i%>].education_entry_id' data-index='<%:i%>' data-property='education_entry_id' value='<%:edu.education_entry_id %>'/>
                               <input type='hidden' name='educations[<%:i%>].faculty' data-index='<%:i%>' data-property='faculty' value='<%:edu.faculty %>'/>
                               <input type='hidden' name='educations[<%:i%>].specialty' data-index='<%:i%>' data-property='specialty' value='<%:edu.specialty %>'/>
                               <input type='hidden' name='educations[<%:i%>].form_entry_id' data-index='<%:i%>' data-property='form_entry_id' value='<%:edu.form_entry_id %>'/>
                        <% } %>
                    </td>
                </tr>   
                <tr>
                    <td data-form-input="educations">
                        <div class="createSubForm">
                            <span class="addSubFormButton">Добавить ещё одно место учебы</span>
                            <div class="body">
                                <div>Период обучения</div>
                                <div>
                                    <input type="text" value="" class="fromDate datepicker_range" id="fromDateLern" data-clone-data="tmp_date_1" data-property="begin_date" data-form="educations"/>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="text" value="" class="toDate datepicker_range" id="toDateLern" data-clone-data="tmp_date_1" data-property="end_date" data-form="educations" />
                                </div>
                                                    
                                <div>Учебное заведение с адресом</div>
                                <div><textarea rows="1" cols="1" data-clone-data="tmp_str_1" data-property="address" data-form="educations"></textarea></div>
                                                    
                                <div>Уровень образования 
                                    <select data-property="education_entry_id" data-form="educations">
                                        <option value="0">-----</option>
                                        <% foreach (SelectListItem item in Model.EducationLevelsList)
                                           {%>
                                           <option value="<%:item.Value %>"><%:item.Text %></option>
                                           <%} %>
                                    </select>
                                </div>
                                                    
                                <div>Факультет <input type="text" value="" class="post" style="margin-left:40px;" data-property="faculty" data-form="educations" /></div>  
                                <div>Специальность&nbsp;&nbsp;<input type="text" value="" class="post" data-clone-data="tmp_str_2" data-property="specialty" data-form="educations"/></div>                                                                                                     
                                <div>Форма обучения
                                    <select data-property="form_entry_id" data-form="educations">
                                        <option value="0">-----</option>
                                        <% foreach (SelectListItem item in Model.LearningFormsList)
                                           {%>
                                           <option value="<%:item.Value %>"><%:item.Text %></option>
                                           <%} %>
                                    </select>
                                </div>
                                                    
                                <div class="buttonPanel">                                                                           <span class="button save" onclick="saveFormHandler('educations')">Сохранить</span> 
                                </div>
                                                    
                            </div>
                        </div>
                    </td>
                </tr>                      
            </table>
								
			<table class="createBlock _cloneWrapper">    
                <tr>
                    <th>Курсы и тренинги</th>
                </tr>                            	
                <tr>
                    <td data-form="trainings" data-index="<%:Model.Trainings.Count %>">
                        <table class="job_place">
                            <!-- шаблон для клонирования, должен быть всегда, даже если нет ни одной записи -->
                            <tr class="_clonePiece _template">
                                <td class="tmp_date_1"></td>
                                <td class="tmp_str_1"></td>
                                <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete" style="display:none;" onclick="deleteHandler(this)" data-delete-index="<%:Model.Trainings.Count %>" /></td>
                            </tr> 
                            <!-- END - шаблон для клонирования, должен быть всегда, даже если нет ни одной записи -->
                                <% for (int i = 0; i < Model.Trainings.Count; i++)
                                   {
                                       var train = Model.Trainings[i];%>
                                <tr class="_clonePiece">
                                    <td>
                                    <%: Formatter.FormatMonthAndYear(train.begin_date) %> - 
                                    <%: Formatter.FormatMonthAndYear(train.end_date) %>
                                    </td>
                                    <td><%: train.description %></td>
                                    <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete" onclick="deleteHandler(this)" data-delete-index="<%: i %>"/></td>  
                                </tr>  
                                <% } %>        
                        </table>
                        <% for (int i = 0; i < Model.Trainings.Count; i++)
                           {
                               var train = Model.Trainings[i];%>
                               <input type='hidden' name='trainings[<%:i%>].begin_date' data-index='<%:i%>' data-property='begin_date' value='<%:train.begin_date %>'/>
                               <input type='hidden' name='trainings[<%:i%>].end_date' data-index='<%:i%>' data-property='end_date' value='<%:train.end_date %>'/>
                               <input type='hidden' name='trainings[<%:i%>].description' data-index='<%:i%>' data-property='description' value='<%:train.description %>'/>
                        <% } %>
                    </td>
                </tr>   
                <tr>
                    <td data-form-input="trainings">
                        <div class="createSubForm">
                            <span class="addSubFormButton">Добавить ещё курсы</span>
                            <div class="body">
                                <div>Период обучения</div>
                                <div>
                                    <input type="text" value="" class="fromDate datepicker_range" id="fromDateСourses" data-clone-data="tmp_date_1" data-property="begin_date" data-form="trainings"/>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="text" value="" class="toDate datepicker_range" id="toDateСourses" data-clone-data="tmp_date_1" data-property="end_date" data-form="trainings"/>
                                </div>
                                                                                                       
                                <div>Название и описание</div>
                                <div><textarea rows="1" cols="1"  data-clone-data="tmp_str_1" data-property="description" data-form="trainings"></textarea></div>
													
                                <div class="buttonPanel">                                                                                       <span class="button save" onclick="saveFormHandler('trainings')">Сохранить</span>                                                              </div>
                            </div>
                        </div>
                    </td>
                </tr>                      
            </table>
                                
            <table class="createBlock">
                <tr>
                    <th>О себе</th>
                </tr>
                <tr>
                    <td style="width:auto;">
                        <%:Html.TextAreaFor(m => m.AboutMySelf, new { rows = 1, columns = 1 })%>
                    </td>
                </tr>
            </table>
                                
            <table class="createBlock _cloneWrapper">
                <tr>
                    <th>Ссылки на портфолио и личные страницы</th>
                </tr>
                <tr>
                    <td style="width:auto;" data-form="links" data-index="<%:Model.Links.Length%>">
                        <table class="job_place">
                            <% for (int i = 0; i < (Model.Links.Length == 0 ? 1 : Model.Links.Length); i++)
                            {%>                            
                            <tr class="_clonePiece">
                            <!-- [0] обязателен в имени для дальнейшего инкрементирования полей через js -->       
                            <td style="width:auto;">
                            <input type="text" value="<%:Model.Links.Length==0?"":Model.Links[i] %>"  name="links[<%:i%>]"/>
                            </td>
                            <td class="td_del"><img src="/content/i/del_cross_red.png" width="16" height="15" alt="Удалить" class="_delete _clone" onclick="deleteLink(this)"/></td>
                            </tr>  
                            <%} %>
                        </table>              
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;width:auto;"><span class="addSubFormButton _cloneButton">Добавить ещё ссылку</span></td>
                </tr>
            </table>
                                
            <table class="createBlock">
                <tr>
                    <th colspan="2">Контакты</th>
                </tr>
                <tr>
                    <td>Адрес</td>
                    <td><%:Html.TextBoxFor(m=>m.Address) %></td>
                </tr>
                <tr>
                    <td>Телефон</td>
                    <td>
                        <%: Html.TextBoxFor(m=>m.Phone,new {@class="phone"}) %>
                        <span class="checkbox"><input type="checkbox" <%: string.IsNullOrEmpty(Model.Phone2) ? "" : "checked" %>/>Добавочный</span>
                        <%: Html.TextBoxFor(m => m.Phone2, new Dictionary<string, object> { { "class", "phone" }, { string.IsNullOrEmpty(Model.Phone2) ? "disabled" : "enabled", ""} })%>
                    </td>
                </tr>
                <tr>
                    <td>Электронная почта</td>
                    <td><%: Html.TextBoxFor(m=>m.Email) %></td>
                </tr>
            </table>
            
            <div class="buttonPanel" style="text-align:center;">
                <span class="isPublishCheckBox">
                     <span class="checkbox">
                        <%: Html.CheckBoxFor(m=>m.IsPublish) %> опубликовать
                     </span>
                </span>   
                <span class="button publish" onClick="$(this).closest('form').submit();">Сохранить резюме</span>    
                                        
            </div>
            <% } %>
        </div>
                            
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
