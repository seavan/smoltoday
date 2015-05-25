<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.InterestingAdsViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>

<div class="advertOffering">
        <% if (Model.Advertismentses.Any()) { %>
        <h3>Интересные предложения <%= string.IsNullOrEmpty(Model.Category) ? string.Empty : string.Format("в категории {0}", Model.Category) %></h3>
            <%  int row = 0;
                foreach (var ad in Model.Advertismentses)
                { %>
                    <% if (row++ == 0) { %>
                        <div class="blockLine">
                    <% } %>
                    <dl>
                        <dt>
                            <a href="<%: ad.ItemUri() %>" title="<%= ad.title %>">
                                <img src="<%= ad.PhotoUrl %>" width="200" height="130" alt="<%= ad.title %>" />
                                <%= ad.title %>
                            </a>
                        </dt>
                        <dd>
                            <% if (ad.price > 0)
                               { %>
                                <span class="price"><%= Formatter.FormatPrice(ad.price) %></span> руб.
                            <% } %>
                        </dd>
                    </dl>
                    <% if (row == 3) { row = 0; %>
                        </div>
                    <% } %>
            <% } %>
            <%if (row != 0) {%>
                </div>
            <% } %>
        <% } %>
</div>