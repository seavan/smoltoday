<%@ Page Title="" Language="C#" MasterPageFile="../Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<string>" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    
    <div class="blockContent security">
        <div class="widthContent">
            <%
                bool success = ViewBag.Success != null ? (bool) ViewBag.Success : false;
            %>
    
            <%if(success){%>
                <h2><%= Model %>,</h2>
                <p>ваш аккаунт активирован. Приветствуем вас на портале «SMOLTODAY.ru»!</p>
            <%}else{ %>
            <h2>Активация аккаунта</h2>
            <p>При попытке активации аккаунта возникли ошибки:</p>
            <p><%= Model %></p>
            <%} %>
        </div>
        <div class="waveEdge"></div>
    </div>
</asp:Content>
