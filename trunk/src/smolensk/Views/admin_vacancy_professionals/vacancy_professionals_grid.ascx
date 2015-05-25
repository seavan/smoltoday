<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.vacancy_professionals>>" %>

<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%

    Html.Telerik().Grid<meridian.smolensk.proto.vacancy_professionals>()
        .Name("t_meridian.smolenskList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", "admin_vacancy_professionals") 
        .Delete("_Delete", "admin_vacancy_professionals")
        .Update("_Update", "admin_vacancy_professionals")
        .Insert("_Insert", "admin_vacancy_professionals") 
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
                    c.Bound(col => col.title).ClientTemplate("<# if(lookup_value_level > 0) { #><div style='padding-left:30px;'><#= title #></div><# } else {#><#= title #><# } #>");
                    
 

                    c.Bound(col => col.id).Edit("admin_vacancy_professionals").Width(100);
                    c.Command(cmd =>
                                  {
                                      cmd.Delete();
                                  }
                        ).Width(100);
                }
        )

        .Resizable( rs => rs.Columns(true))
        .Filterable()
        .Scrollable(scr => scr.Enabled(false))
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


