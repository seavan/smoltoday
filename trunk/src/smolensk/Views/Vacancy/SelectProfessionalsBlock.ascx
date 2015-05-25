<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.SearchVacancyOrResumeViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

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
                <% foreach (VacancyProfessionalViewModel prof in Model.ProfessionalsList)
                   {%>
            <li>
                <span class="checkbox"><%: Html.SimpleCheckBox("Professionals", prof.Id, prof.Selected)%><%:prof.Title %>
                </span>
                <% if (prof.Children != null && prof.Children.Count > 0)
                    { %>
                    <ul style="display:block;">
                        <% foreach (VacancyProfessionalViewModel child in prof.Children)
                           {%>
                                <li><span class="checkbox"><%:Html.SimpleCheckBox("Professionals", child.Id, child.Selected)%><%:child.Title %></span></li>  
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
    </td>
</tr>