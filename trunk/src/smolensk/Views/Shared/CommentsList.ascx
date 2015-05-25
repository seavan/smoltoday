<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.ICommentable>" %>
<%
    var comments = Model.GetComments().ToArray();
%>

<div class="commentsNews">
    <%if (!Model.isReview || comments.Count() > 0) {%>
    <p><strong><%: Model.isReview ? "Отзывы" : "Комментарии"%></strong> <%--(<%:comments.Count()%>)--%></p>
    <%} %>
    
    <%if(Model.isReview){%>
    <div class="allComments list">      
        <% foreach (var comment in comments)
           {
               Html.RenderPartial("CommentOne", comment);
           }
        %>
   </div>

    <%} %>

    <div class="allComments">
        
        <a name="comments"></a>

        <%if(Model.isReview){%>
        <p class="formHeader">Написать отзыв</p>
        <%} %>

        <% if (Request.IsAuthenticated && Model.can_comment){
               var user = Html.UserPrincipal();%>
        <div class="oneComment">
            <span class="avatar"><a href="<%: user.ProfileUrl %>" title="автор"><img src="<%:user.AvatarUrlSmall %>" width="45" height="45" alt="2" /></a></span>
            <form action="#" class="ajaxForm" data-action="<%: Url.Action("AddComment", "Comments")%>" data-target=".commentsNews .allComments.list" data-processing="<%: Model.isReview ? "addAfter" : "addBefor"%>" >
                <div class="commentBody">
                    <span class="arrowBuble"></span> 

                    <%= Html.TextArea("CommentText", new { rows = 1, cols = 1, @class = "_submit_disabled _noempty" })%>     
                    
                    <%= Html.Hidden("ParentId", 0)%>
                    <%= Html.Hidden("MaterialId", Model.id)%>

                    <%= Html.Hidden("ProtoName", Model.ProtoName)%>
                    
                </div>
                <small>не более 300 символов, все сообщения модерируются</small>
                <span class="button" onclick="$(this).parent().submit();">Отправляем</span>
            </form>
        </div>
        <% } else if(Request.IsAuthenticated && !Model.can_comment){%>
        <div class="oneComment authBlock">
          <p>Автор запретил комментирование.</p>
        </div>
        <% } else {%>
        <div class="oneComment authBlock">
          <p>Необходима <span class="enterLink enter">авторизация</span>, чтобы оставлять <%: Model.isReview ? "отзывы" : "комментарии"%> (войти через 
            <a href="<%: OAuthFbService.SignInUrl%>" class="facebook" title="facebook">Facebook</a>, 
            <a href="<%: OAuthGpService.SignInUrl%>" class="google" title="google">Google+</a>, 
            <a href="<%: OAuthVkService.SignInUrl %>" class="vk" title="vkontakte">ВКонтакте</a>).</p>
        </div>
        <%}%>

   </div>

   <%if(!Model.isReview){%>
    <div class="allComments list">      
        <% foreach (var comment in comments)
           {
               Html.RenderPartial("CommentOne", comment);
           }
        %>
   </div>
    <%} %>

    <%--<span class="button">Показать все (84)</span>--%>

</div>