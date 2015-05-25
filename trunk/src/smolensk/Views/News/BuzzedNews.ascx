<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.ViewModels.NewsListViewModel>" %>
<div class="most_discussed">
    <div class="widthContent">
        <h3>Самые обсуждаемые</h3>
		<div class="blockLine">
            <% foreach (var item in Model.Items)
               {
                   Html.RenderPartial("BuzzedSingleNews", item);
               }
            %>
		</div>
    </div>
    <div class="waveEdge"></div>
</div>
