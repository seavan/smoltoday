<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.VacancyViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">
<div class="vacancyOne">
<h3>Создать вакансию</h3>                            
                            
<div class="grayCreateBlock">
   <script type="text/javascript">
       $().ready(function () {
           $("input[disabled]").val('');
       });
   </script>

 <% using (Html.BeginForm("CreateVacancy", "Profile", FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
        <%: Html.HiddenFor(m => m.Id) %>
    <table class="createBlock">                                	
        <tr>
            <td>Название вакансии <span class="need">*</span></td>
            <td>
                <%: Html.TextBoxFor(m => m.Title) %>
                <%: Html.ValidationMessageFor(m => m.Title)%>
            </td>
        </tr>
        <tr>
            <td>Компания <span class="need">*</span></td>
            <td>
                <%--<%: Html.DropDownListFor(m=>m.Company.Id, Model.CompaniesList, new {style = "max-width:439px;"}) %>--%>
                <%: Html.TextBoxFor(m => m.Company.Title, new { @class = "_advautocomplete", rel = "/Companies/GetCompanies" })%>
                <%: Html.HiddenFor(m=>m.Company.Id, new { @class = "_autocompleteid" }) %>
                <%: Html.ValidationMessageFor(m => m.Company.Title)%>
            </td>
        </tr>
        <tr>
            <td>Город <span class="need">*</span></td>
            <td>
<% Html.RenderPartial("RegionSelector", new RegionSelectorViewModel
                                              {
                                                  RegionIdName = "region3",
                                                  CityIdName = "region4",
                                                  RegionName = "City34",//Игнорим
                                                  CityName = "City.Id",
                                                  RegionId = Model.City.ParentId.Value,
                                                  CityId = Model.City.Id,
                                                  ShowAnyVariant = false,
                                              });
%>
            </td>
        </tr>
        <tr>
<%--            <td>Логотип компании</td>
            <td>
                <span class="inputFileWrapper">
                    <span class="text"></span>
                    <span class="button">Выбрать файл</span>
                    <%: Html.TextBoxFor(m => m.Company.LogoFile, new {@class="fileInput", @type="file"})%>
                </span>
            </td>
        </tr>--%>
    </table>
                                
    <table class="createBlock">
        <tr>
            <th colspan="2">Контакты</th>
        </tr>
        <tr>
            <td>Контактное лицо <span class="need">*</span></td>
            <td>
                <%: Html.TextBoxFor(m=>m.ContactPerson) %>
                <%: Html.ValidationMessageFor(m => m.ContactPerson)%>
            </td>
        </tr>
        <tr>
            <td>Телефон <span class="need">*</span></td>
            <td>
                <%: Html.TextBoxFor(m=>m.ContactPhone,new {@class="phone"}) %>
                <span class="checkbox"><input type="checkbox" <%: string.IsNullOrEmpty(Model.ContactPhone2) ? "" : "checked" %>/>Добавочный</span>
                <%: Html.TextBoxFor(m => m.ContactPhone2, new Dictionary<string, object> { { "class", "phone" }, { string.IsNullOrEmpty(Model.ContactPhone2) ? "disabled" : "enabled", ""} })%>
                <%: Html.ValidationMessageFor(m => m.ContactPhone)%>
            </td>
        </tr>
    </table>
                                
    <table class="createBlock">
        <tr>
            <th colspan="2">Оплата труда</th>
        </tr>
        <tr>
            <td rowspan="3" style="vertical-align:top; padding-top:5px;">Зарплата в месяц</td>
            <td>
                <span class="radio">
                    <% bool check = Model.Compensation1.HasValue && !Model.Compensation2.HasValue; %>
                    <%: Html.RadioButton("Compensation", 1, check) %>
                </span>
                <%: Html.TextBoxFor(m=>m.Compensation1, new Dictionary<string, object>{ {"class", "salaryMonth"}, {check ? "nothing" : "disabled", ""}}) %> руб./мес.
            </td>
        </tr>
        <tr>
            <td style="width:444px; padding-left:0px;">
                <span class="radio">
                    <% check = Model.Compensation1.HasValue && Model.Compensation2.HasValue; %>
                    <%: Html.RadioButton("Compensation", 2, check)%>
                </span>
                от <%: Html.TextBoxFor(m=>m.Compensation1, 
                   new Dictionary<string, object>{{"class","range"},{check ? "nothing" : "disabled", ""}}) %> до <%: Html.TextBoxFor(m=>m.Compensation2, 
                   new Dictionary<string, object>{{"class","range"},{check ? "nothing" : "disabled", ""}}) %> руб./мес.
            </td>
        </tr>
        <tr>
            <td style="padding-left:0px;">
                <span class="radio">
                    <%: Html.RadioButton("Compensation", 3, !Model.Compensation1.HasValue && !Model.Compensation2.HasValue) %>
                    </span><span> не указывать</span>
            </td>
        </tr>                                                                    
    </table>
                                
    <table class="createBlock">
        <tr>
            <th colspan="2">Категория соискателя</th>
        </tr>
        <tr>
            <td rowspan="2" style="vertical-align:top; padding-top:5px;">Возраст соискателя</td>
            <td>
                <span class="radio">
                    <% check = Model.Age1.HasValue && Model.Age2.HasValue; %>
                    <%: Html.RadioButton("Age", 1, check) %>
                </span>
                    от <%: Html.TextBoxFor(m=>m.Age1, new Dictionary<string, object>{{"class","range"},{check ? "nothing" : "disabled", ""}}) %> 
                    до <%: Html.TextBoxFor(m=>m.Age2, new Dictionary<string, object>{{"class","range"},{check ? "nothing" : "disabled", ""}}) %> лет
            </td>
        </tr>
        <tr>
            <td style="width:444px; padding-bottom:30px; padding-left:0px;">
                <span class="radio">
                    <%: Html.RadioButton("Age", 2, !Model.Age1.HasValue && !Model.Age2.HasValue)%>
                </span><span> не имеет значения</span>
            </td>
        </tr>
        <tr>
            <td>Пол</td>
            <td>
                <ul class="radioLine">
                    <li><span class="radio">
                            <%: Html.RadioButton("Sex",(int)(Sex.Мужской), Model.Sex == Sex.Мужской) %>
                        </span> мужской</li>
                    <li><span class="radio">
                             <%: Html.RadioButton("Sex",(int)(Sex.Женский), Model.Sex == Sex.Женский) %>
                        </span> женский</li>
                    <li><span class="radio">
                             <%: Html.RadioButton("Sex",0, !Model.Sex.HasValue || (int)Model.Sex == 0) %>
                        </span> не имеет значения</li>
                </ul>
            </td>
        </tr>
    </table>
                                
    <table class="createBlock">                                	
        <tr>
            <% Html.RenderPartial("VacOrRes/ExperienceBlock", Model.Experience); %>
        </tr>
                                    
        <tr>
            <% Html.RenderPartial("VacOrRes/CitizenshipBlock", Model.Citizenship); %>
        </tr>
                                    
        <tr>
            <% Html.RenderPartial("VacOrRes/WorkTypeBlock", Model.WorkType); %>
        </tr>
                
        <tr>
            <% Html.RenderPartial("VacOrRes/WorkModeBlock", Model.WorkMode); %>
        </tr>
                                    
        <tr>
            <td style="vertical-align:top;">Образование</td>
            <td>
                <%: Html.DropDownListFor(m=>m.Education.Id, Model.EducationsList)%>                 
            </td>
        </tr>
                                    
        <tr>
            <td style="vertical-align:top;">Описание</td>
            <td>
                <%: Html.TextAreaFor(m=>m.Description) %>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">Обязанности</td>
            <td>
                <%: Html.TextAreaFor(m=>m.Responsibility) %>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">Требования</td>
            <td>
                <%: Html.TextAreaFor(m=>m.Requirements) %>              
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">Условия</td>
            <td>
                <%: Html.TextAreaFor(m=>m.Terms) %>               
            </td>
        </tr>
    </table>
                                
    <table class="createBlock">    
        <tr>
            <th colspan="2">Льготы</th>
        </tr>    
        
        <% Html.RenderPartial("VacOrRes/FacilitiesBlock", Model.Facilities); %>
                                	
    </table>
                                
    <table class="createBlock">    
        <%--<% Html.RenderPartial("VacOrRes/SelectProfessionalsBlock", Model.Professionals); %>--%>
        <tr>
            <th colspan="2">Профессиональная область</th>
        </tr>  
        <tr>
            <td style="vertical-align:top;">Выберите основные<br/>направления вашей<br/>деятельности <span class="need">*</span></td>
            <td>
                <div class="windowFrame">
                    <div id="scroll1">
                    <ul>
                        <% for (int i = 0; i < Model.Professionals.Count; i++) {%>
                    <li>
                        <span class="checkbox">
                            <%: Html.CheckBox("Professionals[" + i + "].Selected", Model.Professionals[i].Selected)%>
                            <%: Model.Professionals[i].Title%>
                            <%: Html.Hidden("Professionals[" + i + "].Id", Model.Professionals[i].Id)%>
                        </span>
                        <% if (Model.Professionals[i].Children != null && Model.Professionals[i].Children.Count > 0)
                            { %>
                            <ul style="display:<%:Model.Professionals[i].Selected ? "block" : "none" %>;">
                                <% for (int j = 0; j < Model.Professionals[i].Children.Count; j++)
                                   {%>
                                        <li><span class="checkbox">
                                            <%: Html.CheckBox("Professionals[" + i + "].Children[" + j + "].Selected", Model.Professionals[i].Children[j].Selected)%><%: Model.Professionals[i].Children[j].Title%>
                                            <%: Html.Hidden("Professionals[" + i + "].Children[" + j + "].Id", Model.Professionals[i].Children[j].Id)%>
                                            </span></li>  
                                   <%} %>
                            </ul>
                        <% } %>
                    </li>
                           <%} %>
                        </ul>
                    </div>
                </div>
                <div class="buttonPanel">    
                    <span class="button reset">Сбросить всё</span>
                    <!--<span class="button save">Сохранить</span> -->                                   
                </div>
                <%: Html.ValidationMessageFor(m => m.Professionals)%>
            </td>
</tr>
    </table>

                                
    <div class="buttonPanel">
        <span class="isPublishCheckBox">
             <span class="checkbox">
                <%: Html.CheckBoxFor(m=>m.IsPublish) %> опубликовать
             </span>
        </span>    
        <span class="button cancel">Отмена</span>
        <span class="button save" onClick="$(this).closest('form').submit();">Сохранить</span>                   
    </div>
<% } %>
</div>
</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
