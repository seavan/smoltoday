<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.SearchVacancyBlockViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>

<script type="text/javascript">
    function checkSalary(i) {
        $("#salaryId").val(i);
        document.forms["searchForm"].submit();
    }

    function goToExtSearch() {
        var st = $("input[name=searchType][checked]").val();
        if (st == 1) {
            window.location.href = '<%: Url.Action("SearchVacancy", "Vacancy") %>';
        } else {
            window.location.href = '<%: Url.Action("SearchResume", "Vacancy") %>';
        }
    }
</script>

<div class="vacancySearch">
    <% using (Html.BeginForm("Search", "Vacancy", FormMethod.Get, new {id="searchForm"}))
        {%>
        <ul>
            <li>Найти</li>
            <li><span class="radio"><input type="radio" name="searchType" value="1" <%: Model.SearchType == 1 ? "checked=checked" : "" %> /></span><span>вакансию</span></li>
            <li><span class="radio"><input type="radio" name="searchType" value="2" <%: Model.SearchType == 2 ? "checked=checked" : "" %> /></span><span>резюме</span></li>
        </ul>  
                                    
        <div class="hints">Например: Менеджер по продажам <a href="javascript:goToExtSearch()" title="Расширенный поиск">Расширенный поиск</a></div>
        <div class="searchLine">           							                                            
            <input type="text" value="<%:Model.Query %>" name="q" id="q" />                                       		
            <span class="button" onclick="document.forms['searchForm'].submit()">Поиск</span>      
        </div>  
                                    
        <div class="searchLine">                        		
            <label for="prof">Професиональная область</label>
            <select id="prof" name="prof">
                <option value="0" <%:Model.ProfessionId == 0 ? "selected" :"" %>>Любая</option>
                <% foreach (var prof in Model.Professionals)
                   {%>
                      <option value="<%:prof.Id %>" <%:prof.Id==Model.ProfessionId ? "selected" :"" %>><%: prof.Title %></option>
                   <%} %>
            </select>
        </div>
                   
        <input type="hidden" value="0" name="salaryId" id="salaryId"/>                 
        <div class="searchLine salary">    
            Зарплата 
            <%
                var salaries = SearchVacancyBlockViewModel.Salaries;
                for (int i = 0; i < salaries.Length; i++)
               {
                   string title;
                   if (i == 0)
                   {
                       title = string.Format("до {0:N0}", salaries[i+1]);
                   }
                   else if (i == salaries.Length - 1)
                   {
                       title = string.Format("от {0:N0} и более", salaries[i]);
                   }
                   else
                   {
                       title = string.Format("{0:N0} - {1:N0}", salaries[i], salaries[i + 1]);
                   }
                    %>
                    <a href="javascript:checkSalary(<%:i %>)" title="<%:title %>" class="<%: i==Model.SelectedSalaryId ? "cur" :"" %>"><%:title%></a> 
               <% } %>
        </div>
    <% } %>
</div>