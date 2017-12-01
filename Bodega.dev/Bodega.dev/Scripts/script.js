$(document).ready(function () {
    console.log("Home Page is Loading guyssss! :D");
    hidePages();
    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
    }
    $("#HomePage").show();

    $(".navigation").click(function () {
        var navDestination = this.href.substr(this.href.indexOf("#") + 1);
        hidePages();
        switch (navDestination) {
            case "home":
                $("#HomePage").show();
                break;
            case "Gallery":
                console.log("GalleryPage");
                $("#GalleryPage").show();
                getNewsDataApi();
                break;
            case "Contact":
                console.log("ContactPage");
                $("#ContactPage").show();
                break;
        };
    });

    function getNewsDataApi() {
        $.get("api/news").then(function (data) {
            console.log(data);
        });
    }

    



});

