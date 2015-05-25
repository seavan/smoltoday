<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.accounts>>" %>
<div style="padding-top: 30px; margin-top: 10px;  border-top: 1px dotted silver;" >
<%
    string controllerPrefix = "AccountsAdmin";
    
    Html.Telerik().Grid<meridian.smolensk.proto.accounts>()
        .Name("t_EntryList")
        .DataBinding(dataBinding => dataBinding.Ajax()
        .Select("_Select", controllerPrefix)
        .Delete("_Delete", controllerPrefix)
        )
        .DataKeys(keys => keys.Add("id"))
        .Columns(
            c =>
                {
                    c.Bound(col => col.id).Width(80).Id();
                    c.Bound(col => col.email).Display();
                    c.Bound(col => col.email);
                    c.Bound(col => col.created);
                    c.Bound(col => col.firstname);
                    c.Bound(col => col.lastname);
                    c.Bound(col => col.id).Edit(controllerPrefix).Width(100);
                    c.Command(cmd =>
                                  {
                                      cmd.Delete();
                                  }
                        ).Width(100);
                }
        )

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
