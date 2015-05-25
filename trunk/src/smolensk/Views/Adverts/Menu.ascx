<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<meridian.smolensk.proto.ad_categories>>" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%
    string action = ViewContext.ParentActionViewContext.RouteData.Values["action"].ToString().ToLower();
    
    int id = ViewContext.ParentActionViewContext.RouteData.Values["id"] != null
                        ? Convert.ToInt32(ViewContext.ParentActionViewContext.RouteData.Values["id"])
                        : 0;
    long parentId = id; 
                    
    if (action == "one" && id > 0)
    {
        var ad = Meridian.Default.ad_advertismentsStore.Get(id);
        parentId = ad.GetAdvertismentsAd_categorie().parent_id > 0 ? ad.GetAdvertismentsAd_categorie().parent_id : ad.category_id;
    }
%>
<% Html.RenderAction("SubMenu", "Adverts", new { action, id }); %>

<ul class="advertMenu">
    <%foreach (var category in Model) { 
          string curClass = parentId == category.id || category.HasSubcategory(id)? "class=\"cur\"" : string.Empty; %>
    <li <%= curClass %>><a href="<%: Url.Action("Category","Adverts", new { category.id }) %>"
        title="<%= category.title %>">
        <%= category.title %></a> (<%= category.AdsCount %>) </li>
    <%} %>
</ul>
