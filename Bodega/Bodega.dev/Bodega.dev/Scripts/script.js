$(document).ready(function () {
    //Döljer alla sidor från början. 
    hidePages();

    $("#HomePage").show();
    getnewsdataapi();
   
    function hidePages() {
        $("#GalleryPage").hide();
        $("#ContactPage").hide();
        $("#HomePage").hide();
        $("#MenyPage").hide();

    }

    var locationUrl = 'http://localhost:52237/home/Index';
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
                var html = "<div class='well'><div class='media'><a class='pull-left' href=''><img class='media-object' src='/Content/imgr/101.jpg' style='width:250px; height:200px;' ></a><div class='media-body'><h3 class='media-heading' style='font-family:Fjord One, serif; font-weight:bold;'>"
                    + data[i].Title + "</h3><p class='text- right' style='font-family:Fjord One, serif; font-size:17px; font-weight:500;'>"
                    + data[i].Text + "</p><ul class='list-inline list-unstyled'><li><span><i class='glyphicon glyphicon-calendar' ></i>"
                    + data[i].Published + "</span></li></ul></div></div></div>";
                $("#HomePage").append(html);
                
            }
            
         
        });
    }
  


 
    $("#ad-news").click(function () {
        var data = {
            id: 0,
            title: null,
            text: null
        };
        data.title = $("#postTitle").val();
        data.text = $("#postText").val();
        $.post("/api/news", data).then(function () {
            console.log("Nytt inlägg skapad!");
            window.location.href = locationUrl;
        });
    });
    
   

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

