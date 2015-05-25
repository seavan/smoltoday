<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.IMainSlider>>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%
    var grouped = Model.GroupBy(e => e.ProtoName).Take(3);
%>
<div class="photoBlock">
    
    <span class="lArrow"><span class="bg"></span><span class="arrow"></span></span>
    <span class="rArrow"><span class="bg"></span><span class="arrow"></span></span>

    <div class="imgContainer">
        
        <% foreach (var group in grouped) {%>

        <div class="lenta<%: grouped.First().Key.Equals(group.Key) ? " cur" : "" %>">
            <% foreach (var slider in group.Select((x,i) => new { Item = x, Index = i }) ) {%>
                <div class="imgBlock">
                    <ul class="dateSelector">
                        <%  for (int i = 0; i < group.Count(); ++i)
                            {
                                bool current = i == slider.Index;
                        %>
                            <li <%= current ? "class=\"cur\"" : "" %>>
                                <span></span>
                                <p><%: Formatter.FormatLongDateTime(group.ElementAt(i).publish_date) %></p>
                            </li>
                        <% } %>
                    </ul>
                    
                    <a href="<%: slider.Item.ItemMainUri %>">
                    <img src="<%: slider.Item.GetImgItemMainUri() %>" width="650" alt="<%: slider.Item.title %>" /></a>

                    <div class="titleNews">
                        <span class="overlay"></span>
                        <a href="<%: slider.Item.ItemMainUri %>" title="<%: slider.Item.title %>"><%: slider.Item.title%></a>
                    </div>
                </div>
            <% } %>
        </div>

        <% } %>

    </div>

    <div class="shadow"></div>

</div>