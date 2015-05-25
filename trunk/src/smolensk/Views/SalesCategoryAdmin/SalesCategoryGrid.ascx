<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.sale_categories>>" %>




<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.sale_categories>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "SalesCategoryAdmin")
        .Update("_Update", "SalesCategoryAdmin")
        .Insert("_Insert", "SalesCategoryAdmin") 
        .Delete("_Delete", "SalesCategoryAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
//                    c.Bound(col => col.name).ClientTemplate("<# if(lookup_value_level > 0) { #>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<# } #><#= name #>");

                    c.Bound(col => col.title);
                    c.Bound(col => col.order_id);

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
        .ClientEvents(
        s =>
            s.OnDataBound("updateGrids")
            .OnEdit("gridEdit").OnRowDataBound("bindRow")
            )
        .Render();
%>
</div>
