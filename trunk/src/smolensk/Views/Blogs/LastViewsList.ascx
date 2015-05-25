<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.blogs>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<%if(Request.IsAuthenticated && Model != null && Model.Count() > 0){%>
<dl class="blogs">
	<dt>Последние просмотренные</dt>
    <%foreach(var blog in Model){%>
    <dd>
		<a href="<%: blog.ItemUri() %>" title="<%= blog.title %>"><%= blog.title %></a>
		<i><%= blog.UserName() %><%= string.IsNullOrEmpty(blog.UserCareer()) ? "" : ", " + blog.UserCareer()%></i>
	</dd>
    <%} %>
</dl>
<%} %>