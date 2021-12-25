

$(".card-footer>a").hover(function () {
    $(this).append($("<span> Hello</span>"));
}, function () {
    $(this).find("span").last().remove();
});



//$(function () {
//    $(".card-img-top").mouseover(function () {
//        $(this).animate({ height: '+=10', width: '+=10' })
//        //  .animate({ height: '-=125', width: '-=125' });
//    }).mouseout(function () {
//            $(this).animate({ height: '-=10', width: '-=10' })
//        });

//    //$(".card-img-top").mouseout(function () {
//    //    $(this).animate({ height: '-=125', width: '-=125' })
//    //        .animate({ height: '-=125', width: '-=125' });
//    //});
//});


$(".card-img-top").on('click', function () {
    $(this).fadeOut(10);
});



//$(".card-img-top").mouseover(function () {
//    animateElement($(this));
//});

//function animateElement(element) {
//    element.animate({ height: '+=125', width: '+=125' })
//      //  .animate({ height: '-=125', width: '-=125' })
//}

//$(".card-img-top").mouseout(function () {
//    animateElement($(this));
//});

//function animateElement(element) {
//    element.animate({ height: '-=125', width: '-=125' })
//      //  .animate({ height: '-=125', width: '-=125' })
//}





//$(function () {
//    $(".card-img-top").mouseover(function () {
//        $(this).addClass("highlight")
//        //  .animate({ height: '-=125', width: '-=125' });
//    }).mouseout(function () {
//        $(this).removeClass("highlight")
//    });

//    //$(".card-img-top").mouseout(function () {
//    //    $(this).animate({ height: '-=125', width: '-=125' })
//    //        .animate({ height: '-=125', width: '-=125' });
//    //});
//});




//$(".card-img-top").hover(function () {
//    $(this).toggleClass("highlight");
//});