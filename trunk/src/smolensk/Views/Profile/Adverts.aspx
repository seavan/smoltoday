<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.AdsListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3><%=!Model.IsFavorite ? "Объявления" : "Избранные объявления" %></h3>
        <div class="profileTools">
            <form action="#">
                <%if (!Model.IsFavorite) { %>
                <div class="sortingTools">
                    <ul>
                        <li><a href="<%: Url.Action("CreateAdvert") %>" title="Создать объявление"><span>Создать объявление</span></a></li>
                    </ul>
                </div>
                <% } %>
                <div class="formLine">
                    <ul class="radioLine">
                        <li><span class="radio" data-url="<%: Url.Action("Adverts") %>" ><input type="radio" name="photo" value="1" <%=!Model.IsFavorite ? "checked = 'checked'" : "" %>/> Мои объявления</span></li>
                        <li><span class="radio" data-url="<%: Url.Action("FavoriteAdverts") %>" ><input type="radio" name="photo" value="2" <%=Model.IsFavorite ? "checked = 'checked'" : "" %> /> Избранные</span></li>         
                    </ul>
                </div>
            </form>
        </div>
    </div>
    
    <%Html.RenderPartial("AdvertsList", Model); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
