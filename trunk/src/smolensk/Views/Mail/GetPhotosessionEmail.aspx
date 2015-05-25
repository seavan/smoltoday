<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.GetSessionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
    <p>
        Здравствуйте, <%= Model.Photographer.ShortName %>!</p>
    <p>Пользователь портала <%= Model.User.ShortName %> хочет заказать фотосессию.</p>
    <p>
        Комментарий пользователя:
    </p>
    <p>
        <%= Model.Text %>
    </p>
    <p>Для связи, пользователь оставил контактные данные:</p>
    <% if (!string.IsNullOrEmpty(Model.Email))
       { %>
       <p>Электронная почта: <%= Model.Email %></p>
    <% } %>
    
    <% if (!string.IsNullOrEmpty(Model.Phone))
       { %>
       <p>Телефон: <%= Model.Phone %></p>
    <% } %>
    
    <br />
    <br />
    <hr />
    С уважением, редакция портала SmolToday.ru
</asp:Content>