$(document).ready(function () {
    hidePages();
    $("#HomePage").show();
    getnewsdataapi();

    var panels = $('.vote-results');
    var panelsButton = $('.dropdown-results');
    panels.hide();

    //Menubar Single Application.
    $(".navigation").click(function () {
        var navDestination = this.href.substr(this.href.indexOf("#") + 1);
        hidePages();
        switch (navDestination) {
            case "Home":
                $("#HomePage").show();
                $("#addnewspage").hide();
                $("#TitleOverAll").text('Nyheter');
                getnewsdataapi();
                break;
            case "Gallery":
                $("#GalleryPage").show();
                $("#addnewspage").hide();
                $("#TitleOverAll").text('Gallery');
                break;
            case "AddNews":
                $("#addnewspage").show();
                $("#ContactPage").hide();
                $("#TitleOverAll").text('Skapa en nyhet');
                break;
            case "Contact":
                $("#ContactPage").show();
                $("#addnewspage").hide();
                $("#TitleOverAll").text('Kontakt');
                break;
            case "AddNews":
                $("#AddnewsPage").show();
                $("#HomepageTitle").hide();
                break;
            case "Meny":
                $("#MenyPage").show();
                $("#addnewspage").hide();
                $("#TitleOverAll").text('Meny');

                break;
        };
    });

    //Döljer alla sidor.
    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
        $("#MenyPage").hide();
        $("#addnewspage").hide();
    }

    //Hämtar data från databasen och skriver ut det i HTML.
    function getnewsdataapi() {
        $.get("/api/News").then(function (data) {

            //Tömer listan först så det inte dupplicerar.
            $("#HomePage").empty();

            //Går igenom all data som finns och skriver ut allt i HTML.
            for (var i = 0; i < data.length; i++) {
              
                var html = "<div class='well'><div class='media'><a class='pull-left' href=''><img class='media-object' id='" + data[i].Image.Id + "' src='/Content/imgr/" + data[i].Image.imagename + "' style='width:250px; height:200px;' ></a><div class='media-body'><h3 class='media-heading' style='font-family:Fjord One, serif; font-weight:bold;'>"
                    + data[i].Title + "</h3><p class='text- right' style='font-family:Fjord One, serif; font-size:17px; font-weight:500;'>"
                    + data[i].Text + "</p><ul class='list-inline list-unstyled'><li><span><i class='glyphicon glyphicon-calendar' ></i>"
                    + data[i].Published + "</span></li></ul></div></div></div>";
                $("#HomePage").append(html);
                if (data[i].Id <= 0) {
                    console.log("Tjenare");
                }
                

            }


        });
    }

    panelsButton.click(function () {
        var dataFor = $(this).attr('data-for');
        var idFor = $(dataFor);
        var currentButton = $(this);

        idFor.slideToggle(400, function () {
            if (idFor.is(':visible')) {
                currentButton.html('Hide Results');
            }
            else {
                currentButton.html('View Results');
            }
        })
    });

    //Ladda upp bild.
    $('#btnUploadFile').on('click', function () {
        var data = new FormData()
        var files = $("#fileUpload").get(0).files;
        if (files.length > 0) {
            data.append("UploadedImage", files[0]);
        }
        if (files.length == 0) {
            return $("#warnText").text("Du måste välja en bild innan du kan ladda upp den!");
        }
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/api/fileUpload",
            contentType: false,
            processData: false,
            data: data
        });
        ajaxRequest.done(function (xhr, textStatus) { });
    });

    //Skapar ett nytt inlägg
    $("#weyy").click(function () {
        var data = {
            id: 0,
            title: null,
            text: null


        };
        data.title = $("#postTitle").val();
        data.text = $("#postText").val();
        data.ImageId = $("#fileUpload").val();

        $.post("/api/news", data).then(function () {
        });
    });


});

