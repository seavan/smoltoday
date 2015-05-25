<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<smolensk.Controllers.SalesAdminController.CompanyImport>>"
    MasterPageFile="~/Views/Master/AdminSales.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form name="form1" action="?" method="POST">
    <% if (Model != null)
       {
           %>
           <ul>
               <%
                   var cats = Model.Select(s => s.Section).Distinct().OrderBy(s => s).ToArray();
                   foreach (var c in cats)
                   {
                       %>
                       <li><%= c %></li>
                       <%
                   }
                %>
           </ul>
               <%
           
         %>
        <div style="background: silver">
            <input type="hidden" name="add" value="1"/>
            <% foreach (var item in Model)
               {
                   %>
                   <h2><%= item.Section %></h2>
                   <h3><%= item.SubSection %></h3>

                   <h2><%= item.Name %></h2>
                   <p><%= item.Description %><br/>
                   <%= item.Address %><br/>
                   <%= item.Phone %><br/>
                   <%= item.Hours %><br/>
                   <%= item.Url %><br/>
                   <%= item.Email %></p>
                   <p>скидка <%= item.Discount %></p>
                   <%
               } %>

        </div>         
         <%  
       }
       %>

    <textarea name="text" rows="60" cols="80"></textarea>
    <input type="submit" />
    </form>
</asp:Content>
