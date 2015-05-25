<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<meridian.smolensk.proto.photobank_categories>>" %>
<ul class="newsMenu">
    <%
        string action = ViewContext.ParentActionViewContext.RouteData.Values["action"].ToString().ToLower();
        int id = ViewContext.ParentActionViewContext.RouteData.Values["id"] != null
                            ? Convert.ToInt32(ViewContext.ParentActionViewContext.RouteData.Values["id"])
                            : 0;
        if (action == "image" && ViewBag.CategotyId != null)
            id = ViewBag.CategotyId;
        foreach (var category in Model) {
            string curClass = (action == "category" || action == "image") && id == category.id 
                ? "class=\"cur\"" 
                : string.Empty;
    %>
        <li <%= curClass %>>
            <a href="<%: Url.Action("Category","PhotoBank", new { id = category.id }) %>" title="<%= category.title %>"><%= category.title %></a>
        </li>
    <%} %>
</ul>
