<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Mail.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Mail.InvitationSendMailModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageContent" runat="server">
<p>По вашему <a href='<%: Html.Action("Resume","Vacancy",new {Id = Model.ResumeId})%>'>резюме</a> получено предложение:
<%if (Model.Sender != null)
  {%>
        
<%} %> 
</p>
<p>
    <%= Model.Message%>
</p>

</asp:Content>
