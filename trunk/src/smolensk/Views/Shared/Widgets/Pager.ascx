<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% int pageTotal = Model.GetType().GetProperty("pageTotal").GetValue(Model, null); 
   if(pageTotal>1){%>

<div class="blockLine">
    <div class="pager">
 <% 
    int currentPage = Model.GetType().GetProperty("pageN").GetValue(Model, null);
    var prop = Model.GetType().GetProperty("anchor");
    string anchor = prop == null ? "" : prop.GetValue(Model, null);
    int arountLength = 2;
    int endingLength = 3;

    NameValueCollection queryCollection = HttpUtility.ParseQueryString(Request.Url.Query);
    queryCollection.Remove("page");

    string query = queryCollection.Count > 0
        ? "?" + queryCollection + "&page="
        : "?page=";
    
    int i;
    for (i = 1; i <= Math.Min(endingLength, pageTotal); i++)
    {
         %> <a class="button<% if (i == currentPage) { %> cur<% } %>" href="<%= query %><%= i %><%:anchor%>" title="<%= i %>"><%= i %></a> <%
    }
    if (currentPage > endingLength + arountLength + 1)
    {
        %> <a class="button">...</a> <%
        for (i = currentPage - arountLength; i <= Math.Min(currentPage + arountLength, pageTotal); i++)
        {
             %> <a class="button<% if (i == currentPage) { %> cur<% } %>" href="<%= query %><%= i %><%:anchor%>" title="<%= i %>"><%= i %></a> <%
        }
    }
    else
    {
        for (; i <= Math.Min(currentPage + arountLength, pageTotal); i++)
        {
             %> <a class="button<% if (i == currentPage) { %> cur<% } %>" href="<%= query %><%= i %><%:anchor%>" title="<%= i %>"><%= i %></a> <%
        }
    }
    if (currentPage < pageTotal - endingLength - arountLength - 1)
    {
        %> <a class="button">...</a> <%
        for (i = pageTotal - endingLength + 1; i <= pageTotal; i++)
        {
             %> <a class="button<% if (i == currentPage) { %> cur<% } %>" href="<%= query %><%= i %><%:anchor%>" title="<%= i %>"><%= i %></a> <%
        }
    }
    else
    {
        for (; i <= pageTotal; i++)
        {
            %> <a class="button<% if (i == currentPage) { %> cur<% } %>" href="<%= query %><%= i %><%:anchor%>" title="<%= i %>"><%= i%></a> <%
        }
    } %>
    </div>
</div> 

<%}%>