<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<VacancyProfessionalViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<tr>
    <th colspan="2">Профессиональная область</th>
</tr>  
<tr>
    <td style="vertical-align:top;">Выберите основные<br/>направления вашей<br/>деятельности</td>
    <td>
        <div class="windowFrame">
            <div id="scroll1">
            <ul>
                <% for (int i = 0; i < Model.Count; i++)
                   {%>
            <li>
                <span class="checkbox">
                    <%: Html.CheckBox("Professionals["+i+"].Selected", Model[i].Selected)%>
                    <%: Model[i].Title %>
                    <%: Html.Hidden("Professionals["+i+"].Id", Model[i].Id) %>
                </span>
                <% if (Model[i].Children != null && Model[i].Children.Count > 0)
                    { %>
                    <ul style="display:<%:Model[i].Selected ? "block" : "none" %>;">
                        <% for (int j = 0; j < Model[i].Children.Count; j++)
                           {%>
                                <li><span class="checkbox">
                                    <%: Html.CheckBox("Professionals["+i+"].Children["+j+"].Selected", Model[i].Children[j].Selected)%><%: Model[i].Children[j].Title %>
                                    <%: Html.Hidden("Professionals["+i+"].Children["+j+"].Id", Model[i].Children[j].Id) %>
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
    </td>
</tr>