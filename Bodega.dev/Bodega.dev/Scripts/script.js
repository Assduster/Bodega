﻿$(document).ready(function () {
    console.log("Home Page is Loading guyssss! :D");

    hidePages();

    $("#HomePage").show();
    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
       
    }
    getnewsdataapi();
    $(".navigation").click(function () {
        var navDestination = this.href.substr(this.href.indexOf("#") + 1);
        hidePages();
        switch (navDestination) {
            case "home":
                $("#HomePage").show();
                getnewsdataapi();
                break;
            case "Gallery":
                console.log("GalleryPage");
                $("#GalleryPage").show();
                
                break;
            case "Contact":
                console.log("ContactPage");
                $("#ContactPage").show();
                break;
        };
    });

    function getnewsdataapi() {
        
        $.get("api/news").then(function (data) { 
            console.log(data);
            $("#HomePage").empty();

            for (var i = 0; i < data.length; i++) {
                var html = "<div class='well'><div class='media'><a class='pull-left' href='#'><img class='media- object' src='#'></a><div class='media-body'><h4 class='media- heading'>" + data[i].Title + "</h4><p class='text- right'>" + data[i].Text + "</p><ul class='list-inline list-unstyled'><li><span><i class='glyphicon glyphicon-calendar'></i>" + data[i].Published + "</span></li></ul></div></div></div>";
            $("#HomePage").append(html);
             
            }
        });
    }
});