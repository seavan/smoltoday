<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="../Master/Smolensk.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="Content">
    <% Html.RenderPartial("Blocks/FirstRow"); %>
    <% Html.RenderPartial("Blocks/CityPriceRow"); %>
    <% Html.RenderPartial("Blocks/SecondRow"); %>
    <% // Html.RenderPartial("Blocks/MainWebCamRow"); %>
    <% Html.RenderPartial("Blocks/MapRow"); %>
    <% Html.RenderAction("PhotoBankRow"); %>
    
<!-- AddThis Smart Layers BEGIN -->
<!-- Go to http://www.addthis.com/get/smart-layers to customize -->
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=xa-52326a635da8ef81"></script>
<script type="text/javascript">
/*    addthis.layers({
        'theme': 'transparent',
        'share': {
            'position': 'left',
            'numPreferredServices': 5
        },
        'whatsnext': {},
        'recommended': {}
    }); */
</script>
<!-- AddThis Smart Layers END -->


</asp:Content>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Scripts">
     <script type="text/javascript" src="/content/js/index.js"></script>
</asp:Content>