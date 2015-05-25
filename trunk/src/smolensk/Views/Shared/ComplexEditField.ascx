<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    var prop = ViewData["prop"] as ModelMetadata;
    var propname = ViewData["propname"] != null ? (string)ViewData["propname"] : "";
    if( prop == null )
    {
        prop = ViewData.ModelMetadata.Properties.Single(s => s.PropertyName.Equals(propname));
    }
    var optional = ViewData["optional"] != null ? (bool) ViewData["optional"] : false;
     %>
<div class="display-field _field <%= optional ? "_optional" : "" %>">
    <%
        var av = prop.AdditionalValues.FirstOrDefault(s => s.Key == "Link").Value as admin.common.LinkAttribute;

        object key = null;
        if (av != null)
        {
            switch (av.LinkType)
            {
                case admin.common.LinkType.ltOneToOne:
                    break;
                case admin.common.LinkType.ltChild:
                    var dict = new ViewDataDictionary();
                    var ide = Model as admin.db.IDatabaseEntity;
                    bool newItem = true;
                    if (ide != null)
                    {
                        av.Param = ide;
                        ViewData["ParentId"] = ide.id;
                        if (ide.id > 0)
                        {
                            newItem = false;
                        }
                    }
                    dict["Link"] = av;
    %>
    <%= newItem ? MvcHtmlString.Create("сохраните объект перед редактированием этого поля") : Html.Editor(prop.PropertyName, av.Template, new { Link = av })%>
    <%
break;

                                case admin.common.LinkType.ltOneToMany:
key =
    ViewData.ModelMetadata.Properties.Single(ww => ww.PropertyName == av.ThisKeyName);
    %>
    <div class="_expanderCont">
        <span class="_apply">Применить</span> <span class="_expander">Изменить</span> <span class="_deleteLink">Удалить</span>
    </div>
    <span style="display: block; margin-bottom: 5px" class="_thisDisplay"><span class="_disabled">
        <%= Html.Editor(prop.PropertyName) %></span> </span><span class="_foreign"></span>
    <input type="hidden" name="<%= av.ThisKeyName %>" class="_thisKey" value="<%= Html.Display(av.ThisKeyName) %>" />
    <span class="_controller" style="display: none">/<%= av.Controller %>/<%= av.Template %></span>
    <%/* Html.Editor(prop.PropertyName, av.Template + "Display",  
                                        new { Link = av, Key = 
                                                          ViewData.ModelMetadata.Properties.Single(ww => ww.PropertyName == av.ThisKeyName).Model }) */ %>
    <%
break;
                            }
                        }
                        else
                        {

                            {
    %>
    <%=!prop.IsReadOnly && prop.ShowForEdit
                                                      ? Html.Editor(prop.PropertyName)
                                                      : null%>
    <span class="_disabled">
        <%=prop.IsReadOnly && prop.ShowForDisplay
                                                      ? Html.Editor(prop.PropertyName)
                                                      : null%></span>
    <%
                            }
                        }%>
</div>
