<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%
    var fname = ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty);
     %>

<div style="float: right">

    <% if (String.IsNullOrEmpty(Model))
       {%>
    файл отсутствует
    <%
   }
       else
       {
    %>
    <a href="/Content/temp/<%= Model %>" alt style="border: 1px solid black"><%= Model %></a>
    <input type="hidden" name="<%= fname %>" value="<%= Model %>" />
    <%
   }%>
</div>
<div>
    <span>Загрузить файл: </span>
    <%= Html.Telerik().Upload()
    .Name(fname)
    .Multiple(false)


     %>
</div>
<div><a class="_link _removeImage" rel="<%= fname %>">удалить файл</a></div>
