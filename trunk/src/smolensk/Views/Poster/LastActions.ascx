<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ActionCategoryViewModel>>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%if (Model.Count() > 0) { %>
<div class="moreList">
    <% int i = 0;
       int length = 3; 
       foreach (var category in Model)
       {
           bool isStartLine = i % length == 0;
           bool isEndLine = i % length == length - 1 || i == Model.Count() - 1;
           i++;
           if (isStartLine) { %>
           <div class="blockLine">
           <%}%>
            
            <dl>
                <dt><a href="<%: Url.Action("Category","Poster", new { id = category.Id }) %>" title="<%=category.Title%>"><%=category.Title%></a></dt>
                <dd>
                    <ul>
                    <% foreach (var item in category.LastActions){ %>
                        <li><a href="<%: item.GetUri() %>" title="<%=item.Title%>"><%=item.Title%></a> <%=item.GenresList%></li>
                    <%} %>
                    </ul>
                </dd>
            </dl>     
           <%if (isEndLine) { %>
           </div>
           <%}%>       
   <%} %>
</div>
<%} %>
