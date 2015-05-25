<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.GetSessionViewModel>" %>

<span class="photo_order button"><span></span>Заказать фотосъёмку</span>
<% Html.BeginForm("GetPhotoSession", "PhotoBank", FormMethod.Post, new {id = "photo-order-form"}); %>
<form action="#" id = "photo-order-form">
    <p>Заказ фотосъемки с сайта smoltoday.ru</p>
    <div>
        Фотограф:
        <%= Model.Photographer.ShortName %>
        <%: Html.HiddenFor(m => m.Photographer.id) %>
    </div>
    <div>
        <%: Html.LabelFor(m => m.Email) %><br/>
        <%: Html.TextBoxFor(m => m.Email, new { @class="fld" })%>
    </div>
    <div>
        <%: Html.LabelFor(m => m.Phone) %><br/>
        <%: Html.TextBoxFor(m => m.Phone, new { @class = "fld" })%>
    </div>
    <div>
        <%: Html.LabelFor(m => m.Text) %><br/>
        <%: Html.TextAreaFor(m => m.Text, new { @class = "fld", rows = 5 })%>
    </div>
    <div id="getsession-message" style="padding: 10px 0;"></div>
    <div>
        <span class="btn" id="submit">Отправить</span>
        <span class="btn" id="close">Закрыть</span>
    </div>
</form>

<script type="text/javascript">
    $(function () {
        $(".photo_order").on("click", function () {
            $('.overlayBlock').show();
            $("#photo-order-form").appendTo(".getsession");
            $(".getsession").show();
            $("#photo-order-form").show();
        });

        $("#close").on("click", function () {
            $("#Phone").val("");
            $("#Text").val("");
            $("#getsession-message").html("");
            $('.overlayBlock').hide();
            $("#submit").show();
        });

        $('#submit').click(function () {
            if ($("#Text").val().length == 0) {
                $("#getsession-message").html("Не заполнено поле 'Комментарий'");
                return;
            }

            if ($("#Email").val().length == 0 && $("#Phone").val().length == 0) {
                $("#getsession-message").html("Не указаны контактные данные");
                return;
            }
            
            $.ajax({                
                url: '<%: Url.Action("GetPhotoSession", "PhotoBank") %>',
                type: "POST",
                data: $(this).closest("form").serialize(),
                success: function (result) {
                    $("#getsession-message").html(result.message);
                    $("#submit").hide();
                }
            });
          
        });
    });
</script>
