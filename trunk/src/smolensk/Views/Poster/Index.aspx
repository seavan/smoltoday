<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Poster.Master" Inherits="System.Web.Mvc.ViewPage<ActionsListViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Poster" runat="server">

    <div class="listPoster">
        <h3>Афиша. Мероприятия и культурные события</h3>
                           
        <% Html.RenderPartial("ActionDateFilter"); %> 
        <div class="date"><%= Model.DateTitle %></div>

        <% int i = 0;
           int length = 3; 
           foreach (var action in Model.Actions)
           {
               bool isStartLine = i % length == 0;
               bool isEndLine = i % length == length - 1 || i == Model.Actions.Count() - 1;
               i++;
               if (isStartLine) { %>
               <div class="blockLine">
               <%}%>
            
                <% Html.RenderPartial("ActionBlock", action); %>     
               <%if (isEndLine) { %>
               </div>
               <%}%>       
       <%} %> 
       
       <%if (Model.Actions == null || !Model.Actions.Any()) {%>
       <div class="blockLine" style="font-size: 12px;">Ничего нет</div>
       <%}%>                      
    </div>                          
                        
    <%Html.RenderAction("LastActions"); %>              

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
    <% Html.RenderAction("CategoryMenu", new { dateRange = Model.Date }); %>      
    <%if (SecurityService.IsAuthorize){%>                   
    <div style="text-align:center;">
        <span class="button addAction">Добавить мероприятие</span>                            
        <span class="button addQuestion">Задать вопрос</span>
    </div>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
