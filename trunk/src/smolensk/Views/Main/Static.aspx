<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.StaticPageViewModel>" MasterPageFile="~/Views/Master/Inner.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentCssClass">staticPage</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="LeftBlockContent">
<div class="widthContent">
					<div class="leftBlock">
                    	<div class="blockLine">                       
                       		                           
                            
                            <div class="categoryBlock">
                            
                            	<div class="categoryName">
                            		<h3><%= Model.Title %></h3>                                   
                                </div>
                                
                                <div><%= Model.Content %>
                                </div>

                            </div>
                            
                        </div>                                        
                    </div>
                  
            	</div>
</asp:Content>



