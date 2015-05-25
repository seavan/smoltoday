<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Smolensk.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.ViewModels.RestaurantsListViewModel>" %>

<%@ Import Namespace="smolensk.common" %>
<%@ Import Namespace="smolensk.common.HtmlHelpers" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Scripts" runat="server">
<!-- Begin TODO: Пихать это в общий мастерпейдж или нет?-->
    <!-- Kendo -->
    <script src="/content/js/kendo/kendo.web.min.js" type="text/javascript"></script>
    <script src="/content/js/kendo/kendo.aspnetmvc.min.js" type="text/javascript"></script>
    <script src="/content/js/kendo/cultures/kendo.culture.ru-RU.min.js" type="text/javascript"></script>
    <link href="/Content/css/kendo/kendo.common.min.css" rel="stylesheet"/>
    <link href="/Content/css/kendo/kendo.default.min.css" rel="stylesheet"/>
    <link href="/Content/css/kendo/kendo.rtl.min.css" rel="stylesheet"/>    
    <script type="text/javascript">
        kendo.culture("ru-RU");
    </script>
    
    

    <script type="text/javascript" src="/content/js/restaurants.js"></script>
    <script type="text/javascript">
        $(function () {
            initRestaurants(<%: Model.CurrentPage %>);
            InitReserveTableActions();
            ListRestaurantsInit(<%: Model.Restaurants.Count %>);
        });
    </script>

    <link href="/content/css/restaurants.css" rel="stylesheet" type="text/css" />
    
    <link href="/content/css/jquery.scrollable.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/content/js/jquery.tools.min.js"></script>

</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    
    
    <div class="headerRest">
        <div class="widthContent">
            <% Html.RenderPartial("../Companies/Alphabet", Model.Alphabet); %>
            <%: Html.MvcSiteMap().SiteMapPath() %>
            <h2>Кафе и рестораны Смоленска<%
            if (Model.Alphabet != null && Model.Alphabet.Letter != Constants.AnyLetter)
            {
                %>, названия которых начинаются на "<%= Model.Alphabet.Letter %>"
                <%
            }
             %>
            </h2>
        </div>
        <div class="waveEdge"></div>
    </div>

    <div class="blockPrice rest">
        <div class="waveEdge"></div>
        <div class="widthContent">
            
            <div class="name">Поиск по<br/>параметрам</div>

            <div class="prices">
                <div class="lenta">

                    <div class="price kitchen">
                        <% var selectedKitchens = string.Join(", ", Model.Kitchens.Where(k => k.Selected).Select(e => e.Title)); %>

                        <span class="num">кухня</span>
                        <small><%: selectedKitchens.Length == 0 ? "любая" : selectedKitchens %></small>

                        <div class="paramList">
                            <ul>
                                <li class="_reset">сбросить</li>
                                <% foreach (var pair in Model.Kitchens) { %>
                                <li data-entry-id="<%: pair.Id %>" class="<%: pair.Selected ? "checked" : "" %>"><%: pair.Title %></li>
                                <% } %>
                            </ul>
                            <span class="arrow"></span>
                        </div>
                    </div>
                    
                    <div class="price invoice">
                        <% var selectedAverageCosts = string.Join(", ", Model.AverageCosts.Where(k => k.Selected).Select(e => e.Title)); %>

                        <span class="num">счет</span>
                        <small><%: selectedAverageCosts.Length == 0 ? "любой" : selectedAverageCosts%></small>

                        <div class="paramList">
                            <ul>
                                <li class="_reset">сбросить</li>
                                <% foreach (var pair in Model.AverageCosts) { %>
                                <li data-entry-id="<%: pair.Id %>" class="<%: pair.Selected ? "checked" : "" %>"><%: pair.Title %></li>
                                <% } %>
                            </ul>
                            <span class="arrow"></span>
                        </div>
                    </div>

                    
                    <div class="price sale">
                        <% var selectedDiscounts = string.Join(", ", Model.Discounts.Where(k => k.Selected).Select(e=>e.Title)); %>

                        <span class="num">скидка</span>
                        <small><%: selectedDiscounts.Length == 0 ? "любая" : selectedDiscounts%></small>

                        <div class="paramList">
                            <ul>
                                <li class="_reset">сбросить</li>
                                <% foreach (var pair in Model.Discounts) { %>
                                <li data-entry-id="<%: pair.Id %>" class="<%: pair.Selected ? "checked" : "" %>"><%: pair.Title %></li>
                                <% } %>
                            </ul>
                            <span class="arrow"></span>
                        </div>
                    </div>

                    
                    <div class="price features">
                        <% var selectedSpecials = string.Join(", ", Model.Specials.Where(k => k.Selected).Select(e => e.Title)); %>

                        <span class="num">особенности</span>
                        <small><%: selectedSpecials.Length == 0 ? "любые" : selectedSpecials%></small>

                        <div class="paramList">
                            <ul>
                                <li class="_reset">сбросить</li>
                                <% foreach (var pair in Model.Specials) { %>
                                <li data-entry-id="<%: pair.Id %>" class="<%: pair.Selected ? "checked" : "" %>"><%: pair.Title %></li>
                                <% } %>
                            </ul>
                            <span class="arrow"></span>
                        </div>
                    </div>
                    
                    <div class="btn_block">
						<span class="button">Поиск подходящих</span>
						<small style="display: none"><a href="#" title="Подробный поиск">Подробный поиск</a></small>
					</div>

                </div>
            </div>

            <%--<div class="name">
                <a href="#" style="color: gold" class="search" title="Поиск">Поиск</a>
            </div>--%>

        </div>
    </div>
    <div class="blockFilterRest">
        <div class="widthContent">
            <div class="filterHeader">
                <span class="counter">Всего заведений - <%: Model.TotalRestaurants%></span> 
                <span class="switcher events"><i>Мероприятия</i><span></span></span>
                <span class="switcher map"><i>Карта ресторанов</i><span></span></span>
            </div>
            <% Html.RenderPartial("Events", Model.EventsListsCollection); %>

            <div class="filterBody map">
                <% Html.RenderAction("EntityMap"); %>
            </div>

        </div>
    </div>
    <div class="blockContent restaurants">
        
        <div class="widthContent">
            
            <%             int i = 0;
            foreach (var rest in Model.Restaurants)
            {
                i++; %>
            <div class="oneRest <%: rest.IsVip ? "vip" : "" %>">
                
                <div class="blockPhoto">
                    <% //rest.PhotoScroller.Callback = "photoSelect";
                       rest.PhotoScroller.PhotoWidth = 200;
                       rest.PhotoScroller.PhotoHeight = 130;
                       rest.PhotoScroller.Args = "fancyPhoto-" + (i - 1);
                       rest.PhotoScroller.PhotosCount = 1;%>
                    <% Html.RenderPartial("PhotoScroller", rest.PhotoScroller); %>
                </div>
                <div class="infoBlock">
                    <dl>
                        <dt><a href="<%: rest.GetItemUri() %>" title="<%: rest.Title %>">
                            <%: rest.Title %></a></dt>
                        <dd>
                            <span class="info">
                            <% Html.RenderPartial("Widgets/Rating", rest.Marks); %>
                            </span>
                            <span class="typeList">
                                <% foreach (var type in rest.Types) {%>
                                    <span><%:type.Title %></span>
                                <% } %>
                            </span>
                            <% if (rest.CanBookTable) { %>
                            <span class="button" data-id="<%: rest.Id %>" data-title="<%: rest.Title %>">Забронировать столик</span>
                            <% } %>
                        </dd>
                    </dl>
                </div>
                <div class="extInfoBlock">
                    <table>
                        <tr>
                            <td>Кухня:</td>
                            <td>
                                <span style="display:inline-block;width:300px"><%: string.Join(", ", rest.Kitchen.Select(k => k.Title)) %></span>
                            </td>
                        </tr>
                        <tr>
                            <td>Средний счет:</td>
                            <td>
                                <%: rest.AverageCost != null ? rest.AverageCost.Title : "н.д."%>
                            </td>
                        </tr>
                        <tr>
                            <td>Телефон:</td>
                            <td>
                                <%: rest.Phone %>
                            </td>
                        </tr>
                        <tr>
                            <td>Адрес:</td>
                            <td><%: rest.Address %></td>
                        </tr>
                        <tr>
                            <td>Кол-во залов:</td>
                            <td><%: rest.HolesCount %></td>
                        </tr>
                        <tr>
                            <td>Время работы:</td>
                            <td><%: rest.WorkTime %></td>
                        </tr>
                    </table>
                </div>
                <%Html.RenderPartial("StarFavorite", rest.Favorite); %>
            </div>
            <% } %>

            <div class='blockLine'>
                <%: Html.Pager(Model.CurrentPage, Model.TotalPages, "RestaurantsList", new { entries = Model.ToEntriesString() }, "page")%>
            </div>
        </div>
        
        <div class="waveEdge"></div>
    </div>
    
   <% Html.RenderPartial("ReserveTable", new ReserveTableViewModel()); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Meta" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">Все о Смоленске - SmolToday.RU</asp:Content>
