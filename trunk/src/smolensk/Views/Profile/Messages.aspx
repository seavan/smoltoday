<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.Profile.MessagesList>" %>
<%@ Import Namespace="smolensk.Models.ViewModels.Blogs" %>
<%@ Import Namespace="smolensk.common" %>
<%@ Import Namespace="smolensk.Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">

    <div class="profileHeader">
        <h3>Сообщения</h3>

        <div class="profileTools">
            <form action="<%: Url.Action("Messages") %>" class="submitOnChange" method="post">
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
                   <%-- <input type="hidden" value="<%: Model.CurrentPage %>" name="page" />--%>
                </div>
            </form>
        </div>

    </div>
                        
    <div class="profileBody">
        <% foreach (var message in Model.Messages){%>
        <div class="oneMessage">
            <p><a href="<%: message.link %>" title="<%= message.link_name %>" class="type"><%= message.link_name %></a> <span class="date"><%: Formatter.FormatLongDateTimeWithHyphen(message.create_date)%></span></p>
            <p class="title"><%= HttpUtility.HtmlDecode(message.title)%></p>
            <p class="descr"><%= HttpUtility.HtmlDecode(message.text)%></p>
        </div>
        <%} %>
    </div>
                        
                        
    <div class="blockLine">
	<%: Html.Pager(Model.CurrentPage, Model.TotalPages, "ProfileMessages", new { sortDirection = Model.sortDirection }, "page")%>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
