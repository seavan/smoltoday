<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.SearchVacancyOrResumeViewModel>" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">

    <div class="vacancyOne">
        <h3>Поиск резюме</h3>                            
                            
        <div class="grayCreateBlock">
            <% using (Html.BeginForm("SearchResume", "Vacancy", FormMethod.Get))
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
                        <span class="checkbox"><%: Html.CheckBoxFor(m=>m.InTitle) %> В названии резюме</span><br/>
                        <span class="checkbox"><%: Html.CheckBoxFor(m=>m.InDescription) %> В описании резюме</span><br/>                                            
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
                    <td style="vertical-align:top; padding-top:5px;">Уровень заработной<br/>платы</td>
                    <td>
                        от <%: Html.TextBoxFor(m => m.Compensation1, new {@class = "range"}) %> 
						до <%: Html.TextBoxFor(m => m.Compensation2, new {@class = "range"}) %><br/><br/>
                        <span class="checkbox" style="margin-left:10px;"><%: Html.CheckBoxFor(m => m.HideWithoutSalary) %> Скрыть резюме без указания зарплаты</span>
                    </td>
                </tr>
                                    
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Возрастные ограничения</td>
                    <td>
                        <span class="radio"><input type="radio" value="2"  />Не имеет значения</span> <br/><br/>
                                            
                        от <%: Html.TextBoxFor(m => m.Age1, new {@class = "range"}) %> 
						до <%: Html.TextBoxFor(m => m.Age2, new {@class = "range"}) %><br/><br/>
                        <span class="checkbox" style="margin-left:10px;"><%: Html.CheckBoxFor(m => m.HideWithoutAge) %> Скрывать резюме без сведенийо требуемом возрасте</span>
                        <br/><br/>
                    </td>
                </tr>
                                    
                <tr>
                    <td style="vertical-align:top; padding-top:5px;">Опыт работы</td>
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
    <%: Html.CheckBoxFor(m => m.HideForNational) %> Скрывать резюме<br/>иностранных работников
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
                            <span class="addSubFormButton">Настройки отображения результатов</span>
                            <div class="body">
                                
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
                                   <% } %>                                                  <br/>
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
