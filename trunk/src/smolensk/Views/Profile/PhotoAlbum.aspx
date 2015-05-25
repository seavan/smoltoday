<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.photobank_user_albums>" %>
<%@ Import Namespace="smolensk.Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Моё портфолио</h3>

        <div class="profileTools">
            
            <form action="#">
                <div class="formLine">
                    <ul class="radioLine">
                        <li><span class="radio" data-url="<%: Url.Action("PhotoBank") %>" ><input type="radio" name="photo" value="1" /> Приобретенные фото</span></li>
                        <li><span class="radio" data-url="<%: Url.Action("PhotoProfile") %>" ><input type="radio" name="photo" value="2"  checked="checked" /> Мои фото</span></li>     
                    </ul>
                </div>
            </form>

        </div>
							
	    <div class="clear"></div>

	    <div class="albumInfo">
		    <div class="info">
			    <p class="name"><%: Model.title %></p>
			    <p class="date"><%= Formatter.FormatCompanyPublishDate(Model.shoot_date)%></p>
			    <p class="count"><%: Model.CountPhotos.ToCounterWordForm(Int64Extensions.PhotoForm, false)%></p>
		    </div>
		    <span class="button createPortfolio addNewPhoto">Добавить фотографию</span>
	    </div>

    </div>
                        
    <% Html.RenderAction("PhotoList", Model.id); %>   
                         
						 
    <div class="profileBody">
	    <div class="clear"></div>
							
	    <% Html.RenderAction("AddNewPhoto");%>   
        
      <%--  <% Html.RenderAction("AddRelPhoto"); %> --%>
      <div class="grayCreateBlock form_addRelPhoto" style="display:none;"></div>
      <div class="overlayProfile">
        <div class="overlayLayer"></div>
        <div class="preloader"></div>
    </div>
							
	    
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
