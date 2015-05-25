<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.AdvertRequestModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
    <p>
        Пользователь портала <%= Model.Account.ShortName %> сделал <%= Model.Type %> для 
        данного <a href="http://smoltoday.ru/Adverts/One/<%= Model.AdvertismentId %>">объявления.</a>
    </p>
</asp:Content>