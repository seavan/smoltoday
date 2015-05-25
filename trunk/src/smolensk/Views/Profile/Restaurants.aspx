<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<RestaurantsReserveListViewModel>" %>
<%@ Import Namespace="smolensk.ViewModels" %>
<%@ Import Namespace="smolensk.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Рестораны</h3>
        <div class="profileTools">
            Информация о бронированиях
        </div>
    </div>
                        
    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>Название</th>
                <th>Дата и время брони</th>
                <th>Дата и время посещения</th>                                  
                <th>Кол-во персон</th>
            </tr>
            <% foreach (var item in Model.Items) { %>
            <tr>
                <td><a href="<%: Url.Action("One", "Restaurants", new { id = item.Restaurant.Id }) %>" title="<%=item.Restaurant.Title %>" class="type">
                    <%= item.Restaurant.Title %></a>
                </td>
                <td class="date"><%= Formatter.FormatRestaurantReservesPublishDate(item.CreateDate) %></td>    
                <td class="date"><%= Formatter.FormatRestaurantReservesPublishDate(item.VisitDate) %></td>                                  
                <td class="center"><%= item.PersonCount %></td>
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
