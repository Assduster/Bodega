$(document).ready(function () {
    console.log("Home Page is Loading guyssss! :D");

    hidePages();

    $("#HomePage").show();
    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
        $("#MenyPage").hide();
       
    }

    var panels = $('.vote-results');
    var panelsButton = $('.dropdown-results');
    panels.hide();

    getnewsdataapi();
    $(".navigation").click(function () {
        var navDestination = this.href.substr(this.href.indexOf("#") + 1);
        hidePages();
        switch (navDestination) {
            case "Home":
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
            case "Meny":
                console.log("MenyPage");
                $("#MenyPage").show();
                break;
        };
    });

    function getnewsdataapi() {
        
        $.get("api/news").then(function (data) { 
            console.log(data);
            $("#HomePage").empty();

            for (var i = 0; i < data.length; i++) {
                var html = "<div class='well'><div class='media'><a class='pull-left' href='#'><img class='media- object' src='#'></a><div class='media-body'><h3 class='media- heading' style='font-family:Fjord One, serif; font-weight:bold;'>" + data[i].Title + "</h3><p class='text- right' style='font-family:Fjord One, serif; font-size:17px; font-weight:500;'>" + data[i].Text + "</p><ul class='list-inline list-unstyled'><li><span><i class='glyphicon glyphicon-calendar'></i>" + data[i].Published + "</span></li></ul></div></div></div>";
            $("#HomePage").append(html);
             
            }
        });
    }

    panelsButton.click(function () {
        //get data-for attribute
        var dataFor = $(this).attr('data-for');
        var idFor = $(dataFor);

        //current button
        var currentButton = $(this);
        idFor.slideToggle(400, function () {
            //Completed slidetoggle
            if (idFor.is(':visible')) {
                currentButton.html('Hide Results');
            }
            else {
                currentButton.html('View Results');
            }
        })
    });
});

