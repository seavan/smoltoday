<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<IComment>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="smolensk.Mappers" %>

<% if (Model.Count > 0 ) { %>
<dl class="freshReview">
	<dt>Свежие отзывы</dt>
    <% foreach (IComment comment in Model)
       {
           string companyTitle = comment.GetCommentTitle();
           %>
	    <dd>
            <a href="/Companies/One/<%: comment.MaterialId %>/<%:companyTitle.TransliterateAndClear() %>" title="<%= companyTitle %>"><%=companyTitle%></a>
            <p><%= comment.CommentText %></p>
        </dd>  
      <% } %>
</dl>
<% } %>