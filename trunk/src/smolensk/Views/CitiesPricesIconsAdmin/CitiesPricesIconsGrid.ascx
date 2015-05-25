﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.city_prices_icons>>" %>
<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.city_prices_icons>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "CitiesPricesIconsAdmin") 
        .Update("_Update", "CitiesPricesIconsAdmin")
        .Insert("_Insert", "CitiesPricesIconsAdmin")        
        .Delete("_Delete", "CitiesPricesIconsAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
                    c.Bound(col => col.title).Display();
                    c.Bound(col => col.title);
                    c.Bound(col => col.css_class);
                    
 
                    //c.Bound(col => col.hideDelete).ClientTemplate("<# if(hideDelete) { #>Да<# } else {#>Нет<# } #>").Width(40);
                    //c.Bound(col => col.show_on_main).ClientTemplate("<# if(show_on_main) { #>Да<# } else {#>Нет<# } #>").Width(40);
                    //c.Bound(col => col.text).Width(120);
                    // c.Template(s => Html.("Просмотреть", "OneBlog", "Blogs", "http", "zakon.ru", "", new { id = s.id }, null)).Width(120);
                    //c.Bound(col => col.id).Edit("CitiesPricesIconsAdmin").Width(100);
                    c.Command(cmd =>
                        {
                            cmd.Edit();
                                  }
                        ).Width(100);
                    c.Command(cmd =>
                    {
                        cmd.Delete();
                    }
                        ).Width(100);
                    
                }
        )
        .ToolBar(tb => tb.Insert())
        .Editable( s => s.Mode(GridEditMode.PopUp))
        .Resizable( rs => rs.Columns(true))
        .Sortable( st => st.OrderBy( so => so.Add(e => e.id).Descending()).Enabled(true))
        .Filterable()
        .Scrollable( scr => scr.Height(453) )
        .Pageable(
            pager => pager.PageSize(10)
        )
        .ClientEvents(
        s =>
            s.OnDataBound("updateGrids")
            .OnEdit("gridEdit").OnRowDataBound("bindRow")
            )
        .Render();
%>
</div>
