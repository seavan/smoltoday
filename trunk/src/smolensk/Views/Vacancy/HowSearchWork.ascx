<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div class="howSearch">
    <h3>Как найти работу?</h3>
    <div>
        <dl>
            <dt>1</dt>
            <dd><p>Первый шаг</p><a href="<%: Url.Action("CreateResume", "Vacancy") %>" title="Создайте резюме">Создайте резюме</a></dd>
        </dl>
        <dl>
            <dt>2</dt>
            <dd><p>Второй шаг</p><a href="<%: Url.Action("Vacancies", "Vacancy") %>" title="Выберите вакансию и откликнитесь">Выберите вакансию и откликнитесь</a></dd>
        </dl>
        <dl>
            <dt class="third">3</dt>
            <dd><p>Третий шаг</p><a href="#" title="Оформите подписку на вакансии">Оформите подписку на вакансии</a></dd>
        </dl>
    </div>
</div>