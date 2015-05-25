<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.actions_comments>>" %>
<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.actions_comments>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "PosterCommentsAdmin") 
        .Update("_Update", "PosterCommentsAdmin")
        .Insert("_Insert", "PosterCommentsAdmin")        
        .Delete("_Delete", "PosterCommentsAdmin")
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
                    //c.Bound(col => col.PosterTitle);
                    c.Bound(col => col.AuthorName);
                    c.Bound(col => col.text);
                    

                    //c.Command(cmd =>
                    //    {
                    //        cmd.Edit();
                    //              }
                    //    ).Width(100);
                    c.Bound(col => col.id).Edit("PosterCommentsAdmin").Width(100);
                    c.Command(cmd =>
                    {
                        cmd.Delete();
                    }
                        ).Width(100);
                    
                }
        )
        //.ToolBar(tb => tb.Insert())
        //.Editable( s => s.Mode(GridEditMode.PopUp))
        .Resizable( rs => rs.Columns(true))
        .Sortable( st => st.OrderBy( so => so.Add(e => e.create_date).Descending()).Enabled(true))
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
