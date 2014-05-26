//// Makes sure the document is ready before executing scripts
//$(function ($) {
//    $(document).on('hover', '#productimage>a', function () {
//        console.log($(this).val());
//    });
//    // File to which AJAX requests should be sent
//    var processFile = "/js/ajax/navigator.asp";
//    console.log('loaded');
//    // Pulls up events in the center div
//    $("#productimage>a").live("click", function (event) {
//        console.log('clicked');
//        // Stops the link from loading view.php
//        event.preventDefault();

//        // Adds an "active" class to the link
//        $(this).addClass("active");

//        // Gets the query string from the link href
//        var data = $(this)
//                        .attr("href")
//                        .replace(/.+?\?(.*)$/, "$1");

//        // Loads the event data from the DB
//        $.ajax({
//            type: "POST",
//            url: processFile,
//            data: data,
//            success: function (data) {
//                $('#mainimage').html(data);
//            },
//            error: function (msg) {
//                $('#mainimage').html(msg);
//            }
//        });

//    });

//});