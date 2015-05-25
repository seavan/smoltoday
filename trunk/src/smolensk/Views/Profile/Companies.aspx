<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<CompaniesListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Избранные компании</h3>
    </div>
    <div class="clear"></div>                    
    <div class="profileBody">
        <div class="companyList">
            <% Html.RenderPartial("../Companies/CompaniesList", Model.Companies); %>
        </div>
    </div>
                        
    <div class="blockLine">
		<%: Html.Pager(Model.CurrentPage, Model.TotalPages, Model.RouteName, new { }, "page")%>
	</div>  
    <%if (Model.Companies.Count > 0) {%>
    <div class="blockMap companyPage">
		<div class="waveEdge top"></div>
        <div class="waveEdge"></div>
				
		<div class="widthContent">
		    <p class="showMap">Карта компаний - Банки и кредитные организации</p><br/>
		</div>

		<div class="mapBlock">
            <% Html.RenderAction("FavoriteEntityMap", "Companies"); %>
		</div>							
	</div>
    <%} %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
    
</asp:Content>
