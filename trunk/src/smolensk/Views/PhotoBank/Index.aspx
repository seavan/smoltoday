<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/PhotoBank.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content3" ContentPlaceHolderID="PhotoBank" runat="server">
    <div class="blockLine">
        <div class="newsBlock">
            <% Html.RenderAction("NewPhotos", "PhotoBank"); %>
        </div>
                            
        <div class="categoryBlock">
            <h3>Категории</h3>
                                
            <div class="categoryList">
                <% Html.RenderAction("Categories", "PhotoBank"); %>    	
            </div>
        </div>
    </div>                        
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="ContentScript" runat="server">
    <script src="/content/js/jquery.cycle.min.js" type="text/javascript"></script>
    <script>
        $(function() {
            $('#randomPhotos').cycle({
                fx: 'fade',
                speed: 1000
            });
        });
    </script>
</asp:Content>