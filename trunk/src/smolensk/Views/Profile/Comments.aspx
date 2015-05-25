<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Profile.CommentsList>" %>
<%@ Import Namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Комментарии и отзывы</h3>

        <div class="profileTools">
            <form action="<%: Url.Action("Comments") %>" class="submitOnChange" method="post">
                <div class="formLine">
                    <select>
                        <%if (Model.sortDirection == SortingDirection.Desc){%>
                        <option value="<%: SortingDirection.Desc %>" >Сначала новые</option>
                        <option value="<%:SortingDirection.Asc %>" >Сначала старые</option>         
                        <%} else{%>
                        <option value="<%:SortingDirection.Asc %>" >Сначала старые</option>         
                        <option value="<%: SortingDirection.Desc %>" >Сначала новые</option>
                        <%} %>
                    </select>
                    <input type="hidden" value="<%: Model.sortDirection %>" name="sortDirection" />
                    <%--<input type="hidden" value="<%: Model.CurrentPage %>" name="page" />--%>
                </div>
            </form>
        </div>

    </div>
                        
    <div class="profileBody">
        <%if (Model.Comments != null && Model.Comments.Count() > 0) {%>
        <table class="prfTable">
            <tr>
                <th>Категория</th>
                <th>Дата</th>
                <th>Сообщение</th>
            </tr>
            <% foreach (var comment in Model.Comments) {%>
            <tr>
                <td><%: comment.CommentMaterialType() %></td>
                <td class="date"><%: Formatter.FormatLongDateTimeWithHyphen(comment.CreateDate)%></td>
                <td><a href="<%: comment.Link %>" title=""  class="type"><%= HttpUtility.HtmlDecode(comment.CommentText)%></a></td>
            </tr>
            <%} %>
        </table>
        <%} %>

    </div>
                        
                        
    <div class="blockLine">
	<%: Html.Pager(Model.CurrentPage, Model.TotalPages, "ProfileComments", new { sortDirection = Model.sortDirection }, "page")%>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
