<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.IDescriptable>" %>

        <p id="desc">
            <span id="short"><%= Model.GetShortDescription() %></span>            
            <% if (Model.GetShortDescriptionLength() != Model.Description.Length)
               {%>
                <span id="full" style="display:none;"><%= Model.Description %></span> 
                <a href="javascript:showFullDescription()" title="Читать полностью" class="more">Читать полностью</a>
            <% } %>
        </p>