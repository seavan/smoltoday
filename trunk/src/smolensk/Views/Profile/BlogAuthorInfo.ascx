<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.accounts>" %>
<%@ Import namespace="smolensk.Domain" %>
<%@ Import Namespace="smolensk.common" %>

<div class="userInfo">
    <img src="<%: Model.AvatarUrlSmall %>" width="85" alt="1" />
    <div class="info">
        <div><a href="<%: Model.ProfileUrl %>" title="<%: Model.NameAndSurname %>" class="name"><%: Model.NameAndSurname %></a></div>
        <div class="date">С нами с <%: Formatter.FormatVacancyPublishDate(Model.created)%></div>
        <div><img src="/content/i/record_ico.png" width="14" height="17" alt=" " /><a href="<%: Url.Action("Author", "Blogs", new {sortingType = SortingType.Rating, page = 1, authorId = Model.id}) %>" title="записи в блоге"><%: Model.BlogsUser.Count().ToCounterWordForm(Int64Extensions.RecordForm,false)%> в блоге</a><span class="comments"><%: Model.CommentsCount.ToCounterWordForm(Int64Extensions.CommentsForm,false) %></span></div>
    </div>
    
    <span class="button createRecord" onclick="location.href='<%: Url.Action("BlogEdit")%>'"><span></span>Создать запись</span>

</div>