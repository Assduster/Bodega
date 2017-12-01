$(document).ready(function () {
    console.log("Galery sidan körs");
});
$("#showInformationtext1").hide();
$("#showInformationtext2").hide();
$("#showInformationtext3").hide();
$("#showInformationtext4").hide();
$("#showInformationtext5").hide();
$("#showInformationtext6").hide();

$("#bild1").click(function () {
    $("#imagediv2").fadeToggle();
    $("#showInformationtext1").fadeToggle();
    $("#bild2").fadeToggle();
    $("#bild3").fadeToggle();
});
$("#bild2").click(function () {
    $("#imagediv2").fadeToggle();
    $("#showInformationtext2").fadeToggle();
    $("#bild1").fadeToggle();
    $("#bild3").fadeToggle();
});
$("#bild3").click(function () {
    $("#imagediv2").fadeToggle();
    $("#showInformationtext3").fadeToggle();
    $("#bild2").fadeToggle();
    $("#bild1").fadeToggle();
});

 
