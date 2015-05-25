<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Vacancy.Master" Inherits="System.Web.Mvc.ViewPage<smolensk.Models.ViewModels.VacancyCompanySearchViewModel>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<%@ Import Namespace="meridian.smolensk.system" %>
<%@ Import Namespace="smolensk.Mappers" %>
<%@ Import Namespace="smolensk.Models.CodeModels" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Vacancy" runat="server">
    <script type="text/javascript">
        function search() {
            //NOTE: Сделал костыль((, т.к BeginRouteForm не правильно формирует запрос...
            var url = '<%:Constants.VacancyCompaniesUrl %>';
            var filter = $("#filter").val();
            var regionId = $("#region").val();//из RegionSelector
            var cityId = $("#region2").val(); //из RegionSelector
            var allCompanies = $("#noname").attr('checked') == 'checked' ? 'on' : 'off';
            var ch = '<%:Model.Alphabet.Letter %>';
            var arr = [regionId, cityId, allCompanies, ch];
            if (filter != '' && filter != undefined) arr.push(filter);
            url = url + "/" + arr.join('/');
            window.location.href = url;
        }

    </script>

    <div class="vacancyList">
        <h3>Поиск по компаниям</h3>
        <div class="vacancyTools">
            <%--<span class="button register">Регистрация работодателя</span>--%>                               
        </div>
                            
        <div class="vacancySearch">
<%--            <% using (Html.BeginRouteForm("VacancyCompanyList", FormMethod.Get, new { id = "srchCmpny" }))
               {%>--%>
                <ul>
                    <li>Название компании</li>                                        
                </ul>  
                                    
                <br/><br/>
                <div class="searchLine">           							                                            
                    <input type="text" value="<%:Model.Filter %>" name="filter" id="filter" />                                       		
                    <span class="button" onclick="search()">Поиск</span>                                        
                </div>  
                                    
                <div class="searchLine">                        		
                    <label for="region">Регион</label>
                    <% Html.RenderPartial("RegionSelector", new RegionSelectorViewModel { RegionName = "regionId", CityName = "cityId", RegionId = Model.RegionId, CityId = Model.CityId }); %>
                </div>
                                    
                <div class="searchLine salary"> 
                    <span class="checkbox">
                        <input type="checkbox" id="noname" name="allCompanies" <%: Model.AllCompanies?"checked=checked":"" %> />
                        Показать компании без вакансий
                    </span>
                </div>
                                    
<%--            <% } %>--%>
        </div>
                            
        <% Html.RenderPartial("Alphabet", Model.Alphabet); %>
                            
        <div class="whiteBorderGrayBlock resultCompanySearch">
            <% if (Model.Alphabet != null && Model.Alphabet.Letter != Constants.AnyLetter)
               { %>
               <p class="header">По алфавиту - «<%: char.IsNumber(Model.Alphabet.Letter[0]) ? "0-9": Model.Alphabet.Letter%>»</p>
            <% } %>
            <p><i><%: Model.Companies.Count.ToString() %> компаний найдено</i></p>
            <div>
                <% int count = Model.Companies.Count;
                   int page1Size = count/3 + (count%3 != 0 ? 1 : 0);
                   int page2Size = count/3 + (count%3 == 2 ? 1 : 0); %>
                <ul>
                <% foreach (companies company in Model.Companies.Skip(0).Take(page1Size))
                   {%>
                        <li><a href="<%: company.ItemVacancyUri() %>" title="<%: company.title %>"><%: company.title%></a> <%: company.CountOfActualVacancies()%></li>
                   <%} %>
                </ul>
                <ul>
                <% foreach (companies company in Model.Companies.Skip(page1Size).Take(page2Size))
                   {%>
                        <li><a href="<%: company.ItemVacancyUri() %>" title="<%: company.title %>"><%: company.title%></a> <%: company.CountOfActualVacancies()%></li>
                   <%} %>
                </ul>
                <ul>
                <% foreach (companies company in Model.Companies.Skip(page1Size + page2Size))
                   {%>
                        <li><a href="<%: company.ItemVacancyUri() %>" title="<%: company.title %>"><%: company.title%></a> <%: company.CountOfActualVacancies()%></li>
                   <%} %>
                </ul>
            </div>
                                
            <a href="<%: Constants.VacancyCompaniesUrl %>" title="Все компании">Все компании</a>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
<% Html.RenderPartial("Statistics", Meridian.Default.ToVacancyStatistic()); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
<% Html.RenderPartial("PopularityVacancies", Meridian.Default.GetPopularityVacancies()); %>
</asp:Content>
