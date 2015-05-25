<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<InformerViewModel>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<div class="metrics">
<%--    <div class="metric t">
        <p>Пробки</p>
        <span class="typeMetric"><%= Model.JamsDegree %></span>
        <span class="infoMetric">
            <span>баллов</span>
            <small><%= Model.JamsDescription %></small>
        </span>
    </div>--%>
    <div class="metric d">
        <p>Валюта</p>
        <span class="typeMetric"></span>
        <span class="infoMetric">
            <span><b><%= Formatter.FormatPrice(Model.DollarPrice) %></b></span>
            <small><%= Formatter.FormatChange(Model.DollarChange) %></small>
        </span>
    </div>
    <div class="metric e">
        <p>&nbsp;</p>
        <span class="typeMetric"></span>
        <span class="infoMetric">
            <span><b><%= Formatter.FormatPrice(Model.EuroPrice) %></b></span>
            <small><%= Formatter.FormatChange(Model.EuroChange) %></small>
        </span>
    </div>
</div>