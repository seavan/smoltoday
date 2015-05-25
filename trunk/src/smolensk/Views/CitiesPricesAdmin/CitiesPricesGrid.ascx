<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.city_prices>>" %>
<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.city_prices>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "CitiesPricesAdmin") 
        .Update("_Update", "CitiesPricesAdmin")
        .Insert("_Insert", "CitiesPricesAdmin")        
        .Delete("_Delete", "CitiesPricesAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
                    c.Bound(col => col.title).Display();
                    c.Bound(col => col.title);
                    c.Bound(col => col.value);
                    c.Bound(col => col.url_icon);
                    c.Bound(col => col.url_showall);

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
            .OnEdit("gridEdit").OnSave("gridSave").OnRowDataBound("bindRow")
            )
        .Render();
%>
</div>
