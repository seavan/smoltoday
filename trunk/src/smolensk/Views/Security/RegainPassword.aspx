<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<string>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="blockContent security">
        <div class="widthContent">
            <%
                bool success = ViewBag.Success != null ? (bool) ViewBag.Success : false;
            %>
    
            <%if(success){%>
                <h2><%= Model %>,</h2>
                <p>ваш пароль успешно изменён.</p>
            <%}else{ %>
            <h2>Восстановление пароля</h2>
            <p>При попытке восстановления пароля возникли ошибки:</p>
            <p><%= Model %></p>
            <%} %>
        </div>
        <div class="waveEdge"></div>
    </div>

</asp:Content>
