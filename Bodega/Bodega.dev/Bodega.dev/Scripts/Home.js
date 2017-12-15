$(document).ready(function () {

    hidePages()
    $("#HomePage").show();
    homePageNews();

    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
        $("#MenyPage").hide();

    }




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
                break;
            case "Gallery":
                $("#GalleryPage").show();
                $("#addnewspage").hide();
                $("#TitleOverAll").text('Gallery');
                break;

            case "AddNews":
                $("#addnewspage").show();
                $("#ContactPage").hide();
                $("#postTitle").empty();
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

    function homePageNews() {
        var apiUrl = "/api/News"
        $.ajax({
            url: apiUrl,
            type: "GET",
            success: function (data) {
                if (data.length <= 0) {
                    console.log("Tomt med nyheter!");
                }
                else {
                    getnewsdataapi();
                }

            }
        })
    }


    //Hämtar data från databasen och skriver ut det i HTML.
    function getnewsdataapi() {
        $.get("/api/News").then(function (data) {
            console.log(data);
            //Tömer listan först så det inte dupplicerar.
            $("#HomePage").empty();



            //Går igenom all data som finns och skriver ut allt i HTML.
            for (var i = 0; i < data.length; i++) {
                //console.log(data[i].ImageUploads["0"].ImageUrl);
                var html = "<div class='well'><div class='media'><a class='pull-left' href=''><img class='media-object' src='/Content/imgr/" + data[i].ImageUploads.ImageUrl + "' style='width:250px; height:200px;' ></a><div class='media-body'><h3 class='media-heading' style='font-family:Fjord One, serif; font-weight:bold;'>"
                    + data[i].Title + "</h3><p class='text- right' style='font-family:Fjord One, serif; font-size:17px; font-weight:500;'>"
                    + data[i].Text + "</p><ul class='list-inline list-unstyled'><li><span><i class='glyphicon glyphicon-calendar' ></i>"
                    + data[i].Published + "</span></li></ul><hr/></div></div></div>";
                $("#HomePage").append(html);
            }
        });
        //<section>
        //    <i class="glyphicon glyphicon-folder-open"></i>Bootstrap
		      //              <i class="glyphicon glyphicon-user"></i>RaymondDragon
		      //              <i class="glyphicon glyphicon-calendar"></i>1395/12/21
		      //              <i class="glyphicon glyphicon-eye-open"></i>10000
		      //              <a href="#" class="btn btn-default btn-sm pull-right">More ... </a>
        //</section>
    }
    $("#uploadImage").on('click', function () {
        debugger
        var data = new FormData()
        var files = $("#fileUpload").get(0).files;
        if (files.length > 0) {
            data.append("UploadedImage", files[0]);
        }

        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/api/fileUpload",
            contentType: false,
            processData: false,
            data: data
        });
        ajaxRequest.done(function (xhr, textStatus) {
            var apiUrl = "/api/News";
            var data = {
                id: 0,
                title: null,
                text: null,

            };

            data.title = $("#postTitle").val();
            data.text = $("#postText").val();


            $.ajax({
                url: apiUrl,
                type: "POST", data,
                data: JSON.stringify(data),
                contentType: "application/json"
            }).done(function () {
                window.location.href = "#/home";
            
            });
            homePageNews();

            $("#HomePage").show();
            $("#addnewspage").hide();
            $("#TitleOverAll").text('Nyheter');
            location.reload();

        });
    });











    //Kontakt forumuläret
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

