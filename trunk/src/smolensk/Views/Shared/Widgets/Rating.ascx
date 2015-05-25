<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IMarkable>" %>

<% int rating = Model.GetRating(); %>

<span class="rating<%: Request.IsAuthenticated ? " isAuth" : "" %>" data-proto="<%: Model.ProtoName %>" data-id="<%: Model.id %>">
    <%for (int i = 1; i <= 5; i++)
      {
          string star = rating >= i ? "class=\"cur\"" : string.Empty; %>
    <span <%= star %>><%= i %></span>
    <% } %>
</span>