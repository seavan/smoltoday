<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.company_categories>>" %>


<script>

    var CCGEdit = false;

    function customCCGsaveFinish() {
        if (CCGEdit == false) return;
//        alert(1);
        CCGEdit = false;
        var grid = $('#t_EntryList').data('tGrid');
        grid.rebind();
        
    }

    function customCCGsaveStart() {
        CCGEdit = true;
    }

</script>


<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.company_categories>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "CompaniesCategoriesAdmin")
        .Update("_Update", "CompaniesCategoriesAdmin")
        .Insert("_Insert", "CompaniesCategoriesAdmin") 
        .Delete("_Delete", "CompaniesCategoriesAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    //c.Bound(col => col.id).Width(80).Id();
                    c.Bound(col => col.name).ClientTemplate("<# if(lookup_value_level > 0) { #>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<# } #><#= name #>");

//                    c.Bound(col => col.title);
//                    c.Bound(col => col.key);
//                    c.Bound(col => col.order_id);

                    
 
                    //c.Bound(col => col.hideDelete).ClientTemplate("<# if(hideDelete) { #>Да<# } else {#>Нет<# } #>").Width(40);
                    //c.Bound(col => col.show_on_main).ClientTemplate("<# if(show_on_main) { #>Да<# } else {#>Нет<# } #>").Width(40);
                    //c.Bound(col => col.text).Width(120);
                    // c.Template(s => Html.("Просмотреть", "OneBlog", "Blogs", "http", "zakon.ru", "", new { id = s.id }, null)).Width(120);
                    // c.Bound(col => col.id).Edit("CompaniesCategoriesAdmin").Width(100);
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
            .OnEdit("gridEdit").OnRowDataBound("bindRow").OnSave("customCCGsaveStart").OnComplete("customCCGsaveFinish")
            )
        .Render();
%>
</div>
