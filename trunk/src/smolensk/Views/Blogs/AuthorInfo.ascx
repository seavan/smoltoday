<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.accounts>" %>
<%@ Import namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>

<div class="userInfo">
        <img src="<%: Model.AvatarUrlSmall %>" width="85" alt="1" />
        <div class="info">
            <div><a href="<%: Model.ProfileUrl %>" title="<%: Model.NameAndSurname %>" class="name"><%: Model.NameAndSurname %></a></div>
            <div class="date">С нами с <%: Formatter.FormatVacancyPublishDate(Model.created)%></div>
            <div><img src="/content/i/record_ico.png" width="14" height="17" alt=" " /><a href="<%: Url.Action("Author", new {sortingType = SortingType.Rating, page = 1, authorId = Model.id}) %>" title="записи в блоге"><%: Model.BlogsUser.Count()%> записи в блоге</a><span class="comments"><%: Model.CommentsCount %> комментария</span></div>
            <%--<div>
                <table>
                    <tr>
                        <td>Email:</td>
                        <td><a href="mailto:ivanov@mail.ru">ivanov@mail.ru</a></td>                                            
                    </tr>
                    <tr>
                        <td>Телефон:</td>
                        <td>+7 000 00 00</td>                                            
                    </tr>
                    <tr>
                        <td>Местонахождение:</td>
                        <td>Россия, г. Смоленск</td>                                            
                    </tr>
                </table>
            </div>--%>
        </div>
    </div>