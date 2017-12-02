$(document).ready(function () {
    console.log("Home Page is Loading guyssss! :D");

    hidePages();
    $("#HomePage").show();
    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
       
    }
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
        
        $.get("api/News").then(function (data) {
            debugger
            $("#GalleryPage").empty();
            for (var i = 0; i < data.length; i++) {
            var html = "<div class='col-lg-4'><img src='Content/imgr/101.jpg' width='140' height='140'><h5 id='hidetext'>" + data[i].Title + "</h5><p>" + data[i].Text + "</p></div>"
            $("#GalleryPage").append(html);
            }
        });
    }
});

