<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<meridian.smolensk.proto.IComment>" %>

<div class="oneComment">
    <a name="comment_<%: Model.id %>" id="comment_<%: Model.id %>"></a>
    <span class="avatar"><a href="<%: Model.GetUser().ProfileUrl %>" title="автор"><img src="<%: Model.GetUser().AvatarUrlSmall %>" width="45" height="45" alt="1" /></a></span>
    <div class="commentBody">
        <span class="arrowBuble"></span>
        <span class="datetime"><%: smolensk.Domain.Formatter.FormatLongDateTimeNoComma(Model.CreateDate) %></span>
        
        <%if (Model.ParentId > 0)
          {
              var parent = Model.GetParentComment();%>
        <span class="review_info">Ответ на комментарий пользователя <a href="#" ><%: parent.GetUser().ShortName%></a> от <%: smolensk.Domain.Formatter.FormatLongDateTimeNoComma(parent.CreateDate)%>. <a href="#comment_<%:Model.ParentId %>" title="Показать" class="show_parentComment">Показать</a></span>
        <%} %>            
        <%= Model.CommentText %>
        
        <p>
          <i><a href="#"><%: Model.GetUser().ShortName %></a></i>
          
          <span class="write_review" title="Ответить">Ответить</span>
        </p>
        

    </div>
</div>
<% if (Request.IsAuthenticated)
   { %>
<div class="oneComment replyForm">
    <form action="#" class="ajaxForm" data-action="<%: Url.Action("AddComment", "Comments") %>" data-target=".commentsNews .allComments.list" data-processing="<%: Model.isReview ? "addAfter" : "addBefor" %>" >
        <div class="commentBody">
                    
            <textarea rows="1" cols="1" name="CommentText" class="_submit_disabled _noempty"></textarea>
            <input type="hidden" value="<%: Model.id %>" name="ParentId" />
            <input type="hidden" value="<%: Model.MaterialId %>" name="MaterialId" />
            <input type="hidden" value="<%: Model.MaterialProtoName %>" name="ProtoName" />
            
        </div>
        <small>не более 300 символов, все сообщения модерируются</small>
        <span class="button" onclick="$(this).parent().submit();">Отправляем</span>
    </form>
</div>
<% } %>