<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Company.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.CompanyViewModel>" %>
<%@ Import Namespace="smolensk.Extensions" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Title1" runat="server" ContentPlaceHolderID="Title">
    <%= Model.Title %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSScripts" runat="server">
    
    <script type="text/javascript" src="/content/js/fancybox/jquery.easing-1.3.pack.js"></script>
    <script type="text/javascript" src="/content/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/content/css/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    
    <script type="text/javascript">

        $(document).ready(function () {
            $("a[rel=fancyPhoto]").fancybox({
                'transitionIn': 'none',
                'transitionOut': 'none',
                'titlePosition': 'over',
                'titleFormat': function (title, currentArray, currentIndex, currentOpts) {
                    return '<span id="fancybox-title-over">Фотография ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
                }
            });

            $('.companyOne .button.mail').click(function () {
                $('.overlayBlock').show();
                $('#company_write_mail_form #companyId').val(<%:Model.Id %>);
                $('#company_write_mail_form').show();
            });
        });
        
	
    </script>

</asp:Content>

<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="popUpLayer">
    <% Html.RenderPartial("WriteMailForm"); %>
</asp:Content>

<asp:Content ID="alphabet" runat="server" ContentPlaceHolderID="AlphabetContent">
    <% Html.RenderPartial("Alphabet", Model.Alphabet); %>
    <a name="menuTop"></a>
</asp:Content>

<asp:Content ID="topCompanies" runat="server" ContentPlaceHolderID="TopCompanies">
    <% Html.RenderPartial("TopCompanies", Model.TopCompanies); %>
</asp:Content>


<asp:Content runat="server" ID="categoriesMenuBlock" ContentPlaceHolderID="CategoriesMenu">
    <% Html.RenderAction("CategoriesMenu", "Companies", new
                                                          {
                                                              categoryBaseId = Model.Category != null && Model.Category.Parent != null ? (long?)Model.Category.Parent.Id : null,
                                                              selectedId = Model.Category == null ? null : (long?)Model.Category.Id
                                                          }); %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Company" runat="server">
    <div class="blockLine">
        <%: Html.MvcSiteMap().SiteMapPath() %>  
    </div>
    <div class="companyOne">
        <div class="infoBlock">
            
            <h2><%= HttpUtility.HtmlDecode(Model.Title) %></h2>
            <div class="buttonPanel">
                <% if (SecurityService.IsAuthorize && !string.IsNullOrEmpty(Model.Email)) { %>
                   <span class="button mail"><span></span>Написать письмо</span>
                <% } %>
                <%--<span class="button print"><span></span>Печать страницы</span>--%>
                <%Html.RenderPartial("ButtonFavorite", Model.Favorite); %>
            </div>
                                
            <img src="<%: Model.LogoUrl %>" style="height: auto" width="140" alt="" /> 
            <table>
                <tr>
                    <td><i>Название:</i></td>
                    <td><%= HttpUtility.HtmlDecode(Model.Title)%></td>
                </tr>
                <tr>
                    <td><i>Рейтинг компании:</i></td>
                    <td>
                        <span class="info">
                            <% Html.RenderPartial("Widgets/Rating", Model.Marks); %>
                        </span>
                    </td>
                </tr>
                <% if (!string.IsNullOrEmpty(Model.WorkTime)) { %>
                <tr>
                    <td><i>График работы:</i></td>
                    <td><%= Model.WorkTime %></td>
                </tr>
                <% } %>

                <tr>
                    <td><i>Контакты:</i></td>
                    <td>
                        <% if (!string.IsNullOrEmpty(Model.Address)) { %>
                        <p><%= Model.Address %></p>
                        <% } %>
                        <p>
                            <% if (!string.IsNullOrEmpty(Model.Www)) { %>
                            <a href="<%: Model.Www %>" title="<%: Model.Www %>" class="site"><%: Model.Www %></a>
                            <% } %>
                            <% if (!string.IsNullOrEmpty(Model.Email)) { %>
                            <a href="mailto:<%: Model.Email %>" title="<%: Model.Email %>" class="mail"><%: Model.Email %></a>
                            <% } %>
                        </p>
                        <% if (!string.IsNullOrEmpty(Model.Phones)) { %>
                        <p class="phone"><b><%: Model.Phones %></b></p>
                        <% } %>
                    </td>
                </tr>

                <% if (!string.IsNullOrEmpty(Model.Leader)) { %>
                <tr>
                    <td>Руководитель:</td>
                    <td><%= Model.Leader %></td>
                </tr>
                <% } %>
                <% if (Model.KindsOfActivities.Count > 0) { %>
                <tr>
                    <td>Вид деятельности:</td>
                    <td> <%= Model.KindsOfActivities.EnumerateToString() %> </td>
                </tr>
                <% } %>
                <% if (!string.IsNullOrEmpty(Model.Description)) { %>
                <tr>
                    <td>Описание компании:</td>
                    <td><%= HttpUtility.HtmlDecode(Model.Description) %></td>
                </tr>
                <% } %>
                <tr>
                    <td>Дата публикации:</td>
                    <td><%: Model.PublishDateStr %></td>
                </tr>
            </table>
        </div>
        <% if (Model.Files.Any()) { %>
        <div class="materialBlock">
            <h3>Скачать материалы</h3>
            <ul>
                <% foreach (FileElement file in Model.Files)
                   {
                       string title = string.Format("Скачать {0}", file.Title);
                %>
  <li><a href="<%: file.Url %>" title="<%: title %>"><%: title %></a> (<%: file.Size.ToFileSize() %>)</li>
                   <% } %>
            </ul>
        </div>
        <% } %>
        <% if (Model.Photos.Any()) { %>
        <div class="photoCompanyBlock">
            <h3>Фотографии</h3>
            <div class="photoList">
                <div class="blockLine">
                    <%
                        var limiter = 0;
                        foreach (RelatedPhoto photo in Model.Photos)
                        {
                            if (limiter > 3)
                            {
                                limiter = 0;
                    %></div><div class="blockLine"><%
                            } %>
                      <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td><a rel="fancyPhoto" href="<%: photo.Link %>" title="<%: photo.Title %>"><img src="<%: photo.PhotoUrl %>" width="138" height="96" alt="<%: photo.Title %>" /></a></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                       <% ++limiter;
                        } %>
                </div>  
            </div>
        </div>
                            <% } %>
        <div class="mapBlock">
            <h3>Офисы компании</h3>
            <% Html.RenderPartial("Widgets/YandexMap", new List<meridian.smolensk.proto.IGeoLocation> { Model.GeoLocation }); %>
        </div>
    </div>

    <% Html.RenderPartial("CommentsList", Model.Comments); %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BreadCrumbsContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CompanyBottom" runat="server">
    <div class="most_discussed">
        <div class="waveEdge"></div>
    </div>
</asp:Content>
