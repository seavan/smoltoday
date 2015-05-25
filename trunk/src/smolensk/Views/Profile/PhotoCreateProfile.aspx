<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.accounts>" %>
<%@Import namespace="smolensk.Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Фотографии - Создать портфолио</h3>
                            
							
		<div class="profileBlock">
            <p><%= Model.ShortName %></p>
            <img src="<%: Model.AvatarUrlMid %>" width="139" alt="<%= Model.ShortName %>"  />
            
            <div class="infoBlock">
                <ul>
                    <li><span>Имя:</span> <%= Model.ShortName %></li>
                    <li><span>Адрес:</span> <i>укажие адрес</i></li>
                    <li><span>Вебсайт:</span> <i>укажите вебсайт</i></li>
                    <li><span>Дата регистрации:</span> <%= Formatter.FormatCompanyPublishDate(Model.created)%></li>
                    <li><span>Компания:</span> <i>укажите компанию</i></li>
                </ul>                                    
                                    
                <dl>
                    <dt>О себе:</dt>
                    <dd><i>немного текста о себе</i></dd>
                </dl>
            </div>
        </div>
							
    </div>
                        
    <div class="profileBody">
							
		<div class="clear"></div>
		<div class="grayCreateBlock">
            <form action="<%: Url.Action("PhotoCreateProfile") %>" method="post">
             <%: Html.HiddenFor(m => m.id) %>  
            <table class="createBlock">   
                    <tr>
                    <th colspan="2">Создание портфолио</th>
                </tr>                 	
                <tr>
                    <td>Адрес</td>
                    <td><%: Html.TextBoxFor(m=>m.address) %></td>
                </tr>
				<tr>
                    <td>Сайт</td>
                    <td><%: Html.TextBoxFor(m=>m.website) %></td>
                </tr>
                <tr>
                    <td>Компания</td>
                    <td><%: Html.TextBoxFor(m=>m.company) %></td>
                </tr>
				<tr>
                    <td style="vertical-align:top;">О себе</td>
                    <td>
                        <%: Html.TextAreaFor(m=>m.description) %>
                    </td>
                </tr>
            </table>   
                                
                                
            <div class="buttonPanel">  									                     	
                <span class="button save" onClick="$(this).closest('form').submit();">Сохранить</span>                                    
            </div>
                                
            </form>
        </div>
								
                        	
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
