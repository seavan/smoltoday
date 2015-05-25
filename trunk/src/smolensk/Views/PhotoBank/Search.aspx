<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>"
    MasterPageFile="~/Views/Master/PhotoBank.Master" %>

<asp:Content runat="server" ID="BreadCrumbs" ContentPlaceHolderID="BreadCrumbsContent">
</asp:Content>
<asp:Content runat="server" ID="PhotoBank" ContentPlaceHolderID="PhotoBank">
    <div class="blockLine">
        <div class="categoryBlock">
            <div class="categoryName">
                <h3>
                    Результаты поиска по запросу: “Природа”</h3>
                <div class="selectorCount">
                    <form action="#">
                    <label for="selector_count">
                        Выводить по</label>
                    <select id="selector_count" name="selector_count">
                        <option value="12">12</option>
                        <option value="25">25</option>
                    </select>
                    </form>
                </div>
            </div>
            <div class="photoList">
                <div class="blockLine">
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="<%: Url.Action("PhotoBankOne","Main") %>" title="1">
                                            <img src="/content/images/onePhoto_1.jpg" width="138" height="96" alt="1" /></a>
                                    </td>
                                    <td>
                                        <span class="bigPreview"><a href="<%: Url.Action("PhotoBankOne","Main") %>" title="1">
                                            <img src="/content/images/previewPhoto.jpg" width="311" height="229" alt="preview" /></a>
                                            <span class="info"><span><span class="photoNum">#334682</span> <span class="photoName">
                                                Горное озеро</span> </span><span><span class="photoAuth"><a href="<%: Url.Action("PhotoBankProfile","Main") %>"
                                                    title="Константинов А.В.">Константинов А.В.</a></span> <span class="photoSize"><a
                                                        href="#" title="S">S</a>, <a href="#" title="M">M</a>, <a href="#" title="L">L</a>,
                                                        <a href="#" title="XL">XL</a>, <a href="#" title="XXL">XXL</a> </span></span>
                                            </span></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="2">
                                            <img src="/content/images/onePhoto_2.jpg" width="138" height="97" alt="2" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="3">
                                            <img src="/content/images/onePhoto_3.jpg" width="109" height="138" alt="3" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="4">
                                            <img src="/content/images/onePhoto_4.jpg" width="138" height="131" alt="4" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                </div>
                <div class="blockLine">
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="1">
                                            <img src="/content/images/onePhoto_1.jpg" width="138" height="96" alt="1" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="2">
                                            <img src="/content/images/onePhoto_2.jpg" width="138" height="97" alt="2" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="3">
                                            <img src="/content/images/onePhoto_3.jpg" width="109" height="138" alt="3" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                    <div>
                        <div class="imgBlock">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" title="4">
                                            <img src="/content/images/onePhoto_4.jpg" width="138" height="131" alt="4" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <span class="info"><span><span class="photoNum">#334682</span> <span class="rating">
                            <span class="cur">1</span> <span class="cur">2</span> <span class="cur">3</span>
                            <span>4</span> <span>5</span> </span></span><span class="basket button"><span></span>
                            </span></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<% Html.RenderPartial("Widgets/Pager"); %>--%>
</asp:Content>
