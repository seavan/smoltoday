<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<ActionsListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Мероприятия</h3>
        <div class="profileTools">
            <form action="#">
                <div class="sortingTools">								
                    <ul>									                                           
                        <li><a href="#" class="addAction" title="Создать новое мероприятие"><span>Создать новое мероприятие</span></a></li>									
                    </ul>									
                </div>                                	
            </form>
        </div>
    </div>
    <div class="clear"></div>                    
    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>Раздел</th>
                <th>Название</th>
                <th>Место</th>
                <th>Дата<br/>публикации</th>
                <th>Статус</th>
                <th>&nbsp;</th>
            </tr>
            <%foreach (var a in Model.Actions) {%>

            <tr>
                <td><%=a.Category.Title %></td>                                    
                <td><a href="<%= a.GetUri() %>" title="<%= a.GetHrefTitle() %>"><%=a.Title %></a></td>
                <td><%= string.Join(", ", a.Places.Select(p => p.Title)) %></td>
                <td class="date"><%=a.CreateDate.ToShortDateString()%><br/><%=a.CreateDate.ToShortTimeString()%></td>                                                                         
                <td>
                <%if (a.Status != ActionStatus.Create)
                  {%>
                    <span class="checkbox" data-url="<%=Url.Action("SetStatusAction", "Poster", new {id = a.Id}) %>">
                        <input type="checkbox" <%= a.Status == ActionStatus.Approve ? "checked" : "" %> />опубликовано</span>
                <%} %>
                <%else
                  { %>
                    не проверено
                <%} %>
                </td>
                <td>
                    <%--<span class="edit" title="Редактировать"></span>--%>
                    <span class="delete" data-url="<%=Url.Action("DeleteAction", "Poster", new {id = a.Id}) %>" title="Удалить"></span>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
                        
                        
    <div class="blockLine">
		<%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.RouteName, new { }, "page")%>
	</div>  

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="popUpLayer">
    <% Html.RenderPartial("../Poster/AddAction", new smolensk.Models.ViewModels.Mail.SimpleMailModel()); %>
</asp:Content>