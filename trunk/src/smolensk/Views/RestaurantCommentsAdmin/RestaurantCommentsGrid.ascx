<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.restaurant_comments>>" %>
<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.restaurant_comments>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "RestaurantCommentsAdmin") 
        .Update("_Update", "RestaurantCommentsAdmin")
        .Insert("_Insert", "RestaurantCommentsAdmin")        
        .Delete("_Delete", "RestaurantCommentsAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
                    c.Bound(col => col.RestaurantTitle);
                    c.Bound(col => col.AuthorName);
                    c.Bound(col => col.text);
                    

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
        //.ToolBar(tb => tb.Insert())
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
