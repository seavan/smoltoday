<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.blogs>>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>

<%if(Model != null && Model.Count() > 0) {%>

    <div class="blogsBestList">
		<h3>Блог<%: Model.Count() == 1 ? "" : "и"%> месяца</h3>
                            
        <% foreach (var blog in Model){%>
           <dl class="blogsAdvt">
            <dt>
                <a href="<%: blog.GetAuthorUri() %>" title="<%: blog.UserName() %>"><img src="<%: blog.GetUser().AvatarUrlSmall %>" width="75" alt="<%: blog.UserName() %>" /><%: blog.UserName() %></a>
            </dt>
            <dd>
                <span class="blogAdvt">
                    <span class="date"><%: blog.PublishDate()%></span>
                    <span class="name"><a href="<%: blog.ItemUri() %>" title="<%= blog.title %>"><%= blog.title %></a></span>
                    <span class="descr"><%= blog.BestAnnounce() %></span>
                </span>
                                    
                <ul class="info">
                    <li>
                        <span class="descr">Рейтинг</span>
                        <% Html.RenderPartial("Widgets/Rating", blog); %>
                    </li>
                    <li><span class="descr">Комментарии</span><span class="comments no"><%: blog.comment_count%></span></li>
                    <li><span class="descr">Оценок</span><%: blog.GetCountMarks() %></li>
                    
                    <li><span class="tag"><a href="<%: blog.GetCategoryUri() %>" title="<%: blog.CategoryName() %>"><%: blog.CategoryName() %></a></span></li>
                </ul>
            </dd>
        </dl>
        <% } %>
    </div>
<%} %>