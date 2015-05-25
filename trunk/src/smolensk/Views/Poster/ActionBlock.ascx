<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ActionViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<dl>
    <dt>								
        <% if (!string.IsNullOrEmpty(Model.ThumbnailUrl)){%>
        <a href="<%: Model.GetUri() %>" title="<%=Model.Title %>">
            <img src="<%=Model.ThumbnailUrl %>" width="200"  alt="1" />                                           
        </a>
        <%} %>
        <span class="info">
            <span class="descr"><%= Model.Category.Title%></span>
            <% Html.RenderPartial("Widgets/Rating", Model.Marks); %>
        </span>								
    </dt>
    <dd>
        <a href="<%: Model.GetUri() %>" title="<%=Model.Title %>"><%=Model.Title %></a>
                                        
        <%=Model.Announce%>
                                        
        <span class="info">                                            						  
            <span class="comments"><%=Model.Comments.GetComments().Count() %> отзывов</span>
        </span>
    </dd>
</dl>