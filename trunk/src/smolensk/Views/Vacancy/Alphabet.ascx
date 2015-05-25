<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AlphabetViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>

<div class="whiteBorderGrayBlock alphabetSearch">
            <div>
            <% foreach (string letter in AlphabetViewModel.RusAlphabet)
               { %>
               <% if (letter.ToLower() != Model.Letter)
                  {%>
                    <a href="<%= Model.RouteUrl(Url, letter) %>" title="<%: letter %>"><%: letter %></a>
               <% }
                  else
                  {%>
                  <span><%: letter %></span>
               <% } %>
            <% } %>
            </div>
            <div>
            <% foreach (string letter in AlphabetViewModel.EngAlphabet)
               { %>
               <% if (letter.ToLower() != Model.Letter)
                  {%>
                    <a href="<%= Model.RouteUrl(Url, letter) %>" title="<%: letter %>"><%: letter %></a>
               <% }
                  else
                  {%>
                  <span><%: letter %></span>
               <% } %>
            <% } %>
                &nbsp;&nbsp;&nbsp;
               <% if (string.IsNullOrEmpty(Model.Letter) || !char.IsNumber(Model.Letter[0]))
                  {%>
                    <a href="<%= Model.RouteUrl(Url, "0") %>" title="0-9">0-9</a>
               <% }
                  else
                  {%>
                  <span>0-9</span>
               <% } %>
            </div>
        </div>