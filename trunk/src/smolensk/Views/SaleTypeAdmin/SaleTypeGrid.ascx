<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.sale_types>>" %>




<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.sale_types>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "SaleTypeAdmin")
        .Update("_Update", "SaleTypeAdmin")
        .Insert("_Insert", "SaleTypeAdmin") 
        .Delete("_Delete", "SaleTypeAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();

                    c.Bound(col => col.title);
                    //c.Bound(col => col.order_id);

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
        .Resizable( rs => rs.Columns(true))
        //.Sortable( rs => rs.Enabled(true))
        .Editable(s => s.Mode(GridEditMode.PopUp))
        .Filterable()
        .Scrollable( scr => scr.Enabled(false) )
        .Pageable(
            pager => pager.Enabled(false)
        )
        /*.ClientEvents(
        s =>
            s.OnDataBound("updateGrids")
            .OnEdit("gridEdit").OnRowDataBound("bindRow")
            ) */
        .Render();
%>
</div>
