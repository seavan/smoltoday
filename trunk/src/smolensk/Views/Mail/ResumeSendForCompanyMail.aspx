<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.ResumeSendForCompanyModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<h2>Пользователь отправил вам резюме </h2>
<p>
    <%: Html.Action("Resume","Vacancy",new {Id = Model.ResumeId})%>
</p>

</asp:Content>
