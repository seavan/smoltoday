<%@ Page Title="Поиск по объявлениям" Language="C#" MasterPageFile="~/Views/Master/Advert.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.AdsListViewModel>" %>
<%@ Import Namespace="smolensk.common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Advert" runat="server">
    <div class="advertList">
        <h3><%= Model.Title %></h3>
        <div id="advert_filter">
            <div class="selectorCount">
            <form action="#">
            <label for="selector_count">
                Выводить по</label>
            <select id="selector_count" name="pageSize">
                <%
                    int pageSize = Request.QueryString["pageSize"] != null
                                        ? Convert.ToInt32(Request.QueryString["pageSize"])
                                        : Constants.PageSize;
                            
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
         
        <% Html.RenderPartial("AdsListPartial", Model); %>
    </div>
    
    
<% string query = Request.QueryString["q"] != null
    ? "?q=" + Request.QueryString["q"] + "&pageSize="
    : "?pageSize=";
%>
<script>
    $(function () {
        $("#selector_count").on("change", function () {
            window.location = "<%= query %>" + $(this).val();
        });
    });
</script>
</asp:Content>