<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.company_kind_activities>>" %>

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
    Html.Telerik().Grid<meridian.smolensk.proto.company_kind_activities>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
		.Select("_Select", "CompaniesActivityAdmin")
		.Update("_Update", "CompaniesActivityAdmin")
		.Insert("_Insert", "CompaniesActivityAdmin")
		.Delete("_Delete", "CompaniesActivityAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(c =>
            {
				c.Bound(col => col.id).Width(60).Id();
                c.Bound(col => col.name).ClientTemplate("<# if(lookup_value_level > 0) { #>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<# } #><#= name #>");
                c.Command(cmd =>
                {
                    cmd.Edit();
                }).Width(100);
                c.Command(cmd =>
                {
                    cmd.Delete();
                }).Width(100);
            }
        )
        .ToolBar(tb => tb.Insert())
        .Resizable( rs => rs.Columns(true))
        //.Sortable( rs => rs.Enabled(true))
        .Editable(s => s.Mode(GridEditMode.PopUp))
        .Filterable()
        .Scrollable( scr => scr.Enabled(false) )
        .Pageable(pager => pager.Enabled(false)
        )
        .ClientEvents(
        s =>
            s.OnDataBound("updateGrids")
            .OnEdit("gridEdit").OnRowDataBound("bindRow").OnSave("customCCGsaveStart").OnComplete("customCCGsaveFinish")
            )
        .Render();
%>
</div>
