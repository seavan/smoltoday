<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.FilterAdsViewModel>" %>
<%@ Import Namespace="smolensk.common" %>
<% Html.BeginForm("Category", "Adverts",new { id = Model.CategoryId }, FormMethod.Get); %>
    <% if (Model.Types.Any())
       { %>
       <div class="selectorType">
            <ul>
            <% foreach (var type in Model.Types)
               { %>
               <li>
                    <% if (type.Id == Model.Type)
                       { %>
                       <span class="radio" style="background-position: 0px -50px;">
                        <input type="radio" name="type" value="<%= type.Id %>" checked="checked">
                       </span>
                    <% }
                       else
                       { %>
                       <span class="radio" style="background-position: 0px 0px;">
                        <input type="radio" name="type" value="<%= type.Id %>">
                       </span>
                    <% } %>
                   
                   <%= type.Type %> <span>(<%= type.AdsCount %>)</span>
               </li>
            <% } %>
            </ul>
        </div>
    <% } %>
    

    <div class="sortingTools">
        <ul>
        <li class="name">Сортировка:</li>
        <li>
            <a href="javascript:void(0);" title="По дате" class="sort-type <%= Model.Sort == "date" ? "cur" : string.Empty %>" data-type="date">
            <span>По дате</span>
            </a>
        </li>
        <li>
            <a href="javascript:void(0);" title="Сначала дешевые" class="sort-type <%= Model.Sort == "asc" ? "cur" : string.Empty %>" data-type="asc">
            <span>Сначала дешевые</span>
            </a>
        </li>
        <li>
            <a href="javascript:void(0);" title="Сначала дорогие" class="sort-type <%= Model.Sort == "desc" ? "cur" : string.Empty %>" data-type="desc">
            <span>Сначала дорогие</span>
            </a>
        </li>
        </ul>
        <%: Html.HiddenFor(m => m.Sort) %>
        
        <div class="selectorCount">
            <form action="#">
            <label for="selector_count">
                Выводить по</label>
            <select id="selector_count" name="pageSize">
                <%
                    int pageSize = Request.QueryString["pageSize"] != null
                                        ? Convert.ToInt32(Request.QueryString["pageSize"])
                                        : Constants.AdvertsPageSize;
                            
                    foreach (int count in Constants.PageSizes)
                    {
                        string selected = count == pageSize ? "selected" : string.Empty;
                        %>
                        <option value="<%= count %>" <%= selected %>><%= count %></option>
                <% } %>
            </select>
            </form>
        </div>
    </div>
<% Html.EndForm(); %>

<script type="text/javascript">
    $(function () {
        $(".radio").on("click", function () {
            $(this).closest("form").submit();
        });

        $(".sort-type").on("click", function () {
            var $this = $(this);
            $("#Sort").val($this.data("type"));
            $this.closest("form").submit();
        });

        $("#selector_count").on("change", function () {
            $(this).closest("form").submit();
        });
    });
</script>