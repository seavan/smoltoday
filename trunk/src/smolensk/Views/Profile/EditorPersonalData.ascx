<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.accounts>" %>

<div class="grayCreateBlock profile">
    <form action="#" class="ajaxForm" data-action="<%: Url.Action("EditPersonalData", "Profile")%>" data-target=".vacancyOne.main" data-callback="initProfileMain">
        <%: Html.HiddenFor(m => m.id) %> 
        <table class="createBlock">                                                                        	
            <tr>
                <td>Имя</td>
                <td><%: Html.TextBoxFor(m=>m.firstname) %></td>
            </tr>
            <tr>
                <td>Фамилия</td>
                <td><%: Html.TextBoxFor(m=>m.lastname) %></td>
            </tr>
            <tr>
                <td>Отчество</td>
                <td><%: Html.TextBoxFor(m=>m.secondname) %></td>
            </tr>
            <tr>
                <td>Дата рождения</td>
                <td>
                    <%if(Model.birthdate != null && Model.birthdate.Year > 1900){%>
                    <%: Html.TextBoxFor(m => m.birthdate, new { @class = "range datepickerProfile" })%>
                    <%} else {%>
                    <input class="range datepicker" id="birthdate" name="birthdate" type="text" value=""/>
                    <%} %>
                </td>
            </tr>
            <tr>
                <td>Пол</td>
                <td>
                    <ul class="radioLine">
                        <li><span class="radio"><%: Html.RadioButtonFor(m=>m.is_male, false) %></span> женский</li>                                               
                        <li><span class="radio"><%: Html.RadioButtonFor(m=>m.is_male, true) %></span> мужской</li>
                    </ul>
                </td>
            </tr>                                        
            <tr>
                <td>Фотография</td>
                <td>
                    <span class="inputFileWrapper">
                        <span class="text photo"></span>
                        <span class="button">Выбрать фотографию</span>
                        <input type="file" name="avatara" class="fileInput avatara" data-maxsize="4194304" data-uploadurl="/Profile/SaveTempImgForCrop" />
                        <%= Html.HiddenFor(m => m.avatar)%>
                    </span>
                </td>
            </tr>
            <tr>
                <td>Род деятельности</td>
                <td><%: Html.TextBoxFor(m=>m.career) %></td>
            </tr>
            <%--<tr>
                <td style="vertical-align:top;">О себе</td>
                <td>
                    <%: Html.TextAreaFor(m=>m.description) %>
                </td>
            </tr>--%>
        </table>
        <div class="buttonPanel">    
            <span class="button reset">Отменить</span>
            <span class="button save">Сохранить</span>                                 
        </div>
    </form>
</div>
<div class="overlayProfile">
    <div class="overlayLayer"></div>
    <div class="preloader"></div>
</div>