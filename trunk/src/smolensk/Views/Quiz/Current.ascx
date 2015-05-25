<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.QuizViewModel>" %>
<dl class="quiz" style="display:none;">
	<dt>Опрос</dt>
	<dd>
		<i><%=Model.Title %></i>
		<form action="#">
            <input type="hidden" name="quiz" value="<%=Model.Id %>"/>
			<ul>
            <%foreach (var option in Model.Options) { %>
				<li>
                    <span class="radio">
                        <input type="radio" name="option" value="<%=option.Id %>" <%= Model.SelectedOption == option.Id ? "checked" : ""%>/>
                    </span>
                    <span><%=option.Value %> </span>
                </li>
            <%} %>
			</ul>
			<div class="tools">
            <%if (SecurityService.IsAuthorize && Model.VoteAvailable && Model.SelectedOption == 0) { %>
				<span class="button">Голосовать</span>
            <%} %>
				<span class="result">Результаты</span>
			</div>
		</form>
	</dd>
</dl>