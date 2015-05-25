<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.SearchVacancyOrResumeViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

    <div class="vacancyOne">
        <h3>Поиск вакансий</h3>                            
                            
        <div class="grayCreateBlock">
            <% using (Html.BeginForm("SearchVacancy", "Vacancy", FormMethod.Get))
               { %>
               <%: Html.HiddenFor(m => m.Type) %>
            <table class="createBlock">                                	
                <tr>
                    <td>Ключевые слова</td>
                    <td><%: Html.TextBoxFor(m=>m.Keywords) %></td>
                </tr>                                   
                <tr>
                    <td style="vertical-align:top;">Искать только</td>
                    <td>
                        <span class="checkbox"><%: Html.CheckBoxFor(m=>m.InTitle) %> В названии вакансии</span><br/>
                        <span class="checkbox"><%: Html.CheckBoxFor(m=>m.InDescription) %> В описании вакансии</span><br/>
                        <span class="checkbox"><%: Html.CheckBoxFor(m=>m.InCompanyTitle) %> В названии компании</span><br/><br/>                                           
                    </td>
                </tr>
                
                <% Html.RenderPartial("SelectProfessionalsBlock", Model); %>

            </table>
                                
            <table class="createBlock">                                	
                <tr>
                    <td>Регион трудоустройства</td>
                    <td>
                        <% Html.RenderPartial("RegionSelector", new RegionSelectorViewModel { RegionName = "RegionId", CityName = "CityId", RegionId = Model.RegionId, CityId = Model.CityId }); %>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">Образование</td>
                    <td>
                        <%: Html.DropDownListFor(m => m.EducationId, Model.EducationsList) %>                           </td>
                </tr>
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Уровень заработной<br/>платы</td>
                    <td>
                        от <%: Html.TextBoxFor(m => m.Compensation1, new {@class = "range"}) %>
                        <span class="checkbox" style="margin-left:10px;">
                            <%: Html.CheckBoxFor(m => m.HideWithoutSalary) %> 
                            Скрыть вакансии без указания зарплаты
                        </span>
                    </td>
                </tr>

                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Возрастные ограничения</td>
                    <td>
                        <span class="radio">
                            <input type="checkbox" id="cbAge" />Не имеет значения
                        </span> <br/><br/>
                                            
                        от <%: Html.TextBoxFor(m => m.Age1, new {@class = "range"}) %>
                        <span class="checkbox" style="margin-left:10px;">
                            <%: Html.CheckBoxFor(m => m.HideWithoutAge) %> Скрывать вакансии без сведений<br/>о требуемом возрасте
                        </span>
                        <br/><br/>
                    </td>
                </tr>
                                    
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Требуемый опыт работы</td>
                    <td>
                        <% foreach (VacancyEntryViewModel v in Model.Experiences)
                           { %>
<div class="facilities"><span class="radio"><%: Html.RadioButtonFor(m => m.ExperienceId, v.Id) %><%:v.Title %></span></div>
                           <%} %>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Гражданство</td>
                    <td>
                        <% for (int i = 0; i < Model.Citizenships.Count; i++)
                           {
                               var v = Model.Citizenships[i];%>
<div class="facilities"><span class="radio"><%: Html.RadioButtonFor(m => m.CitizenshipId, v.Id) %><%:v.Title %></span>
    <% if (i == 0)
        { %>
<span class="checkbox" style="margin-left:90px;">
    <%: Html.CheckBoxFor(m => m.HideForNational) %> Скрывать вакансии<br/>для иностранных работников
</span>
    <% } %>
</div>                            
                        <% } %>
                    </td>
                </tr>
                <tr class="_custom_check_radio">
                    <td style="vertical-align:top;padding-top:5px;">Тип занятости</td>
                    <td>
                        <span class="radio"><input type="radio" value="0"  checked="checked"/> Не имеет значения</span><br/><br/>
                        <div>
                        <% foreach (VacancyEntryViewModel wt in Model.WorkTypes)
                           { %>

<span class="checkbox"><%: Html.SimpleCheckBox("WorkTypeIds", wt.Id, Model.WorkTypeIds.Contains(wt.Id))%><%: wt.Title %></span><br/>  
                           <% } %>                         
                        </div>
                    </td>
                </tr>
                <tr class="_custom_check_radio">
                    <td style="vertical-align:top;padding-top:5px;">График работы</td>
                    <td>
                        <span class="radio"><input type="radio" value="0"  checked="checked"/> Не имеет значения</span><br/><br/>
                        <div>
                        <% foreach (VacancyEntryViewModel wm in Model.WorkModes)
                           { %>

<span class="checkbox"><%: Html.SimpleCheckBox("WorkModeIds", wm.Id, Model.WorkModeIds.Contains(wm.Id))%><%: wm.Title %></span><br/>  
                           <% } %>                             
                        </div>                                            	
                    </td>
                </tr>
            </table>      
                                
            <% Html.RenderPartial("SelectFacilitiesBlock", Model); %>
                                
            <table class="createBlock" style="margin-top:-20px;">    
                <tr>
                    <td> 
                        <div class="createSubForm" style="text-align: left;">
                            <span class="addSubFormButton">Сведения о предприятии</span>
                            <div class="body">
                                <div class="facilities">
                                    <span class="checkbox">
                                        <%: Html.CheckBoxFor(m => m.UseOwnership) %> Форма собственности
                                    </span>
                                    <%: Html.DropDownListFor(m => m.OwnershipId, Model.OwnershipsList) %>
                                </div>
                                <!-- NOTE: Скрыто до востребования -->
<%--                                <div class="facilities">
                                    <span class="checkbox">
                                        <%: Html.CheckBoxFor(m => m.OwnerExtInform) %> Только с дополнительными сведениями о работодателе
                                    </span>
                                </div>--%>
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
                                <!-- NOTE: Скрыто до востребования -->                                
<%--                                <div class="facilities">Скрыть в результатах поиска</div>
                                <div class="facilities"><span class="checkbox"><%: Html.CheckBoxFor(m => m.HideAgents) %> Вакансии агентств</span></div>
                                <div class="facilities"><span class="checkbox"><%: Html.CheckBoxFor(m => m.HideDisabled) %> Вакансии, недоступные людям с инвалидностью</span></div>
                                <br/><br/>--%>
                                <div class="facilities">Сортировать по</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Sorting, VacancySortingType.ChangeDate) %>Дате изменения</span>
</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Sorting, VacancySortingType.SalaryDescending) %>Зарплате (от большей к меньшей)</span>
</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Sorting, VacancySortingType.SalaryAscending) %>Зарплате (от меньшей к большей)</span>
</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Sorting, VacancySortingType.Accordance) %>Соответствию</span>
</div>
                                <br/><br/>

                                <div class="facilities">Выводить</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Print, VacancyPrintType.Month) %>За месяц</span>
</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Print, VacancyPrintType.Week) %>За неделю</span>
</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Print, VacancyPrintType.ThreeDays) %>За три дня</span>
</div>
<div class="facilities">
    <span class="radio"><%: Html.RadioButtonFor(m => m.Print, VacancyPrintType.Day) %>За сутки</span>
</div>
                                                    
                                <br/><br/>
                                <div class="facilities">Элементов на страницу</div>
                                <% foreach (int size in Constants.PageSizes)
                                   { %>
  <div class="facilities"><span class="radio"><%: Html.RadioButtonFor(m => m.PageSize, size) %> <%: size %></span></div>
                                   <% } %>
                                  <br/>
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
