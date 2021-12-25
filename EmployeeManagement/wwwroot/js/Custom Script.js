$(".card-footer>a").hover(function () {
    $(this).append($("<span> Hello</span>"));
}, function () {
    $(this).find("span").last().remove();
});

$(".card-img-top").on('click', function () {
    $(this).fadeOut(1000);
});