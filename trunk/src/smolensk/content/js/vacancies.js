/*Общее*/

function InitVacancyOne(url) {
    $(".phoneHide").on("click", function () {
        $(".phoneHide").html("<img src='" + url + "' alt='' />");
        $(".phoneHide").unbind("click");
        $(".phoneHide").removeClass("phoneHide");
    });
}