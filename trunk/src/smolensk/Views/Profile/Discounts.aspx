<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<SalesListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Избранные скидки</h3>
    </div>
    <div class="clear"></div>                    
    <div class="profileBody">
        <div class="saleList">
            <% Html.RenderPartial("../Discounts/List"); %>
        </div>
    </div>
                        
    <div class="blockLine">
		<%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.RouteName, new { }, "page")%>
	</div>  

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
