<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.accounts>" %>
<%@ Import Namespace="smolensk.Domain" %>

<div class="vacancyOne main">
                            
    <div class="userGeneral">
                            
        <img src="<%: Model.AvatarUrlLarge %>" width="165" height="165"  alt="<%= Model.ShortName %>" class="_avatar" />
                                
		<div class="profileBlock">
            <h3><%= Model.FullName %></h3>
                                    
            <table class="requirements resume">
                    
                <%if(Model.birthdate!=null && Model.birthdate.Year >=1900){%>
                <tr>
                    <td>Дата рождения:</td>
                    <td><%: Formatter.FormatLongDate(Model.birthdate)%> г.</td>
                </tr>
                <%} %>      
                                  
                <tr>
                    <td>Дата регистрации:</td>
                    <td><%: Formatter.FormatLongDate(Model.created)%> г.</td>
                </tr>
                    
                <%if(!string.IsNullOrEmpty(Model.career)){%>
                <tr>
                    <td>Род деятельности:</td>
                    <td><%= Model.career %></td>
                </tr>
                <%} %>

                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Комментариев и<br/>отзывов:</td>
                    <td><%: Model.comments_count %></td>
                </tr>
                    
            </table>
        </div>
    </div>
        
    <%if(ViewBag.Main != null) {%>
    <div class="editProfileLink"><span>Редактировать</span></div>
    <%Html.RenderPartial("EditorPersonalData", Model); %>
    <% }%>
                            
</div>