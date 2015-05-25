<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div id="company_write_mail_form" class="enterForm no_resume _closest">
    <p>Написать письмо</p>
<%--    <small><b>Пользователь:</b> Менеджер по продажам</small><br/>
    <small><b>Компания:</b> РОСИМПОРТ, ООО, Санкт-Петербург</small>--%>
    <%using (Ajax.BeginForm("WriteMail", "Companies", new AjaxOptions
                                                                                   {
                                                                                       OnSuccess="alert('Письмо отправлено');"
                                                                                   }))
      { %>
        <input type="hidden" id="companyId" name="companyId"/>
        <div class="field">   
            <label for="theme" class="_autohide">Тема</label>                                 
            <input type="text" id="theme" name="theme"/>
        </div>
        <div class="field">
            <label for="message" class="_autohide">Сообщение</label>   
            <textarea rows="" cols="" id="message" name="message"></textarea>
        </div>
        <span class="button" onclick="$(this).closest('form').submit();">Написать</span>
    <% } %>
</div>
